using DevEduEducationSystem.API.Tests.Support.MethodForTests;
using DevEduEducationSystem.API.Tests.Support.Models;
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
            string tokenMethodist = AuthClient.AuthUser(newUser.Email, newUser.Password);
            ScenarioContext.Current["TokenMethodist"] = tokenMethodist;
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
        }          
        
        [When(@"I login as an Methodist and create new course")]
        public void WhenILoginAsAnMethodistAndCreateNewCourse(Table table)
        {
            RegistrationRequestModel newUser = (RegistrationRequestModel)ScenarioContext.Current["NewUser"];
            string tokenMethodist = AuthClient.AuthUser(newUser.Email, newUser.Password);
            ScenarioContext.Current["TokenMethodist"] = tokenMethodist;
            ScenarioContext.Current["NewCourse"] = table.CreateSet<CourseRequestModel>().ToList().First();
            CourseRequestModel courseModel = (CourseRequestModel)ScenarioContext.Current["NewCourse"]; 
            CourseResponseModel newCourse = AddEntitysClients.CreateCourse((string)ScenarioContext.Current["TokenMethodist"], courseModel);          
            ScenarioContext.Current["idNewCourse"] = newCourse.Id;
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

        [Then(@"Delete new course")]
        public void ThenDeleteNewCourse()
        {
            DeleteClient.DeleteCourseById((string)ScenarioContext.Current["TokenMethodist"], (int)ScenarioContext.Current["idNewCourse"]);
        }

        [Then(@"Delete new user")]
        public void ThenDeleteNewUser()
        {
            DeleteClient.DeleteUserById((string)ScenarioContext.Current["TokenAdmin"], (int)ScenarioContext.Current["idNewUser"]);
        }   

    }
}