﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace DevEduEducationSystem.API.Tests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("OrganizationOfLessons")]
    public partial class OrganizationOfLessonsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "OrganizationOfLessons.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "OrganizationOfLessons", "A short summary of the feature", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User in role Teacher can create Lesson on the topic")]
        [NUnit.Framework.CategoryAttribute("Teacher")]
        [NUnit.Framework.TestCaseAttribute("Anton", "Kutepov", "Vldimirovich", "TroyanovIP@mail.ru", "IvanPT", "Qwerty123", "Dnipro", "02.02.1993", "string", "899912349954", "ProstoCourse", "I don\'t have word for description", "Teacher", null)]
        public virtual void UserInRoleTeacherCanCreateLessonOnTheTopic(string firstName, string lastName, string patronymic, string email, string username, string password, string city, string birthDate, string gitHubAccount, string phoneNumber, string name, string description, string role, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Teacher"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("FirstName", firstName);
            argumentsOfScenario.Add("LastName", lastName);
            argumentsOfScenario.Add("Patronymic", patronymic);
            argumentsOfScenario.Add("Email", email);
            argumentsOfScenario.Add("Username", username);
            argumentsOfScenario.Add("Password", password);
            argumentsOfScenario.Add("City", city);
            argumentsOfScenario.Add("BirthDate", birthDate);
            argumentsOfScenario.Add("GitHubAccount", gitHubAccount);
            argumentsOfScenario.Add("PhoneNumber", phoneNumber);
            argumentsOfScenario.Add("Name", name);
            argumentsOfScenario.Add("Description", description);
            argumentsOfScenario.Add("Role", role);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User in role Teacher can create Lesson on the topic", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 6
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table142 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "Patronymic",
                            "Email",
                            "Username",
                            "Password",
                            "City",
                            "BirthDate",
                            "GitHubAccount",
                            "PhoneNumber"});
                table142.AddRow(new string[] {
                            string.Format("{0}", firstName),
                            string.Format("{0}", lastName),
                            string.Format("{0}", patronymic),
                            string.Format("{0}", email),
                            string.Format("{0}", username),
                            string.Format("{0}", password),
                            string.Format("{0}", city),
                            string.Format("{0}", birthDate),
                            string.Format("{0}", gitHubAccount),
                            string.Format("{0}", phoneNumber)});
#line 7
 testRunner.Given("I create new user", ((string)(null)), table142, "Given ");
#line hidden
#line 10
 testRunner.Given(string.Format("I login as an admin and give new user role {0}", role), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table143 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Description"});
                table143.AddRow(new string[] {
                            string.Format("{0}", name),
                            string.Format("{0}", description)});
#line 11
 testRunner.And("I create course under login admin", ((string)(null)), table143, "And ");
#line hidden
                TechTalk.SpecFlow.Table table144 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Duration"});
                table144.AddRow(new string[] {
                            "Thema 1",
                            "1"});
                table144.AddRow(new string[] {
                            "Thema 2",
                            "2"});
#line 14
 testRunner.And("I create topics under login admin", ((string)(null)), table144, "And ");
#line hidden
                TechTalk.SpecFlow.Table table145 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Position"});
                table145.AddRow(new string[] {
                            "Thema 1",
                            "1"});
                table145.AddRow(new string[] {
                            "Thema 2",
                            "2"});
#line 18
 testRunner.And("I add course topics on positions under login admin", ((string)(null)), table145, "And ");
#line hidden
                TechTalk.SpecFlow.Table table146 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "GroupStatusId",
                            "StartDate",
                            "EndDate",
                            "Timetable",
                            "PaymentPerMonth"});
                table146.AddRow(new string[] {
                            "Group",
                            "1",
                            "28.06.2022",
                            "28.10.2022",
                            "пн, ср, пт 10:00 - 14:00",
                            "7500"});
#line 22
 testRunner.And("I create groupe under login admin", ((string)(null)), table146, "And ");
