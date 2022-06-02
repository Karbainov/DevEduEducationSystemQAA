using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEduEducationSystemQAA.WEB.Tests.Support.XPaths
{
    public class Journal_WindowXPath
    {
        public static By ButtonJournal = By.XPath(@"//a[@href='/journal']");
        public static By DropDownRoles = By.XPath(@"//div[@class='drop-down-filter  left']");
        public static By DropDownRoleTeacher = By.XPath(@"//*[text()='Преподаватель']");
    }
}
