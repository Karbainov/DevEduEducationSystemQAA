using DevEduEducationSystem.API.Tests.Support.MethodForTests;
using DevEduEducationSystem.API.Tests.Support.Models;
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
                Auth registr = new Auth();
               FeatureContext.Current["TokenUser"] = registr.AuthUser(email, password);
        }


        [When(@"Get User Models by id")]
        public void WhenGetUserModelsById()
        {
            string token = (string)FeatureContext.Current["TokenUser"];
            Get user = new Get();
            int id = (int)FeatureContext.Current["IdUser"];
            FeatureContext.Current["ActualUserModel"] = user.GetUserById(token,id);
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

    }
}
