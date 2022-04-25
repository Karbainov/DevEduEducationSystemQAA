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
            ScenarioContext.Current["NewUser"] = table.CreateSet<RegisterRequestModel>().ToList().First();

        }

        [Given(@"I login as an admin and give new user role ""([^""]*)""")]
        public void GivenILoginAsAnAdminAndGiveNewUserRole(string methodist)
        {
            throw new PendingStepException();
        }

        [When(@"I login as an ""([^""]*)"" and create new course with name III and description Samiy luchiy course v tvoei zhizni")]
        public void WhenILoginAsAnAndCreateNewCourseWithNameIIIAndDescriptionSamiyLuchiyCourseVTvoeiZhizni(string methodist)
        {
            throw new PendingStepException();
        }

        [Then(@"Should Course Models coincide with the returned models of these entities")]
        public void ThenShouldCourseModelsCoincideWithTheReturnedModelsOfTheseEntities()
        {
            throw new PendingStepException();
        }
    }
}
