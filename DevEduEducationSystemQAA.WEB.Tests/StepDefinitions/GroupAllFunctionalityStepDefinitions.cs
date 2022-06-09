using DevEduEducationSystemQAA.WEB.Tests.Support.ViewModels;
using System.Drawing;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace DevEduEducationSystemQAA.WEB.Tests.StepDefinitions
{
    [Binding]
    public class GroupAllFunctionalityStepDefinitions
    {
        private IWebDriver _driver;

        [Given(@"I open Google Chrome browser")]
        public void GivenIOpenGoogleChromeBrowser()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
            _driver = new ChromeDriver(chromeOptions);            
            _driver.Navigate().GoToUrl(UrlStorage.EnterWindow);
            _driver.Manage().Window.Position = new Point(0, 0);
            _driver.Manage().Window.Maximize();
            //((IJavaScriptExecutor)_driver).ExecuteScript("document.body.style.zoom='70%'");
            //Thread.Sleep(3000);
            //неявное ожидание
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);           
        }

        [Given(@"I login as an manager and enter in my account")]
        public void GivenILoginAsAnManagerAndEnterInMyAccount()
        {  
            LoginRequestModel adminEnterRequestModel = new LoginRequestModel()
            {
                Email = "PopovAS@example.com",
                Password = "Qwerty123"
            };
            IWebElement inputLogin = _driver.FindElement(Enter_WindowXPaths.InputLogin);
            inputLogin.SendKeys(adminEnterRequestModel.Email);
            IWebElement inputPassword = _driver.FindElement(Enter_WindowXPaths.InputPassword);
            inputPassword.Clear();
            inputPassword.SendKeys(adminEnterRequestModel.Password);
            IWebElement authUser = _driver.FindElement(Enter_WindowXPaths.ButtonEnter);
            authUser.Click();
            _driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 0, 3, 0);
            ScenarioContext.Current["Driver"] = _driver;
        }


        [When(@"I click on the button Exit")]
        public void WhenIClickOnTheButtonExit()
        {
            IWebElement exitFromAccount = _driver.FindElement(GroupAllFunctionalityXPath.ButtonExit);
            exitFromAccount.Click();
        }

        [Then(@"I go to the login tab")]
        public void ThenIGoToTheLoginTab()
        {
            string expected = UrlStorage.EnterWindow;
            string actual = _driver.Url;
            Assert.AreEqual(expected, actual);
            _driver.Quit();
        }

        [When(@"I fill in the fields pages of create group and click on the button Cancel")]
        public void WhenIFillInTheFieldsPagesOfCreateGroupAndClickOnTheButtonCancel(Table table)
        {
            List<string> names = table.Rows[0]["Name"]
                 .Split(',')
                 .Select(str => Convert.ToString(str))
                 .ToList();
            string name = names[0];
            IWebElement enterInCreateGroup = _driver.FindElement(GroupAllFunctionalityXPath.PageCreateGroupe);
            enterInCreateGroup.Click();           
            IWebElement inputName = _driver.FindElement(GroupAllFunctionalityXPath.InputName);
            inputName.SendKeys(name);
            IWebElement choiceCourse = _driver.FindElement(GroupAllFunctionalityXPath.DropDownCourse);
            choiceCourse.Click();
            IWebElement selectCourse = _driver.FindElement(GroupAllFunctionalityXPath.СhooseACourse);
            selectCourse.Click();
            _driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 0, 3, 0);
            //выбрать препода половина ширины элемента+ 10 пксл
            By SearchTeacher = By.XPath("//span[text()='Антон Ефременков']");
            IWebElement teacher = _driver.FindElement(SearchTeacher);
            Actions action = new Actions(_driver);
            action.MoveToElement(teacher).MoveByOffset(-teacher.Size.Width / 2 - 8, 0).Click().Build().Perform();
            Thread.Sleep(1000);
            By SearchTutor = By.XPath("//span[text()='Макар Океанов']");
            IWebElement tutor = _driver.FindElement(SearchTutor);
            Actions actionFindTutor = new Actions(_driver);
            actionFindTutor.MoveToElement(tutor).MoveByOffset(-tutor.Size.Width / 2 - 8, 0).Click().Build().Perform();
            IWebElement cancelAction = _driver.FindElement(GroupAllFunctionalityXPath.ButtonCancel);
            cancelAction.Click();
        }

        [Then(@"I go to the notifications tab")]
        public void ThenIGoToTheNotificationsTab()
        {
            string expected = UrlStorage.BasePage;
            string actual = _driver.Url;
            Assert.AreEqual(expected, actual);
            _driver.Quit();
        }

        [When(@"I fill all fields pages of create group <Name> and click on the button Save")]
        public void WhenIFillAllFieldsPagesOfCreateGroupNameAndClickOnTheButtonSave(Table table)
        {
            List<string> names = table.Rows[0]["Name"]
                .Split(',')
                .Select(str => Convert.ToString(str))
                .ToList();
            string name = names[0];
            IWebElement enterInCreateGroup = _driver.FindElement(GroupAllFunctionalityXPath.PageCreateGroupe);
            enterInCreateGroup.Click();
            IWebElement inputName = _driver.FindElement(GroupAllFunctionalityXPath.InputName);
            inputName.SendKeys(name);
            IWebElement choiceCourse = _driver.FindElement(GroupAllFunctionalityXPath.DropDownCourse);
            choiceCourse.Click();
            IWebElement selectCourse = _driver.FindElement(GroupAllFunctionalityXPath.СhooseACourse);
            selectCourse.Click();
            _driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 0, 3, 0);
            //выбрать препода половина ширины элемента+ 10 пксл
            By SearchTeacher = By.XPath("//span[text()='Антон Ефременков']");
            IWebElement teacher = _driver.FindElement(SearchTeacher);
            Actions action = new Actions(_driver);
            action.MoveToElement(teacher).MoveByOffset(-teacher.Size.Width / 2 - 8, 0).Click().Build().Perform();
            Thread.Sleep(1000);
            By SearchTutor = By.XPath("//span[@class = 'custom-checkbox-text' and text() = 'Макар Океанов']");
            IWebElement tutor = _driver.FindElement(SearchTutor);
            Actions actionFindTutor = new Actions(_driver);
            actionFindTutor.MoveToElement(tutor).MoveByOffset(-tutor.Size.Width / 2 - 8, 0).Click().Build().Perform();
            IWebElement saveDate = _driver.FindElement(GroupAllFunctionalityXPath.ButtonSave);
            saveDate.Click();
        }

        [Then(@"I can see new group in the list all groups")]
        public void ThenICanSeeNewGroupInTheListAllGroups()
        {
            //ищем вкладку "группы" переходим на нее
            //ищем элемент, содержащий XPath с названием нашей группы по тексту
            //проверяем что поля равны тем,которые мы передали при создании
            _driver.Quit();
        }

        [When(@"I can add students in Group")]
        public void WhenICanAddStudentsInGroup()
        {
            throw new PendingStepException();
        }

    }
}
