using DevEduEducationSystem.API.Tests.Support.Models.RequestModels;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace DevEduEducationSystem.API.Tests.StepDefinitions
{
    [Binding]
    public class Homework_Creation_FeaturesStepDefinitions
    {
        private List<int> _userId = new List<int>();
        private string _tokenAdmin;
        private int _courseId;
        private int _groupeId;
        private int _taskMethodistId;
        private string _tokenTeacher;
        private int _homeworkId;

        [Given(@"Create  user")]
        public void GivenCreateUser(Table table)
        {
            List<RegistrationRequestModel> user = table.CreateSet<RegistrationRequestModel>().ToList();
            for (int i = 0; i < user.Count; i++)
            {
                RegistrationResponseModel userResponse = AuthClient.RegistrationReturnModel(user[i]);
                _userId.Add(userResponse.Id);
            }
            ScenarioContext.Current["User Request"] = user;
        }

        [Given(@"Autorized as admin ""([^""]*)"" , ""([^""]*)""")]
        public void GivenAutorizedAsAdmin(string email, string password)
        {
            _tokenAdmin = AuthClient.AuthUser(email,password);
        }

        [Given(@"Assing  User ""([^""]*)""")]
        public void GivenAssingUser(string teacher)
        {
            AddRoleUsers.AddRole(teacher, _userId[0], _tokenAdmin);
        }

        [Given(@"Create  course")]
        public void GivenCreateCourse(Table table)
        {
            CourseRequestModel courseRequest = table.CreateSet<CourseRequestModel>().ToList().First();
            CourseResponseModel courseResponse = AddEntitysClients.CreateCourse(_tokenAdmin, courseRequest);
            _courseId = courseResponse.Id;
        }

        [Given(@"Create  Groupe")]
        public void GivenCreateGroupe(Table table)
        {
            GroupRequestModel groupeRequest = table.CreateSet<GroupRequestModel>().ToList().First();
            groupeRequest.CourseId = _courseId;
            GroupResponseModel groupeResponse = AddEntitysClients.CreateGroupe(_tokenAdmin, groupeRequest);
            _groupeId = groupeResponse.Id;
            ScenarioContext.Current["Groupe Request"] = groupeRequest;
        }

        [Given(@"Add users to group")]
        public void GivenAddUserToGroup()
        {
            AddEntitysClients.AddUserInGroup(_groupeId, _userId[0], "Student", _tokenAdmin);
            AddEntitysClients.AddUserInGroup(_groupeId, _userId[1], "Student", _tokenAdmin);
        }

        [Given(@"Create task")]
        public void GivenCreateTask(Table table)
        {
            var taskRequest = table.CreateSet<TaskMethodistRequestModel>().ToList().First();
            var taskResponse = AddEntitysClients.CreateTaskByMethodist(_tokenAdmin, taskRequest);
            _taskMethodistId = taskResponse.Id;
            ScenarioContext.Current["Task Request"] = taskRequest;
        }

        [Given(@"Authorized by teacher")]
        public void GivenAuthorazedByTeacher()
        {
            List<RegistrationRequestModel> user = (List<RegistrationRequestModel>)ScenarioContext.Current["User Request"];
            _tokenTeacher = AuthClient.AuthUser(user[0].Email, user[0].Password);
        }

        [Given(@"Create Homework")]
        [When(@"Create Homework")]
        public void WhenCreateHomework(Table table)
        {
            var homeworkRequest = table.CreateSet<HomeworkRequestModel>().ToList().First();
            var homeworkResponse = AddEntitysClients.CreateHomework(_tokenTeacher, _taskMethodistId, _groupeId, homeworkRequest);
            ScenarioContext.Current["Homework Request"] = homeworkRequest;
            FeatureContext.Current["Homework Response"] = homeworkResponse;
            _homeworkId = homeworkResponse.Id;
        }


        [When(@"Get Homework By Id")]
        public void WhenGetHomeWorkById()
        {
           var homeworkResponse = (HomeworkResponseModel)FeatureContext.Current["Homework Response"];
           FeatureContext.Current["Get Homework by Id"] = GetClient.GetHomeworkById(_tokenTeacher, homeworkResponse.Id);
           _homeworkId = homeworkResponse.Id;
        }

        [Then(@"Created homework should return")]
        public void ThenCreatedHomeworkShouldReturn()
        {
            TaskMethodistRequestModel taskRequest = (TaskMethodistRequestModel)ScenarioContext.Current["Task Request"];
            GroupRequestModel groupRequest = (GroupRequestModel)ScenarioContext.Current["Groupe Request"];
            GetHomeworkByIdResponseModel actual = (GetHomeworkByIdResponseModel)FeatureContext.Current["Get Homework by Id"];
            var homeworkRequest = (HomeworkRequestModel)ScenarioContext.Current["Homework Request"];
            GetHomeworkByIdResponseModel expected = new GetHomeworkByIdResponseModel()
            {
                Id = _homeworkId,
                StartDate = homeworkRequest.StartDate,
                EndDate = homeworkRequest.EndDate,
                Group = new GroupHomework()
                {
                    StartDate = groupRequest.StartDate,
                    GroupStatus = "Forming",
                    Id = _groupeId,
                    Name = groupRequest.Name,
                    IsDeleted = false
                },
                Task = new TaskMethodistResponseModel()
                {
                    Id = _taskMethodistId,
                    Description = taskRequest.Description,
                    Name = taskRequest.Name,
                    Links = taskRequest.Links,
                    IsRequired = taskRequest.IsRequired,
                    IsDeleted = false
                }
            };

            Assert.AreEqual(expected, actual);
        }

        // new Scenario Create Homework.Negative

        [Then(@"The created homework status code should be (.*)")]
        public void ThenTheCreatedHomeworkStatusCodeShouldBe(int statusCode)
        {
            HttpResponseMessage httpResponse = AddEntitysClients.CreateHomework();
            HttpStatusCode expected = (HttpStatusCode)statusCode;
            HttpStatusCode actual = httpResponse.StatusCode;
            Assert.AreEqual(expected, actual);
        }

        // new Scenario Edit homework by teacher

        [When(@"Edit a previously created homework")]
        public void WhenEditAPreviouslyCreatedHomework(Table table)
        {
            HomeworkRequestModel homeworkUpdate = table.CreateSet<HomeworkRequestModel>().ToList().First();
            UpdateClient.UpdateHomework(_tokenTeacher, homeworkUpdate, _homeworkId);
            ScenarioContext.Current["Update Homework"] = homeworkUpdate;
        }

        [Then(@"—heck the modified homework should have come")]
        public void Then—heckTheModifiedHomeworkShouldHaveCome()
        {
            GetHomeworkByIdResponseModel actual = (GetHomeworkByIdResponseModel)FeatureContext.Current["Get Homework by Id"];
            HomeworkRequestModel expected = (HomeworkRequestModel)ScenarioContext.Current["Update Homework"];
            Assert.AreEqual(expected.StartDate, actual.StartDate);
            Assert.AreEqual(expected.EndDate, actual.EndDate);
        }



    }
}
