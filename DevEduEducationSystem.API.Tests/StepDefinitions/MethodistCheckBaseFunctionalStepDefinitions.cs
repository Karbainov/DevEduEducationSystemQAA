using DevEduEducationSystem.API.Tests.Support.MethodForTests;
using DevEduEducationSystem.API.Tests.Support.Models;
using DevEduEducationSystem.API.Tests.Support.Models.CourseResponseModelForAdd;
using System;
using System.Net;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace DevEduEducationSystem.API.Tests.StepDefinitions
{
    [Binding]
    public class MethodistCheckBaseFunctionalStepDefinitions
    {
        [Given(@"I create new user and get his token")]
        public void GivenICreateNewUserAndGetHisToken(Table table)
        {
            ScenarioContext.Current["NewUser"] = table.CreateSet<RegistrationRequestModel>().ToList().First();
            RegistrationRequestModel newUser = (RegistrationRequestModel)ScenarioContext.Current["NewUser"];
            RegistrationResponseModel newUserModel = AuthClient.RegistrationReturnModel(newUser);
            ScenarioContext.Current["idNewUser"] = newUserModel.Id;            
        }        
        
        [Given(@"I login as an admin and give new user role (.*)")]
        public void GivenILoginAsAnAdminAndGiveNewUserRoleMethodist(string methodist)
        {
            LoginRequestModel adminEnterRequestModel = new LoginRequestModel()
            {
                Email = "user@example.com",
                Password = "stringst"
            };
            string tokenAdmin = AuthClient.AuthUser(adminEnterRequestModel.Email, adminEnterRequestModel.Password);
            AddRoleUsers.AddRole(methodist, (int)ScenarioContext.Current["idNewUser"], tokenAdmin);
            ScenarioContext.Current["TokenAdmin"] = tokenAdmin;
            RegistrationRequestModel userModelForTokinMethodist = (RegistrationRequestModel)ScenarioContext.Current["NewUser"];
            string tokenMethodist = AuthClient.AuthUser(userModelForTokinMethodist.Email, userModelForTokinMethodist.Password);
            ScenarioContext.Current["TokenMethodist"] = tokenMethodist;
        }          
        
        [When(@"I login as an Methodist and create new course")]
        public void WhenILoginAsAnMethodistAndCreateNewCourse(Table table)
        {
           
            ScenarioContext.Current["NewCourse"] = table.CreateSet<CourseRequestModel>().ToList().First();
            CourseRequestModel courseModel = (CourseRequestModel)ScenarioContext.Current["NewCourse"]; 
            CourseResponseModel newCourse = AddEntitysClients.CreateCourse((string)ScenarioContext.Current["TokenMethodist"], courseModel);
            ScenarioContext.Current["idNewCourse"] = newCourse.Id;
        }

        [When(@"I login as an Methodist and create new courses")]
        public void WhenILoginAsAnMethodistAndCreateNewCourses(Table table)
        { 
            ScenarioContext.Current["SetCourses"] = table.CreateSet<CourseRequestModel>().ToList();
            List<CourseRequestModel> courses = (List<CourseRequestModel>)ScenarioContext.Current["SetCourses"];
            List<CourseResponseModel> newCourses = new List<CourseResponseModel>();
            foreach (CourseRequestModel course in courses)
            {
                newCourses.Add(AddEntitysClients.CreateCourse((string)ScenarioContext.Current["TokenMethodist"], course));
            }
            ScenarioContext.Current["NewCourses"] = newCourses;
        }

        [When(@"I get all courses")]
        public void WhenIGetAllCourses()
        {
            List<CourseResponseModel> listCourses = GetClient.GetAllCourses((string)ScenarioContext.Current["TokenMethodist"]);
            ScenarioContext.Current["ListCourses"] = listCourses;
        }

        [Then(@"The list contains all created courses")]
        public void ThenTheListContainsAllCreatedCourses()
        {
            List<CourseResponseModel> actualAllCourses = GetClient.GetAllCourses((string)ScenarioContext.Current["TokenMethodist"]);
            List<CourseResponseModel> expectedCourses = (List<CourseResponseModel>)ScenarioContext.Current["NewCourses"];
            foreach (CourseResponseModel course in expectedCourses)
            {
                CourseResponseModel actualModel = actualAllCourses.FirstOrDefault(C => C.Id == course.Id);
                Assert.IsNotNull(actualModel);
                Assert.AreEqual(course.Name, actualModel.Name);
                Assert.AreEqual(course.Description, actualModel.Description);
            }
        }

        [When(@"I update new course")]
        public void WhenIUpdateNewCourse(Table table)
        {
            ScenarioContext.Current["NewModelUpdateCourse"] = table.CreateSet<CourseRequestModel>().ToList().First();
            CourseResponseModel newUpdatedCourse = UpdateClient.UpdateCourse((CourseRequestModel)ScenarioContext.Current["NewModelUpdateCourse"], 
                (int)ScenarioContext.Current["idNewCourse"], (string)ScenarioContext.Current["TokenMethodist"]);
            ScenarioContext.Current["NewUpdatedCourse"] = newUpdatedCourse;
        }
        
        [When(@"I login as an Methodist and get course by not existing Id (.*)")]
        public void WhenILoginAsAnMethodistAndGetCourseByNotExistingId(int id)
        {
            HttpResponseMessage resoponseCode = GetClient.GetClientByIdError(id, (string)ScenarioContext.Current["TokenMethodist"]);            
            ScenarioContext.Current["StatusCode"] = resoponseCode.StatusCode;
        }

        

        [Then(@"Should return (.*) code response status")]
        public void ThenShouldReturnCodeResponseStatus(int statusCode)
        {
            HttpStatusCode expected = (HttpStatusCode)statusCode;
            HttpStatusCode actual = (HttpStatusCode)ScenarioContext.Current["StatusCode"];
            Assert.AreEqual(expected, actual);
        }

        [Then(@"Should Course Models coincide with the returned models of these entities")]
        [Then(@"Should course model coincide with the returned model")]
        public void ThenShouldCourseModelsCoincideWithTheReturnedModelsOfTheseEntities()
        {            
            CourseResponseModel actualModelCourse = GetClient.GetCourseByIdCourseSimpleModel((string)ScenarioContext.Current["TokenMethodist"], 
                (int)ScenarioContext.Current["idNewCourse"]);
            CourseRequestModel actualModelCourseNow = Mapper.MapCourseResponseModelToCourseRequestModel
                (actualModelCourse);
            CourseRequestModel excpectedModelCourse = (CourseRequestModel)ScenarioContext.Current["NewCourse"];            
                           
            Assert.AreEqual(excpectedModelCourse, actualModelCourseNow);            
        }
        

        [Then(@"Should new course model coincide with the returned model of changes entities")]
        public void ThenShouldNewCourseModelCoincideWithTheReturnedModelOfChangesEntities()
        {
            CourseResponseModel actualModelCourse = GetClient.GetCourseByIdCourseSimpleModel((string)ScenarioContext.Current["TokenMethodist"],
                (int)ScenarioContext.Current["idNewCourse"]);
            CourseRequestModel actualModelCourseNow = Mapper.MapCourseResponseModelToCourseRequestModel
                (actualModelCourse);

            CourseResponseModel model = (CourseResponseModel)ScenarioContext.Current["NewUpdatedCourse"];
            CourseRequestModel excpectedModelCourse = Mapper.MapCourseResponseModelToCourseRequestModel(model);           

            Assert.AreEqual(excpectedModelCourse, actualModelCourseNow);
        }

        [When(@"I deleting new course")]
        public void WhenIDeletingNewCourse()
        {
            DeleteClient.DeleteCourseById((string)ScenarioContext.Current["TokenMethodist"], (int)ScenarioContext.Current["idNewCourse"]);
        }

        [When(@"I get new course by id full models")]
        public void WhenIGetNewCourseByIdFullModels()
        {
            CourseResponseFullModel fullCourseModel = GetClient.GetCourseByIdCourseFullModel((string)ScenarioContext.Current["TokenMethodist"], (int)ScenarioContext.Current["idNewCourse"]);
            ScenarioContext.Current["NewCourseFullModel"] = fullCourseModel;
        }

        

        [Then(@"Field IsDeleted full models course must be true")]
        public void ThenFieldIsDeletedFullModelsCourseMustBeTrue()
        {
            CourseResponseFullModel actualFullCourseModel = (CourseResponseFullModel)ScenarioContext.Current["NewCourseFullModel"];
            bool actualField = actualFullCourseModel.IsDeleted;
            bool expectedField = true;
            Assert.AreEqual(actualField, expectedField);
        }

        [Then(@"In the list of all courses can't be a remote course")]
        public void ThenInTheListOfAllCoursesCantBeARemoteCourse()
        {
            List<CourseResponseModel> listCourses = (List<CourseResponseModel>)ScenarioContext.Current["ListCourses"];
            foreach (CourseResponseModel course in listCourses)
            {
                Assert.AreNotEqual(course.Id, (int)ScenarioContext.Current["idNewCourse"]);
            }           
        }
        
    }
}
