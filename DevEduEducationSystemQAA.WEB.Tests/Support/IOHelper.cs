using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEduEducationSystemQAA.WEB.Tests.Support
{
    public class IOHelper
    {
        public static void CheckAuthNegative(IWebDriver driver, string email, string password)
        {
            driver.Navigate().GoToUrl(UrlStorage.EnterWindow);
            Thread.Sleep(200);
            var inputEmail = driver.FindElement(Enter_WindowXPaths.InputLogin);
            inputEmail.SendKeys(email);
            var inputPassword = driver.FindElement(Enter_WindowXPaths.InputPassword);
            inputPassword.Clear();
            inputPassword.SendKeys(password);
            var buttonEnterWinLogin = driver.FindElement(Enter_WindowXPaths.ButtonEnter);
            buttonEnterWinLogin.Click();
            Thread.Sleep(500);
            driver.Navigate().GoToUrl(UrlStorage.BasePage);
            string actual = driver.Url;
            string expected = UrlStorage.EnterWindow;
            Assert.AreEqual(expected, actual);
        }

        public static void CheckAuth(IWebDriver driver, string email, string password)
        {
            driver.Navigate().GoToUrl(UrlStorage.EnterWindow);
            Thread.Sleep(200);
            var inputEmail = driver.FindElement(Enter_WindowXPaths.InputLogin);
            inputEmail.SendKeys(email);
            var inputPassword = driver.FindElement(Enter_WindowXPaths.InputPassword);
            inputPassword.Clear();
            inputPassword.SendKeys(password);
            var buttonEnterWinLogin = driver.FindElement(Enter_WindowXPaths.ButtonEnter);
            buttonEnterWinLogin.Click();
            Thread.Sleep(500);
            driver.Navigate().GoToUrl(UrlStorage.BasePage);
            string actual = driver.Url;
            string expected = UrlStorage.BasePage;
            Assert.AreEqual(expected, actual);
        }

        public static void EnterInSystem(string email, string password, IWebDriver driver)
        {
            var inputEmail = driver.FindElement(Enter_WindowXPaths.InputLogin);
            inputEmail.SendKeys(email);
            var inputPassword = driver.FindElement(Enter_WindowXPaths.InputPassword);
            inputPassword.Clear();
            inputPassword.SendKeys(password);
            var buttonEnterWinLogin = driver.FindElement(Enter_WindowXPaths.ButtonEnter);
            buttonEnterWinLogin.Click();
            Thread.Sleep(500);
            driver.Navigate().GoToUrl(UrlStorage.BasePage);
        }
    }
}
