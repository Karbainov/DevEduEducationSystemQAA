
using OpenQA.Selenium.Support.UI;

using System;
using TechTalk.SpecFlow;

namespace DevEduEducationSystemQAA.WEB.Tests.StepDefinitions
{
    [Binding]
    public class Settings_WindowStepDefinitions
    {
        private IWebDriver _driver;
        private string _userPhotosSrc;

        [Given(@"I log in to the system  with the window size (.*) and (.*)")]
        public void GivenILogInToTheSystemWithTheWindowSizeAnd(int oneSize, int twoSize, Table table)
        {
            LoginRequestModel emailAndPassword = table.CreateSet<LoginRequestModel>().ToList().First();
            FeatureContext.Current["emailAndPassword"] = emailAndPassword;
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
            ScenarioContext.Current["Driver"] = _driver;
            _driver.Navigate().GoToUrl(UrlStorage.BasePage);
        }

        [Given(@"I click the button Setting")]
        public void GivenIClickTheButtonSetting()
        {
            var buttonSetting = _driver.FindElement(Setting_WindowXPaths.ButtonNameUserItIsSetting);
            buttonSetting.Click();
        }

        [Given(@"I enter data in the fields that I want to change")]
        public void GivenIEnterDataInTheFieldsThatIWantToChange(Table table)
        {
            RegistrationRequestModel user = table.CreateSet<RegistrationRequestModel>().ToList().First();
            FeatureContext.Current["UpdateUserExpected"] = user;
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
            RegistrationRequestModel expected = (RegistrationRequestModel)FeatureContext.Current["UpdateUserExpected"];
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
            _driver.Close();
        }

        // new Scenario - cancel save update user

        [When(@"Button click cancel in window setting")]
        public void WhenButtonClickCancelInWindowSetting()
        {
            var buttonCancel = _driver.FindElement(Setting_WindowXPaths.ButtonCancel);
            buttonCancel.Click();
            Thread.Sleep(500);
        }

        [Then(@"Should return to the notification window")]
        public void ThenShouldReturnToTheNotificationWindow()
        {
            string expected = UrlStorage.BasePage;
            string actual = _driver.Url;
            Thread.Sleep(1000);
            Assert.AreEqual(expected, actual);
        }

        [Then(@"Check that the changes are not saved")]
        public void ThenCheckThatTheChangesAreNotSaved(Table table)
        {
            string attributeType = "value";
            _driver.Navigate().GoToUrl(UrlStorage.SettingWindow);
            RegistrationRequestModel expected = table.CreateSet<RegistrationRequestModel>().ToList().First();
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            var ph = webDriverWait.Until((dr) =>dr.FindElement(Setting_WindowXPaths.Surname));
            string surname = _driver.FindElement(Setting_WindowXPaths.Surname).GetAttribute(attributeType);
            string name = _driver.FindElement(Setting_WindowXPaths.Name).GetAttribute(attributeType);
            string patronymic = _driver.FindElement(Setting_WindowXPaths.Patronymic).GetAttribute(attributeType);
            string inputBirthdate = _driver.FindElement(Setting_WindowXPaths.BirthDate).GetAttribute(attributeType);
            string inputPhone = _driver.FindElement(Setting_WindowXPaths.Phone).GetAttribute(attributeType);
            string inputLinkGitHub = _driver.FindElement(Setting_WindowXPaths.LinkByGitHub).GetAttribute(attributeType);
            Assert.AreEqual(expected.Name, name);
            Assert.AreEqual(expected.Patronymic, patronymic);
            Assert.AreEqual(expected.Surname, surname);
            Assert.AreEqual(expected.BirthDate, inputBirthdate); // не забыть подключить дату - она у них не работает
            Assert.AreEqual(expected.Phone, inputPhone);
            Assert.AreEqual(expected.LinkByGitHub, inputLinkGitHub);
            _driver.Close();
        }

        // new Scenario - update password

        [When(@"Click on the pencil")]
        public void WhenClickOnThePencil()
        {
            var buttonPencil = _driver.FindElement(Setting_WindowXPaths.ButtonPencil);
            buttonPencil.Click();
            string urlActual = _driver.Url;
            string expected = UrlStorage.UpdatePassword;
            Assert.AreEqual(expected, urlActual);
        }

        [Given(@"Fill in the fields with data to change the password")]
        public void GivenFillInTheFieldsWithDataToChangeThePassword(Table table)
        {
            LoginRequestModel emailAndPassword = (LoginRequestModel)FeatureContext.Current["emailAndPassword"];
            var inputOldPassword = _driver.FindElement(Setting_WindowXPaths.InputOldPassword);
            inputOldPassword.SendKeys(emailAndPassword.Password);
            LoginRequestModel newPassword = table.CreateSet<LoginRequestModel>().ToList().First();
            ScenarioContext.Current["newPassword"] = newPassword;
            var inputNewPassword = _driver.FindElement(Setting_WindowXPaths.InputNewPassword);
            inputNewPassword.SendKeys(newPassword.Password);
            var inputNewPasswordRepead = _driver.FindElement(Setting_WindowXPaths.InputNewPasswordReaped);
            inputNewPasswordRepead.SendKeys(newPassword.Password);
        }

        [When(@"Button click save in window update password")]
        public void GivenButtonClickSaveInWindowUpdatePassword()
        {
            var buttonSave = _driver.FindElement(Setting_WindowXPaths.ButtonSaveNewPassword);
            buttonSave.Click();
        }

