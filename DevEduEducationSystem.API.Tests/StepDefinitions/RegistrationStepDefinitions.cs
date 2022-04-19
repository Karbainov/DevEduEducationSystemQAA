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
            FeatureContext.Current["RegisterRequestModels"] = user;
            for (int i = 0; i < userResponses.Count; i++)
            {
                FeatureContext.Current["IdUser"] = userResponses[i].Id;
            }
        }

        [When(@"Autorized by (.*) and (.*)")]
        public void AutorizedByEmailAndPassword(string email, string password)
        {
            FeatureContext.Current["TokenUser"] = AuthClient.AuthUser(email, password);
        }

        [When(@"Get User by my Id")]
        public void WhenGetUserByMyId()
        {
            var token = (string)FeatureContext.Current["TokenUser"];
            var idUser=(int)FeatureContext.Current["IdUser"];
            FeatureContext.Current["ActualUserModel"] = GetClient.GetUserById(token, idUser);
        }

        [Then(@"Should User Models coincide with the returned models of these entities")]
        public void ThenShouldUserModelsCoincideWithTheReturnedModelsOfTheseEntities()
        {
            if (FeatureContext.Current["RegisterRequestModels"] is List<RegisterRequestModel>)
            {
                Mapper mapper = new Mapper();
                List<RegisterRequestModel> expectedUserModels = (List<RegisterRequestModel>)FeatureContext.Current["RegisterRequestModels"];
                foreach (var m in expectedUserModels)
                {
                    m.Password = null;
                }

                List<RegistrationResponsesModel> registerRequestModels = (List<RegistrationResponsesModel>)FeatureContext.Current["ActualUserModel"];
                List<RegisterRequestModel> actualUserModels = new List<RegisterRequestModel>();
                foreach (var m in registerRequestModels)
                {
                    actualUserModels.Add(mapper.MapRegistrationResponsesModelToRegisterRequestModel(m));
                }

                CollectionAssert.AreEqual(expectedUserModels, actualUserModels);
            }
            else if(FeatureContext.Current["RegisterRequestModels"] is RegistrationResponsesModel)
            {
                RegistrationResponsesModel expectedUserModel = (RegistrationResponsesModel)FeatureContext.Current["RegisterRequestModels"];
                expectedUserModel.City = "SaintPetersburg";
                 RegistrationResponsesModel actualUserModel = ((List<RegistrationResponsesModel>)FeatureContext.Current["ActualUserModel"])[0];

                Assert.AreEqual(expectedUserModel, actualUserModel);
            }
        }

        [When(@"I try to register as")]
        public void WhenITryToRegisterAs(Table table)
        {
            AuthClient registr = new AuthClient();
            
            RegisterRequestModel user = table.CreateInstance<RegisterRequestModel>();
            HttpResponseMessage httpResponse = registr.Registration(user);
            FeatureContext.Current["StatusCode"] = httpResponse.StatusCode;
        }

        [Then(@"Should return (.*) status code response")]
        public void ThenShouldReturnUnprocessableEntityResponse(int statusCode)
        {
            HttpStatusCode expected = (HttpStatusCode)statusCode;
            
            HttpStatusCode actual = (HttpStatusCode)FeatureContext.Current["StatusCode"];

            Assert.AreEqual(expected, actual);
        }

        [When(@"I Update myself")]
        public void WhenIUpdateMyself(Table table)
        {
            RegistrationResponsesModel newUserModel = table.CreateInstance<RegistrationResponsesModel>();
            newUserModel.Id = (int)FeatureContext.Current["IdUser"];
            newUserModel.City = "1";
            FeatureContext.Current["RegisterRequestModels"] = newUserModel;
            UpdateClient.UpdateUser(newUserModel, (int)FeatureContext.Current["IdUser"], (string)FeatureContext.Current["TokenUser"]);
        }



        [AfterScenario]
        public void AfterScenario()
        {
            LoginRequestModel adminEnterRequestModel = new LoginRequestModel()
            {
                Email = "user@example.com",
                Password = "stringst"
            };
            string tokenAdmin = AuthClient.AuthUser(adminEnterRequestModel.Email, adminEnterRequestModel.Password);
            DeleteClient.DeleteUserById(tokenAdmin, (int)FeatureContext.Current["IdUser"]);
            GetClient.GetUserByIdAfterDeleted(tokenAdmin, (int)FeatureContext.Current["IdUser"]);
        }
    }
}
