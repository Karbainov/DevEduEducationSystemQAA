using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEduEducationSystemQAA.WEB.Tests.Support.XPaths
{
    public class GroupAllFunctionalityXPath
    {
        public static By ChangeRole = By.XPath("//div[@data-lesson-id= '4']");
        public static By RoleSelection = By.XPath("//li[text() = 'Менеджер']");
        public static By PageCreateGroupe = By.XPath("//span[text() = 'Создать группу']");
        public static By InputName = By.XPath("//input[@class='form-input']");
        public static By DropDownCourse = By.XPath("//div[@class='drop-down-filter  '] //child::*");
        public static By СhooseACourse = By.XPath("//ul[@class='drop-down-filter__list overflow']/li[2]");
        public static By ButtonSave = By.XPath("//button[text() = 'Сохранить']");
        public static By ButtonCancel = By.XPath("//button[text() = 'Отмена']");
        public static By ButtonExit = By.XPath(@"//span[text() = 'Выйти']");
    }
}
