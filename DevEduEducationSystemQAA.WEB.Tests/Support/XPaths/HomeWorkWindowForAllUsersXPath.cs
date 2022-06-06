﻿using System;
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
        //Редактирование
        public static By ButtonUpdateInCard = By.XPath("//a[@class='link-with-text-decoration' and text() = 'Редактировать']");
        public static By DateOfIssue = By.XPath("//div[text()='Дата выдачи задания']/child::div/child::div/child::div/child::input");
        public static By Deadline = By.XPath("//div[text()='Срок сдачи задания']/child::div/child::div/child::div/child::input");
        public static By NameOfHomeWork = By.XPath("//input[@placeholder='Введите название']");
        public static By DescriptionOfHomeWork = By.XPath("//textarea[@placeholder='Введите текст']");  
        public static By ButtonSaveAfterUpdate = By.XPath("//button[@class='sc-bczRLJ jsAGPN btn btn-white-with-border flex-container']");
        //Списки ДЗ
        public static By NewHomeWorkInList = By.XPath("//SPAN[@class='homework-title' and text() = 'HomeWork 3'] / following-sibling::a");
        public static By ButtonNewAfterUpdateHomeWork = By.XPath("//SPAN[@class='homework-title' and text() = 'HomeWork 3.1'] / following-sibling::a");
        public static By UpdatedHomeWorkInList = By.XPath("//span[@class='homework-title' and text()= 'HomeWork 3.1'] / following-sibling::a");
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
        


    }
}
