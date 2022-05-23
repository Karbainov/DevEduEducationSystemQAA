using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEduEducationSystemQAA.WEB.Tests.Support.XPaths
{
    public class Setting_WindowXPaths
    {
        public static By Surname = By.XPath(@"//input[@name='lastName']");
        public static By Name = By.XPath(@"//input[@name='firstName']");
        public static By Patronymic = By.XPath(@"//input[@name='patronymic']");
        public static By BirthDate = By.XPath(@"//input[@class='form-control']");
        public static By Phone = By.XPath(@"//input[@name='phoneNumber']");
        public static By LinkByGitHub = By.XPath(@"//input[@name='gitHubAccount']");
        public static By textUploadNewPhoto = By.XPath(@"//a[text()='Загрузить новое фото']");
        public static By ButtonSave = By.XPath(@"//*[text()='Сохранить']");
        public static By ButtonCancel = By.XPath(@"//*[text()='Отмена']");
        public static By caev = By.XPath(@"");
    }
}
