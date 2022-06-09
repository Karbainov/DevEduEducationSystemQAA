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
namespace DevEduEducationSystemQAA.WEB.Tests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Settings_Window")]
    public partial class Settings_WindowFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "Settings_Window.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Settings_Window", "Окно настроект. Иземенение, данных пользователя", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("As a user, I want to change my details and save them")]
        [NUnit.Framework.CategoryAttribute("SettingWindow")]
        [NUnit.Framework.TestCaseAttribute("1920", "1080", null)]
        public virtual void AsAUserIWantToChangeMyDetailsAndSaveThem(string length, string width, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SettingWindow"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("length", length);
            argumentsOfScenario.Add("width", width);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user, I want to change my details and save them", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
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
                TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table21.AddRow(new string[] {
                            "userTestStudent@example.com",
                            "userTestStudent"});
#line 7
 testRunner.Given(string.Format("I log in to the system  with the window size {0} and {1}", length, width), ((string)(null)), table21, "Given ");
#line hidden
#line 10
 testRunner.And("I click the button Setting", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table22 = new TechTalk.SpecFlow.Table(new string[] {
                            "Surname",
                            "Name",
                            "Patronymic",
                            "BirthDate",
                            "Password",
                            "RepeatPassword",
                            "Email",
                            "Phone",
                            "LinkByGitHub"});
                table22.AddRow(new string[] {
                            "Ignatov",
                            "Ignat",
                            "Ignatovich",
                            "31.08.1998",
                            "HarryPotter",
                            "HarryPotter",
                            "Harry@mail.ru",
                            "89990089090",
                            "https://github.com/"});
#line 11
 testRunner.And("I enter data in the fields that I want to change", ((string)(null)), table22, "And ");
#line hidden
#line 14
 testRunner.When("Button click save in window setting", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 15
 testRunner.Then("Refresh the page changes should be saved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a user, I want to change my details and cancel them")]
        [NUnit.Framework.CategoryAttribute("SettingWindow")]
        [NUnit.Framework.TestCaseAttribute("1920", "1080", null)]
        public virtual void AsAUserIWantToChangeMyDetailsAndCancelThem(string length, string width, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SettingWindow"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("length", length);
            argumentsOfScenario.Add("width", width);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user, I want to change my details and cancel them", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 21
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
                TechTalk.SpecFlow.Table table23 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table23.AddRow(new string[] {
                            "userTestStudent@example.com",
                            "userTestStudent"});
#line 22
 testRunner.Given(string.Format("I log in to the system  with the window size {0} and {1}", length, width), ((string)(null)), table23, "Given ");
#line hidden
#line 25
 testRunner.And("I click the button Setting", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table24 = new TechTalk.SpecFlow.Table(new string[] {
                            "Surname",
                            "Name",
                            "Patronymic",
                            "BirthDate",
                            "Password",
                            "RepeatPassword",
                            "Email",
                            "Phone",
                            "LinkByGitHub"});
                table24.AddRow(new string[] {
                            "James",
                            "Harry",
                            "Potter",
                            "31.08.1998",
                            "HarryPotter",
                            "HarryPotter",
                            "Harry@mail.ru",
                            "89211234567",
                            "https://github.com/"});
#line 26
 testRunner.And("I enter data in the fields that I want to change", ((string)(null)), table24, "And ");
#line hidden
#line 29
 testRunner.When("Button click cancel in window setting", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 30
 testRunner.Then("Should return to the notification window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table25 = new TechTalk.SpecFlow.Table(new string[] {
                            "Surname",
                            "Name",
                            "Patronymic",
                            "BirthDate",
                            "Password",
                            "RepeatPassword",
                            "Email",
                            "Phone",
                            "LinkByGitHub"});
                table25.AddRow(new string[] {
                            "Ignatov",
                            "Ignat",
                            "Ignatovich",
                            "31.08.1998",
                            "HarryPotter",
                            "HarryPotter",
                            "Harry@mail.ru",
                            "89990089090",
                            "https://github.com/"});
#line 31
 testRunner.Then("Check that the changes are not saved", ((string)(null)), table25, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As user, I want change my password and save")]
        [NUnit.Framework.CategoryAttribute("SettingWindow")]
        [NUnit.Framework.TestCaseAttribute("1920", "1080", null)]
        public virtual void AsUserIWantChangeMyPasswordAndSave(string length, string width, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SettingWindow"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("length", length);
            argumentsOfScenario.Add("width", width);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As user, I want change my password and save", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 39
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
                TechTalk.SpecFlow.Table table26 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table26.AddRow(new string[] {
                            "userTestStudent@example.com",
                            "userTestStudent"});
#line 40
 testRunner.Given(string.Format("I log in to the system  with the window size {0} and {1}", length, width), ((string)(null)), table26, "Given ");
#line hidden
#line 43
 testRunner.And("I click the button Setting", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 44
 testRunner.When("Click on the pencil", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table27 = new TechTalk.SpecFlow.Table(new string[] {
                            "Password"});
                table27.AddRow(new string[] {
                            "ignatignat"});
#line 45
 testRunner.Given("Fill in the fields with data to change the password", ((string)(null)), table27, "Given ");
#line hidden
#line 48
 testRunner.When("Button click save in window update password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 49
 testRunner.Then("Check that the password has changed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As user, I want change my password and button click back")]
        [NUnit.Framework.CategoryAttribute("SettingWindow")]
        [NUnit.Framework.TestCaseAttribute("1920", "1080", null)]
        public virtual void AsUserIWantChangeMyPasswordAndButtonClickBack(string length, string width, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SettingWindow"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("length", length);
            argumentsOfScenario.Add("width", width);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As user, I want change my password and button click back", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 55
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
                TechTalk.SpecFlow.Table table28 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table28.AddRow(new string[] {
                            "userTestStudent@example.com",
                            "userTestStudent"});
#line 56
 testRunner.Given(string.Format("I log in to the system  with the window size {0} and {1}", length, width), ((string)(null)), table28, "Given ");
#line hidden
#line 59
 testRunner.And("I click the button Setting", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 60
 testRunner.When("Click on the pencil", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table29 = new TechTalk.SpecFlow.Table(new string[] {
                            "Password"});
                table29.AddRow(new string[] {
                            "ignatignat"});
#line 61
 testRunner.Given("Fill in the fields with data to change the password", ((string)(null)), table29, "Given ");
#line hidden
#line 64
 testRunner.When("Button click back in window update password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 65
 testRunner.Then("Back to settings window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As user, I want change my password and cancel")]
        [NUnit.Framework.CategoryAttribute("SettingWindow")]
        [NUnit.Framework.TestCaseAttribute("1920", "1080", null)]
        public virtual void AsUserIWantChangeMyPasswordAndCancel(string length, string width, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SettingWindow"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("length", length);
            argumentsOfScenario.Add("width", width);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As user, I want change my password and cancel", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 71
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
                            "Email",
                            "Password"});
                table30.AddRow(new string[] {
                            "userTestStudent@example.com",
                            "userTestStudent"});
#line 72
 testRunner.Given(string.Format("I log in to the system  with the window size {0} and {1}", length, width), ((string)(null)), table30, "Given ");
#line hidden
#line 75
 testRunner.And("I click the button Setting", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 76
 testRunner.When("Click on the pencil", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table31 = new TechTalk.SpecFlow.Table(new string[] {
                            "Password"});
                table31.AddRow(new string[] {
                            "ignatignat"});
#line 77
 testRunner.Given("Fill in the fields with data to change the password", ((string)(null)), table31, "Given ");
#line hidden
#line 80
 testRunner.When("Button click cancel in window update password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 81
 testRunner.Then("Check that the password don\'t has changed and moved to the last window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As user, I wand add or change photo to my profile and save")]
        [NUnit.Framework.CategoryAttribute("SettingWindow")]
        [NUnit.Framework.TestCaseAttribute("1920", "1080", null)]
        public virtual void AsUserIWandAddOrChangePhotoToMyProfileAndSave(string length, string width, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SettingWindow"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("length", length);
            argumentsOfScenario.Add("width", width);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As user, I wand add or change photo to my profile and save", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 87
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
                            "Email",
                            "Password"});
                table32.AddRow(new string[] {
                            "userTestStudent@example.com",
                            "userTestStudent"});
#line 88
 testRunner.Given(string.Format("I log in to the system  with the window size {0} and {1}", length, width), ((string)(null)), table32, "Given ");
#line hidden
#line 91
 testRunner.And("I click the button Setting", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 92
 testRunner.When("I user, I click text Upload new photo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 93
 testRunner.Then("A window should appear with cancel buttons and select a file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 94
 testRunner.Given("Click button Select a file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 95
 testRunner.Then("Photo should be changed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As user, I want add or change photo to my profile and cancel")]
        [NUnit.Framework.CategoryAttribute("SettingWindow")]
        [NUnit.Framework.TestCaseAttribute("1920", "1080", null)]
        public virtual void AsUserIWantAddOrChangePhotoToMyProfileAndCancel(string length, string width, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SettingWindow"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("length", length);
            argumentsOfScenario.Add("width", width);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As user, I want add or change photo to my profile and cancel", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 101
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
                            "Email",
                            "Password"});
                table33.AddRow(new string[] {
                            "userTestStudent@example.com",
                            "userTestStudent"});
#line 102
 testRunner.Given(string.Format("I log in to the system  with the window size {0} and {1}", length, width), ((string)(null)), table33, "Given ");
#line hidden
#line 105
 testRunner.And("I click the button Setting", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 106
 testRunner.And("I user, I click text Upload new photo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 107
 testRunner.When("Click on the cancel button to deselect the photo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 108
 testRunner.Then("The message box for choosing a photo should close", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a user, I want to change my details and save them.Negative")]
        [NUnit.Framework.CategoryAttribute("Negative")]
        [NUnit.Framework.TestCaseAttribute("1920", "1080", null)]
        public virtual void AsAUserIWantToChangeMyDetailsAndSaveThem_Negative(string length, string width, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Negative"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("length", length);
            argumentsOfScenario.Add("width", width);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user, I want to change my details and save them.Negative", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 114
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
                TechTalk.SpecFlow.Table table34 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "Password"});
                table34.AddRow(new string[] {
                            "userTestStudent@example.com",
                            "userTestStudent"});
#line 115
 testRunner.Given(string.Format("I log in to the system  with the window size {0} and {1}", length, width), ((string)(null)), table34, "Given ");
#line hidden
#line 118
 testRunner.And("I click the button Setting", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table35 = new TechTalk.SpecFlow.Table(new string[] {
                            "Surname",
                            "Name",
                            "Patronymic",
                            "BirthDate",
                            "Password",
                            "RepeatPassword",
                            "Email",
                            "Phone",
                            "LinkByGitHub"});
                table35.AddRow(new string[] {
                            "Ignatov",
                            "Ignat",
                            "Ignatovich",
                            "31.08.1998",
                            "HarryPotter",
                            "HarryPotter",
                            "sasasa@mail.ru",
                            "89990089090",
                            "https://github.com/"});
#line 119
 testRunner.When("I clean and new enter email that I want to change", ((string)(null)), table35, "When ");
#line hidden
#line 122
 testRunner.Then("Check that the email field is not cleared", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
