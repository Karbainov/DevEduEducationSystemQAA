using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEduEducationSystemQAA.WEB.Tests.Support.XPaths
{
    public class HomeWorkWindowForAllUsersXPath
    {
        public static string groupNameBeforeUpdate = "Frontend React";
        public static string groupNameAfterUpdate = "Group 1 BaseC#";

        //Кнопки вкладок
        public static By ButtonIssuingHomeWorks = By.XPath("//SPAN[@class='links-name transition-styles' and text() = 'Выдача заданий']");
        public static By ChangeRole = By.XPath("//div[@data-lesson-id= '2']");        
        public static By RoleSelection = By.XPath("//li[text() = 'Преподаватель']");
        public static By TabHomeWork = By.XPath("//SPAN[@class='links-name transition-styles' and text() = 'Домашние задания'] //ancestor::a");
        //Выборг группы
        public static By ChoiceGroup = By.XPath("//span[@class = 'radio-text' and text() = 'Group 2 Frontend']");
        public static By ChoiceGroupUpdate = By.XPath("//span[@class = 'radio-text' and text() = 'Group 1 BaseC#']");
        public static By ChoiceGroupInListHomeworksBeforeUpdate = By.XPath($"//div[text() = '{groupNameBeforeUpdate}']");
        public static By ChoiceGroupInListHomeworksAfterUpdate = By.XPath($"//div[text() = '{groupNameAfterUpdate}']");
        //Заполнение карточки с ДЗ при создании и в режиме редактирования
        //Создание
        public static By FieldDateofIssue = By.XPath("//span[text()='Дата выдачи' ]/ following-sibling::span");
        public static By FieldDateofDeadline = By.XPath("//span[text()='Срок сдачи' ]/ following-sibling::span");        
        public static By FieldDescription = By.XPath("//span[@class='homework-description-title']");
        public static By Link = By.XPath("//textarea[@placeholder='Вставьте ссылку']");
        public static By ButtonAddLink = By.XPath("//button[@class='sc-bczRLJ kEeNDb btn btn-fill ellipse flex-container']");
        public static By ButtonPublish = By.XPath("//button[@class='sc-bczRLJ iJvUkY btn btn-fill flex-container']");
        public static By ButtonSaveAsDraft = By.XPath("//button[@class='sc-bczRLJ jsAGPN btn btn-white-with-border flex-container']");
        public static By ButtonCancel = By.XPath("//button[@class='sc-bczRLJ kEeNDb btn btn-text flex-container']");
        public static By NewHomeWorkInListHomeWork11 = By.XPath("//SPAN[@class='homework-title' and text() = 'HomeWork 11'] / following-sibling::a");
        //Редактирование
        public static By ButtonUpdateInCard = By.XPath("//a[@class='link-with-text-decoration' and text() = 'Редактировать']");
        public static By DateOfIssue = By.XPath("//div[text()='Дата выдачи задания']/child::div/child::div/child::div/child::input");
        public static By Deadline = By.XPath("//div[text()='Срок сдачи задания']/child::div/child::div/child::div/child::input");
        public static By NameOfHomeWork = By.XPath("//input[@placeholder='Введите название']");
        public static By DescriptionOfHomeWork = By.XPath("//textarea[@placeholder='Введите текст']");  
        public static By ButtonSaveAfterUpdate = By.XPath("//button[@class='sc-bczRLJ jsAGPN btn btn-white-with-border flex-container']");
        public static By ButtonDeleteTask = By.XPath("//button[@class = 'sc-bczRLJ kEeNDb btn btn-text flex-container' and text() = 'Удалить задание']");
        public static By PopUpWindowAfterClickDeleteTask = By.XPath("//div[@class = 'modal-content' and text() = 'Вы уверены, что хотите удалить задание?']']");        
        public static By ButtonAccepteDeleteInPopUpWindowAfterClickDeleteTask = By.XPath("//button[@class = 'sc-bczRLJ iJvUkY btn btn-fill flex-container' and text() = 'Удалить']");
        public static By ButtonCancelDeleteInPopUpWindowAfterClickDeleteTask = By.XPath("//div[@class = 'modal-window']//div[@class = 'buttons-group']//button[text() = 'Отмена']");
        public static By WindowsWithMessageAboutOnSuccessfulRemoval = By.XPath("//div[@class = 'modal-content' and text() = 'Задание успешно удалено.']");
        public static By ButtonOKInWindowsWithMessage = By.XPath("//div[@class = 'modal-window']//div[@class = 'buttons-group']//button[text() = 'Ок']");       
        public static By ButtonUpdateInListOfAllUnpublishTask = By.XPath("//span[text()= 'HomeWork 2'] / following-sibling::a");
        public static By ButtonUpdateInListOfAllUnpublishTask8 = By.XPath("//span[text()= 'HomeWork 8'] / following-sibling::a");
        //Списки ДЗ
        public static By NewHomeWorkInList = By.XPath("//SPAN[@class='homework-title' and text() = 'HomeWork 3'] / following-sibling::a");
        public static By NewHomeWorkInListHomeWork7 = By.XPath("//SPAN[@class='homework-title' and text() = 'HomeWork 7'] / following-sibling::a");
        public static By NewHomeWorkInListHomeWork11 = By.XPath("//SPAN[@class='homework-title' and text() = 'HomeWork 11'] / following-sibling::a");
        public static By NewHomeWorkInListForTestCreate = By.XPath("//SPAN[@class='homework-title' and text() = 'HomeWork 1'] / following-sibling::a");
        public static By NewHomeWorkInListForSavedTask = By.XPath("//SPAN[@class='homework-title' and text() = 'HomeWork 2'] / following-sibling::a");
        public static By HomeWorkInListAfterPublish = By.XPath("//SPAN[@class='homework-title' and text() = 'HomeWork 4'] / following-sibling::a");
        public static By HomeWorkInListBeforePublish = By.XPath("//SPAN[@class='homework-title' and text() = 'HomeWork 8'] / following-sibling::a");
        public static By ButtonNewAfterUpdateHomeWork = By.XPath("//SPAN[@class='homework-title' and text() = 'HomeWork 3.1'] / following-sibling::a");
        public static By UpdatedHomeWorkInList = By.XPath("//span[@class='homework-title' and text()= 'HomeWork 3.1'] / following-sibling::a");
        public static By ListAllHomeworksOrTasks = By.XPath("//span[@class = 'homework-title']");
        //Поиск сохраненных элементов
        public static By ButtonDeleteFirstLink = By.XPath("//div[@class='form-input_link__container'] //following::div");
        public static By ButtonDeleteSecondLink = By.XPath("//a[@href='https://metanit.com/'] //following::div");
        public static By ElementWithFirstSaveLink = By.XPath("//a[@href='https://www.figma.com/']");
        public static By ElementWithSecondSaveLink = By.XPath("//a[@href='https://metanit.com/']");
        public static By ListAllLinksInCardHomeWorks = By.XPath("//a[@class = 'homework-useful-link']");
        public static By DateOfIssueInCardOfHomeWork = By.XPath("//span[text()= 'Дата выдачи'] //following::span");
        public static By DateOfDeadlineInCardOfHomeWork = By.XPath("//span[text()= 'Срок сдачи'] //following::span");
        public static By FieldName = By.XPath("//span[@class='homework-title']");
        public static By DescriptionInCard = By.XPath("//p[@class = 'homework-card__description']");
        // выбор курса
        public static By ButtonCourse = By.XPath(@"//*[text()='QA Automation']");
        //переход к заданию
        public static By ButtonToTheTask = By.XPath(@"//a[@class='link-arrow']");
        // input for link student homework
        public static By InputStudentHomework = By.XPath(@"//input[@name='answer']");
        // send homework
        public static By ButtonSendHomework = By.XPath(@"//button[@class='button-fly']");
        public static By TextSendHomework = By.XPath(@"//*[text()='Выполненное задание']");

        // Edit homework student
        // button edit window homework , role - student
        public static By ButtonEdit = By.XPath(@"//a[@class='link-with-text-decoration']");
        public static By ButtonGoToBack = By.XPath(@"//*[text()='Назад']");

    }
}

