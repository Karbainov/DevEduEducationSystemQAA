using System;
using TechTalk.SpecFlow;

namespace DevEduEducationSystemQAA.WEB.Tests.StepDefinitions
{
    [Binding]
    public class Journal_WindowStepDefinitions
    {
       private IWebDriver _driver;

        [Given(@"I logged in as a teacher and went to the journal window with the window size (.*) and (.*)")]
        public void GivenILoggedInAsATeacherAndWentToTheJournalWindowWithTheWindowSizeLengthAndWidth(int oneSize, int twoSize, Table table)
        {
            LoginRequestModel emailAndPassword = table.CreateSet<LoginRequestModel>().ToList().First();
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(UrlStorage.EnterWindow);
            _driver.Manage().Window.Position = new Point(0, 0);
            _driver.Manage().Window.Size = new Size(oneSize, twoSize);
            IOHelper.EnterInSystem(emailAndPassword.Email, emailAndPassword.Password, _driver);
            var dropDownRole = _driver.FindElement(Journal_WindowXPath.DropDownRoles);
            dropDownRole.Click();
            var dropdownRoleTeacher = _driver.FindElement(Journal_WindowXPath.DropDownRoleTeacher);
            dropdownRoleTeacher.Click();
            var buttonJournal = _driver.FindElement(Journal_WindowXPath.ButtonJournal);
            buttonJournal.Click();
        }

        [Then(@"Check that you have entered the Journal window")]
        public void ThenCheckThatYouHaveEnteredTheJournalWindow()
        {
            string urlActual = _driver.Url;
            string urlExpected = UrlStorage.JournalWindow;
            Assert.AreEqual(urlExpected, urlActual);
        }

    }
}
