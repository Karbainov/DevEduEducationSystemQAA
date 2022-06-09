using DevEduEducationSystemQAA.WEB.Tests.Support.MockListStudent;
using System;
using TechTalk.SpecFlow;

namespace DevEduEducationSystemQAA.WEB.Tests.StepDefinitions
{
    [Binding]
    public class Journal_WindowStepDefinitions
    {
       private IWebDriver _driver;

        [Given(@"I click button Journal")]
        public void GivenIClickButtonJournal()
        {
            _driver = (IWebDriver)ScenarioContext.Current["Driver"];
            _driver.Navigate().GoToUrl(UrlStorage.BasePage);
            Thread.Sleep(500);
            var dropdownRole = _driver.FindElement(Journal_WindowXPath.DropDownRoles);
            dropdownRole.Click();
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

        [Given(@"Select group in window Journal")]
        public void GivenSelectGroupInWindowJournal()
        {
            var buttonSelectGroup = _driver.FindElement(Journal_WindowXPath.ButtonGroup);
            buttonSelectGroup.Click();
        }

        [When(@"Click on filter rating down")]
        public void WhenClickOnFilterRatingDown()
        {
            var filter = _driver.FindElement(Journal_WindowXPath.FilterDown);
            filter.Click();
        }

        [Then(@"Checking that the rating order has changed in ascending order")]
        public void ThenCheckingThatTheRatingOrderHasChangedInAscendingOrder()
        {
            var generalRating = _driver.FindElement(Journal_WindowXPath.GeniralListRatingPercent);
            List<IWebElement> ratingActual = generalRating.FindElement(Journal_WindowXPath.ListRatingStudent)
                                                          .FindElements(Journal_WindowXPath.ListRatingStudent).ToList();
            List<GridJournalModel> students = JournalStudentMock.GetStudent();
            int countExpected = students.Count + 2;
            Assert.AreEqual(countExpected, ratingActual.Count);
            Assert.AreEqual(students[0].Percent, ratingActual[3].Text);
            Assert.AreEqual(students[1].Percent, ratingActual[1].Text);
            Assert.AreEqual(students[2].Percent, ratingActual[2].Text);
        }

        [When(@"Click on filter rating up")]
        public void WhenClickOnFilterRatingUp()
        {
            var filter = _driver.FindElement(Journal_WindowXPath.FilterUp);
            filter.Click();
        }

        [Then(@"Checking that the rating order has changed in descending order")]
        public void ThenCheckingThatTheRatingOrderHasChangedInDescendingOrder()
        {
            var generalRating = _driver.FindElement(Journal_WindowXPath.GeniralListRatingPercent);
            List<IWebElement> ratingActual = generalRating.FindElements(Journal_WindowXPath.ListRatingStudent).ToList();
            List<GridJournalModel> students = JournalStudentMock.GetStudent();
            int countExpected = students.Count + 2;
            Assert.AreEqual(countExpected, ratingActual.Count);
            Assert.AreEqual(students[0].Percent, ratingActual[1].Text);
            Assert.AreEqual(students[1].Percent, ratingActual[3].Text);
            Assert.AreEqual(students[2].Percent, ratingActual[2].Text);
        }

        [Given(@"Horizontal scroll")]
        public void GivenHorizontalScroll()
        {
            var horizontalScroll = _driver.FindElement(Journal_WindowXPath.HorizontalScroll);
            Actions build = new Actions(_driver);
            build.DragAndDropToOffset(horizontalScroll,-125,0).Build().Perform();
        }

        [Then(@"Checking the class date")]
        public void ThenCheckingTheClassDate()
        {
            string getAttribute = "value";
            List<IWebElement> dateClass = _driver.FindElements(Journal_WindowXPath.DateClass).ToList();
            List<GridJournalModel> students = JournalStudentMock.GetStudent();
            Assert.AreEqual(students[0].DateEmployment[0], dateClass[0].GetAttribute(getAttribute));
            Assert.AreEqual(students[1].DateEmployment[0], dateClass[0].GetAttribute(getAttribute));
            Assert.AreEqual(students[2].DateEmployment[0], dateClass[0].GetAttribute(getAttribute));
        }

        [Then(@"Verify that the desired attendance item is selected")]
        public void ThenWeCheckThatTheAttendanceSetByUsIsSaved()
        {
            var attendanceStudent = _driver.FindElements(Journal_WindowXPath.GeneralListAttendance)[1];
            var listClass = attendanceStudent.FindElements(By.XPath(@"//div[@class='one-block journal-filter-item']")).ToList();
            listClass[0].Click();
            List<IWebElement> dropdownElement0_05 = _driver.FindElements(Journal_WindowXPath.DropdownElement0_0_5).ToList();
            dropdownElement0_05[0].Click();
            var text = _driver.FindElement(By.XPath(@"//*[text()='������ ������������']"));
            text.Click();
            //check for 0
            Assert.AreEqual("0", listClass[0].Text);
            //check for 0.5
            listClass[0].Click();
            List<IWebElement> dropdownElement0_05_05 = _driver.FindElements(Journal_WindowXPath.DropdownElement0_0_5).ToList();
            dropdownElement0_05_05[1].Click();
            text.Click();
            Assert.AreEqual("0.5", listClass[0].Text);
            //check for 1
            listClass[0].Click();
            List<IWebElement> dropdownElement0_05_1 = _driver.FindElements(Journal_WindowXPath.DropdownElement0_0_5).ToList();
            dropdownElement0_05_1[1].Click();
            text.Click();
            Assert.AreEqual("1", listClass[0].Text);
        }


        [When(@"Click to sort by last name")]
        public void WhenClickToSortByLastName()
        {
            var sortingFIO = _driver.FindElement(Journal_WindowXPath.SortingFIO);
            sortingFIO.Click();
        }

        [Then(@"The list of students should be sorted by last name")]
        public void ThenTheListOfStudentsShouldBeSortedByLastName()
        {
            var generalListStudent = _driver.FindElement(Journal_WindowXPath.GeneralListStudent);
            List<IWebElement> listStudentActual = generalListStudent.FindElements(Journal_WindowXPath.ListAllStudentsFIO).ToList();
            int countActual = listStudentActual.Count;
            int countExpected = 3 + JournalStudentMock.GetStudent().Count;
            Assert.AreEqual(countExpected, countActual);
            List<GridJournalModel> students = JournalStudentMock.GetStudent();
            Assert.AreEqual(students[0].Name, listStudentActual[2].Text);
            Assert.AreEqual(students[1].Name, listStudentActual[3].Text);
            Assert.AreEqual(students[2].Name, listStudentActual[4].Text);
            _driver.Close();
        }

        // new Scenario ���������, ��� �������� ������������ ���������

        [Then(@"We check that the student corresponds to the element of attendance and the date of the lesson")]
        public void ThenWeCheckThatTheStudentCorrespondsToTheElementOfAttendanceAndTheDateOfTheLesson()
        {
            string getAttribute = "value";
            string getAttributeId = "data-lesson-id";
            // ���� � ������
            List<IWebElement> dateClass = _driver.FindElements(Journal_WindowXPath.DateClass).ToList();
            // ��� ������� ������
            List<GridJournalModel> students = JournalStudentMock.GetStudent();
            // ��� ������� 1 ��� 0 ��� 0.5
            List<IWebElement> simpleBall = _driver.FindElements(Journal_WindowXPath.Ball).ToList();
            // ������� �������� ���������� � 2 
            var generalListStudent = _driver.FindElement(Journal_WindowXPath.GeneralListStudent);
            List<IWebElement> listStudentActual = generalListStudent.FindElements(Journal_WindowXPath.ListAllStudentsFIO).ToList();
            // �������� � ��������
            var generalRating = _driver.FindElement(Journal_WindowXPath.GeniralListRatingPercent);
            List<IWebElement> ratingActual = generalRating.FindElements(Journal_WindowXPath.ListRatingStudent).ToList();
            // �������� ������ ��� ��������� ����������, ����� ����� �������� ������ � �����
            List<GridJournalModel> actualListJornalModel = new List<GridJournalModel>();

            // ����� ������ ���� �������� ������ � ��������� �� � ���� 
            // ������ � ���� �������� ������� ��� ��������, ��� ������������ � ������� � ���������
            // ���-�� ���������� ��������� 6 �������� 3 (3 ����� ���������� ����� ��� � ���������� � �����)

            int i = 0;
            int count = 0;
            for (int j = 2; j < listStudentActual.Count - 1; j++) // count 6
            {
                List<string> ballStudent = new List<string>();
                while (i < simpleBall.Count)
                {
                    ballStudent.Add(simpleBall[i].GetAttribute(getAttributeId));
                    i = i + students.Count;
                }
                count++;
                i = count;
                actualListJornalModel.Add(new GridJournalModel()
                {
                    Ball = ballStudent,
                    Name = listStudentActual[j].Text,
                    Percent = ratingActual[j - 1].Text
                });
            }

            // ���� ���� ��������� � ������ ���� ������� � ������� ��������

            for (int j = 0; j < actualListJornalModel.Count; j++)
            {
                List<string> date = new List<string>();
                for (i = 0; i < dateClass.Count; i++)
                {
                    date.Add(dateClass[i].GetAttribute(getAttribute));
                }
                actualListJornalModel[j].DateEmployment = date;
            }
            Assert.AreEqual(students.Count, actualListJornalModel.Count);
            for (i = 0; i < students.Count; i++)
            {
                Assert.AreEqual(students[i], actualListJornalModel[i]);
            }

            // ������ ������ �������� , ��� ������� ������� ����� ��������� 

            List<double> allTotalExpected = JournalStudentMock.GetAllTotal();
            List<IWebElement> totalActual = _driver.FindElements(Journal_WindowXPath.Total).ToList();
            List<double> actualTotal = new List<double>();
            string s = totalActual[0].GetAttribute("innerText");
            for (int bb = 0; bb < totalActual.Count; bb++)
            {
                string a = totalActual[bb].GetAttribute("innerText"); 
                actualTotal.Add(Convert.ToDouble(a));
            }
            for(i = 0; i < allTotalExpected.Count; i++)
            {
                Assert.AreEqual(allTotalExpected[i], actualTotal[i]);
            }
            _driver.Close();  
        }
    }
}
