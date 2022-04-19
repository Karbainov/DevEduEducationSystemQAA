using DevEduEducationSystem.API.Tests.Support.MethodForTests;
using DevEduEducationSystem.API.Tests.Support.Models;
using DevEduEducationSystem.API.Tests.Support.Models.StudentModelClassesForModel;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace DevEduEducationSystem.API.Tests.StepDefinitions
{
    [Binding]
    public class RegistrationStepDefinitions
    {
        [Given(@"Create registration model")]
        public void GivenCreateRegistrationModel(Table table)
        {
            FeatureContext.Current["ModelRegistrUser"] = table.CreateSet<RegisterRequestModel>().ToList();
        }

        [When(@"Activate registration endpoint")]
        public void WhenActivateRegistrationEndpoint()
        {
            List<RegisterRequestModel> user = (List<RegisterRequestModel>)FeatureContext.Current["ModelRegistrUser"];
            Auth registr = new Auth();
            List<RegistrationResponsesModel> userResponses = registr.Registration(user);
            FeatureContext.Current["RegistrationResponsesUserActual"] = userResponses;
            for (int i = 0; i < userResponses.Count; i++)
            {
                FeatureContext.Current["IdUser"] = userResponses[i].Id;
            }
        }

        [When(@"Activate Authorization method")]
        public void WhenActivateAuthorizationMethod()
        {
            List<RegisterRequestModel> userModel = (List<RegisterRequestModel>)FeatureContext.Current["ModelRegistrUser"];
                string email = userModel[0].Email;
                string password = userModel[0].Password;
               FeatureContext.Current["TokenUser"] = Auth.AuthUser(email, password);
        }


        [When(@"Get User Models by id")]
        public void WhenGetUserModelsById()
        {
            //string token = (string)FeatureContext.Current["TokenUser"];
            //int id = (int)FeatureContext.Current["IdUser"];

            FeatureContext.Current["ActualUserModel"] = Get.GetUserById((string)FeatureContext.Current["TokenUser"], 
                (int)FeatureContext.Current["IdUser"]);
        }

        [Then(@"Should User Models coincide with the returned models of these entities")]
        public void ThenShouldUserModelsCoincideWithTheReturnedModelsOfTheseEntities()
        {
            List<RegisterRequestModel> expectedUserModel = (List<RegisterRequestModel>)FeatureContext.Current["ModelRegistrUser"];
            List<RegistrationResponsesModel> actualUserModel = (List<RegistrationResponsesModel>)FeatureContext.Current["ActualUserModel"];
            Assert.AreEqual(expectedUserModel[0].FirstName, actualUserModel[0].FirstName);
            Assert.AreEqual(expectedUserModel[0].LastName, actualUserModel[0].LastName);
            Assert.AreEqual(expectedUserModel[0].Patronymic, actualUserModel[0].Patronymic);
            Assert.AreEqual(expectedUserModel[0].Email, actualUserModel[0].Email);
            Assert.AreEqual(expectedUserModel[0].Username, actualUserModel[0].Username);
            Assert.AreEqual(expectedUserModel[0].City, actualUserModel[0].City);
            Assert.AreEqual(expectedUserModel[0].BirthDate, actualUserModel[0].BirthDate);
            Assert.AreEqual(expectedUserModel[0].GitHubAccount, actualUserModel[0].GitHubAccount);
            Assert.AreEqual(expectedUserModel[0].PhoneNumber, actualUserModel[0].PhoneNumber);
        }

<<<<<<< Updated upstream
=======
<<<<<<< HEAD
        [Given(@"New model User")]
        public void GivenNewModelUser(Table table)
        {
            FeatureContext.Current["NewModelUser"] = table.CreateSet<RegistrationResponsesModel>().ToList().First();
        }


        [When(@"I want update user model")]
        public void WhenIWantUpdateUserModel()
        {
            RegistrationResponsesModel newUserModel = (RegistrationResponsesModel)FeatureContext.Current["NewModelUser"];
            newUserModel.Id = (int)FeatureContext.Current["IdUser"];
            newUserModel.City = "1";
            Update.UpdateUser(newUserModel, (int)FeatureContext.Current["IdUser"], (string)FeatureContext.Current["TokenUser"]);
        }

        [When(@"Get new User Model by id")]
        public void WhenGetNewUserModelById()
        {            
            FeatureContext.Current["newGetUser"] = Get.GetUserByIdReturnModel((string)FeatureContext.Current["TokenUser"], 
                (int)FeatureContext.Current["IdUser"]);
        }

        //[Then(@"Should my new model user with the returned models of these entities")]
        //public void ThenShouldMyNewModelUserWithTheReturnedModelsOfTheseEntities()
        //{
        //    RegistrationResponsesModel expectedUserModel = (RegistrationResponsesModel)FeatureContext.Current["NewModelUser"];
        //    StudentModel actualUserModel = (StudentModel)FeatureContext.Current["newGetUser"];
        //    Assert.AreEqual(expectedUserModel.FirstName, actualUserModel.FirstName);
        //    Assert.AreEqual(expectedUserModel.LastName, actualUserModel.LastName);
        //    Assert.AreEqual(expectedUserModel.Patronymic, actualUserModel.Patronymic);
        //    Assert.AreEqual(expectedUserModel.Email, actualUserModel.Email);
        //    Assert.AreEqual(expectedUserModel.Username, actualUserModel.Username);
        //    Assert.AreEqual(expectedUserModel.City, actualUserModel.City);
        //    Assert.AreEqual(expectedUserModel.BirthDate, actualUserModel.BirthDate);
        //    Assert.AreEqual(expectedUserModel.PhoneNumber, actualUserModel.PhoneNumber);
        //}

        [Then(@"Get Admins Token")]
        public void ThenGetAdminsToken(Table table)
        {
            FeatureContext.Current["Admin"] = table.CreateSet<LoginRequestModel>().ToList().First();
            LoginRequestModel adminEnterRequestModel = (LoginRequestModel)FeatureContext.Current["Admin"];
            FeatureContext.Current["TokenAdmin"] = Auth.AuthUser(adminEnterRequestModel.Email, adminEnterRequestModel.Password);
        }


        [Then(@"Delete user")]
        public void ThenDeleteUser()
        {
            Delete.DeleteUserById((string)FeatureContext.Current["TokenAdmin"], (int)FeatureContext.Current["IdUser"]);
            Get.GetUserByIdAfterDeleted((string)FeatureContext.Current["TokenAdmin"], (int)FeatureContext.Current["IdUser"]);
=======
>>>>>>> Stashed changes
        [Given(@"Create too old, too young and write a thong in the phone number string")]
        public void GivenCreateTooOldTooYoungAndWriteAThongInThePhoneNumberString(Table table)
        {
            FeatureContext.Current["ModelRegistrUser"] = table.CreateSet<RegisterRequestModel>().ToList();
        }

        [Then(@"Should return UnprocessableEntity response")]
        public void ThenShouldReturnUnprocessableEntityResponse()
        {
            List<RegisterRequestModel> user = (List<RegisterRequestModel>)FeatureContext.Current["ModelRegistrUser"];
            Auth registr = new Auth();
            List<RegistrationResponsesModel> userResponses = registr.Registration(user);
            FeatureContext.Current["RegistrationResponsesUserActual"] = userResponses;
            for (int i = 0; i < userResponses.Count; i++)
            {
                FeatureContext.Current["IdUser"] = userResponses[i].Id;
            }
<<<<<<< Updated upstream
=======
>>>>>>> TestScenarioRegistrUpdateAndDelete
>>>>>>> Stashed changes
        }
    }
}