#line hidden
#line 25
 testRunner.And("I to appoint new group \"Teacher\" under login admin", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table147 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "Patronymic",
                            "Email",
                            "Username",
                            "Password",
                            "City",
                            "BirthDate",
                            "GitHubAccount",
                            "PhoneNumber"});
                table147.AddRow(new string[] {
                            "Student 1",
                            "Student 1",
                            "Student 1",
                            "student_1@mail.ru",
                            "Student 1",
                            "Qwerty123",
                            "SaintPetersburg",
                            "01.01.2000",
                            "string",
                            "89991122334"});
                table147.AddRow(new string[] {
                            "Student 2",
                            "Student 2",
                            "Student 2",
                            "student_2@mail.ru",
                            "Student 2",
                            "Qwerty123",
                            "SaintPetersburg",
                            "01.01.1992",
                            "string",
                            "89213456789"});
                table147.AddRow(new string[] {
                            "Student 3",
                            "Student 3",
                            "Student 3",
                            "student_3@mail.ru",
                            "Student 3",
                            "Qwerty123",
                            "SaintPetersburg",
                            "01.12.2001",
                            "string",
                            "89210081122"});
#line 26
    testRunner.And("I Create students for group", ((string)(null)), table147, "And ");
#line hidden
#line 31
 testRunner.And("I login as an admin and add students in group", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table148 = new TechTalk.SpecFlow.Table(new string[] {
                            "Date",
                            "AdditionalMaterials",
                            "linkToRecord"});
                table148.AddRow(new string[] {
                            "28.06.2022",
                            "string",
                            "https://json2csharp.com/"});
#line 32
 testRunner.When("I login as an Lecturer and create Lesson with topics", ((string)(null)), table148, "When ");
#line hidden
#line 35
    testRunner.And("I login as an admin and add to group lesson", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 36
 testRunner.Then("Under login Lecturer I get lesson by id <Teacher> and check that lessons is in re" +
                        "turn model and have correct field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 37
 testRunner.Then("Under login Lecturer I get lesson by id <Group> and check that lessons is in retu" +
                        "rn model and have correct field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User in role Teacher can mark attendance of students in Lesson")]
        [NUnit.Framework.CategoryAttribute("TeacherLesson")]
        [NUnit.Framework.TestCaseAttribute("Anton", "Kutepov", "Vldimirovich", "TroyanovIP@mail.ru", "IvanPT", "Qwerty123", "Dnipro", "02.02.1993", "string", "899912349954", "ProstoCourse", "I don\'t have word for description", "Teacher", null)]
        public virtual void UserInRoleTeacherCanMarkAttendanceOfStudentsInLesson(string firstName, string lastName, string patronymic, string email, string username, string password, string city, string birthDate, string gitHubAccount, string phoneNumber, string name, string description, string role, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "TeacherLesson"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("FirstName", firstName);
            argumentsOfScenario.Add("LastName", lastName);
            argumentsOfScenario.Add("Patronymic", patronymic);
            argumentsOfScenario.Add("Email", email);
            argumentsOfScenario.Add("Username", username);
            argumentsOfScenario.Add("Password", password);
            argumentsOfScenario.Add("City", city);
            argumentsOfScenario.Add("BirthDate", birthDate);
            argumentsOfScenario.Add("GitHubAccount", gitHubAccount);
            argumentsOfScenario.Add("PhoneNumber", phoneNumber);
            argumentsOfScenario.Add("Name", name);
            argumentsOfScenario.Add("Description", description);
            argumentsOfScenario.Add("Role", role);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User in role Teacher can mark attendance of students in Lesson", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 43
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table149 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "Patronymic",
                            "Email",
                            "Username",
                            "Password",
                            "City",
                            "BirthDate",
                            "GitHubAccount",
                            "PhoneNumber"});
                table149.AddRow(new string[] {
                            string.Format("{0}", firstName),
                            string.Format("{0}", lastName),
                            string.Format("{0}", patronymic),
                            string.Format("{0}", email),
                            string.Format("{0}", username),
                            string.Format("{0}", password),
                            string.Format("{0}", city),
                            string.Format("{0}", birthDate),
                            string.Format("{0}", gitHubAccount),
                            string.Format("{0}", phoneNumber)});
#line 44
 testRunner.Given("I create new user", ((string)(null)), table149, "Given ");
#line hidden
#line 47
 testRunner.Given(string.Format("I login as an admin and give new user role {0}", role), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table150 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Description"});
                table150.AddRow(new string[] {
                            string.Format("{0}", name),
                            string.Format("{0}", description)});
#line 48
 testRunner.And("I create course under login admin", ((string)(null)), table150, "And ");
#line hidden
                TechTalk.SpecFlow.Table table151 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Duration"});
                table151.AddRow(new string[] {
                            "Thema 1",
                            "1"});
                table151.AddRow(new string[] {
                            "Thema 2",
                            "2"});
#line 51
 testRunner.And("I create topics under login admin", ((string)(null)), table151, "And ");
#line hidden
                TechTalk.SpecFlow.Table table152 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "GroupStatusId",
                            "StartDate",
                            "EndDate",
                            "Timetable",
                            "PaymentPerMonth"});
                table152.AddRow(new string[] {
                            "Group",
                            "1",
                            "28.06.2022",
                            "28.10.2022",
                            "пн, ср, пт 10:00 - 14:00",
                            "7500"});
