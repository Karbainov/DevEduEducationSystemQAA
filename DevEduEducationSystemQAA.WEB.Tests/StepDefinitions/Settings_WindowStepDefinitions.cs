
using System;
using TechTalk.SpecFlow;

namespace DevEduEducationSystemQAA.WEB.Tests.StepDefinitions
{
    [Binding]
    public class Settings_WindowStepDefinitions
    {
        private IWebDriver _driver;

        [Given(@"I user, I enter the account settings window")]
        public void GivenIUserIEnterTheAccountSettingsWindow()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(UrlStorage.SettingWindow);
            _driver.Manage().Window.Maximize();
        }

        [Given(@"I enter data in the fields that I want to change")]
        public void GivenIEnterDataInTheFieldsThatIWantToChange(Table table)
        {
            RegistrationRequestModel user = table.CreateSet<RegistrationRequestModel>().ToList().First();
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
            inputBirthdate.SendKeys(Keys.Backspace);
            inputBirthdate.SendKeys(Keys.Backspace);
            inputBirthdate.SendKeys(Keys.Backspace);
            inputBirthdate.SendKeys(Keys.Backspace);
            inputBirthdate.SendKeys(Keys.Backspace);
            inputBirthdate.SendKeys(Keys.Backspace);
            inputBirthdate.SendKeys(Keys.Backspace);
            inputBirthdate.SendKeys(Keys.Backspace);
            inputBirthdate.SendKeys(Keys.Backspace);
            inputBirthdate.SendKeys(Keys.Backspace);
            inputBirthdate.SendKeys(Keys.Backspace);
            inputBirthdate.SendKeys(user.BirthDate);
            var inputPhone = _driver.FindElement(Setting_WindowXPaths.Phone);
            inputPhone.Clear();
            inputPhone.SendKeys(user.Phone);
            var inputLinkGitHub = _driver.FindElement(Setting_WindowXPaths.LinkByGitHub);
            inputLinkGitHub.Clear();
            inputLinkGitHub.SendKeys(user.LinkByGitHub);
        }


    }
}
