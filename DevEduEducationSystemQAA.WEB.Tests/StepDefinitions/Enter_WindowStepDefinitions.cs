
using System;
using TechTalk.SpecFlow;

namespace DevEduEducationSystemQAA.WEB.Tests.StepDefinitions
{
    [Binding]
    public class Enter_WindowStepDefinitions
    {
        private IWebDriver _driver; 

        // Scenario Window Enter Click on button cancel

        [Given(@"I enter the  window enter with the window size (.*) and (.*)")]
        public void GivenIEnterTheWindowEnterWithTheWindowSizeAnd(int oneSize, int twoSize)
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(UrlStorage.EnterWindow);
            _driver.Manage().Window.Position = new Point(0, 0);
            _driver.Manage().Window.Size = new Size(oneSize, twoSize);
        }

        [Given(@"I am a user filling in email and password")]
        public void GivenIAmAUserFillingInEmailAndPassword(Table table)
        {
            LoginRequestModel loginAndPassword = table.CreateSet<LoginRequestModel>().ToList().First();
            var inputLogin = _driver.FindElement(Enter_WindowXPaths.InputLogin);
            inputLogin.SendKeys(loginAndPassword.Email);
            var inputPassword = _driver.FindElement(Enter_WindowXPaths.InputPassword);
            inputPassword.Clear();
            inputPassword.SendKeys(loginAndPassword.Password);
        }

        [When(@"I click the cancel button")]
        public void WhenIClickTheCancelButton()
        {
            var buttonCancel = _driver.FindElement(Enter_WindowXPaths.ButtonCancel);
            buttonCancel.Click();
        }

        [Then(@"The entered data should be erased")]
        public void ThenTheEnteredDataShouldBeErased()
        {
            string attributeType = "value";
            string inputEmailActual = _driver.FindElement(Enter_WindowXPaths.InputLogin).GetAttribute(attributeType);
            string loginEcpected = "";
            string inputPassword = _driver.FindElement(Enter_WindowXPaths.InputPassword).GetAttribute(attributeType);
            string passwordExpected = "password";
            Assert.AreEqual(loginEcpected, inputEmailActual);
            Assert.AreEqual(passwordExpected, inputPassword);
            _driver.Close();
        }

        // New Scenario - click on button enter

        [Given(@"I click the enter button")]
        [When(@"I click the enter button")]
        public void WhenIClickTheEnterButton()
        {
            var buttonEnter = _driver.FindElement(Enter_WindowXPaths.ButtonEnter);
            buttonEnter.Click();
            Thread.Sleep(1000);
        }

        [Then(@"A new window should open - Notifications section")]
        public void ThenANewWindowShouldOpen_NotificationsSection()
        {
            _driver.Navigate().GoToUrl(UrlStorage.BasePage);
            string expected = UrlStorage.BasePage;
            string actual = _driver.Url;
            Assert.AreEqual(expected, actual);
            _driver.Close();
        }

        // new Scenario negative test - not valid Login and password
        [Then(@"There should be a message with the text - Incorrect login or password and the url won't change")]
        public void ThenThereShouldBeAMessageWithTheText_IncorrectLoginOrPasswordAndTheUrlWontChange()
        {
            string expected = UrlStorage.EnterWindow;
            string actual = _driver.Url;
            Assert.AreEqual(expected, actual);
            _driver.Close();
        }




    }
}
