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


        [Then(@"Check that the comment sent by the teacher under the student's homework should have been returned by id")]
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


        [Then(@"Check that the comment sent by the tutor under the student's homework should be returned by id")]
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


        [Then(@"I am a teacher checking that the homework submitted by the student should be returned by id")]
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

        [Then(@"I am a student, check that my submitted homework is returned to me by id")]
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


        [Then(@"I am a student, check that the created comment is returned by id correct")]
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

        // new Scenario (Get all students homework on task by task)

        [Given(@"Add all Users to group")]
        public void GivenAddAllUsersToGroup()
        {
            AddEntitysClients.AddUserInGroup(_idGroup, _idUser[0], "Teacher", _tokenAdmin);
            AddEntitysClients.AddUserInGroup(_idGroup, _idUser[1], "Student", _tokenAdmin);
            AddEntitysClients.AddUserInGroup(_idGroup, _idUser[2], "Tutor", _tokenAdmin);
            for (int i = 3; i < _idUser.Count; i++)
            {
                AddEntitysClients.AddUserInGroup(_idGroup, _idUser[i], "Student", _tokenAdmin);
            }
        }

        [Given(@"We are students and we add our homework")]
        public void GivenWeAreStudentsAndWeAddOurHomework(Table table)
        {
            List<StudentHomeworkResponseModel> studentHomeworksResponse = new List<StudentHomeworkResponseModel>();
            List<StudentHomeworkRequestModel> studHomeworks = table.CreateSet<StudentHomeworkRequestModel>().ToList();
            List<string> tokens = new List<string>();
            List<RegistrationRequestModel> users = (List<RegistrationRequestModel>)FeatureContext.Current["Users"];
            tokens.Add(AuthClient.AuthUser(users[1].Email, users[1].Password));
            for (int i = 3; i < users.Count; i++) 
            {
                     tokens.Add(AuthClient.AuthUser(users[i].Email, users[i].Password));
            }
            for (int i = 0; i < tokens.Count; i++)
            {
                studentHomeworksResponse.Add(AddEntitysClients.CreateStudentHomework(studHomeworks[i], tokens[i], _idHomework));
            }

            ScenarioContext.Current["StudentHomeworkResponse"] = studentHomeworksResponse;
            ScenarioContext.Current["StudentHomeworkRequest"] = studHomeworks;
        }


        [When(@"I teacher, get all students homework on task by task")]
        public void WhenGetAllStudentsHomeworkOnTaskByTask()
        {
          ScenarioContext.Current["List Shw by Taskid"] = GetClient.GetAllStudentHomeworkOnTaskByTask(_idTask, _tokenTeacher);
        }

        [When(@"I tutor, get all students homework on task by task")]
        public void WhenITutorGetAllStudentsHomeworkOnTaskByTask()
        {
            List<RegistrationRequestModel> users = (List<RegistrationRequestModel>)FeatureContext.Current["Users"];
            string tokenTutor = AuthClient.AuthUser(users[2].Email, users[2].Password);
            ScenarioContext.Current["Tutor get List Shw by Taskid"] = GetClient.GetAllStudentHomeworkOnTaskByTask(_idTask, tokenTutor);
        }


        [Then(@"I am a teacher and I check that all students submitted homeworks for a specific task has been returned to me")]
        public void ThenIAmATeacherAndICheckThatAllStudentsSubmittedHomeworksForASpecificTaskHasBeenReturnedToMe()
        {
            List<UserResponseModel> u = new List<UserResponseModel>();
            var shwRequest = (List<StudentHomeworkRequestModel>)ScenarioContext.Current["StudentHomeworkRequest"];
            var users = (List<RegistrationRequestModel>)FeatureContext.Current["Users"];
            var actual = (List<StudentHomeworkByTaskResponseModel>)ScenarioContext.Current["List Shw by Taskid"];
            List<StudentHomeworkResponseModel> shw = (List<StudentHomeworkResponseModel>)ScenarioContext.Current["StudentHomeworkResponse"];
            List< StudentHomeworkByTaskResponseModel> expected = new List<StudentHomeworkByTaskResponseModel>();
            UserResponseModel student1 = new UserResponseModel()
            {
                Email = users[1].Email,
                FirstName = users[1].FirstName,
                LastName = users[1].LastName,
                Photo = null,
                Id = _idUser[1]
            };
            u.Add(student1);
            for (int i = 3;i<users.Count;i++)
            {
                UserResponseModel student2_3 = new UserResponseModel()
                {
                    Email = users[i].Email,
                    FirstName = users[i].FirstName,
                    LastName = users[i].LastName,
                    Photo = null,
                    Id = _idUser[i]
                };
                u.Add(student2_3);
            }
            
            for (int i = 0; i < shw.Count; i++) 
            {
                var a = new StudentHomeworkByTaskResponseModel()
                {
                    Id = shw[i].Id,
                    Status = "ToCheck",
                    CompletedDate = null,
                    IsDeleted = false,
                    Answer = shwRequest[i].Answer,
                    User = u[i]
                };
                expected.Add(a);
            }
            for(int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [Then(@"I am a tutor and I check that all students submitted homeworks for a specific task has been returned to me")]
        public void ThenIAmATutorAndICheckThatAllStudentsSubmittedHomeworksForASpecificTaskHasBeenReturnedToMe()
        {
            var actual = (List<StudentHomeworkByTaskResponseModel>)ScenarioContext.Current["Tutor get List Shw by Taskid"];
            List<UserResponseModel> u = new List<UserResponseModel>();
            var shwRequest = (List<StudentHomeworkRequestModel>)ScenarioContext.Current["StudentHomeworkRequest"];
            var users = (List<RegistrationRequestModel>)FeatureContext.Current["Users"];
            List<StudentHomeworkResponseModel> shw = (List<StudentHomeworkResponseModel>)ScenarioContext.Current["StudentHomeworkResponse"];
            List<StudentHomeworkByTaskResponseModel> expected = new List<StudentHomeworkByTaskResponseModel>();
            UserResponseModel student1 = new UserResponseModel()
            {
                Email = users[1].Email,
                FirstName = users[1].FirstName,
                LastName = users[1].LastName,
                Photo = null,
                Id = _idUser[1]
            };
            u.Add(student1);
            for (int i = 3; i < users.Count; i++)
            {
                UserResponseModel student2_3 = new UserResponseModel()
                {
                    Email = users[i].Email,
                    FirstName = users[i].FirstName,
                    LastName = users[i].LastName,
                    Photo = null,
                    Id = _idUser[i]
                };
                u.Add(student2_3);
            }

            for (int i = 0; i < shw.Count; i++)
            {
                var a = new StudentHomeworkByTaskResponseModel()
                {
                    Id = shw[i].Id,
                    Status = "ToCheck",
                    CompletedDate = null,
                    IsDeleted = false,
                    Answer = shwRequest[i].Answer,
                    User = u[i]
                };
                expected.Add(a);
            }
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        // new Scenario (Get all anwsers of student)

        [Given(@"Create Tasks")]
        public void GivenCreateTasks(Table table)
        {
           List<TaskResponseModel> tasksResponse = new List<TaskResponseModel>();
           List<TaskMethodistRequestModel> tasks = table.CreateSet<TaskMethodistRequestModel>().ToList();
            for (int i = 0; i < tasks.Count; i++)
            {
                tasksResponse.Add(AddEntitysClients.CreateTaskByMethodist(_tokenAdmin, tasks[i]));
            }
            ScenarioContext.Current["TasksResponse"] = tasksResponse;
            ScenarioContext.Current["TasksRequest"] = tasks;
        }

        [Given(@"Create homeworks")]
        public void GivenCreateHomeworks(Table table)
        {
            List<HomeworkResponseModel> hwResponse = new List<HomeworkResponseModel>();
            List<TaskResponseModel> tasksResponse = (List<TaskResponseModel>)ScenarioContext.Current["TasksResponse"];
            List<HomeworkRequestModel> hw = table.CreateSet<HomeworkRequestModel>().ToList();
            for (int i = 0; i < tasksResponse.Count; i++)
            {
                hwResponse.Add(AddEntitysClients.CreateHomework(_tokenTeacher, tasksResponse[i].Id,_idGroup,hw[i]));
            }
            ScenarioContext.Current["hw Response"] = hwResponse;
            ScenarioContext.Current["hw Request"] = hw;
        }

        [Given(@"I am a student adding my completed homework")]
        public void GivenIAmAStudentAddingMyCompletedHomework(Table table)
        {
            List<HomeworkResponseModel> hwResponse = (List<HomeworkResponseModel>)ScenarioContext.Current["hw Response"];
            List<StudentHomeworkResponseModel> shwResponse = new List<StudentHomeworkResponseModel>();
            List<StudentHomeworkRequestModel> shw = table.CreateSet<StudentHomeworkRequestModel>().ToList();
            for(int i = 0;i<shw.Count;i++)
            {
                shwResponse.Add(AddEntitysClients.CreateStudentHomework(shw[i], _tokenStudent, hwResponse[i].Id));
            }
            ScenarioContext.Current["SHW Response"] = shwResponse;
            ScenarioContext.Current["SHW Request"] = shw;
        }

        [When(@"I am a teacher, I get all student answers")]
        public void WhenIAmATeacherIGetAllStudentAnswers()
        {
           ScenarioContext.Current["Teacher actual"] = GetClient.GetAllAnswersOfStudent(_tokenTeacher, _idUser[1]);
        }

        [When(@"I am a tutor, I get all student answers")]
        public void WhenIAmATutorIGetAllStudentAnswers()
        {
            List<RegistrationRequestModel> users = (List<RegistrationRequestModel>)FeatureContext.Current["Users"];
            string tokenTutor = AuthClient.AuthUser(users[2].Email, users[2].Password);
            ScenarioContext.Current["Tutor actual"] = GetClient.GetAllAnswersOfStudent(tokenTutor, _idUser[1]);
        }

        [When(@"I am a student, I get all my homeworks")]
        public void WhenIAmAStudentIGetAllMyHomeworks()
        {
            List<RegistrationRequestModel> users = (List<RegistrationRequestModel>)FeatureContext.Current["Users"];
            string tokenStudent = AuthClient.AuthUser(users[1].Email, users[1].Password);
            ScenarioContext.Current["Student actual"] = GetClient.GetAllAnswersOfStudent(tokenStudent, _idUser[1]);
        }

        [Then(@"I am a teacher, check that all student homework is returned")]
        public void ThenIAmATeacherMakeSureAllStudentHomeworkIsReturned()
        {
            var actual = (List<StudentHomeworkGetAllAnswersOfStudentResponseModel>)ScenarioContext.Current["Teacher actual"];
            var expected = new List<StudentHomeworkGetAllAnswersOfStudentResponseModel>();
            var shw = (List<StudentHomeworkRequestModel>)ScenarioContext.Current["SHW Request"];
            var shwResponse = (List<StudentHomeworkResponseModel>)ScenarioContext.Current["SHW Response"];
            var homeworkResponse = (List<HomeworkResponseModel>)ScenarioContext.Current["hw Response"];
            var homeworkrequest = (List<HomeworkRequestModel>)ScenarioContext.Current["hw Request"];
            var tasksResponse = (List<TaskResponseModel>)ScenarioContext.Current["TasksResponse"];
            var tasksRequest = (List<TaskMethodistRequestModel>)ScenarioContext.Current["TasksRequest"];

            for (int i = 0; i < shw.Count; i++)
            {
                var a = new StudentHomeworkGetAllAnswersOfStudentResponseModel()
                {
                    Id = shwResponse[i].Id,
                    Answer = shw[i].Answer,
                    CompletedDate = null,
                    Status = "ToCheck",
                    IsDeleted = false,
                    Homework = new Homework()
                    {
                        Id = homeworkResponse[i].Id,
                        EndDate = homeworkrequest[i].EndDate,
                        StartDate = homeworkrequest[i].StartDate,
                        Task = new TaskResponseModel()
                        {
                            Id = tasksResponse[i].Id,
                            Description = tasksRequest[i].Description,
                            IsDeleted = false,
                            IsRequired = tasksRequest[i].IsRequired,
                            Links = tasksRequest[i].Links,
                            Name = tasksRequest[i].Name,
                        },
                    },
                };
                expected.Add(a);
            }

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]); // Û Ú‡ÒÍ‡ Ó·ˇÁ‡ÚÂÎ¸ÌÓÒÚ¸ ‚ÒÂ„Î‡ false
            }
        }

        [Then(@"I am a tutor, check that all student homework is returned")]
        public void ThenIAmATutorMakeSureAllStudentHomeworkIsReturned()
        {
            var actual = (List<StudentHomeworkGetAllAnswersOfStudentResponseModel>)ScenarioContext.Current["Tutor actual"];
            var expected = new List<StudentHomeworkGetAllAnswersOfStudentResponseModel>();
            var shw = (List<StudentHomeworkRequestModel>)ScenarioContext.Current["SHW Request"];
            var shwResponse = (List<StudentHomeworkResponseModel>)ScenarioContext.Current["SHW Response"];
            var homeworkResponse = (List<HomeworkResponseModel>)ScenarioContext.Current["hw Response"];
            var homeworkrequest = (List<HomeworkRequestModel>)ScenarioContext.Current["hw Request"];
            var tasksResponse = (List<TaskResponseModel>)ScenarioContext.Current["TasksResponse"];
            var tasksRequest = (List<TaskMethodistRequestModel>)ScenarioContext.Current["TasksRequest"];

            for (int i = 0; i < shw.Count; i++)
            {
                var a = new StudentHomeworkGetAllAnswersOfStudentResponseModel()
                {
                    Id = shwResponse[i].Id,
                    Answer = shw[i].Answer,
                    CompletedDate = null,
                    Status = "ToCheck",
                    IsDeleted = false,
                    Homework = new Homework()
                    {
                        Id = homeworkResponse[i].Id,
                        EndDate = homeworkrequest[i].EndDate,
                        StartDate = homeworkrequest[i].StartDate,
                        Task = new TaskResponseModel()
                        {
                            Id = tasksResponse[i].Id,
                            Description = tasksRequest[i].Description,
                            IsDeleted = false,
                            IsRequired = tasksRequest[i].IsRequired,
                            Links = tasksRequest[i].Links,
                            Name = tasksRequest[i].Name,
                        },
                    },
                };
                expected.Add(a);
            }

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }


        [Then(@"I am a student, check that all student homework is returned")]
        public void ThenIAmAStudentCheckThatAllStudentHomeworkIsReturned()
        {
            var actual = (List<StudentHomeworkGetAllAnswersOfStudentResponseModel>)ScenarioContext.Current["Student actual"];
            var expected = new List<StudentHomeworkGetAllAnswersOfStudentResponseModel>();
            var shw = (List<StudentHomeworkRequestModel>)ScenarioContext.Current["SHW Request"];
            var shwResponse = (List<StudentHomeworkResponseModel>)ScenarioContext.Current["SHW Response"];
            var homeworkResponse = (List<HomeworkResponseModel>)ScenarioContext.Current["hw Response"];
            var homeworkrequest = (List<HomeworkRequestModel>)ScenarioContext.Current["hw Request"];
            var tasksResponse = (List<TaskResponseModel>)ScenarioContext.Current["TasksResponse"];
            var tasksRequest = (List<TaskMethodistRequestModel>)ScenarioContext.Current["TasksRequest"];

            for (int i = 0; i < shw.Count; i++)
            {
                var a = new StudentHomeworkGetAllAnswersOfStudentResponseModel()
                {
                    Id = shwResponse[i].Id,
                    Answer = shw[i].Answer,
                    CompletedDate = null,
                    Status = "ToCheck",
                    IsDeleted = false,
                    Homework = new Homework()
                    {
                        Id = homeworkResponse[i].Id,
                        EndDate = homeworkrequest[i].EndDate,
                        StartDate = homeworkrequest[i].StartDate,
                        Task = new TaskResponseModel()
                        {
                            Id = tasksResponse[i].Id,
                            Description = tasksRequest[i].Description,
                            IsDeleted = false,
                            IsRequired = tasksRequest[i].IsRequired,
                            Links = tasksRequest[i].Links,
                            Name = tasksRequest[i].Name,
                        },
                    },
                };
                expected.Add(a);
            }

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}
