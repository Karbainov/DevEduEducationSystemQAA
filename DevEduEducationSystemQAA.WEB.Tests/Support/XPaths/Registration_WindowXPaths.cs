﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEduEducationSystemQAA.WEB.Tests.Support.XPaths
{
    public class Registration_WindowXPaths
    {
        public static By InputSurname = By.XPath(@"//input[@id='lastName']");
        public static By InputName = By.XPath(@"//input[@id='firstName']");
        public static By InputPatronymic = By.XPath(@"//input[@name='patronymic']");
        public static By DatePicker = By.XPath(@"//input[@class='form-control']");
        public static By InputPassword = By.XPath(@"//input[@name='password']");
        public static By InputRepeatPassword = By.XPath(@"//label[@for='repeat-password']/following-sibling::input");
        public static By InputEmail = By.XPath(@"//input[@name='email']");
        public static By InputPhone = By.XPath(@"//input[@name='phoneNumber']");
        public static By ChecBoxPrivacyPolicy = By.XPath(@"//label[@class='custom-checkbox']");       
    }
}
