﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEduEducationSystemQAA.WEB.Tests.Support.XPaths
{
    public class Enter_WindowXPaths
    {           
        public static By InputLogin = By.XPath(@"//input[@name='email']");
        public static By InputPassword = By.XPath(@"//input[@name='password']");
        public static By ButtonEnter = By.XPath(@"//button[text()='Войти']");
        public static By ButtonCancel = By.XPath(@"//button[@class='btn btn-text']");
    }
}

