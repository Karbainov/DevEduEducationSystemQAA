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
    [NUnit.Framework.DescriptionAttribute("MethodistCheckBaseFunctional")]
    public partial class MethodistCheckBaseFunctionalFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "MethodistCheckBaseFunctional.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "MethodistCheckBaseFunctional", "Check base functional for Methodist", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("User in role methodist create new course")]
        [NUnit.Framework.CategoryAttribute("Metodist")]
        [NUnit.Framework.TestCaseAttribute("Ivan", "Troyanov", "Petrovich", "TroyanovIP@mail.ru", "IvanPT", "qwerty123", "Dnipro", "02.02.1993", "string", "89991234567", "Samiy luchshiy kurs", "Samiy luchshiy kurs", "Methodist", null)]
        public virtual void UserInRoleMethodistCreateNewCourse(string firstName, string lastName, string patronymic, string email, string username, string password, string city, string birthDate, string gitHubAccount, string phoneNumber, string name, string description, string role, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Metodist"};
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
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User in role methodist create new course", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
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
                TechTalk.SpecFlow.Table table25 = new TechTalk.SpecFlow.Table(new string[] {
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
                table25.AddRow(new string[] {
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
 testRunner.Given("I create new user and get his token", ((string)(null)), table25, "Given ");
#line hidden
#line 10
 testRunner.And(string.Format("I login as an admin and give new user role {0}", role), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table26 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Description"});
                table26.AddRow(new string[] {
                            string.Format("{0}", name),
                            string.Format("{0}", description)});
#line 11
 testRunner.When("I login as an Methodist and create new course", ((string)(null)), table26, "When ");
#line hidden
#line 14
 testRunner.Then("Should Course Models coincide with the returned models of these entities", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User in role methodist update course")]
        [NUnit.Framework.CategoryAttribute("Metodist")]
        [NUnit.Framework.TestCaseAttribute("Ivan", "Troyanov", "Petrovich", "TroyanovIP@mail.ru", "IvanPT", "qwerty123", "Dnipro", "02.02.1993", "string", "899912349954", "Samiy luchshiy kurs", "Samiy luchshiy kurs", "Samiy luchshiy kurs v tvoei", "Samiy luchshiy kurs v tvoei", "Methodist", null)]
        public virtual void UserInRoleMethodistUpdateCourse(
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
                    string name, 
                    string description, 
                    string newName, 
                    string newDescription, 
                    string role, 
                    string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Metodist"};
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
            argumentsOfScenario.Add("NewName", newName);
            argumentsOfScenario.Add("NewDescription", newDescription);
            argumentsOfScenario.Add("Role", role);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User in role methodist update course", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 20
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
                TechTalk.SpecFlow.Table table27 = new TechTalk.SpecFlow.Table(new string[] {
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
                table27.AddRow(new string[] {
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
#line 21
 testRunner.Given("I create new user and get his token", ((string)(null)), table27, "Given ");
#line hidden
#line 24
 testRunner.And(string.Format("I login as an admin and give new user role {0}", role), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table28 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Description"});
                table28.AddRow(new string[] {
                            string.Format("{0}", name),
                            string.Format("{0}", description)});
#line 25
 testRunner.When("I login as an Methodist and create new course", ((string)(null)), table28, "When ");
#line hidden
                TechTalk.SpecFlow.Table table29 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Description"});
                table29.AddRow(new string[] {
                            string.Format("{0}", newName),
                            string.Format("{0}", newDescription)});
#line 28
 testRunner.And("I update new course", ((string)(null)), table29, "And ");
#line hidden
#line 31
 testRunner.Then("Should new course model coincide with the returned model of changes entities", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User in role methodist can get course by ID")]
        [NUnit.Framework.CategoryAttribute("Metodist")]
        [NUnit.Framework.TestCaseAttribute("Ivan", "Troyanov", "Petrovich", "TroyanovIP@mail.ru", "IvanPT", "qwerty123", "Dnipro", "02.02.1993", "string", "899912349954", "Samiy luchshiy kurs v tvoei zchizni", "Samiy luchshiy kurs v tvoei zchizni", "Methodist", null)]
        public virtual void UserInRoleMethodistCanGetCourseByID(string firstName, string lastName, string patronymic, string email, string username, string password, string city, string birthDate, string gitHubAccount, string phoneNumber, string name, string description, string role, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Metodist"};
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
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User in role methodist can get course by ID", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 37
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
                TechTalk.SpecFlow.Table table30 = new TechTalk.SpecFlow.Table(new string[] {
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
                table30.AddRow(new string[] {
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
#line 38
 testRunner.Given("I create new user and get his token", ((string)(null)), table30, "Given ");
#line hidden
#line 41
 testRunner.And(string.Format("I login as an admin and give new user role {0}", role), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table31 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Description"});
                table31.AddRow(new string[] {
                            string.Format("{0}", name),
                            string.Format("{0}", description)});
#line 42
 testRunner.When("I login as an Methodist and create new course", ((string)(null)), table31, "When ");
#line hidden
#line 45
 testRunner.Then("Should course model coincide with the returned model", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User in role methodist can get course by ID.Negative")]
        [NUnit.Framework.CategoryAttribute("Metodist")]
        [NUnit.Framework.CategoryAttribute("Negative")]
        [NUnit.Framework.TestCaseAttribute("Ivan", "Troyanov", "Petrovich", "TroyanovIP@mail.ru", "IvanPT", "qwerty123", "Dnipro", "02.02.1993", "string", "899912349954", "ProstoCourse", "l;sjdhsg", "Methodist", "-1", null)]
        [NUnit.Framework.TestCaseAttribute("Petr", "Seredin", "Petrovich", "Seredin@mail.ru", "SeredinPP", "qwerty123", "Dnipro", "02.02.1993", "string", "899912347896", "ProstoCourse2", "l;sjdhsg", "Methodist", "0", null)]
        public virtual void UserInRoleMethodistCanGetCourseByID_Negative(string firstName, string lastName, string patronymic, string email, string username, string password, string city, string birthDate, string gitHubAccount, string phoneNumber, string name, string description, string role, string id, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Metodist",
                    "Negative"};
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
            argumentsOfScenario.Add("Id", id);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User in role methodist can get course by ID.Negative", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 51
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
                TechTalk.SpecFlow.Table table32 = new TechTalk.SpecFlow.Table(new string[] {
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
                table32.AddRow(new string[] {
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
#line 52
 testRunner.Given("I create new user and get his token", ((string)(null)), table32, "Given ");
#line hidden
#line 55
 testRunner.And(string.Format("I login as an admin and give new user role {0}", role), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 56
 testRunner.When(string.Format("I login as an Methodist and get course by not existing Id {0}", id), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 57
 testRunner.Then("Should return 404 code response status", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User in role methodist can delete course by ID")]
        [NUnit.Framework.CategoryAttribute("Metodist")]
        [NUnit.Framework.TestCaseAttribute("Ivan", "Troyanov", "Petrovich", "TroyanovIP@mail.ru", "IvanPT", "qwerty123", "Dnipro", "02.02.1993", "string", "899912349954", "Samiy luchshiy kurs v tvoei zchizni", "Samiy luchshiy kurs v tvoei zchizni", "Methodist", null)]
        public virtual void UserInRoleMethodistCanDeleteCourseByID(string firstName, string lastName, string patronymic, string email, string username, string password, string city, string birthDate, string gitHubAccount, string phoneNumber, string name, string description, string role, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Metodist"};
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
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User in role methodist can delete course by ID", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 64
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
                TechTalk.SpecFlow.Table table33 = new TechTalk.SpecFlow.Table(new string[] {
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
                table33.AddRow(new string[] {
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
#line 65
 testRunner.Given("I create new user and get his token", ((string)(null)), table33, "Given ");
#line hidden
#line 68
 testRunner.And(string.Format("I login as an admin and give new user role {0}", role), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table34 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Description"});
                table34.AddRow(new string[] {
                            string.Format("{0}", name),
                            string.Format("{0}", description)});
#line 69
 testRunner.When("I login as an Methodist and create new course", ((string)(null)), table34, "When ");
#line hidden
#line 72
 testRunner.And("I deleting new course", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 73
 testRunner.And("I get new course by id full models", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 74
 testRunner.And("I get all courses", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 75
 testRunner.Then("Field IsDeleted full models course must be true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 76
 testRunner.Then("In the list of all courses can\'t be a remote course", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User in role methodist can see all courses")]
        [NUnit.Framework.CategoryAttribute("Metodist")]
        [NUnit.Framework.TestCaseAttribute("Ivan", "Troyanov", "Petrovich", "TroyanovIP@mail.ru", "IvanPT", "qwerty123", "Dnipro", "02.02.1993", "string", "899912349954", "Methodist", null)]
        public virtual void UserInRoleMethodistCanSeeAllCourses(string firstName, string lastName, string patronymic, string email, string username, string password, string city, string birthDate, string gitHubAccount, string phoneNumber, string role, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Metodist"};
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
            argumentsOfScenario.Add("Role", role);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User in role methodist can see all courses", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 82
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
                TechTalk.SpecFlow.Table table35 = new TechTalk.SpecFlow.Table(new string[] {
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
                table35.AddRow(new string[] {
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
#line 83
 testRunner.Given("I create new user and get his token", ((string)(null)), table35, "Given ");
#line hidden
#line 86
 testRunner.And(string.Format("I login as an admin and give new user role {0}", role), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table36 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Description"});
                table36.AddRow(new string[] {
                            "Course 1",
                            "Samiy luchshiy kurs"});
                table36.AddRow(new string[] {
                            "Course 2",
                            "Samiy luchshiy kurs v tvoei zchizni"});
                table36.AddRow(new string[] {
                            "Course 3",
                            "Samiy luchshiy kurs v tvoei zchizni.Perezagruzka."});
#line 87
 testRunner.When("I login as an Methodist and create new courses", ((string)(null)), table36, "When ");
#line hidden
#line 92
 testRunner.And("I get all courses", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 93
 testRunner.Then("The list contains all created courses", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
