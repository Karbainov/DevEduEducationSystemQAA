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
            List<RegisterRequestModel> user = table.CreateSet<RegisterRequestModel>().ToList();
            AuthClient registr = new AuthClient();
            List<RegistrationResponsesModel> userResponses = registr.Registration(user);
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

        [Then(@"Should User Models coincide with the returned models of these entities")]
        public void ThenShouldUserModelsCoincideWithTheReturnedModelsOfTheseEntities()
        {
            if (ScenarioContext.Current["RegisterRequestModels"] is List<RegisterRequestModel>)
            {
                Mapper mapper = new Mapper();
                List<RegisterRequestModel> expectedUserModels = (List<RegisterRequestModel>)ScenarioContext.Current["RegisterRequestModels"];
                foreach (var m in expectedUserModels)
                {
                    m.Password = null;
                }

                List<RegistrationResponsesModel> registerRequestModels = (List<RegistrationResponsesModel>)ScenarioContext.Current["ActualUserModel"];
                List<RegisterRequestModel> actualUserModels = new List<RegisterRequestModel>();
                foreach (var m in registerRequestModels)
                {
                    actualUserModels.Add(mapper.MapRegistrationResponsesModelToRegisterRequestModel(m));
                }

                CollectionAssert.AreEqual(expectedUserModels, actualUserModels);
            }
            else if(ScenarioContext.Current["RegisterRequestModels"] is RegistrationResponsesModel)
            {
                RegistrationResponsesModel expectedUserModel = (RegistrationResponsesModel)ScenarioContext.Current["RegisterRequestModels"];
                expectedUserModel.City = "SaintPetersburg";
                 RegistrationResponsesModel actualUserModel = ((List<RegistrationResponsesModel>)ScenarioContext.Current["ActualUserModel"])[0];

                Assert.AreEqual(expectedUserModel, actualUserModel);
            }
        }

        [When(@"I try to register as")]
        public void WhenITryToRegisterAs(Table table)
        {
            AuthClient registr = new AuthClient();
            
            RegisterRequestModel user = table.CreateInstance<RegisterRequestModel>();
            HttpResponseMessage httpResponse = registr.Registration(user);
            ScenarioContext.Current["StatusCode"] = httpResponse.StatusCode;
        }

        [Then(@"Should return (.*) status code response")]
        public void ThenShouldReturnUnprocessableEntityResponse(int statusCode)
        {
            HttpStatusCode expected = (HttpStatusCode)statusCode;
            
            HttpStatusCode actual = (HttpStatusCode)ScenarioContext.Current["StatusCode"];

            Assert.AreEqual(expected, actual);
        }

        [When(@"I Update myself")]
        public void WhenIUpdateMyself(Table table)
        {
            RegistrationResponsesModel newUserModel = table.CreateInstance<RegistrationResponsesModel>();
            newUserModel.Id = (int)ScenarioContext.Current["IdUser"];
            newUserModel.City = "1";
            ScenarioContext.Current["RegisterRequestModels"] = newUserModel;
            UpdateClient.UpdateUser(newUserModel, (int)ScenarioContext.Current["IdUser"], (string)ScenarioContext.Current["TokenUser"]);
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

        [Then(@"Delete user can not pass authorization by (.*) and (.*)")]
        public void ThenDeleteUserCanNotPassAuthorizationByQQQYYYAAAMail_RuAndQwerty(string login, string password)
        {
            AuthClient.AuthUserErrorForNegativeTest(login, password);
        }

        [Then(@"Delete user not found in list all Users")]
        public void ThenDeleteUserNotFoundInListAllUsers()
        {
            int idUser = (int) ScenarioContext.Current["IdUser"];
            List<GetAllUsersResponseModel> allUsers = GetClient.GetAllClients((string)ScenarioContext.Current["AdminToken"]);
            foreach (GetAllUsersResponseModel model in allUsers)
            {
                GetAllUsersResponseModel actualModel = allUsers.FirstOrDefault(C => C.Id == model.Id);
                Assert.IsNull(actualModel);
            }
        }

        //[AfterScenario]
        //public void AfterScenario()
        //{
        //    LoginRequestModel adminEnterRequestModel = new LoginRequestModel()
        //    {
        //        Email = "user@example.com",
        //        Password = "stringst"
        //    };
        //    string tokenAdmin = AuthClient.AuthUser(adminEnterRequestModel.Email, adminEnterRequestModel.Password);
        //    DeleteClient.DeleteUserById(tokenAdmin, (int)ScenarioContext.Current["IdUser"]);
        //    GetClient.GetUserByIdAfterDeleted(tokenAdmin, (int)ScenarioContext.Current["IdUser"]);
        //}
    }
}
