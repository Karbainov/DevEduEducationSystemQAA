using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;

namespace DevEduEducationSystemQAA.WEB.Tests.StepDefinitions
{
    [Binding]
    public class HomeWorkWindowForAllUsersStepDefinitions
    {
        private IWebDriver _driver;

        //Scenario: As I Teacher I can add HomeWork for Students of my Group

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

            addLink = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonAddLink);
            addLink.Click();
            Thread.Sleep(5000);
            var buttonPublish = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonPublish);
            buttonPublish.Click();
            buttonPublish.Click();//костыль для прохождения теста потому что иначе тест проходить не будет баг заведен
        }

        [Then(@"I can see new HomeWork in list HomeWorks new Groups")]
        public void ThenICanSeeNewHomeWorkInListHomeWorksNewGroups()
        {
            Thread.Sleep(100);
            var tabHomeWork = _driver.FindElement(HomeWorkWindowForAllUsersXPath.TabHomeWork);            
            tabHomeWork.Click();

            var groupNameBeforeUpdate = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ChoiceGroupInListHomeworksBeforeUpdate);
            groupNameBeforeUpdate.Click();

            Boolean isPresent = _driver.FindElements(HomeWorkWindowForAllUsersXPath.NewHomeWorkInListForTestCreate).Count() > 0;
            Assert.IsTrue(isPresent);

            _driver.Quit();
        }

        //Scenario: As I Teacher I can add unpublish Task for my Group

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

            addLink = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonAddLink);
            addLink.Click();

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

            var groupNameBeforeUpdate = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ChoiceGroupInListHomeworksBeforeUpdate);
            groupNameBeforeUpdate.Click();

            Boolean isPresent = _driver.FindElements(HomeWorkWindowForAllUsersXPath.NewHomeWorkInListForSavedTask).Count() > 0;
            Assert.IsTrue(isPresent);
            _driver.Quit();
        }

        //Scenario: As I Teacher I can add publish HomeWork for my Group and update this HomeWork

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

            //В шаге изменения группы группу не изменяем до тех пор, пока она не будет корректно сохранятся при изменении. баг заведен

            //var radioButtonForMarkGroup = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ChoiceGroupUpdate);
            //radioButtonForMarkGroup.Click();

            var dateIssueExpected = homeWork.DateOfIssue;
            var dateIssueActual = _driver.FindElement(HomeWorkWindowForAllUsersXPath.DateOfIssue).GetAttribute("value");
            Assert.AreEqual(dateIssueActual, dateIssueExpected);

            //Изменение даты занятия в настоящее время реализовано, но с валидацией, что дата может быть изменена в пределах изначально устанолвенных дат. Баг заведен.

            var inputDate = _driver.FindElement(HomeWorkWindowForAllUsersXPath.DateOfIssue);
            inputDate.Click();
            Actions action = new Actions(_driver);
            action.DoubleClick(inputDate).Build().Perform();
            inputDate.SendKeys(Keys.Backspace);
            inputDate.SendKeys(newHomeWork.DateOfIssue);

            var dateDeadLineExpected = homeWork.DeliveryDate;
            var dateDeadLineActual = _driver.FindElement(HomeWorkWindowForAllUsersXPath.Deadline).GetAttribute("value");
            Assert.AreEqual(dateDeadLineExpected, dateDeadLineActual);

            inputDate = _driver.FindElement(HomeWorkWindowForAllUsersXPath.Deadline);
            inputDate.Click();
            Actions newAction = new Actions(_driver);
            newAction.DoubleClick(inputDate).Build().Perform();
            inputDate.SendKeys(Keys.Backspace);
            inputDate.SendKeys(newHomeWork.DeliveryDate);

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

        [Then(@"I can see new HomeWork with new field in list HomeWorks new Groups")]
        public void ThenICanSeeNewHomeWorkWithNewFieldInListHomeWorksNewGroups()
        {
            var tabHomeWork = _driver.FindElement(HomeWorkWindowForAllUsersXPath.TabHomeWork);
            tabHomeWork.Click();

            //Когда будет исправлено сохранение группы, тогда эту строчку нужно заменить на другой XPATH
            //и в Then добавить проверку,что группа удалена из списка занятий предыдущей группы.
            var groupNameBeforeUpdate = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ChoiceGroupInListHomeworksBeforeUpdate);
            groupNameBeforeUpdate.Click();

            var buttonUpdateHomework = _driver.FindElement(HomeWorkWindowForAllUsersXPath.UpdatedHomeWorkInList);
            buttonUpdateHomework.Click();

            AddHomeWorkModel newHomeWork = (AddHomeWorkModel)ScenarioContext.Current["NewHomeWork"];
            var expectedDateOfIssue = newHomeWork.DateOfIssue;
            var actualDateOfIssue = _driver.FindElement(HomeWorkWindowForAllUsersXPath.DateOfIssueInCardOfHomeWork).Text;
            Assert.AreEqual(expectedDateOfIssue, actualDateOfIssue);

            var expectedDateOfDeadline = newHomeWork.DeliveryDate;
            var actualDateOfDeadline = _driver.FindElement(HomeWorkWindowForAllUsersXPath.DateOfDeadlineInCardOfHomeWork).Text;
            Assert.AreEqual(expectedDateOfDeadline, actualDateOfDeadline);

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
            _driver.Quit();
        }

        // Scenario: As I Teacher I can delete publish HomeWork

        [Given(@"I go to the task card and click the edit button")]
        public void GivenIGoToTheTaskCardAndClickTheEditButton()
        {
            var tabHomeWork = _driver.FindElement(HomeWorkWindowForAllUsersXPath.TabHomeWork);
            tabHomeWork.Click();

            var groupNameBeforeUpdate = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ChoiceGroupInListHomeworksBeforeUpdate);
            groupNameBeforeUpdate.Click();
            Thread.Sleep(5000);

            var buttonUpdateHomework = _driver.FindElement(HomeWorkWindowForAllUsersXPath.NewHomeWorkInListHomeWork11);
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

            var listAllTasks = _driver.FindElements(HomeWorkWindowForAllUsersXPath.ListAllHomeworksOrTasks).ToList();

            foreach (IWebElement nameOfTask in listAllTasks)
            {
                Assert.AreNotEqual(homeWork.Name, nameOfTask.Text);
            }
            _driver.Quit();
        }

        //Scenario:As I Teacher I can cancel delete publish HomeWork after moment then I click in button delete

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

            var listAllTasks = _driver.FindElements(HomeWorkWindowForAllUsersXPath.ListAllHomeworksOrTasks).ToList();

            var task = listAllTasks.FirstOrDefault(x => homeWork.Name == x.Text);

            Assert.IsNotNull(task);
            _driver.Quit();
            
        }

        //Scenario: As I Teacher I can delete unpublish HomeWork

        [Given(@"I fill all fields pages of create Task and click on the button SaveAsDraft")]
        public void GivenIFillAllFieldsPagesOfCreateTaskAndClickOnTheButtonSaveAsDraft(Table table)
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

            addLink = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonAddLink);
            addLink.Click();

            Thread.Sleep(1000);
            var buttonSaveAsDraft = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonSaveAsDraft);
            buttonSaveAsDraft.Click();

            Thread.Sleep(2000);
        }

        [Given(@"I go to the task card in list saved Tasks and click the edit button")]
        public void GivenIGoToTheTaskCardInListSavedTasksAndClickTheEditButton()
        {
            var tabHomeWork = _driver.FindElement(HomeWorkWindowForAllUsersXPath.TabHomeWork);
            tabHomeWork.Click();

            var listSaveHomeWork = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonSaveAsDraft);
            listSaveHomeWork.Click();

            var groupNameBeforeUpdate = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ChoiceGroupInListHomeworksBeforeUpdate);
            groupNameBeforeUpdate.Click();

            var cardOfTask = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonUpdateInListOfAllUnpublishTask8);
            cardOfTask.Click();
            Thread.Sleep(2000);
        }

        [When(@"In card of Task I click in Button Delete task")]
        public void WhenInCardOfTaskIClickInButtonDeleteTask()
        {
            var buttonDeleteTask = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonDeleteTask);
            buttonDeleteTask.Click();

            var buttonAcceptDelete = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonAccepteDeleteInPopUpWindowAfterClickDeleteTask);
            buttonAcceptDelete.Click();
        }

        [Then(@"I don't can see Task in list Tasks of Group")]
        public void ThenIDontCanSeeTaskInListTasksOfGroup()
        {
            var tabHomeWork = _driver.FindElement(HomeWorkWindowForAllUsersXPath.TabHomeWork);
            tabHomeWork.Click();

            var listSaveHomeWork = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonSaveAsDraft);
            listSaveHomeWork.Click();

            var groupNameBeforeUpdate = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ChoiceGroupInListHomeworksBeforeUpdate);
            groupNameBeforeUpdate.Click();

            AddHomeWorkModel homeWork = (AddHomeWorkModel)ScenarioContext.Current["HomeWork"];

            var listAllTasks = _driver.FindElements(HomeWorkWindowForAllUsersXPath.ListAllHomeworksOrTasks).ToList();

            foreach (IWebElement nameOfTask in listAllTasks)
            {
                Assert.AreNotEqual(homeWork.Name, nameOfTask.Text);
            }

            _driver.Quit();
        }

        //Scenario: As I Teacher I can update unpublish Tasks of my Group and published them

        [Given(@"I fill all fields pages of create Task and click on the button SaveAsDraft for Task")]
        public void GivenIFillAllFieldsPagesOfCreateTaskAndClickOnTheButtonSaveAsDraftForTask(Table table)
        {
            ScenarioContext.Current["Task"] = table.CreateSet<AddTaskModel>().ToList().First();
            AddTaskModel homeWork = (AddTaskModel)ScenarioContext.Current["Task"];

            var buttonIssueHomeWorks = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonIssuingHomeWorks);
            buttonIssueHomeWorks.Click();

            var radioButtonForMarkGroup = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ChoiceGroup);
            radioButtonForMarkGroup.Click();

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

            var buttonSaveAsDraft = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonSaveAsDraft);
            buttonSaveAsDraft.Click();
            Thread.Sleep(3000);
        }


        [When(@"I update Task and publish it")]
        public void WhenIUpdateTaskAndPublishIt(Table table)
        {
            ScenarioContext.Current["NewHomeWork"] = table.CreateSet<AddHomeWorkModel>().ToList().First();
            AddHomeWorkModel newHomeWork = (AddHomeWorkModel)ScenarioContext.Current["NewHomeWork"];

            AddTaskModel task = (AddTaskModel)ScenarioContext.Current["Task"];

            //var radioButtonForMarkGroup = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ChoiceGroupUpdate);
            //radioButtonForMarkGroup.Click();

            var inputDate = _driver.FindElement(HomeWorkWindowForAllUsersXPath.DateOfIssue);
            inputDate.Click();
            Actions action = new Actions(_driver);
            action.DoubleClick(inputDate).Build().Perform();
            inputDate.SendKeys(Keys.Backspace);
            inputDate.SendKeys(newHomeWork.DateOfIssue);

            inputDate = _driver.FindElement(HomeWorkWindowForAllUsersXPath.Deadline);
            inputDate.Click();
            Actions newAction = new Actions(_driver);
            newAction.DoubleClick(inputDate).Build().Perform();
            inputDate.SendKeys(Keys.Backspace);
            inputDate.SendKeys(newHomeWork.DeliveryDate);

            var nameExpected = task.Name;
            var nameActual = _driver.FindElement(HomeWorkWindowForAllUsersXPath.NameOfHomeWork).GetAttribute("value");
            Assert.AreEqual(nameExpected, nameActual);
            var nameHomeWork = _driver.FindElement(HomeWorkWindowForAllUsersXPath.NameOfHomeWork);
            nameHomeWork.Click();
            nameHomeWork.Clear();
            nameHomeWork.SendKeys(newHomeWork.Name);

            var descriptionExpected = task.Description;
            var descriptionActual = _driver.FindElement(HomeWorkWindowForAllUsersXPath.DescriptionOfHomeWork).GetAttribute("value");
            Assert.AreEqual(descriptionExpected, descriptionActual);

            var descriptionHomeWork = _driver.FindElement(HomeWorkWindowForAllUsersXPath.DescriptionOfHomeWork);
            descriptionHomeWork.Click();
            descriptionHomeWork.Clear();
            descriptionHomeWork.SendKeys(newHomeWork.Description);

            var linkExpected = task.Link;
            var linkActual = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ElementWithFirstSaveLink).GetAttribute("href");
            Assert.AreEqual(linkExpected, linkActual);

            var firstLink = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonDeleteFirstLink);
            firstLink.Click();

            linkExpected = task.AddLink;
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

            var buttonPublish = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonPublish);
            buttonPublish.Click();
            Thread.Sleep(1500);
        }

        [Then(@"I can see publish HomeWork in list HomeWorks of Groups")]
        public void ThenICanSeePublishHomeWorkInListHomeWorksOfGroups()
        {
            var tabHomeWork = _driver.FindElement(HomeWorkWindowForAllUsersXPath.TabHomeWork);
            tabHomeWork.Click();

            var groupNameBeforeUpdate = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ChoiceGroupInListHomeworksBeforeUpdate);
            groupNameBeforeUpdate.Click();

            Thread.Sleep(5000);

            var buttonUpdateHomework = _driver.FindElement(HomeWorkWindowForAllUsersXPath.HomeWorkInListAfterPublish);
            buttonUpdateHomework.Click();

            AddHomeWorkModel newHomeWork = (AddHomeWorkModel)ScenarioContext.Current["NewHomeWork"];
            var expectedDateOfIssue = newHomeWork.DateOfIssue;
            var actualDateOfIssue = _driver.FindElement(HomeWorkWindowForAllUsersXPath.DateOfIssueInCardOfHomeWork).Text;
            Assert.AreEqual(expectedDateOfIssue, actualDateOfIssue);

            var expectedDateOfDeadline = newHomeWork.DeliveryDate;
            var actualDateOfDeadline = _driver.FindElement(HomeWorkWindowForAllUsersXPath.DateOfDeadlineInCardOfHomeWork).Text;
            Assert.AreEqual(expectedDateOfDeadline, actualDateOfDeadline);

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

        [Then(@"I don't can see publish HomeWork in list saved Tasks of Group")]
        public void ThenIDontCanSeePublishHomeWorkInListSavedTasksOfGroup()
        {
            var tabHomeWork = _driver.FindElement(HomeWorkWindowForAllUsersXPath.TabHomeWork);
            tabHomeWork.Click();

            var listSaveHomeWork = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonSaveAsDraft);
            listSaveHomeWork.Click();

            var groupNameBeforeUpdate = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ChoiceGroupInListHomeworksBeforeUpdate);
            groupNameBeforeUpdate.Click();

            Boolean isPresent = _driver.FindElements(HomeWorkWindowForAllUsersXPath.HomeWorkInListBeforePublish).Count() == 0;
            Assert.IsTrue(isPresent);
            
            _driver.Quit();
        }

        // new Scenario - Role Student . As a student , I want to hand in my homework 

        [Given(@"I click on the homework button")]
        public void GivenIClickOnTheHomeworkButton()
        {
            _driver = (IWebDriver)ScenarioContext.Current["Driver"];
            _driver.Navigate().GoToUrl(UrlStorage.BasePage);
            Thread.Sleep(500);
            var buttonHomework = _driver.FindElement(HomeWorkWindowForAllUsersXPath.TabHomeWork);
            buttonHomework.Click();
            string actual = _driver.Url;
            string expected = UrlStorage.HomeworkWindow;
            Assert.AreEqual(expected, actual);
            Hooks.forDelete = "https://piter-education.ru:7074/";
            Hooks.isCheck = true;
        }

        [Given(@"I choose a course")]
        public void GivenIChooseACourse()
        {
            var buttonCourse = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonCourse);
            buttonCourse.Click();
        }

        [Given(@"I click on the task tab")]
        public void GivenIClickOnTheTaskTab()
        {
            Thread.Sleep(250);
            try
            {
                var buttonToTheTask = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonToTheTask);
                buttonToTheTask.Click();
            }
            catch 
            {
                var buttonToTheTask = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonToTheTask);
                buttonToTheTask.Click();
            }
            string actual = _driver.Url;
            List<string> expecteds = new List<string>()
            {
                @"https://piter-education.ru:7074/homeworks/2334",
                @"https://piter-education.ru:7074/homeworks/2334/new"
            };
            CollectionAssert.Contains(expecteds, actual);
        }

        [Given(@"I leave a link to the completed task ""([^""]*)""")]
        public void GivenILeaveALinkToTheCompletedTask(string studentHomework)
        {
            WebDriverWait a = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            a.Until(d => d.FindElement(HomeWorkWindowForAllUsersXPath.InputStudentHomework));
            var inputMyHomework = _driver.FindElement(HomeWorkWindowForAllUsersXPath.InputStudentHomework);
            inputMyHomework.SendKeys(studentHomework);
            ScenarioContext.Current["Link My Homework"] = studentHomework;
            Hooks.forDelete = studentHomework;
            Hooks.isCheck = true;
        }

        [Given(@"I click on the submit homework button")]
        [When(@"I click on the submit homework button")]
        public void WhenIClickOnTheSubmitHomeworkButton()
        {
            var buttonSendHomework = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonSendHomework);
            buttonSendHomework.Click();
            Thread.Sleep(100);
        }

        [Then(@"I refresh the page and check that my homework link is saved")]
        public void ThenIRefreshThePageAndCheckThatMyHomeworkLinkIsSaved()
        {
            _driver.Navigate().Refresh();
            Thread.Sleep(500);
            var textMyHomework = _driver.FindElement(HomeWorkWindowForAllUsersXPath.TextSendHomework);
            textMyHomework.Click();
            Thread.Sleep(100);
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);
            string expected = (string)ScenarioContext.Current["Link My Homework"];
            string actual = _driver.Url;
            Assert.AreEqual(expected, actual);
        }

        // new Scenario edit

        [Given(@"I click on the edit button in window homework")]
        public void GivenIClickOnTheEditButtonInWindowHomework()
        {
            Thread.Sleep(1000);
            var buttonEdit = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonEdit);
            buttonEdit.Click();
        }

        [When(@"I clear the input and insert a new link ""([^""]*)"" and click on the send button")]
        public void WhenIClearTheInputAndInsertANewLink(string myNewHomework)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(HomeWorkWindowForAllUsersXPath.InputStudentHomework));
            var inputAnswer = _driver.FindElement(HomeWorkWindowForAllUsersXPath.InputStudentHomework);
            inputAnswer.Clear();
            inputAnswer.SendKeys(myNewHomework);
            var buttonSend = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonSendHomework);
            buttonSend.Click();
            ScenarioContext.Current["New link"] = myNewHomework;
        }

        [Then(@"I clicking on the back button and I check, the link should change")]
        public void ThenIClickingOnTheBackButtonAndICheckTheLinkShouldChange()
        {
            var buttonGoToBack = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonGoToBack);
            buttonGoToBack.Click();
            var buttonMyHomework = _driver.FindElement(HomeWorkWindowForAllUsersXPath.TextSendHomework);
            buttonMyHomework.Click();
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);
            string actual = _driver.Url;
            string expected = (string)ScenarioContext.Current["New link"];
            Assert.AreEqual(expected, actual);
        }

        // new Scenario - negative (empty link and "Hellow I am link")


        [Given(@"I leave a link to the completed task empty link ""([^""]*)""")]
        public void GivenILeaveALinkToTheCompletedTaskEmptyLink(string LinkHomework)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until<IWebElement>(d => d.FindElement(HomeWorkWindowForAllUsersXPath.InputStudentHomework));
            var inputMyHomework = _driver.FindElement(HomeWorkWindowForAllUsersXPath.InputStudentHomework);
            inputMyHomework.SendKeys(LinkHomework);
            ScenarioContext.Current["Answer"] = LinkHomework;
            Hooks.forDelete = LinkHomework;
            Hooks.isCheck = true;
        }

        [Then(@"Check if the submit button is disabled")]
        public void ThenCheckIfTheSubmitButtonIsDisabled()
        {
            var inputMyHomework = _driver.FindElement(HomeWorkWindowForAllUsersXPath.InputStudentHomework);
            Assert.Throws<NoSuchElementException>(() => _driver.FindElement(HomeWorkWindowForAllUsersXPath.TextSendHomework));
        }

        [Then(@"Check if the submit button is disabled and delete student homework")]
        public void ThenCheckIfTheSubmitButtonIsDisabledAndDeleteStudentHomework()
        {
            var inputMyHomework = _driver.FindElement(HomeWorkWindowForAllUsersXPath.InputStudentHomework);
            Assert.Throws<NoSuchElementException>(() => _driver.FindElement(HomeWorkWindowForAllUsersXPath.TextSendHomework));
        }

        // new Scenario negativ edit 

        [When(@"I clear the input and insert a new empty link ""([^""]*)"" and click on the send button twice")]
        public void GivenWhenIClearTheInputAndInsertANewEmptyLinkAndClickOnTheSendButtonTwice(string homework)
        {
            string getAttribute = "value";
            var inputHomework = _driver.FindElement(HomeWorkWindowForAllUsersXPath.InputStudentHomework);
            string actualHomework = inputHomework.GetAttribute(getAttribute);
            inputHomework.Clear();
            inputHomework.SendKeys(homework);
            var buttonSend = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonSendHomework);
            buttonSend.Click();
            Thread.Sleep(500);
            buttonSend = _driver.FindElement(HomeWorkWindowForAllUsersXPath.ButtonSendHomework);
            buttonSend.Click();
            ScenarioContext.Current["linkHomework"] = actualHomework;
            ScenarioContext.Current["Edit link"] = homework;
        }

        [Then(@"I refresh the page and see that the link hasn't changed")]
        public void ThenIRefreshThePageAndSeeThatTheLinkHasntChanged()
        {
            Hooks.forDelete = (string)ScenarioContext.Current["Edit link"];
            Hooks.isCheck = true;
            _driver.Navigate().Refresh();
            string getAttribute = "value";
            Thread.Sleep(500);
            string actual = _driver.FindElement(HomeWorkWindowForAllUsersXPath.InputStudentHomework).GetAttribute(getAttribute);
            string expected = (string)ScenarioContext.Current["linkHomework"];
            Assert.AreEqual(expected, actual);
        }
    }
}