#line 55
 testRunner.And("I create groupe under login admin", ((string)(null)), table152, "And ");
#line hidden
#line 58
 testRunner.And("I to appoint new group \"Teacher\" under login admin", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table153 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "Patronymic",
                            "Email",
                            "Username",
                            "Password",
                            "City",
                            "BirthDate",
                            "GitHubAccount",
                            "PhoneNumber"});
                table153.AddRow(new string[] {
                            "Student 1",
                            "Student 1",
                            "Student 1",
                            "student_1@mail.ru",
                            "Student 1",
                            "Qwerty123",
                            "SaintPetersburg",
                            "01.01.2000",
                            "string",
                            "89991122334"});
                table153.AddRow(new string[] {
                            "Student 2",
                            "Student 2",
                            "Student 2",
                            "student_2@mail.ru",
                            "Student 2",
                            "Qwerty123",
                            "SaintPetersburg",
                            "01.01.1992",
                            "string",
                            "89213456789"});
                table153.AddRow(new string[] {
                            "Student 3",
                            "Student 3",
                            "Student 3",
                            "student_3@mail.ru",
                            "Student 3",
                            "Qwerty123",
                            "SaintPetersburg",
                            "01.12.2001",
                            "string",
                            "89210081122"});
#line 59
    testRunner.And("I Create students for group", ((string)(null)), table153, "And ");
#line hidden
#line 64
 testRunner.And("I login as an admin and add students in group", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table154 = new TechTalk.SpecFlow.Table(new string[] {
                            "Date",
                            "AdditionalMaterials",
                            "linkToRecord"});
                table154.AddRow(new string[] {
                            "28.06.2022",
                            "string",
                            "https://json2csharp.com/"});
#line 65
 testRunner.When("I login as an Lecturer and create Lesson with topics", ((string)(null)), table154, "When ");
#line hidden
#line 68
    testRunner.And("I login as an admin and add to group lesson", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table155 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "AttendanceType"});
                table155.AddRow(new string[] {
                            "student_1@mail.ru",
                            "Absent"});
                table155.AddRow(new string[] {
                            "student_2@mail.ru",
                            "Attend"});
                table155.AddRow(new string[] {
                            "student_3@mail.ru",
                            "PartiallyAttended"});
#line 69
 testRunner.And("Under login Lecturer I can mark attendance of students in Lesson", ((string)(null)), table155, "And ");
#line hidden
#line 74
 testRunner.Then("I get full-info about Lesson and check that AttendanceType of student mark for th" +
                        "e relevant student", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
