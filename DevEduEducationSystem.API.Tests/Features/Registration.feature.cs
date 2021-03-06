// ------------------------------------------------------------------------------
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
    [NUnit.Framework.DescriptionAttribute("User CRUD")]
    public partial class UserCRUDFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "Registration.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "User CRUD", "Страница регистрации новых клиентов (студентов)", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Registration in system")]
        [NUnit.Framework.CategoryAttribute("User")]
        [NUnit.Framework.TestCaseAttribute("Северус", "Снейп", "Аланович", "severus@mail.ru", "север", "северусСнейп", "SaintPetersburg", "01.01.1993", "string", "89991234567", null)]
        [NUnit.Framework.TestCaseAttribute("Северус", "Снейп", "Аланович", "severus@mail.ru", "север", "северусСнейп", "SaintPetersburg", "01.01.1993", "string", "89991234567", null)]
        public virtual void RegistrationInSystem(string firstName, string lastName, string patronymic, string email, string username, string password, string city, string birthDate, string gitHubAccount, string phoneNumber, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "User"};
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
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Registration in system", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
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
                TechTalk.SpecFlow.Table table176 = new TechTalk.SpecFlow.Table(new string[] {
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
                table176.AddRow(new string[] {
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
 testRunner.When("I register", ((string)(null)), table176, "When ");
#line hidden
#line 10
 testRunner.And(string.Format("Autorized by {0} and {1}", email, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 11
 testRunner.And("Get User by my Id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 12
 testRunner.Then("Should User Models coincide with the returned models of these entities", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Registration in system. Negative")]
        [NUnit.Framework.CategoryAttribute("Negative")]
        [NUnit.Framework.TestCaseAttribute("Малыш", "Малышев", "Малышович", "Малыш@mail.ru", "БоссМолокосос", "северусСнейп", "SaintPetersburg", "09.01.2021", "string", "89991234567", null)]
        [NUnit.Framework.TestCaseAttribute("Альбрехт", "Вильгельм", "Эдуардович", "Вильгельм@mail.ru", "Альбрехт", "Вильгельм", "SaintPetersburg", "04.03.1800", "string", "89991234567", null)]
        [NUnit.Framework.TestCaseAttribute("Телефон", "Телефонов", "Телефонович", "Телефон@mail.ru", "Телефончик", "Телефонама", "SaintPetersburg", "04.03.2003", "string", "Чукча кушать хочет", null)]
        [NUnit.Framework.TestCaseAttribute("", "", "", "", "", "", "", "", "", "", null)]
        public virtual void RegistrationInSystem_Negative(string firstName, string lastName, string patronymic, string email, string username, string password, string city, string birthDate, string gitHubAccount, string phoneNumber, string[] exampleTags)
        {
            string[] @__tags = new string[] {
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
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Registration in system. Negative", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
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
                TechTalk.SpecFlow.Table table177 = new TechTalk.SpecFlow.Table(new string[] {
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
                table177.AddRow(new string[] {
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
 testRunner.When("I try to register as", ((string)(null)), table177, "When ");
#line hidden
#line 24
 testRunner.Then("Should return 422 status code response", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Update User")]
        [NUnit.Framework.CategoryAttribute("User")]
        [NUnit.Framework.TestCaseAttribute("Северус", "Снейп", "Аланович", "severus@mail.ru", "север", "Qwerty123", "SaintPetersburg", "01.01.1993", "string", "89991234567", "Богданов", "Арутр", "Ашотович", "Ashot", "severus@mail.ru", "Dnipro", "01.02.1993", "string", "89991234563", null)]
        public virtual void UpdateUser(
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
                    string newUsername, 
                    string newEmail, 
                    string newCity, 
                    string newBirthDate, 
                    string newGitHubAccount, 
                    string newPhoneNumber, 
                    string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "User"};
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
            argumentsOfScenario.Add("NewUsername", newUsername);
            argumentsOfScenario.Add("NewEmail", newEmail);
            argumentsOfScenario.Add("NewCity", newCity);
            argumentsOfScenario.Add("NewBirthDate", newBirthDate);
            argumentsOfScenario.Add("NewGitHubAccount", newGitHubAccount);
            argumentsOfScenario.Add("NewPhoneNumber", newPhoneNumber);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update User", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 33
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
                TechTalk.SpecFlow.Table table178 = new TechTalk.SpecFlow.Table(new string[] {
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
                table178.AddRow(new string[] {
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
#line 34
 testRunner.Given("I register", ((string)(null)), table178, "Given ");
#line hidden
#line 37
 testRunner.When(string.Format("Autorized by {0} and {1}", email, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table179 = new TechTalk.SpecFlow.Table(new string[] {
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
                table179.AddRow(new string[] {
                            string.Format("{0}", newFirstName),
                            string.Format("{0}", newLastName),
                            string.Format("{0}", newPatronymic),
                            string.Format("{0}", newEmail),
                            string.Format("{0}", newUsername),
                            "<NewPassword>",
                            string.Format("{0}", newCity),
                            string.Format("{0}", newBirthDate),
                            string.Format("{0}", newGitHubAccount),
                            string.Format("{0}", newPhoneNumber)});
#line 38
 testRunner.And("I Update myself", ((string)(null)), table179, "And ");
#line hidden
#line 41
 testRunner.And("Get User by my Id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 42
 testRunner.Then("Should User Models coincide with the returned models of these entities", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete User")]
        [NUnit.Framework.CategoryAttribute("Negative")]
        [NUnit.Framework.TestCaseAttribute("QQQ", "YYY", "AAA", "QYA@mail.ru", "QYA", "qwerty123", "SaintPetersburg", "02.02.1992", "string", "89991234567", null)]
        public virtual void DeleteUser(string firstName, string lastName, string patronymic, string email, string username, string password, string city, string birthDate, string gitHubAccount, string phoneNumber, string[] exampleTags)
        {
            string[] @__tags = new string[] {
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
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete User", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 49
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
                TechTalk.SpecFlow.Table table180 = new TechTalk.SpecFlow.Table(new string[] {
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
                table180.AddRow(new string[] {
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
#line 50
 testRunner.Given("I register", ((string)(null)), table180, "Given ");
#line hidden
#line 53
 testRunner.When(string.Format("Autorized by {0} and {1}", email, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 54
 testRunner.And("I Deleted created User By ID", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 55
 testRunner.Then(string.Format("Delete user can not pass authorization by {0} and {1}", email, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 56
 testRunner.And("Delete user not found in list all Users", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
