using DevEduEducationSystemQAA.WEB.Tests.Support;
using DevEduEducationSystemQAA.WEB.Tests.Support.ViewModels;
using DevEduEducationSystemQAA.WEB.Tests.Support.XPaths;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Drawing;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace DevEduEducationSystemQAA.WEB.Tests.StepDefinitions
{
    [Binding]
    public class Registration_WindowStepDefinitions
    {
        private IWebDriver _driver;

        [Given(@"I enter the registration window with the window size (.*) and (.*)")]
        public void GivenIEnterTheRegistrationWindowWithTheWindowSizeAnd(int oneSize, int secondSize)
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(UrlStorage.RegistrationWindow);
            _driver.Manage().Window.Maximize();
            var buttonRegisterByWindowLogin = _driver.FindElement(Registration_WindowXPaths.buttonRegisterByWindowLogin);
            buttonRegisterByWindowLogin.Click();
        }


        [Given(@"I am a user fill in all required fields")]
        public void GivenIAmAUserFillInAllRequiredFields(Table table)
        {
            RegistrationRequestModel user = table.CreateSet<RegistrationRequestModel>().ToList().First();
            FeatureContext.Current["Register User"] = user;
            IWebElement inputSurname = _driver.FindElement(Registration_WindowXPaths.InputSurname);
            inputSurname.SendKeys(user.Surname);
            var inputName = _driver.FindElement(Registration_WindowXPaths.InputName);
            inputName.SendKeys(user.Name);
            var inputPatronymic = _driver.FindElement(Registration_WindowXPaths.InputPatronymic);
            inputPatronymic.SendKeys(user.Patronymic);
            var datePicker = _driver.FindElement(Registration_WindowXPaths.DatePicker);
            Actions action = new Actions(_driver);
            action.DoubleClick(datePicker).Build().Perform();
            datePicker.SendKeys(Keys.Backspace);
            datePicker.SendKeys(user.BirthDate);
            var inputPassword = _driver.FindElement(Registration_WindowXPaths.InputPassword);
            inputPassword.SendKeys(user.Password);
            var inputRepeatPassword = _driver.FindElement(Registration_WindowXPaths.InputRepeatPassword);
            inputRepeatPassword.SendKeys(user.RepeatPassword);
            var inputEmail = _driver.FindElement(Registration_WindowXPaths.InputEmail);
            inputEmail.SendKeys(user.Email);
            var inputPhone = _driver.FindElement(Registration_WindowXPaths.InputPhone);
            inputPhone.Click();
            inputPhone.SendKeys(user.Phone);
        }

        //[Then(@"When the Privacy Policy checkbox is unchecked, the Register button should be inactive")]
        //public void ThenWhenThePrivacyPolicyCheckboxIsUncheckedTheRegisterButtonShouldBeInactive()
        //{
        //    RegistrationRequestModel user = (RegistrationRequestModel)FeatureContext.Current["Register User"];
        //    _driver.Navigate().GoToUrl(UrlStorage.EnterWindow);
        //    var inputEmail = _driver.FindElement(Enter_WindowXPaths.InputLogin);
        //    inputEmail.SendKeys(user.Email);
        //    var inputPassword = _driver.FindElement(Enter_WindowXPaths.InputPassword);
        //    inputPassword.Clear();
        //    inputPassword.SendKeys(user.Password);
        //    var buttonEnter = _driver.FindElement(Enter_WindowXPaths.ButtonEnter);
        //    buttonEnter.Click();
        //    Thread.Sleep(500);
        //    _driver.Navigate().GoToUrl(UrlStorage.BasePage);
        //    string actual = _driver.Url;
        //    string expected = UrlStorage.EnterWindow;
        //    Assert.AreEqual(expected, actual);
        //}

        [Given(@"Click checkbox on the privacy policy")]
        public void GivenClickCheckboxOnThePrivacyPolicy()
        {
            var checkBox = _driver.FindElement(Registration_WindowXPaths.ChecBoxPrivacyPolicy);
            // ýòîò êóñîê êîäà èìèòèðóåò ìûøêó
            Actions build = new Actions(_driver);
            build.MoveToElement(checkBox).MoveByOffset(0, -5).Click().Build().Perform();
        }

        [When(@"Click on register button")]
        public void WhenClickOnRegisterButton()
        {
            var buttonReister = _driver.FindElement(Registration_WindowXPaths.ButtonRegister);
            buttonReister.Click();
        }


        [Then(@"Ñheck that a registered user will log into the application")]
        public void ThenÑheckThatARegisteredUserWillLogIntoTheApplication()
        {
            RegistrationRequestModel user = (RegistrationRequestModel)FeatureContext.Current["Register User"];
            _driver.Navigate().GoToUrl(UrlStorage.EnterWindow);
            var inputEmail = _driver.FindElement(Enter_WindowXPaths.InputLogin);
            inputEmail.SendKeys(user.Email);
            var inputPassword = _driver.FindElement(Enter_WindowXPaths.InputPassword);
            inputPassword.Clear();
            inputPassword.SendKeys(user.Password);
            var buttonEnter = _driver.FindElement(Enter_WindowXPaths.ButtonEnter);
            buttonEnter.Click();
            Thread.Sleep(500);
            _driver.Navigate().GoToUrl(UrlStorage.BasePage);
            string actual = _driver.Url;
            string expected = UrlStorage.BasePage;
            Assert.AreEqual(expected, actual);
            _driver.Close();
        }

        [Then(@"Delete User")]
        public void ThenDeleteUser()
        {
            RegistrationRequestModel user = (RegistrationRequestModel)FeatureContext.Current["Register User"];
            string token = IOHelper.AuthUser(user.Email, user.Password);
            UserModel userModel = IOHelper.GetUserByToken(token);
            IOHelper.DeleteUser(userModel.Id);
        }


        //[When(@"Click on the privacy policy link")]
        //public void WhenClickOnThePrivacyPolicyLink()
        //{

        //}


        // new Scenario  - click on button "Cancel"

        [When(@"Click on ""([^""]*)"" button")]
        public void WhenClickOnButton(string cancel)
        {
            var buttonCancel = _driver.FindElement(Registration_WindowXPaths.ButtonCancel);
            buttonCancel.Click();
        }

        [Then(@"The registration window should return to the Login window\.")]
        public void ThenTheRegistrationWindowShouldReturnToTheLoginWindow_()
        {
            string actual = _driver.Url;
            string expected = UrlStorage.EnterWindow;
            Assert.AreEqual(expected, actual);
        }

        // negative - test ( invalid data phone, birthday and email

        [Then(@"The system should respond, the register button will be inactive")]
        public void ThenTheSystemShouldRespondTheRegisterButtonWillBeInactive()
        {
            string birthdayExpected = "30.01.1800";
            string getAttribute = "value";
            RegistrationRequestModel user = (RegistrationRequestModel)FeatureContext.Current["Register User"];
            string inputBirthday = _driver.FindElement(Registration_WindowXPaths.DatePicker).GetAttribute(getAttribute);
            if (inputBirthday == birthdayExpected)
            {
                var textMessageBirthday = _driver.FindElement(Registration_WindowXPaths.TextMessageBirthday);
                IOHelper.CheckAuthNegative(_driver, user.Email, user.Password);
                _driver.Close();
            }
            string phoneExpected = "×óê÷à êóøàòü õî÷åò";
            if(user.Phone == phoneExpected)
            {
                string inputPhone = _driver.FindElement(Registration_WindowXPaths.InputPhone).GetAttribute(getAttribute);
                IOHelper.CheckAuthNegative(_driver, user.Email, user.Password);
                _driver.Close();
            }
            string emailExpeted = "ß email";
            if(user.Email == emailExpeted)
            {
                string inputEmail = _driver.FindElement(Registration_WindowXPaths.InputEmail).GetAttribute(getAttribute);
                IOHelper.CheckAuthNegative(_driver, user.Email, user.Password);
                _driver.Close();
            }
        }


        [Then(@"Delete users")]
        public void ThenDeleteUsers()
        {
            RegistrationRequestModel user = (RegistrationRequestModel)FeatureContext.Current["Register User"];
            string email = "ß email"; 
            if (user.Email == email)
            {
                string myEmail = "Harry2@mail.ru";
                string token = IOHelper.AuthUser(myEmail, user.Password);
                UserModel deleteUser = IOHelper.GetUserByToken(token);
                IOHelper.DeleteUser(deleteUser.Id);
            }
        }
    }
}
