using DevEduEducationSystem.API.Tests.Support.MethodForTests;
using DevEduEducationSystem.API.Tests.Support.Models;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace DevEduEducationSystem.API.Tests.StepDefinitions
{
    [Binding]
    public class MethodistCheckBaseFunctionalStepDefinitions
    {
        [Given(@"I create new user")]
        public void GivenICreateNewUser(Table table)
        {
            ScenarioContext.Current["NewUser"] = table.CreateSet<RegistrationRequestModel>().ToList().First();
            RegistrationRequestModel newUser = (RegistrationRequestModel)ScenarioContext.Current["NewUser"];
            RegistrationResponseModel newUerModel = AuthClient.RegistrationReturnModel(newUser);
            ScenarioContext.Current["idNewUser"] = newUerModel.Id;
        }
        
        [Given(@"I login as an admin and give new user role Methodist ""([^""]*)""")]
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
            ScenarioContext.Current["NewCourse"] = table.CreateSet<CourseRequestModel>().ToList().First();
            CourseRequestModel courseModel = (CourseRequestModel)ScenarioContext.Current["NewCourse"];
            RegistrationRequestModel newUser = (RegistrationRequestModel)ScenarioContext.Current["NewUser"];         
            string tokenMethodist = AuthClient.AuthUser(newUser.Email, newUser.Password);
            CourseResponseModel newCourse = AddEntitysClients.CreateCourse(tokenMethodist, courseModel);
            ScenarioContext.Current["TokenMethodist"] = tokenMethodist;
            ScenarioContext.Current["idNewCourse"] = newCourse.Id;
        }


        [Then(@"Should Course Models coincide with the returned models of these entities")]
        public void ThenShouldCourseModelsCoincideWithTheReturnedModelsOfTheseEntities()
        {            
            CourseResponseModel actualModelCourse = GetClient.GetUserByIdCourseSimpleModel((string)ScenarioContext.Current["TokenMethodist"], 
                (int)ScenarioContext.Current["idNewCourse"]);
            CourseRequestModel actualModelCourseNow = Mapper.MapCourseResponseModelToCourseRequestModel
                (actualModelCourse);
            CourseRequestModel excpectedModelCourse = (CourseRequestModel)ScenarioContext.Current["NewCourse"];            
                           
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
