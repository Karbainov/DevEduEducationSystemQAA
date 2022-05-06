using DevEduEducationSystem.API.Tests.Support.Models.CourseResponseModelForAdd;
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
        private string _tokenTutor;

        [Given(@"Create Users")]
        public void GivenCreateUsers(Table table)
        {
            List<RegistrationRequestModel> users = table.CreateSet<RegistrationRequestModel>().ToList();
            List<RegistrationResponseModel> usersResponse = AuthClient.Registration(users);
            for(int i = 0; i < usersResponse.Count; i++)
            {
                _idUser.Add(usersResponse[i].Id);
            }
            FeatureContext.Current["Users"] = users;
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
            if(_idUser.Count == 3)
            {
                AddEntitysClients.AddUserInGroup(_idGroup, _idUser[2], "Tutor", _tokenAdmin);
            }
        }

        [Given(@"Create Task")]
        public void GivenCreateTask(Table table)
        {
            TaskMethodistRequestModel taskRequest = table.CreateSet<TaskMethodistRequestModel>().ToList().First();
            TaskResponseModel taskResponse = AddEntitysClients.CreateTaskByMethodist(_tokenAdmin, taskRequest);
            _idTask = taskResponse.Id;
            FeatureContext.Current["Task Request"] = taskRequest;
        }

        [Given(@"Authorized by Teacher")]
        public void GivenAuthorizedByTeacher()
        {
            List<RegistrationRequestModel> users = (List<RegistrationRequestModel>)FeatureContext.Current["Users"];
            _tokenTeacher = AuthClient.AuthUser(users[0].Email, users[0].Password);
        }

        [Given(@"Create homework")]
        public void GivenCreateHomework(Table table)
        {
            HomeworkRequestModel homeworkRequest = table.CreateSet<HomeworkRequestModel>().ToList().First();
            HomeworkResponseModel homeworkResponse = AddEntitysClients.CreateHomework(_tokenTeacher, _idTask, _idGroup, homeworkRequest);
            _idHomework = homeworkResponse.Id;
            FeatureContext.Current["Homework Request"] = homeworkRequest;
        }

        [Given(@"Authorized by student")]
        public void GivenAuthorizedByStudent()
        {
            List<RegistrationRequestModel> users = (List<RegistrationRequestModel>)FeatureContext.Current["Users"];
            _tokenStudent = AuthClient.AuthUser(users[1].Email, users[1].Password);
        }

        [Given(@"I am a student adding my homework")]
        public void GivenIAmAStudentAddingMyHomework(Table table)
        {
            var studentHomeworkRequest = table.CreateSet<StudentHomeworkRequestModel>().ToList().First();
            var studentHomeworkResponse = AddEntitysClients.CreateStudentHomework(studentHomeworkRequest, _tokenStudent, _idHomework);
            _idStudentHomework = studentHomeworkResponse.Id;
            FeatureContext.Current["Student Homework"] = studentHomeworkRequest;
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
            var users = (List<RegistrationRequestModel>)FeatureContext.Current["Users"];
            var homework = (HomeworkRequestModel)FeatureContext.Current["Homework Request"];
            var studHomework = (StudentHomeworkRequestModel)FeatureContext.Current["Student Homework"];
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

        // new Scebario (Add comment as tutor)

        [Given(@"Assing user ""([^""]*)"" and ""([^""]*)"" removing the role assigned by default")]
        public void GivenAssingUserAndRemovingTheRoleAssignedByDefault(string teacher, string tutor)
        {
            AddRoleUsers.AddRole(teacher, _idUser[0], _tokenAdmin);
            AddRoleUsers.AddRole(tutor, _idUser[2], _tokenAdmin);
            DeleteClient.DeleteRoleFromUser(_tokenAdmin, "Student", _idUser[0]);
            DeleteClient.DeleteRoleFromUser(_tokenAdmin, "Student", _idUser[2]);
        }

        [Given(@"Authorized by Tutor")]
        public void GivenAuthorizedByTutor()
        {
           List<RegistrationRequestModel> users = (List<RegistrationRequestModel>)FeatureContext.Current["Users"];
           _tokenTutor = AuthClient.AuthUser(users[2].Email,users[2].Password);
        }

        [When(@"Add as tutor new comment to student answer")]
        public void WhenAddAsTutorNewCommentToStudentAnswer(Table table)
        {
            CommentRequestModel comment = table.CreateSet<CommentRequestModel>().ToList().First();
            ScenarioContext.Current["Comment Response"] = AddEntitysClients.CreateComment(_tokenTutor, _idStudentHomework, comment);
        }

        [When(@"Get comment by ID")]
        public void WhenGetCommentByID()
        {
           CommentResponeseModel commentRes = (CommentResponeseModel)ScenarioContext.Current["Comment Response"];
           ScenarioContext.Current["Comment Response by id actusl"] = GetClient.GetCommentById(commentRes.Id, _tokenTutor);
        }

        [Then(@"Check the left comment tutor should have returned")]
        public void ThenCheckTheLeftCommentTutorShouldHaveReturned()
        {
            var users = (List<RegistrationRequestModel>)FeatureContext.Current["Users"];
            var homework = (HomeworkRequestModel)FeatureContext.Current["Homework Request"];
            var studHomework = (StudentHomeworkRequestModel)FeatureContext.Current["Student Homework"];
            CommentRequestModel comment = (CommentRequestModel)ScenarioContext.Current["Comment Request"];
            CommentResponeseModel actual = (CommentResponeseModel)ScenarioContext.Current["Comment Response by id actusl"];
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
                    Roles = new List<string>() { "Student" }
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


        // new Scenario (Get student homework by id)

        [When(@"Get student homework by id")]
        public void WhenGetStudentHomeworkById()
        {
           ScenarioContext.Current["Get Stud Homew actual"] = GetClient.GetStudentHomeworkById(_tokenTeacher, _idStudentHomework);
        }

        [Then(@"Compare , submitted homework should return")]
        public void ThenCompareSubmittedHomeworkShouldReturn()
        {
            var users = (List<RegistrationRequestModel>)FeatureContext.Current["Users"];
            var taskRequest = (TaskMethodistRequestModel)FeatureContext.Current["Task Request"];
            var studHomework = (StudentHomeworkRequestModel)FeatureContext.Current["Student Homework"];
            var homework = (HomeworkRequestModel)FeatureContext.Current["Homework Request"];
            var actual = (StudentHomeworkResponseModel)ScenarioContext.Current["Get Stud Homew actual"];
            var expected = new StudentHomeworkResponseModel()
            {
                Id = _idStudentHomework,
                Answer = studHomework.Answer,
                Status = "ToCheck",
                CompletedDate = null,
                IsDeleted = false,
                Homework = new Homework()
                {
                    Id = _idHomework,
                    EndDate = homework.EndDate,
                    StartDate = homework.StartDate,
                    Task = new TaskResponseModel()
                    {
                        Id = _idTask,
                        Description = taskRequest.Description,
                        IsDeleted = false,
                        IsRequired = true,
                        Links = taskRequest.Links,
                        Name = taskRequest.Name,
                    }
                },
                User = new UserResponseModel()
                {
                    Email = users[1].Email,
                    FirstName = users[1].FirstName,
                    LastName = users[1].LastName,
                    Photo = null,
                    Id = _idUser[1]
                }
            };
            Assert.AreEqual(expected, actual);
        }

        // New Scenario (Approve student homework)

        [When(@"I teacher and can approve student homework")]
        public void WhenITeacherAndCanApproveStudentHomework()
        {
          ScenarioContext.Current["Student Homework Response"] = AddEntitysClients.AddApproveStudentHomework(_tokenTeacher,_idStudentHomework);
        }

        [Then(@"—heck selected homework should have been approved")]
        public void Then—heckSelectedHomeworkShouldHaveBeenApproved()
        {
            var actual = (StudentHomeworkResponseModel)ScenarioContext.Current["Student Homework Response"];
            var users = (List<RegistrationRequestModel>)FeatureContext.Current["Users"];
            var taskRequest = (TaskMethodistRequestModel)FeatureContext.Current["Task Request"];
            var studHomework = (StudentHomeworkRequestModel)FeatureContext.Current["Student Homework"];
            var homework = (HomeworkRequestModel)FeatureContext.Current["Homework Request"];
            var expected = new StudentHomeworkResponseModel()
            {
                Id = _idStudentHomework,
                Answer = studHomework.Answer,
                Status = "Done",
                CompletedDate = $"{DateTime.Now.ToString("dd.MM.yyyy")}",
                IsDeleted = false,
                Homework = new Homework()
                {
                    Id = _idHomework,
                    EndDate = homework.EndDate,
                    StartDate = homework.StartDate,
                    Task = new TaskResponseModel()
                    {
                        Id = _idTask,
                        Description = taskRequest.Description,
                        IsDeleted = false,
                        IsRequired = true,
                        Links = taskRequest.Links,
                        Name = taskRequest.Name,
                    }
                },
                User = new UserResponseModel()
                {
                    Email = users[1].Email,
                    FirstName = users[1].FirstName,
                    LastName = users[1].LastName,
                    Photo = null,
                    Id = _idUser[1]
                }
            };
            Assert.AreEqual(actual, expected);
        }

        // new Scenario (Decline student homework)

        [When(@"I teacher and can decline student homework")]
        public void WhenITeacherAndCanDeclineStudentHomework()
        {
            ScenarioContext.Current["Student Homework Response"] = 
            AddEntitysClients.AddDeclineStudentHomework(_tokenTeacher, _idStudentHomework);
        }

        [Then(@"—heck selected homework should have been declined")]
        public void Then—heckSelectedHomeworkShouldHaveBeenDeclined()
        {
            var actual = (StudentHomeworkResponseModel)ScenarioContext.Current["Student Homework Response"];
            var users = (List<RegistrationRequestModel>)FeatureContext.Current["Users"];
            var taskRequest = (TaskMethodistRequestModel)FeatureContext.Current["Task Request"];
            var studHomework = (StudentHomeworkRequestModel)FeatureContext.Current["Student Homework"];
            var homework = (HomeworkRequestModel)FeatureContext.Current["Homework Request"];
            var expected = new StudentHomeworkResponseModel()
            {
                Id = _idStudentHomework,
                Answer = studHomework.Answer,
                Status = "ToFix",
                CompletedDate = $"{DateTime.Now.ToString("dd.MM.yyyy")}",
                IsDeleted = false,
                Homework = new Homework()
                {
                    Id = _idHomework,
                    EndDate = homework.EndDate,
                    StartDate = homework.StartDate,
                    Task = new TaskResponseModel()
                    {
                        Id = _idTask,
                        Description = taskRequest.Description,
                        IsDeleted = false,
                        IsRequired = true,
                        Links = taskRequest.Links,
                        Name = taskRequest.Name,
                    }
                },
                User = new UserResponseModel()
                {
                    Email = users[1].Email,
                    FirstName = users[1].FirstName,
                    LastName = users[1].LastName,
                    Photo = null,
                    Id = _idUser[1]
                }
            };
            Assert.AreEqual(actual, expected);
        }

        // new Scenario (role student get myself homework by id)

        [When(@"Get Student homework by id")]
        public void WhenGetStudentsHomeworkById()
        {
          ScenarioContext.Current["Get stud hw by id"] = GetClient.GetStudentHomeworkById(_tokenStudent,_idStudentHomework);
        }

        [Then(@"Check if the student's homework submitted should be returned")]
        public void ThenCheckIfTheStudentsHomeworkSubmittedShouldBeReturned()
        {
            var users = (List<RegistrationRequestModel>)FeatureContext.Current["Users"];
            var taskRequest = (TaskMethodistRequestModel)FeatureContext.Current["Task Request"];
            var studHomework = (StudentHomeworkRequestModel)FeatureContext.Current["Student Homework"];
            var homework = (HomeworkRequestModel)FeatureContext.Current["Homework Request"];
            StudentHomeworkResponseModel actual = (StudentHomeworkResponseModel)ScenarioContext.Current["Get stud hw by id"];
            StudentHomeworkResponseModel expected = new StudentHomeworkResponseModel()
            {
                Id = _idStudentHomework,
                Answer = studHomework.Answer,
                Status = "ToCheck",
                CompletedDate = null,
                IsDeleted = false,
                Homework = new Homework()
                {
                    Id = _idHomework,
                    EndDate = homework.EndDate,
                    StartDate = homework.StartDate,
                    Task = new TaskResponseModel()
                    {
                        Id = _idTask,
                        Description = taskRequest.Description,
                        IsDeleted = false,
                        IsRequired = true,
                        Links = taskRequest.Links,
                        Name = taskRequest.Name,
                    }
                },
                User = new UserResponseModel()
                {
                    Email = users[1].Email,
                    FirstName = users[1].FirstName,
                    LastName = users[1].LastName,
                    Photo = null,
                    Id = _idUser[1]
                }
            };
            Assert.AreEqual(actual, expected);
        }

        // new Scenario (role student - add comment)

        [When(@"Add a comment as a student to your homework")]
        public void WhenAddACommentAsAStudentToYourHomework(Table table)
        {
           CommentRequestModel comment = table.CreateSet<CommentRequestModel>().ToList().First();
           ScenarioContext.Current["Comment Response"] = AddEntitysClients.CreateComment(_tokenStudent, _idStudentHomework, comment);
           
        }


        [When(@"Get student comment by id")]
        public void WhenGetStudentCommentById()
        {
            CommentResponeseModel commentResponse = (CommentResponeseModel)ScenarioContext.Current["Comment Response"];
           ScenarioContext.Current["actual CommRespoModel"] = GetClient.GetCommentById(commentResponse.Id, _tokenStudent);
        }

        [Then(@"Check the student ˚Â„‚ÛÚÂ comment should have returned")]
        public void ThenCheckTheStudent€Â„‚ÛÚÂCommentShouldHaveReturned()
        {
            CommentResponeseModel commentResponse = (CommentResponeseModel)ScenarioContext.Current["Comment Response"];
            var users = (List<RegistrationRequestModel>)FeatureContext.Current["Users"];
            var homework = (HomeworkRequestModel)FeatureContext.Current["Homework Request"];
            var studHomework = (StudentHomeworkRequestModel)FeatureContext.Current["Student Homework"];
            CommentRequestModel comment = (CommentRequestModel)ScenarioContext.Current["Comment Request"];
            CommentResponeseModel actual = (CommentResponeseModel)ScenarioContext.Current["actual CommRespoModel"];
            CommentResponeseModel expected = new CommentResponeseModel()
            {
                Id = commentResponse.Id,
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
                    Roles = new List<string>() { "Student" }
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
