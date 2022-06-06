using System;
using TechTalk.SpecFlow;

namespace DevEduEducationSystemQAA.WEB.Tests.StepDefinitions
{
    [Binding]
    public class HomeWorkWindowForAllUsersStepDefinitions
    {
        private IWebDriver _driver;

        //As I Teacher I can add HomeWork for Students of my Group

        [Given(@"I choose role Teacher for next step")]
        public void GivenIChooseRoleManagerForNextStep()
        {
            _driver = (IWebDriver)ScenarioContext.Current["Driver"];
            IWebElement changeRole = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ChangeRole);
            changeRole.Click();
            IWebElement selectRole = _driver.FindElement(HomeWorkWindowForAllUsersXPath.RoleSelection);
            selectRole.Click();
        }        

        [When(@"I fill all fields pages of create Task and click on the button Publish")]
        public void WhenIFillAllFieldsPagesOfCreateTaskAndClickOnTheButtonPublish(Table table)
        {
            ScenarioContext.Current["HomeWork"] = table.CreateSet<AddHomeWorkModel>().ToList().First();
            AddHomeWorkModel homeWork = (AddHomeWorkModel)ScenarioContext.Current["HomeWork"];             
            var buttonIssueHomeWorks = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonIssuingHomeWorks);
            buttonIssueHomeWorks.Click();
            var radioButtonForMarkGroup = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ChoiceGroup);
            radioButtonForMarkGroup.Click();
            var inputDate = _driver.FindElement(HomeWorkWindowForAllUsersXPath.DateOfIssue);
            inputDate.Click();
            Actions action = new Actions(_driver);
            action.DoubleClick(inputDate).Build().Perform();
            inputDate.SendKeys(Keys.Backspace);
            inputDate.SendKeys(homeWork.DateOfIssue);
            inputDate = _driver.FindElement(HomeWorkWindowForAllUsersXPath.Deadline);
            inputDate.Click();
            Actions newAction = new Actions(_driver);
            newAction.DoubleClick(inputDate).Build().Perform();
            inputDate.SendKeys(Keys.Backspace);
            inputDate.SendKeys(homeWork.DeliveryDate);
            var nameHomeWork = _driver.FindElement(HomeWorkWindowForAllUsersXPath.NameOfHomeWork);
            nameHomeWork.Click();
            nameHomeWork.SendKeys(homeWork.Name);
            var descriptionHomeWork = _driver.FindElement(HomeWorkWindowForAllUsersXPath.DescriptionOfHomeWork);
            descriptionHomeWork.Click();
            descriptionHomeWork.SendKeys(homeWork.Description);
            var link = _driver.FindElement(HomeWorkWindowForAllUsersXPath.Link);
            link.Click();
            link.SendKeys(homeWork.Link);
            var addLink = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonAddLink);
            addLink.Click();
            var fieldNewLink = _driver.FindElement(HomeWorkWindowForAllUsersXPath.Link);
            fieldNewLink.Click();
            fieldNewLink.SendKeys(homeWork.AddLink);
            Thread.Sleep(10000);
            var buttonPublish = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonPublish);
            buttonPublish.Click();
        }

        [Then(@"I can see new HomeWork in list HomeWorks new Groups")]
        public void ThenICanSeeNewHomeWorkInListHomeWorksNewGroups()
        {
            Thread.Sleep(100);
            var tabHomeWork = _driver.FindElement(HomeWorkWindowForAllUsersXPath.TabHomeWork);            
            tabHomeWork.Click();
            Boolean isPresent = _driver.FindElements(HomeWorkWindowForAllUsersXPath.NewHomeWorkInList).Count() > 0;
            Assert.IsTrue(isPresent);
        }

        //As I Teacher I can add unpublish Task for my Group

        [When(@"I fill all fields pages of create Task and click on the button SaveAsDraft")]
        public void WhenIFillAllFieldsPagesOfCreateTaskAndClickOnTheButtonSaveAsDraft(Table table)
        {
            ScenarioContext.Current["HomeWork"] = table.CreateSet<AddHomeWorkModel>().ToList().First();
            AddHomeWorkModel homeWork = (AddHomeWorkModel)ScenarioContext.Current["HomeWork"];            
            var buttonIssueHomeWorks = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonIssuingHomeWorks);
            buttonIssueHomeWorks.Click();
            var radioButtonForMarkGroup = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ChoiceGroup);
            radioButtonForMarkGroup.Click();
            var inputDate = _driver.FindElement(HomeWorkWindowForAllUsersXPath.DateOfIssue);
            inputDate.Click();
            Actions action = new Actions(_driver);
            action.DoubleClick(inputDate).Build().Perform();
            inputDate.SendKeys(Keys.Backspace);
            inputDate.SendKeys(homeWork.DateOfIssue);
            inputDate = _driver.FindElement(HomeWorkWindowForAllUsersXPath.Deadline);
            inputDate.Click();
            Actions newAction = new Actions(_driver);
            newAction.DoubleClick(inputDate).Build().Perform();
            inputDate.SendKeys(Keys.Backspace);
            inputDate.SendKeys(homeWork.DeliveryDate);
            var nameHomeWork = _driver.FindElement(HomeWorkWindowForAllUsersXPath.NameOfHomeWork);
            nameHomeWork.Click();
            nameHomeWork.SendKeys(homeWork.Name);
            var descriptionHomeWork = _driver.FindElement(HomeWorkWindowForAllUsersXPath.DescriptionOfHomeWork);
            descriptionHomeWork.Click();
            descriptionHomeWork.SendKeys(homeWork.Description);
            var link = _driver.FindElement(HomeWorkWindowForAllUsersXPath.Link);
            link.Click();
            link.SendKeys(homeWork.Link);
            var addLink = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonAddLink);
            addLink.Click();
            var fieldNewLink = _driver.FindElement(HomeWorkWindowForAllUsersXPath.Link);
            fieldNewLink.Click();
            fieldNewLink.SendKeys(homeWork.AddLink);
            Thread.Sleep(1000);
            var buttonSaveAsDraft = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonSaveAsDraft);
            buttonSaveAsDraft.Click();            
        }

        [Then(@"I can see new HomeWork in the list of saved homework")]
        public void ThenICanSeeNewHomeWorkInTheListOfSavedHomework()
        {
            Thread.Sleep(5000);
            var tabHomeWork = _driver.FindElement(HomeWorkWindowForAllUsersXPath.TabHomeWork);
            tabHomeWork.Click();
            var listSaveHomeWork = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonSaveAsDraft);
            listSaveHomeWork.Click();

            Boolean isPresent = _driver.FindElements(HomeWorkWindowForAllUsersXPath.NewHomeWorkInList).Count() > 0;
            Assert.IsTrue(isPresent);
        }

        //As I Teacher I can add publish HomeWork for my Group and update this HomeWork

        [Given(@"I fill all fields pages of create Task and click on the button Publish")]
        public void GivenIFillAllFieldsPagesOfCreateTaskAndClickOnTheButtonPublish(Table table)
        {
            Thread.Sleep(1000);
            ScenarioContext.Current["HomeWork"] = table.CreateSet<AddHomeWorkModel>().ToList().First();
            AddHomeWorkModel homeWork = (AddHomeWorkModel)ScenarioContext.Current["HomeWork"];

            var buttonIssueHomeWorks = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonIssuingHomeWorks);
            buttonIssueHomeWorks.Click();
            var radioButtonForMarkGroup = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ChoiceGroup);
            radioButtonForMarkGroup.Click();
            var inputDate = _driver.FindElement(HomeWorkWindowForAllUsersXPath.DateOfIssue);
            inputDate.Click();
            Actions action = new Actions(_driver);
            action.DoubleClick(inputDate).Build().Perform();
            inputDate.SendKeys(Keys.Backspace);
            inputDate.SendKeys(homeWork.DateOfIssue);
            inputDate = _driver.FindElement(HomeWorkWindowForAllUsersXPath.Deadline);
            inputDate.Click();
            Actions newAction = new Actions(_driver);
            newAction.DoubleClick(inputDate).Build().Perform();
            inputDate.SendKeys(Keys.Backspace);
            inputDate.SendKeys(homeWork.DeliveryDate);
            var nameHomeWork = _driver.FindElement(HomeWorkWindowForAllUsersXPath.NameOfHomeWork);
            nameHomeWork.Click();
            nameHomeWork.SendKeys(homeWork.Name);
            var descriptionHomeWork = _driver.FindElement(HomeWorkWindowForAllUsersXPath.DescriptionOfHomeWork);
            descriptionHomeWork.Click();
            descriptionHomeWork.SendKeys(homeWork.Description);
            var link = _driver.FindElement(HomeWorkWindowForAllUsersXPath.Link);
            link.Click();
            link.SendKeys(homeWork.Link);
            var addLink = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonAddLink);
            addLink.Click();
            var fieldNewLink = _driver.FindElement(HomeWorkWindowForAllUsersXPath.Link);
            fieldNewLink.Click();
            fieldNewLink.SendKeys(homeWork.AddLink);
            addLink = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonAddLink);
            addLink.Click();
            addLink.Click();// костыль. баг заведен
            Thread.Sleep(1000);

            var buttonPublish = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonPublish);
            buttonPublish.Click();
        }

        [When(@"I update new HomeWork")]
        public void WhenIUpdateNewHomeWork(Table table)
        {
            var tabHomeWork = _driver.FindElement(HomeWorkWindowForAllUsersXPath.TabHomeWork);
            tabHomeWork.Click();          

            var groupNameBeforeUpdate = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ChoiceGroupInListHomeworksBeforeUpdate);
            groupNameBeforeUpdate.Click();
            Thread.Sleep(5000);

            var buttonUpdateHomework = _driver.FindElement(HomeWorkWindowForAllUsersXPath.NewHomeWorkInList);
            buttonUpdateHomework.Click();

            var buttonUpdate = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonUpdateInCard);
            buttonUpdate.Click();

            ScenarioContext.Current["NewHomeWork"] = table.CreateSet<AddHomeWorkModel>().ToList().First();
            AddHomeWorkModel newHomeWork = (AddHomeWorkModel)ScenarioContext.Current["NewHomeWork"];

            AddHomeWorkModel homeWork = (AddHomeWorkModel)ScenarioContext.Current["HomeWork"];

            //изменение группы не сохран€етс€ заведен баг

            //var radioButtonForMarkGroup = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ChoiceGroupUpdate);
            //radioButtonForMarkGroup.Click();

            var dateIssueExpected = homeWork.DateOfIssue;
            var dateIssueActual = _driver.FindElement(HomeWorkWindowForAllUsersXPath.DateOfIssue).GetAttribute("value");
            Assert.AreEqual(dateIssueActual, dateIssueExpected);

            //«амену дат пока не делаю так как заведен баг на исправление дат (не сохран€етс€ ƒ« с измененными датами)

            //var inputDate = _driver.FindElement(HomeWorkWindowForAllUsersXPath.DateOfIssue);
            //inputDate.Click();
            //Actions action = new Actions(_driver);
            //action.DoubleClick(inputDate).Build().Perform();
            //inputDate.SendKeys(Keys.Backspace);
            //inputDate.SendKeys(newHomeWork.DateOfIssue);

            var dateDeadLineExpected = homeWork.DeliveryDate;
            var dateDeadLineActual = _driver.FindElement(HomeWorkWindowForAllUsersXPath.Deadline).GetAttribute("value");
            Assert.AreEqual(dateDeadLineExpected, dateDeadLineActual);

            //«амену дат пока не делаю так как заведен баг на исправление дат (не сохран€етс€ ƒ« с измененными датами)

            //inputDate = _driver.FindElement(HomeWorkWindowForAllUsersXPath.Deadline);
            //inputDate.Click();
            //Actions newAction = new Actions(_driver);
            //newAction.DoubleClick(inputDate).Build().Perform();
            //inputDate.SendKeys(Keys.Backspace);
            //inputDate.SendKeys(newHomeWork.DeliveryDate);

            var nameExpected = homeWork.Name;
            var nameActual = _driver.FindElement(HomeWorkWindowForAllUsersXPath.NameOfHomeWork).GetAttribute("value");
            Assert.AreEqual(nameExpected, nameActual);
            var nameHomeWork = _driver.FindElement(HomeWorkWindowForAllUsersXPath.NameOfHomeWork);
            nameHomeWork.Click();
            nameHomeWork.Clear();
            nameHomeWork.SendKeys(newHomeWork.Name);

            var descriptionExpected = homeWork.Description;
            var descriptionActual = _driver.FindElement(HomeWorkWindowForAllUsersXPath.DescriptionOfHomeWork).GetAttribute("value");
            Assert.AreEqual(descriptionExpected, descriptionActual);
            var descriptionHomeWork = _driver.FindElement(HomeWorkWindowForAllUsersXPath.DescriptionOfHomeWork);
            descriptionHomeWork.Click();
            descriptionHomeWork.Clear();
            descriptionHomeWork.SendKeys(newHomeWork.Description);

            var linkExpected = homeWork.Link;
            var linkActual = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ElementWithFirstSaveLink).GetAttribute("href");
            Assert.AreEqual(linkExpected, linkActual);

            var firstLink = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonDeleteFirstLink);
            firstLink.Click();

            linkExpected = homeWork.AddLink;
            linkActual = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ElementWithSecondSaveLink).GetAttribute("href");
            Assert.AreEqual(linkExpected, linkActual);

            var secondLink = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonDeleteSecondLink);
            secondLink.Click();

            var fieldNewLink = _driver.FindElement(HomeWorkWindowForAllUsersXPath.Link);
            fieldNewLink.Click();
            fieldNewLink.SendKeys(newHomeWork.Link);

            var buttonAddLink = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonAddLink);
            buttonAddLink.Click();

            fieldNewLink = _driver.FindElement(HomeWorkWindowForAllUsersXPath.Link);
            fieldNewLink.Click();
            fieldNewLink.SendKeys(newHomeWork.AddLink);

            var addLink = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonAddLink);
            addLink.Click();

            var buttonSave = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonSaveAfterUpdate);
            buttonSave.Click();
            Thread.Sleep(1500);
        }

        // остановилась тут значит данные измененные не сохранились.¬вести вручную через базу, продолжить писать сравнение измененного дз с заданными пол€ми
        [Then(@"I can see new HomeWork with new field in list HomeWorks new Groups")]
        public void ThenICanSeeNewHomeWorkWithNewFieldInListHomeWorksNewGroups()
        {
            var tabHomeWork = _driver.FindElement(HomeWorkWindowForAllUsersXPath.TabHomeWork);
            tabHomeWork.Click();

            //выбор группы Frontend, потом после исправлени€ бага заменить на Ѕэкенд
            var groupNameBeforeUpdate = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ChoiceGroupInListHomeworksBeforeUpdate);
            groupNameBeforeUpdate.Click();
            Thread.Sleep(5000);

            var buttonUpdateHomework = _driver.FindElement(HomeWorkWindowForAllUsersXPath.UpdatedHomeWorkInList);
            buttonUpdateHomework.Click();

            AddHomeWorkModel newHomeWork = (AddHomeWorkModel)ScenarioContext.Current["NewHomeWork"];
            var expectedDateOfIssue = newHomeWork.DateOfIssue;
            var actualDateOfIssue = _driver.FindElement(HomeWorkWindowForAllUsersXPath.DateOfIssueInCardOfHomeWork).Text;
            //Assert.AreEqual(expectedDateOfIssue, actualDateOfIssue);

            var expectedDateOfDeadline = newHomeWork.DeliveryDate;
            var actualDateOfDeadline = _driver.FindElement(HomeWorkWindowForAllUsersXPath.DateOfIssueInCardOfHomeWork).Text;
            //Assert.AreEqual(expectedDateOfDeadline, actualDateOfDeadline);

            var expectedDescription = newHomeWork.Description;
            var actualDescription = _driver.FindElement(HomeWorkWindowForAllUsersXPath.DescriptionInCard).Text;
            Assert.AreEqual(expectedDescription, actualDescription);

            List<string> listExpectedHrefs = new List<string>();
            listExpectedHrefs.Add(newHomeWork.Link);
            listExpectedHrefs.Add(newHomeWork.AddLink);

            List<IWebElement> listActualHrefs = new List<IWebElement>();
            listActualHrefs = _driver.FindElements(HomeWorkWindowForAllUsersXPath.ListAllLinksInCardHomeWorks).ToList();
            foreach (IWebElement href in listActualHrefs)
            {
                Assert.IsTrue(listExpectedHrefs.Contains(href.Text));
            }
        }

        // As I Teacher I can delete publish HomeWork

        [Given(@"I go to the task card and click the edit button")]
        public void GivenIGoToTheTaskCardAndClickTheEditButton()
        {
            var tabHomeWork = _driver.FindElement(HomeWorkWindowForAllUsersXPath.TabHomeWork);
            tabHomeWork.Click();

            var groupNameBeforeUpdate = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ChoiceGroupInListHomeworksBeforeUpdate);
            groupNameBeforeUpdate.Click();
            Thread.Sleep(5000);

            var buttonUpdateHomework = _driver.FindElement(HomeWorkWindowForAllUsersXPath.NewHomeWorkInList);
            buttonUpdateHomework.Click();

            var buttonUpdate = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonUpdateInCard);
            buttonUpdate.Click();
        }

        [When(@"In card of HomeWork I click in Button Delete task")]
        public void WhenInCardOfHomeWorkIClickInButtonDeleteTask()
        {
            var buttonDeleteTask = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonDeleteTask);
            buttonDeleteTask.Click();           

            var buttonAcceptDelete = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonAccepteDeleteInPopUpWindowAfterClickDeleteTask);
            buttonAcceptDelete.Click();
        }

        [Then(@"I can see message about HomeWork is Deleted")]
        public void ThenICanSeeMessageAboutHomeWorkIsDeleted()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            IWebElement windowAcceptDelete = wait.Until(e => e.FindElement(HomeWorkWindowForAllUsersXPath.WindowsWithMessageAboutOnSuccessfulRemoval));
            Assert.IsNotNull(windowAcceptDelete);

            var buttonOKInWindowsWithMessage = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonOKInWindowsWithMessage);
            buttonOKInWindowsWithMessage.Click();
        }

        [Then(@"I don't can see HomeWork in list HomeWorks of Groups")]
        public void ThenIDontCanSeeHomeWorkInListHomeWorksOfGroups()
        {
            var buttonHomeWorks = _driver.FindElement(HomeWorkWindowForAllUsersXPath.TabHomeWork);
            buttonHomeWorks.Click();

            var groupNameBeforeUpdate = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ChoiceGroupInListHomeworksBeforeUpdate);
            groupNameBeforeUpdate.Click();

            AddHomeWorkModel homeWork = (AddHomeWorkModel)ScenarioContext.Current["HomeWork"];

            var listAllTasks = _driver.FindElements(HomeWorkWindowForAllUsersXPath.ListAllHomeworks).ToList();

            foreach (IWebElement nameOfTask in listAllTasks)
            {
                Assert.AreNotEqual(homeWork.Name, nameOfTask.Text);
            }
        }

        //As I Teacher I can cancel delete publish HomeWork after moment then I click in button delete

        [When(@"In card of HomeWork I click in Button cancel Delete task")]
        public void WhenInCardOfHomeWorkIClickInButtonCancelDeleteTask()
        {
            var buttonDeleteTask = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonDeleteTask);
            buttonDeleteTask.Click();

            var buttonCancelDelete = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonCancelDeleteInPopUpWindowAfterClickDeleteTask);
            buttonCancelDelete.Click();
            Thread.Sleep(1000);

        }

        [Then(@"I can see new HomeWork in list HomeWorks of Groups")]
        public void ThenICanSeeNewHomeWorkInListHomeWorksOfGroups()
        {
            var buttonHomeWorks = _driver.FindElement(HomeWorkWindowForAllUsersXPath.TabHomeWork);
            buttonHomeWorks.Click();

            var groupNameBeforeUpdate = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ChoiceGroupInListHomeworksBeforeUpdate);
            groupNameBeforeUpdate.Click();

            AddHomeWorkModel homeWork = (AddHomeWorkModel)ScenarioContext.Current["HomeWork"];

            var listAllTasks = _driver.FindElements(HomeWorkWindowForAllUsersXPath.ListAllHomeworks).ToList();

            foreach (IWebElement nameOfTask in listAllTasks)
            {
                Assert.AreEqual(homeWork.Name, nameOfTask.Text);
            }
        }
    }
}
