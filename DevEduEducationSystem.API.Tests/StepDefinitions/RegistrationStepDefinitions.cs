using DevEduEducationSystem.API.Tests.Support.MethodForTests;
using DevEduEducationSystem.API.Tests.Support.Models;
using DevEduEducationSystem.API.Tests.Support.Models.StudentModelClassesForModel;
using System;
using System.Net;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace DevEduEducationSystem.API.Tests.StepDefinitions
{
    [Binding]
    public class RegistrationStepDefinitions
    {
        [When(@"I register")]
        [Given(@"I register")]
        public void IRegister(Table table)
        {
            List<RegistrationRequestModel> user = table.CreateSet<RegistrationRequestModel>().ToList();
            List<RegistrationResponseModel> userResponses = AuthClient.Registration(user);
            ScenarioContext.Current["RegisterRequestModels"] = user;
            for (int i = 0; i < userResponses.Count; i++)
            {
                ScenarioContext.Current["IdUser"] = userResponses[i].Id;
            }
        }

        [When(@"Autorized by (.*) and (.*)")]
        public void AutorizedByEmailAndPassword(string email, string password)
        {
            ScenarioContext.Current["TokenUser"] = AuthClient.AuthUser(email, password);
        }

        [When(@"Get User by my Id")]
        public void WhenGetUserByMyId()
        {
            var token = (string)ScenarioContext.Current["TokenUser"];
            var idUser=(int)ScenarioContext.Current["IdUser"];
            ScenarioContext.Current["ActualUserModel"] = GetClient.GetUserById(token, idUser);
        }
       

        [When(@"I Update myself")]
        public void WhenIUpdateMyself(Table table)
        {
            RegistrationResponseModel newUserModel = table.CreateInstance<RegistrationResponseModel>();
            newUserModel.Id = (int)ScenarioContext.Current["IdUser"];
            newUserModel.City = "2";
            ScenarioContext.Current["RegisterRequestModels"] = newUserModel;
            UpdateClient.UpdateUser(newUserModel, (int)ScenarioContext.Current["IdUser"], (string)ScenarioContext.Current["TokenUser"]);
        }

        [When(@"I try to register as")]
        public void WhenITryToRegisterAs(Table table)
        {
            AuthClient registr = new AuthClient();
            
            RegistrationRequestModel user = table.CreateInstance<RegistrationRequestModel>();
            HttpResponseMessage httpResponse = registr.Registration(user);
            ScenarioContext.Current["StatusCode"] = httpResponse.StatusCode;
        }

        [When(@"I Deleted created User By ID")]
        public void WhenIDeletedCreatedUserByID()
        {
            LoginRequestModel adminEnterRequestModel = new LoginRequestModel()
            {
                Email = "user@example.com",
                Password = "stringst"
            };
            ScenarioContext.Current["AdminToken"] = AuthClient.AuthUser(adminEnterRequestModel.Email, adminEnterRequestModel.Password);
            DeleteClient.DeleteUserById((string)ScenarioContext.Current["AdminToken"], (int)ScenarioContext.Current["IdUser"]);
        }        


        [Then(@"Should User Models coincide with the returned models of these entities")]
        public void ThenShouldUserModelsCoincideWithTheReturnedModelsOfTheseEntities()
        {
            if (ScenarioContext.Current["RegisterRequestModels"] is List<RegistrationRequestModel>)
            {
                Mapper mapper = new Mapper();
                List<RegistrationRequestModel> expectedUserModels = (List<RegistrationRequestModel>)ScenarioContext.Current["RegisterRequestModels"];
                foreach (var m in expectedUserModels)
                {
                    m.Password = null;
                }

                RegistrationResponseModel registerRequestModels = (RegistrationResponseModel)ScenarioContext.Current["ActualUserModel"];
                List<RegistrationRequestModel> actualUserModels = new List<RegistrationRequestModel>();
                actualUserModels.Add(mapper.MapRegistrationResponsesModelToRegisterRequestModel(registerRequestModels));    
               
                CollectionAssert.AreEqual(expectedUserModels, actualUserModels);
            }
            else if (ScenarioContext.Current["RegisterRequestModels"] is RegistrationResponseModel)
            {
                RegistrationResponseModel expectedUserModel = (RegistrationResponseModel)ScenarioContext.Current["RegisterRequestModels"];
                expectedUserModel.City = "Dnipro";
                RegistrationResponseModel actualUserModel = (RegistrationResponseModel)ScenarioContext.Current["ActualUserModel"];

                Assert.AreEqual(expectedUserModel, actualUserModel);
            }
        }

        [Then(@"Should return (.*) status code response")]
        public void ThenShouldReturnUnprocessableEntityResponse(int statusCode)
        {
            HttpStatusCode expected = (HttpStatusCode)statusCode;
            
            HttpStatusCode actual = (HttpStatusCode)ScenarioContext.Current["StatusCode"];

            Assert.AreEqual(expected, actual);
        }       

        [Then(@"Delete user can not pass authorization by (.*) and (.*)")]
        public void ThenDeleteUserCanNotPassAuthorizationByQQQYYYAAAMail_RuAndQwerty(string login, string password)
        {
            AuthClient.AuthUserErrorForNegativeTest(login, password);
        }

        [Then(@"Delete user not found in list all Users")]
        public void ThenDeleteUserNotFoundInListAllUsers()
        {
            int idUser = (int) ScenarioContext.Current["IdUser"];
            List<AllUsersResponseModel> allUsers = GetClient.GetAllUsers((string)ScenarioContext.Current["AdminToken"]);
            foreach (AllUsersResponseModel model in allUsers)
            {
                Assert.AreNotEqual(idUser, model.Id);                
            }
        }
    }
}
