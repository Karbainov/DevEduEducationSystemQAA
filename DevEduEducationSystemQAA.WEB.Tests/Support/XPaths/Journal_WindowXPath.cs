using DevEduEducationSystemQAA.WEB.Tests.Support.MockListStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEduEducationSystemQAA.WEB.Tests.Support.XPaths
{
    public class Journal_WindowXPath
    {
        private static List<GridJournalModel> students = JournalStudentMock.GetStudent();
        public static By ButtonJournal = By.XPath(@"//a[@href='/journal']");
        public static By DropDownRoles = By.XPath(@"//div[@class='drop-down-filter  left']/*");
        public static By DropDownRoleTeacher = By.XPath(@"//*[text()='Преподаватель']");
        public static By ButtonGroup = By.XPath(@"//*[text()='Вечный студент']"); // это тестовая группа созданная в базе, вероятно xpath может поменяться
        public static By DropDown1 = By.XPath(@"//div[@data-lesson-id='1']");
        public static By DropDown0 = By.XPath(@"//div[@data-lesson-id='0']");
        public static By DropDown0_5 = By.XPath(@"//div[@data-lesson-id='0.5']");
        public static By ButtonAddHomework = By.XPath(@"//div[@class='form-input_link__button']");
        public static By SortingFIO = By.XPath(@"//button[@data-sort-name='reset']");
        public static By FilterUp = By.XPath(@"//div[@class='one-block rating sort-buttons']/button[@class='button-style-reset']/*");
        public static By FilterDown = By.XPath(@"//button[@class='button-style-reset']/following-sibling::button/*");
        // XPath на конкретных учеников , меняются если меняется листик
        public static By GeneralListStudent = By.XPath(@"//div[@class='list-container']");
        public static By ListAllStudentsFIO = By.XPath(@"//div[@class='one-block students-list']");
        public static By ListOneStudent = By.XPath($@"//*[text()='{students[0].Name}']");
        public static By ListTwoStudent = By.XPath($@"//*[text()='{students[1].Name}']");
        public static By ListThreeStudent = By.XPath($@"//*[text()='{students[2].Name}']");
        // XPath на проценты raiting students
        public static By GeniralListRatingPercent = By.XPath(@"//div[@class='list-container rating']");
        public static By ListRatingStudent = By.XPath(@"//div[@class='one-block rating']");
        public static By HorizontalScroll = By.XPath(@"//div[@class='swiper swiper-initialized swiper-horizontal swiper-pointer-events']/child::div/child::div[@class='swiper-scrollbar-drag']");
        // XPath date Class
        public static By DateClass = By.XPath(@"//input[@class='one-block list-view-input']");
        // XPath attendance student 
        public static By GeneralListAttendance = By.XPath(@"//div[@class='swiper-slide swiper-slide-active']");
        // XPath drop down element 0, 0.5 , 1
        public static By DropdownElement0_0_5 = By.XPath(@"//li[@class='drop-down-filter__element ']");
        // XPath drop down element выбранный который
        public static By DropdownElement_1 = By.XPath(@"//li[@class='drop-down-filter__element selected']");
        //XPath List всех отметок посещаемости 
        public static By AllBall = By.XPath(@"//div[@class='swiper-wrapper']");
        public static By Ball = By.XPath(@"//div[@class='drop-down-filter  ']");
        // Total ball
        public static By Total = By.XPath(@"//div[@class='swiper swiper-initialized swiper-horizontal swiper-pointer-events']/div[@class='swiper-wrapper']/*/child::*[text()]");

    }
}
