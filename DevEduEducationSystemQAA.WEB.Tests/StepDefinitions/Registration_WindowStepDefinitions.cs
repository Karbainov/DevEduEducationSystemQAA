using DevEduEducationSystemQAA.WEB.Tests.Support;
using DevEduEducationSystemQAA.WEB.Tests.Support.Models;
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

        [Given(@"I enter the registration window")]
        public void GivenIEnterTheRegistrationWindow() // можно передавать размеры экрана
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(UrlStorage.RegistrationWindow);
            _driver.Manage().Window.Position = new Point(0,0);
            _driver.Manage().Window.Size = new Size(1024,768);
        }


        [Given(@"I am a user fill in all required fields")]
        public void GivenIAmAUserFillInAllRequiredFields(Table table)
        {
            RegistrationRequestModel user = table.CreateSet<RegistrationRequestModel>().ToList().First();
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
            var checkBox = _driver.FindElement(Registration_WindowXPaths.ChecBoxPrivacyPolicy);
            
            // этот кусок кода имитирует мышку, но что то не работает
            Actions build = new Actions(_driver);
            build.MoveToElement(checkBox).MoveByOffset(0,-5).Click().Build().Perform();

        }

        //[Given(@"Click checkbox on the privacy policy")]
        //public void GivenClickCheckboxOnThePrivacyPolicy()
        //{
            
        //}

        //[When(@"Click on the privacy policy link")]
        //public void WhenClickOnThePrivacyPolicyLink()
        //{
            
        //}

        //[When(@"Click on register button")]
        //public void WhenClickOnRegisterButton()
        //{
            
        //}
    }
}
