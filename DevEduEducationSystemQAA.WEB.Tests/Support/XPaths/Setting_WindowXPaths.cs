using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEduEducationSystemQAA.WEB.Tests.Support.XPaths
{
    public class Setting_WindowXPaths
    {
        public static By ButtonMainMinuSetting = By.XPath(@"//*[@class='main-nav-panel']/child::a[@href='/settings']");
        public static By ButtonNameUserItIsSetting = By.XPath(@"//span[@class='avatar-name transition-styles']");
        public static By Surname = By.XPath(@"//input[@name='lastName']");
        public static By Name = By.XPath(@"//input[@name='firstName']");
        public static By Patronymic = By.XPath(@"//input[@name='patronymic']");
        public static By BirthDate = By.XPath(@"//input[@class='form-control']");
        public static By Phone = By.XPath(@"//input[@name='phoneNumber']");
        public static By LinkByGitHub = By.XPath(@"//input[@name='gitHubAccount']");
        public static By TextUploadNewPhoto = By.XPath(@"//a[text()='Загрузить новое фото']");
        public static By ButtonSave = By.XPath(@"//*[text()='Сохранить']");
        public static By ButtonCancel = By.XPath(@"//*[text()='Отмена']");
        public static By ButtonPencil = By.XPath(@"//a[@href='/change-password']");
        public static By PhotoButtonCancel = By.XPath(@"//div[@class='buttons-container']/child::button");
        public static By PhotoButtonSelectFile = By.XPath(@"//div[@class='buttons-container']/child::label");
        public static By TextAboutPhoto = By.XPath(@"//*[text()='Загрузите свою настоящую фотографию. Вы можете загрузить изображение в формате JPG или PNG']");
        public static By InputOldPassword = By.XPath(@"//input[@name='oldPassword']");
        public static By InputNewPassword = By.XPath(@"//input[@name='newPassword']");
        public static By InputNewPasswordReaped = By.XPath(@"//input[@name='newPasswordRepeat']");
        public static By ButtonSaveNewPassword = By.XPath(@"//button[@class='sc-bczRLJ iJvUkY btn btn-fill flex-container']");
        public static By ButtonCancelNewPassword = By.XPath(@"//button[@class='sc-bczRLJ kEeNDb btn btn-text flex-container']");
        public static By ButtonBack = By.XPath(@"//div[@class='link-arrow']");
        public static By InputEmail = By.XPath(@"//input[@name='email']");
    }
}
