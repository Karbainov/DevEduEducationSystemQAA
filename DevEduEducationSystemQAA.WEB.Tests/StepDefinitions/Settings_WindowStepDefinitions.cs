
using OpenQA.Selenium.Support.UI;

using System;
using TechTalk.SpecFlow;

namespace DevEduEducationSystemQAA.WEB.Tests.StepDefinitions
{
    [Binding]
    public class Settings_WindowStepDefinitions
    {
        private IWebDriver _driver;

        [Given(@"I log in to the system  with the window size (.*) and (.*)")]
        public void GivenILogInToTheSystemWithTheWindowSizeAnd(int oneSize, int twoSize, Table table)
        {
            LoginRequestModel emailAndPassword = table.CreateSet<LoginRequestModel>().ToList().First();
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(UrlStorage.EnterWindow);
            _driver.Manage().Window.Position = new Point(0, 0);
            _driver.Manage().Window.Size = new Size(oneSize, twoSize);
            var inputEmail = _driver.FindElement(Enter_WindowXPaths.InputLogin);
            inputEmail.SendKeys(emailAndPassword.Email);
            var inputPassword = _driver.FindElement(Enter_WindowXPaths.InputPassword);
            inputPassword.Clear();
            inputPassword.SendKeys(emailAndPassword.Password);
            var buttonEnter = _driver.FindElement(Enter_WindowXPaths.ButtonEnter);
            buttonEnter.Click();
            Thread.Sleep(1500);
            //_driver.Navigate().GoToUrl(UrlStorage.BasePage);
        }

        [Given(@"I click the button Setting")]
        public void GivenIClickTheButtonSetting()
        {
            var buttonSetting = _driver.FindElement(Setting_WindowXPaths.ButtonNameUserItIsSetting);
            buttonSetting.Click();
        }

        [Given(@"I user, I enter the account settings window")]
        public void GivenIUserIEnterTheAccountSettingsWindow()
        {
            //_driver.Navigate().GoToUrl(UrlStorage.SettingWindow);
            //Thread.Sleep(1000);
        }


        [Given(@"I enter data in the fields that I want to change")]
        public void GivenIEnterDataInTheFieldsThatIWantToChange(Table table)
        {
            RegistrationRequestModel user = table.CreateSet<RegistrationRequestModel>().ToList().First();
            ScenarioContext.Current["UpdateUserExpected"] = user;
            var surname = _driver.FindElement(Setting_WindowXPaths.Surname);
            surname.Clear();
            surname.SendKeys(user.Surname);
            var name = _driver.FindElement(Setting_WindowXPaths.Name);
            name.Clear();
            name.SendKeys(user.Name);
            var patronymic = _driver.FindElement(Setting_WindowXPaths.Patronymic);
            patronymic.Clear();
            patronymic.SendKeys(user.Patronymic);
            var inputBirthdate = _driver.FindElement(Setting_WindowXPaths.BirthDate);
            Actions action = new Actions(_driver);
            action.DoubleClick(inputBirthdate).Build().Perform();
            inputBirthdate.SendKeys(Keys.Backspace);
            inputBirthdate.SendKeys(user.BirthDate);
            var inputPhone = _driver.FindElement(Setting_WindowXPaths.Phone);
            inputPhone.Clear();
            inputPhone.SendKeys(user.Phone);
            var inputLinkGitHub = _driver.FindElement(Setting_WindowXPaths.LinkByGitHub);
            inputLinkGitHub.Clear();
            inputLinkGitHub.SendKeys(user.LinkByGitHub);
        }

        [When(@"Button click save in window setting")]
        public void WhenButtonClickSaveInWindowSetting()
        {
            var buttonSave = _driver.FindElement(Setting_WindowXPaths.ButtonSave);
            buttonSave.Click();
            _driver.Navigate().Refresh();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Then(@"Refresh the page changes should be saved")]
        public void ThenRefreshThePageChangesShouldBeSaved()
        {
            string attributeType = "value";
            RegistrationRequestModel expected = (RegistrationRequestModel)ScenarioContext.Current["UpdateUserExpected"];
            string surname = _driver.FindElement(Setting_WindowXPaths.Surname).GetAttribute(attributeType);
            string name = _driver.FindElement(Setting_WindowXPaths.Name).GetAttribute(attributeType);
            string patronymic = _driver.FindElement(Setting_WindowXPaths.Patronymic).GetAttribute(attributeType); 
            string inputBirthdate = _driver.FindElement(Setting_WindowXPaths.BirthDate).GetAttribute(attributeType); 
            string inputPhone = _driver.FindElement(Setting_WindowXPaths.Phone).GetAttribute(attributeType); 
            string inputLinkGitHub = _driver.FindElement(Setting_WindowXPaths.LinkByGitHub).GetAttribute(attributeType); 
            Assert.AreEqual(expected.Name, name);
            Assert.AreEqual(expected.Patronymic, patronymic);
            Assert.AreEqual(expected.Surname, surname);
            Assert.AreEqual(expected.BirthDate, inputBirthdate);
            Assert.AreEqual(expected.Phone, inputPhone);
            Assert.AreEqual(expected.LinkByGitHub, inputLinkGitHub);
        }


    }
}