        [Then(@"Check that the password has changed")]
        public void ThenCheckThatThePasswordHasChanged()
        {
            var exit = _driver.FindElement(GroupAllFunctionalityXPath.ButtonExit);
            exit.Click();
            Thread.Sleep(300);
            LoginRequestModel emailAndPassword = (LoginRequestModel)FeatureContext.Current["emailAndPassword"];
            LoginRequestModel newPassword = (LoginRequestModel)ScenarioContext.Current["newPassword"];
            IOHelper.CheckAuth(_driver, emailAndPassword.Email, newPassword.Password);
        }

        // new Scenario - click cancel in window update password

        [When(@"Button click cancel in window update password")]
        public void WhenButtonClickCancelInWindowUpdatePassword()
        {
            var buttonCancel = _driver.FindElement(Setting_WindowXPaths.ButtonCancelNewPassword);
            buttonCancel.Click();
        }

        [Then(@"Check that the password don't has changed and moved to the last window")]
        public void ThenCheckThatThePasswordDontHasChangedAndMovedToTheLastWindow()
        {
           string urlActual = _driver.Url;
           string urlExpected = UrlStorage.SettingWindow;
           Assert.AreEqual(urlExpected, urlActual);
        }

        // new Scenario - change password and button click back

        [When(@"Button click back in window update password")]
        public void WhenButtonClickBackInWindowUpdatePassword()
        {
            var buttonBack = _driver.FindElement(Setting_WindowXPaths.ButtonBack);
            buttonBack.Click();
        }

        [Then(@"Back to settings window")]
        public void ThenBackToSettingsWindow()
        {
            string urlActual = _driver.Url;
            string urlExpected = UrlStorage.SettingWindow;
            Assert.AreEqual(urlExpected, urlActual);
        }


        // new Scenario - save new or update photo

        [Given(@"I user, I click text Upload new photo")]
        [When(@"I user, I click text Upload new photo")]
        public void WhenIUserIClickTextSaveNewPhoto()
        {
            IWebElement uploadPhoto;
            string src="";
            try
            {
                uploadPhoto = _driver.FindElement(By.XPath(@"//img[@class='avatar-photo']"));
                src = uploadPhoto.GetAttribute("src");
            }
            catch(NoSuchElementException)
            {
                uploadPhoto = _driver.FindElement(By.XPath(@"//div[@class='svg-text']"));
            }
            //var uploadPhoto = _driver.FindElement(Setting_WindowXPaths.TextUploadNewPhoto);

            _userPhotosSrc = src;

            uploadPhoto.Click();
            Thread.Sleep(250);
        }

        [Then(@"A window should appear with cancel buttons and select a file")]
        public void ThenAWindowShouldAppearWithCancelButtonsAndSelectAFile()
        {
            var buttonSelectFile = _driver.FindElement(Setting_WindowXPaths.PhotoButtonSelectFile);
            var buttonCancelPhoto = _driver.FindElement(Setting_WindowXPaths.PhotoButtonCancel);
        }

        [Given(@"Click button Select a file")]
        public void GivenClickButtonSelectAFile()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("document.querySelector('.modal-window input[type=\"file\"]').setAttribute('style','display:inline;')");
            _driver.FindElement(By.CssSelector(".modal-window input[type=\"file\"]")).SendKeys(@"C:\Harry.jpg");
            Thread.Sleep(1000);
            _driver.FindElement(By.CssSelector(".modal-window input[type=\"submit\"]")).Click();
            Thread.Sleep(1000);
        }

        [Then(@"Photo should be changed")]
        public void ThenPhotoShouldBeChanged()
        {
            _driver.Navigate().Refresh();
            Thread.Sleep(1000);
            var uploadPhoto = _driver.FindElement(By.XPath(@"//img[@class='avatar-photo']"));
            string actual = uploadPhoto.GetAttribute("src");
            string unexpected = _userPhotosSrc;
            Assert.AreNotEqual(unexpected, actual);
            _driver.Close();
        }

        // new Scenario - cancel save phot

        [When(@"Click on the cancel button to deselect the photo")]
        public void WhenClickOnTheCancelButtonToDeselectThePhoto()
        {
            var buttonCancel = _driver.FindElement(Setting_WindowXPaths.PhotoButtonCancel);
            buttonCancel.Click();
        }

        [Then(@"The message box for choosing a photo should close")]
        public void ThenTheMessageBoxForChoosingAPhotoShouldClose()
        {
            Assert.Throws<NoSuchElementException>(() => _driver.FindElement(Setting_WindowXPaths.TextAboutPhoto));
            _driver.Close();
        }

        // new Scenario - negative test - email it should be readonly

        [When(@"I clean and new enter email that I want to change")]
        public void WhenICleanAndNewEnterEmailThatIWantToChange(Table table)
        {
            RegistrationRequestModel user = table.CreateSet<RegistrationRequestModel>().ToList().First();
            var inputEmail = _driver.FindElement(Setting_WindowXPaths.InputEmail);
            inputEmail.Clear();
            inputEmail.SendKeys(user.Email);
        }

        [Then(@"Check that the email field is not cleared")]
        public void ThenCheckThatTheEmailFieldIsNotCleared()
        {
            string getAttribute = "value";
            LoginRequestModel emailAndPassword = (LoginRequestModel)FeatureContext.Current["emailAndPassword"];
            string actual = _driver.FindElement(Setting_WindowXPaths.InputEmail).GetAttribute(getAttribute);
            string expexted = emailAndPassword.Email;
            Assert.AreEqual(actual, expexted);
            _driver.Close();
        }





    }
}
