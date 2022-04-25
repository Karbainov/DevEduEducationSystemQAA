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
    [NUnit.Framework.DescriptionAttribute("Manager_Functionality")]
    public partial class Manager_FunctionalityFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "Manager_Functionality.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Manager_Functionality", "Как менеджер/админ, я хочу назначать роли юзерам", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("As manadger I want to assign a role to users")]
        [NUnit.Framework.CategoryAttribute("tag1")]
        [NUnit.Framework.TestCaseAttribute("Миневра", "Макгонагалл", "Смит", "Smit@mail.ru", "Minevra", "minevraSmit", "SaintPetersburg", "01.01.1985", "string", "89991111111", "Хагрид", "Рубеус", "Колтрейн", "Rubeus6@mail.ru", "Hagrid", "hagridRubeus", "SaintPetersburg", "01.03.2003", "string", "89211111111", "Methodist", null)]
        [NUnit.Framework.TestCaseAttribute("Миневра", "Макгонагалл", "Смит", "Smit1@mail.ru", "Minevra", "minevraSmit", "SaintPetersburg", "01.01.1985", "string", "89991111111", "Римус", "Джон", "Люпин", "Djon6@mail.ru", "Rimus", "rimusDjon", "SaintPetersburg", "01.03.1990", "string", "89110001234", "Teacher", null)]
        [NUnit.Framework.TestCaseAttribute("Миневра", "Макгонагалл", "Смит", "Smit2@mail.ru", "Minevra", "minevraSmit", "SaintPetersburg", "01.01.1985", "string", "89991111111", "Златопуст", "Локонс", "Брана", "Brana6@mail.ru", "Zlatopust", "zlatopust", "SaintPetersburg", "01.12.2001", "string", "89210081122", "Tutor", null)]
        public virtual void AsManadgerIWantToAssignARoleToUsers(
                    string firstName, 
                    string lastName, 
                    string patronymic, 
                    string email, 
                    string username, 
                    string password, 
                    string city, 
                    string birthDate, 
                    string gitHubAccount, 
                    string phoneNumber, 
                    string newFirstName, 
                    string newLastName, 
                    string newPatronymic, 
                    string newEmail, 
                    string newUsername, 
                    string newPassword, 
                    string newCity, 
                    string newBirthDate, 
                    string newGitHubAccount, 
                    string newPhoneNumber, 
                    string nameRole, 
                    string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "tag1"};
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
            argumentsOfScenario.Add("NewFirstName", newFirstName);
            argumentsOfScenario.Add("NewLastName", newLastName);
            argumentsOfScenario.Add("NewPatronymic", newPatronymic);
            argumentsOfScenario.Add("NewEmail", newEmail);
            argumentsOfScenario.Add("NewUsername", newUsername);
            argumentsOfScenario.Add("NewPassword", newPassword);
            argumentsOfScenario.Add("NewCity", newCity);
            argumentsOfScenario.Add("NewBirthDate", newBirthDate);
            argumentsOfScenario.Add("NewGitHubAccount", newGitHubAccount);
            argumentsOfScenario.Add("NewPhoneNumber", newPhoneNumber);
            argumentsOfScenario.Add("NameRole", nameRole);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As manadger I want to assign a role to users", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
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
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
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
                table1.AddRow(new string[] {
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
 testRunner.Given("Create future manadger", ((string)(null)), table1, "Given ");
#line hidden
#line 10
 testRunner.And("Autorized as admin", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 11
 testRunner.And("Assing Minevra \"Manager\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
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
                table2.AddRow(new string[] {
                            string.Format("{0}", newFirstName),
                            string.Format("{0}", newLastName),
                            string.Format("{0}", newPatronymic),
                            string.Format("{0}", newEmail),
                            string.Format("{0}", newUsername),
                            string.Format("{0}", newPassword),
                            string.Format("{0}", newCity),
                            string.Format("{0}", newBirthDate),
                            string.Format("{0}", newGitHubAccount),
                            string.Format("{0}", newPhoneNumber)});
#line 12
 testRunner.Given("Create new users for our roles", ((string)(null)), table2, "Given ");
#line hidden
#line 15
 testRunner.When("Autorized by manager", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "NameRole"});
                table3.AddRow(new string[] {
                            string.Format("{0}", nameRole)});
#line 16
 testRunner.And("Assing users role methodist, teacher, tutor", ((string)(null)), table3, "And ");
#line hidden
#line 19
 testRunner.Then("Сheck user roles", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a manager, I want to create groups")]
        [NUnit.Framework.TestCaseAttribute("Миневра", "Макгонагалл", "Смит", "Smit3@mail.ru", "Minevra", "minevraSmit", "SaintPetersburg", "01.01.1985", "string", "89991111111", "Хагрид", "Рубеус", "Колтрейн", "Rubeus@mail.ru", "Hagrid", "hagridRubeus", "SaintPetersburg", "01.03.2003", "string", "89211111111", "Manager", "Methodist", null)]
        public virtual void AsAManagerIWantToCreateGroups(
                    string firstName, 
                    string lastName, 
                    string patronymic, 
                    string email, 
                    string username, 
                    string password, 
                    string city, 
                    string birthDate, 
                    string gitHubAccount, 
                    string phoneNumber, 
                    string mehodistFirstName, 
                    string mehodistLastName, 
                    string mehodistPatronymic, 
                    string mehodistEmail, 
                    string mehodistUsername, 
                    string mehodistPassword, 
                    string mehodistCity, 
                    string mehodistBirthDate, 
                    string mehodistGitHubAccount, 
                    string mehodistPhoneNumber, 
                    string nameRole, 
                    string mehodistNameRole, 
                    string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
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
            argumentsOfScenario.Add("MehodistFirstName", mehodistFirstName);
            argumentsOfScenario.Add("MehodistLastName", mehodistLastName);
            argumentsOfScenario.Add("MehodistPatronymic", mehodistPatronymic);
            argumentsOfScenario.Add("MehodistEmail", mehodistEmail);
            argumentsOfScenario.Add("MehodistUsername", mehodistUsername);
            argumentsOfScenario.Add("MehodistPassword", mehodistPassword);
            argumentsOfScenario.Add("MehodistCity", mehodistCity);
            argumentsOfScenario.Add("MehodistBirthDate", mehodistBirthDate);
            argumentsOfScenario.Add("MehodistGitHubAccount", mehodistGitHubAccount);
            argumentsOfScenario.Add("MehodistPhoneNumber", mehodistPhoneNumber);
            argumentsOfScenario.Add("NameRole", nameRole);
            argumentsOfScenario.Add("MehodistNameRole", mehodistNameRole);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a manager, I want to create groups", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 26
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
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
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
                table4.AddRow(new string[] {
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
                table4.AddRow(new string[] {
                            string.Format("{0}", mehodistFirstName),
                            string.Format("{0}", mehodistLastName),
                            string.Format("{0}", mehodistPatronymic),
                            string.Format("{0}", mehodistEmail),
                            string.Format("{0}", mehodistUsername),
                            string.Format("{0}", mehodistPassword),
                            string.Format("{0}", mehodistCity),
                            string.Format("{0}", mehodistBirthDate),
                            string.Format("{0}", mehodistGitHubAccount),
                            string.Format("{0}", mehodistPhoneNumber)});
#line 27
    testRunner.Given("Create future manadger and methodist", ((string)(null)), table4, "Given ");
#line hidden
#line 31
 testRunner.And("Autorized as admin", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                            "NameRole"});
                table5.AddRow(new string[] {
                            string.Format("{0}", nameRole)});
                table5.AddRow(new string[] {
                            string.Format("{0}", mehodistNameRole)});
#line 32
 testRunner.And("Assing Minevra and Methodist roles", ((string)(null)), table5, "And ");
#line hidden
#line 36
 testRunner.When("Autorized by methodist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Description"});
                table6.AddRow(new string[] {
                            "QQQ",
                            "Где Q и как его выводить на экран три раза"});
#line 37
 testRunner.Given("Create Course by methodist", ((string)(null)), table6, "Given ");
#line hidden
#line 40
 testRunner.And("Autorized by manager", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "GroupStatusId",
                            "StartDate",
                            "EndDate",
                            "Timetable",
                            "PaymentPerMonth"});
                table7.AddRow(new string[] {
                            "Группа 1",
                            "1",
                            "28.01.2022",
                            "28.10.2022",
                            "пн, ср, пт 18:00 - 20:00",
                            "7500"});
#line 41
 testRunner.When("Create Groupe", ((string)(null)), table7, "When ");
#line hidden
#line 44
 testRunner.And("Get group by id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 45
 testRunner.Then("Compare group status code 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
