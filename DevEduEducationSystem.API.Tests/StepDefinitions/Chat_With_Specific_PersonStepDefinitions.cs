using DevEduEducationSystem.API.Tests.Support.Models.RequestModels;
using System;
using TechTalk.SpecFlow;

namespace DevEduEducationSystem.API.Tests.StepDefinitions
{
    [Binding]
    public class Chat_With_Specific_PersonStepDefinitions
    {
        private List<int> _idUser = new List<int>();
        private string _tokenAdmin;
        private string _tokenTeacher;
        private string _tokenStudent;
        private int _idCourse;
        private int _idGroup;
        private int _idTask;
        private int _idHomework;
        private int _idStudentHomework;

        [Given(@"Create Users")]
        public void GivenCreateUsers(Table table)
        {
            List<RegistrationRequestModel> users = table.CreateSet<RegistrationRequestModel>().ToList();
            List<RegistrationResponseModel> usersResponse = AuthClient.Registration(users);
            for(int i = 0; i < usersResponse.Count; i++)
            {
                _idUser.Add(usersResponse[i].Id);
            }
            ScenarioContext.Current["Users"] = users;
        }

        [Given(@"Autorized as Admin ""([^""]*)"" , ""([^""]*)""")]
        public void GivenAutorizedAsAdmin(string email, string password)
        {
            _tokenAdmin = AuthClient.AuthUser(email, password);
        }

        [Given(@"Assing user ""([^""]*)"" and removing the role assigned by default")]
        public void GivenAssingUser(string teacher)
        {
            AddRoleUsers.AddRole(teacher, _idUser[0], _tokenAdmin);
            DeleteClient.DeleteRoleFromUser(_tokenAdmin, "Student", _idUser[0]);
        }

        [Given(@"Create Course")]
        public void GivenCreateCourse(Table table)
        {
            CourseRequestModel courseRequest = table.CreateSet<CourseRequestModel>().ToList().First();
            CourseResponseModel courseResponse = AddEntitysClients.CreateCourse(_tokenAdmin, courseRequest);
            _idCourse = courseResponse.Id;
        }

        [Given(@"Create groupe")]
        public void GivenCreateGroupe(Table table)
        {
            GroupRequestModel groupRequest = table.CreateSet<GroupRequestModel>().ToList().First();
            groupRequest.CourseId = _idCourse;
            GroupResponseModel groupResponse = AddEntitysClients.CreateGroupe(_tokenAdmin, groupRequest);
            _idGroup = groupResponse.Id;
        }

        [Given(@"Add Users to group")]
        public void GivenAddUsersToGroup()
        {
            AddEntitysClients.AddUserInGroup(_idGroup, _idUser[0], "Teacher", _tokenAdmin);
            AddEntitysClients.AddUserInGroup(_idGroup, _idUser[1], "Student", _tokenAdmin);
        }

        [Given(@"Create Task")]
        public void GivenCreateTask(Table table)
        {
            TaskMethodistRequestModel taskRequest = table.CreateSet<TaskMethodistRequestModel>().ToList().First();
           TaskMethodistResponseModel taskResponse = AddEntitysClients.CreateTaskByMethodist(_tokenAdmin, taskRequest);
            _idTask = taskResponse.Id;
        }

        [Given(@"Authorized by Teacher")]
        public void GivenAuthorizedByTeacher()
        {
            List<RegistrationRequestModel> users = (List<RegistrationRequestModel>)ScenarioContext.Current["Users"];
            _tokenTeacher = AuthClient.AuthUser(users[0].Email, users[0].Password);
        }

        [Given(@"Create homework")]
        public void GivenCreateHomework(Table table)
        {
            HomeworkRequestModel homeworkRequest = table.CreateSet<HomeworkRequestModel>().ToList().First();
            HomeworkResponseModel homeworkResponse = AddEntitysClients.CreateHomework(_tokenTeacher, _idTask, _idGroup, homeworkRequest);
            _idHomework = homeworkResponse.Id;
            ScenarioContext.Current["Homework Request"] = homeworkRequest;
        }

        [Given(@"Authorized by student")]
        public void GivenAuthorizedByStudent()
        {
            List<RegistrationRequestModel> users = (List<RegistrationRequestModel>)ScenarioContext.Current["Users"];
            _tokenStudent = AuthClient.AuthUser(users[1].Email, users[1].Password);
        }

        [Given(@"I am a student adding my homework")]
        public void GivenIAmAStudentAddingMyHomework(Table table)
        {
            var studentHomeworkRequest = table.CreateSet<StudentHomeworkRequestModel>().ToList().First();
            var studentHomeworkResponse = AddEntitysClients.CreateStudentHomework(studentHomeworkRequest, _tokenStudent, _idHomework);
            _idStudentHomework = studentHomeworkResponse.Id;
            ScenarioContext.Current["Student Homework"] = studentHomeworkRequest;
        }

        [When(@"Add new comment to student answer")]
        public void WhenAddNewCommentToStudentAnswer(Table table)
        {
            CommentRequestModel commentRequest = table.CreateSet<CommentRequestModel>().ToList().First();
            CommentResponeseModel commentResponse = AddEntitysClients.CreateComment(_tokenTeacher, _idStudentHomework, commentRequest);
            ScenarioContext.Current["IdComment"] = commentResponse.Id;
            ScenarioContext.Current["Comment Request"] = commentRequest;
        }


        [When(@"Get comment by id")]
        public void WhenGetCommentById()
        {
            int idComment = (int)ScenarioContext.Current["IdComment"];
            ScenarioContext.Current["Return Comment by Id"] = GetClient.GetCommentById(idComment, _tokenTeacher);
        }

        [Then(@"Check the left comment should have returned")]
        public void ThenCheckTheLeftCommentShouldHaveReturned()
        {
            var users = (List<RegistrationRequestModel>)ScenarioContext.Current["Users"];
            var homework = (HomeworkRequestModel)ScenarioContext.Current["Homework Request"];
            var studHomework = (StudentHomeworkRequestModel)ScenarioContext.Current["Student Homework"];
            CommentRequestModel comment = (CommentRequestModel)ScenarioContext.Current["Comment Request"];
            CommentResponeseModel actual = (CommentResponeseModel)ScenarioContext.Current["Return Comment by Id"];
            CommentResponeseModel expected = new CommentResponeseModel()
            {
                Id = (int)ScenarioContext.Current["IdComment"],
                Text = comment.Text,
                Date = actual.Date,
                IsDeleted = false,
                User = new UserStudentHomework()
                {
                    Id = _idUser[1],
                    FirstName = users[1].FirstName,
                    LastName = users[1].LastName,
                    Email = users[1].Email,
                    Photo = null,
                    Roles = new List<string>() {"Student"}
                },
                StudentHomework = new StudentHomework()
                {
                    Id = _idStudentHomework,
                    Answer = studHomework.Answer,
                    CompletedDate = homework.EndDate
                }
            };
            Assert.AreEqual(expected, actual);
        }
    }
}
