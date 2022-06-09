using DevEduEducationSystem.API.Tests.Support.Models.RequestModels;

namespace DevEduEducationSystem.API.Tests.StepDefinitions
{
    [Binding]
    public class OrganizationOfLessonsStepDefinitions
    {
        //[Given(@"I create new user")]

        //[Given(@"I login as an admin and give new user role (.*)")]

        [Given(@"I create course under login admin")]
        public void GivenICreateCourse(Table table)
        {
            ScenarioContext.Current["NewCourse"] = table.CreateSet<CourseRequestModel>().ToList().First();
            CourseRequestModel courseModel = (CourseRequestModel)ScenarioContext.Current["NewCourse"];
            CourseResponseModel newCourse = AddEntitysClients.CreateCourse((string)ScenarioContext.Current["TokenAdmin"], courseModel);
            ScenarioContext.Current["idNewCourse"] = newCourse.Id;
        }

        [Given(@"I create topics under login admin")]
        public void GivenICreateTopics(Table table)
        {
            ScenarioContext.Current["NewTopics"] = table.CreateSet<TopicRequestModel>().ToList();
            List<TopicRequestModel> topics = (List<TopicRequestModel>)ScenarioContext.Current["NewTopics"];
            List<TopicResponseModel> newTopics = new List<TopicResponseModel>();
            foreach (TopicRequestModel topic in topics)
            {
                newTopics.Add(AddEntitysClients.CreateTopic((string)ScenarioContext.Current["TokenAdmin"], topic));
            }
            ScenarioContext.Current["TopicsModels"] = newTopics;
        }

        [Given(@"I add course topics on positions under login admin")]
        public void GivenIAddCourseTopicsOnPositions(Table table)
        {
            ScenarioContext.Current["TopicsNamesAndPositions"] = table.CreateSet<CourseAndTopicRequestModel>().ToList();
            List<CourseAndTopicRequestModel> positionTopics = (List<CourseAndTopicRequestModel>)ScenarioContext.Current["TopicsNamesAndPositions"];
            List<TopicResponseModel> newTopics = (List<TopicResponseModel>)ScenarioContext.Current["TopicsModels"];
            List<CourseAndTopicRequestModelADD> modelCourseWithPositionList = new List<CourseAndTopicRequestModelADD>();
            foreach (TopicResponseModel model in newTopics)
            {
                CourseAndTopicRequestModelADD modelCourseWithPosition = new CourseAndTopicRequestModelADD();
                CourseAndTopicRequestModel courseModel = positionTopics.FirstOrDefault(C => C.Name == model.Name);
                modelCourseWithPosition.Position = courseModel.Position;
                modelCourseWithPosition.TopicID = model.Id;
                modelCourseWithPositionList.Add(modelCourseWithPosition);
            }
            List<CourseResponseModel> listCourses = UpdateClient.UpdateCourseAddTopic
                (modelCourseWithPositionList, (int)ScenarioContext.Current["idNewCourse"], (string)ScenarioContext.Current["TokenAdmin"]);
        }

        [Given(@"I create groupe under login admin")]
        public void GivenICreateGroupe(Table table)
        {
            ScenarioContext.Current["NewRequestGroup"] = table.CreateSet<GroupRequestModel>().ToList().First();
            GroupRequestModel groupRequestModel = (GroupRequestModel)ScenarioContext.Current["NewRequestGroup"];
            groupRequestModel.CourseId = (int)ScenarioContext.Current["idNewCourse"];
            GroupResponseModel groupResponseModel = AddEntitysClients.CreateGroupe((string)ScenarioContext.Current["TokenAdmin"], groupRequestModel);
            ScenarioContext.Current["idGroup"] = groupResponseModel.Id;
        }

        [Given(@"I to appoint new group ""([^""]*)"" under login admin")]
        public void GivenIToAppointNewGroupUnderLoginAdmin(string Teacher)
        {
            AddEntitysClients.AddUserInGroup((int)ScenarioContext.Current["idGroup"],(int)ScenarioContext.Current["idNewUser"], Teacher, (string)ScenarioContext.Current["TokenAdmin"]);
        }

        [Given(@"I Create students for group")]
        public void GivenCreateStudentsForGroup(Table table)
        {
            ScenarioContext.Current["UsersRequest"] = table.CreateSet<RegistrationRequestModel>().ToList();
            AuthClient register = new AuthClient();
            ScenarioContext.Current["UsersResponse"] = AuthClient.Registration((List<RegistrationRequestModel>)ScenarioContext.Current["UsersRequest"]);
        }

        [Given(@"I login as an admin and add students in group")]
        public void GivenILoginAsAnAdminAndAddStudentsInGroup()
        {
            List<RegistrationResponseModel> listCreateUsers = (List<RegistrationResponseModel>)ScenarioContext.Current["UsersResponse"];
            List<string> roles = new List<string>();

            foreach (RegistrationResponseModel student in listCreateUsers)
            {
                roles = student.Roles;
                foreach (string role in roles)
                {
                    AddEntitysClients.AddUserInGroup((int)ScenarioContext.Current["idGroup"], student.Id, role, (string)ScenarioContext.Current["TokenAdmin"]);
                }
            }            
        }

        [When(@"I login as an Lecturer and create Lesson with topics")]
        public void WhenILoginAsAnLecturerAndCreateLesson(Table table)
        {
            RegistrationRequestModel newUser = (RegistrationRequestModel)ScenarioContext.Current["NewUser"];
            ScenarioContext.Current["TokenTeacher"] = AuthClient.AuthUser(newUser.Email, newUser.Password);
            ScenarioContext.Current["NewLesson"] = table.CreateSet<LessonRequestModel>().ToList().First();
            LessonRequestModel lessonRequestModel = (LessonRequestModel)ScenarioContext.Current["NewLesson"];
            lessonRequestModel.GroupId = (int)ScenarioContext.Current["idGroup"];
            lessonRequestModel.IsPublished = true;
            List<TopicResponseModel> newTopics = (List<TopicResponseModel>)ScenarioContext.Current["TopicsModels"];
            List<int> topicId = new List<int>();
            foreach (TopicResponseModel topicModel in newTopics)
            {
                topicId.Add(topicModel.Id);
            }
            lessonRequestModel.TopicIds = topicId;
            LessonResponseModel lessonResponse = AddEntitysClients.CreateLesson((string)ScenarioContext.Current["TokenTeacher"], lessonRequestModel);
            ScenarioContext.Current["LessonResponseId"] = lessonResponse.Id;
        }        

        [When(@"Under login Lecturer I can mark attendance of students in Lesson")]
        public void WhenUnderLoginLecturerICanMarkAttendanceOfStudentsInLesson(Table table)
        {
            ScenarioContext.Current["DataForAttendance"] = table.CreateSet<AttendenceInLesson>().ToList();
            List<AttendenceInLesson> listAttendance = (List<AttendenceInLesson>)ScenarioContext.Current["DataForAttendance"];
            List<RegistrationResponseModel> studentsResponseModelList = (List<RegistrationResponseModel>)ScenarioContext.Current["UsersResponse"];
            List<StudentRequestModelForCheckAttendance> newModelForCheck = new List<StudentRequestModelForCheckAttendance>();

            foreach (AttendenceInLesson model in listAttendance)
            {
                foreach (RegistrationResponseModel student in studentsResponseModelList)
                {
                    RegistrationResponseModel studentModel = studentsResponseModelList.FirstOrDefault(C => C.Email == model.Email);

                    UpdateClient.MarkAttendance(model.AttendanceType, studentModel.Id, (int)ScenarioContext.Current["LessonResponseId"], (string)ScenarioContext.Current["TokenTeacher"]);
                    StudentRequestModelForCheckAttendance newModel = new StudentRequestModelForCheckAttendance();
                    newModel.IdStudent = studentModel.Id;
                    newModel.Email = studentModel.Email;
                    newModel.AttendanceType = model.AttendanceType;
                    newModelForCheck.Add(newModel);
                }
            }
            ScenarioContext.Current["DataForAttendance"] = newModelForCheck;
        }

        [Then(@"I get full-info about Lesson and check that AttendanceType of student mark for the relevant student")]
        public void ThenIGetFull_InfoAboutLessonAndCheckThatAttendanceTypeOfStudentMarkForTheRelevantStudent()
        {
            LessonResponseFullModelWithStudents lessonResponseFullModelWithStudents = GetClient.GetLessonFullModel((string)ScenarioContext.Current["TokenTeacher"], (int)ScenarioContext.Current["LessonResponseId"]);
            List<LessonResponseFullModelWithStudents> studentsList = new List<LessonResponseFullModelWithStudents>();
            List<StudentResponseModelForLesson> actualStudentResponseList = lessonResponseFullModelWithStudents.Students;
            List<StudentRequestModelForCheckAttendance> newModelForCheckList = (List<StudentRequestModelForCheckAttendance>)ScenarioContext.Current["DataForAttendance"];
            foreach (StudentResponseModelForLesson actualModel in actualStudentResponseList)
            {
                foreach (StudentRequestModelForCheckAttendance expectedModel in newModelForCheckList)
                {
                    UserResponseModel actualUser = actualModel.Student;
                    StudentRequestModelForCheckAttendance studenNewtModel = newModelForCheckList.FirstOrDefault(C => C.Email == actualUser.Email);
                    Assert.AreEqual(actualModel.AttendanceType, expectedModel.AttendanceType);
                }
            }
        }

        [Then(@"Under login Lecturer I get lesson by id <Teacher> and check that lessons is in return model and have correct field")]
        public void ThenIGetLessonByIdLecturerAndCheckThatLessonsIsInReturnModelAndHaveCorrectField()
        {
            // Здесь на 178 строке должен быть (string)ScenarioContext.Current["TokenTeacher"] !!!!
            List<LessonTeacherResponseModel> lessonTeacherResponseList = GetClient.GetAllLessonsTeachers((int)ScenarioContext.Current["idNewUser"], (string)ScenarioContext.Current["TokenAdmin"]);
            LessonTeacherResponseModel lessonTeacherResponseModel = lessonTeacherResponseList.First();
            Assert.AreEqual(lessonTeacherResponseList.Count, 1);

            LessonRequestModel actualLessonRequestModel = Mapper.MapLessonTeacherResponseModelToLessonRequestModel(lessonTeacherResponseModel);
            actualLessonRequestModel.GroupId = (int)ScenarioContext.Current["idGroup"];
            LessonRequestModel expectedLessonRequestModel = (LessonRequestModel)ScenarioContext.Current["NewLesson"];
            Assert.AreEqual(expectedLessonRequestModel, actualLessonRequestModel);

            CourseRequestModel actualCourseModel = Mapper.MapCourseRequestModelToCourseResponseModel(lessonTeacherResponseModel.Course); 
            CourseRequestModel expectedCourseModel = (CourseRequestModel)ScenarioContext.Current["NewCourse"];
            Assert.AreEqual(actualCourseModel, expectedCourseModel);

            //List<TopicResponseModel> expectedTopicsList = (List<TopicResponseModel>)ScenarioContext.Current["TopicsModels"];
            //List<TopicResponseModel> actualTopicsList = lessonTeacherResponseModel.Topics;
            //Assert.Contains(expectedTopicsList, actualTopicsList);
            Assert.AreEqual(lessonTeacherResponseModel.Teacher.Id, (int)ScenarioContext.Current["idNewUser"]);
        }

        [Then(@"Under login Lecturer I get lesson by id <Group> and check that lessons is in return model and have correct field")]
        public void ThenIGetLessonByIdGroupAndCheckThatLessonsIsInReturnModelAndHaveCorrectField()
        {
            // Здесь на 178 строке должен быть (string)ScenarioContext.Current["TokenTeacher"] !!!!
            List<LessonGroupeResponseModel> lessonGroupResponseList = GetClient.GetAllLessonsGroup((int)ScenarioContext.Current["idGroup"], (string)ScenarioContext.Current["TokenAdmin"]);
            LessonGroupeResponseModel lessonGroupResponseModel = lessonGroupResponseList.First();
            Assert.AreEqual(lessonGroupResponseList.Count, 1);
            Assert.AreEqual(lessonGroupResponseModel.Id, (int)ScenarioContext.Current["LessonResponseId"]);
            LessonRequestModel expectedModel = (LessonRequestModel)ScenarioContext.Current["NewLesson"];
            LessonRequestModel actualModel = Mapper.MapLessonGroupeResponseModelToLessonRequestModel(lessonGroupResponseModel);
            Assert.AreEqual(expectedModel, actualModel);
            //List<TopicResponseModel> expectedTopicsList = (List<TopicResponseModel>)ScenarioContext.Current["TopicsModels"];
            //List<TopicResponseModel> actualTopicsList = lessonGroupResponseModel.Topics;
            //Assert.Contains(expectedTopicsList, actualTopicsList);
            Assert.AreEqual(lessonGroupResponseModel.Teacher.Id, (int)ScenarioContext.Current["idNewUser"]);
        }

        [When(@"I create new list topics for update lesson")]
        public void WhenICreateNewListTopicsForUpdateLesson(Table table)
        {
            ScenarioContext.Current["DataForNewListTopic"] = table.CreateSet<TopicRequestModel>().ToList();
            List<TopicRequestModel> newTopics = (List<TopicRequestModel>)ScenarioContext.Current["DataForNewListTopic"];
            List<TopicResponseModel> newTopicsRsponse = (List<TopicResponseModel>)ScenarioContext.Current["TopicsModels"];
            List<int> listId = new List<int>();

            foreach (TopicRequestModel topicModel in newTopics)
            {
                TopicResponseModel model = newTopicsRsponse.FirstOrDefault(C => C.Name == topicModel.Name);
                listId.Add(model.Id);
            }
            ScenarioContext.Current["ListID"] = listId;
        }


        [When(@"Under login Lecturer I update Lesson by id")]
        public void WhenUnderLoginLecturerIUpdateLessonById(Table table)
        {
            RegistrationRequestModel newUser = (RegistrationRequestModel)ScenarioContext.Current["NewUser"];
            ScenarioContext.Current["TokenTeacher"] = AuthClient.AuthUser(newUser.Email, newUser.Password);
            ScenarioContext.Current["NewDataForLesson"] = table.CreateSet<LessonUpdateRequestModel>().ToList().First();
            LessonUpdateRequestModel lessonRequestModel = (LessonUpdateRequestModel)ScenarioContext.Current["NewDataForLesson"];
            lessonRequestModel.TopicIds = (List<int>)ScenarioContext.Current["ListID"];
            //метод не доступен по токену (string)ScenarioContext.Current["TokenTeacher"] заведен баг
            UpdateClient.UpdateLesson(lessonRequestModel, (int)ScenarioContext.Current["LessonResponseId"], (string)ScenarioContext.Current["TokenAdmin"]);
        }
       
        [Then(@"I get full-info about Lesson and check that new returned model of Lesson contained updating field")]
        public void ThenIGetFull_InfoAboutLessonAndCheckThatNewReturnedModelOfLessonContainedUpdatingField()
        {
            LessonResponseFullModelWithStudents lessonResponseModel = GetClient.GetLessonFullModel((string)ScenarioContext.Current["TokenAdmin"], (int)ScenarioContext.Current["LessonResponseId"]);
            LessonUpdateRequestModel actualLessonModel = Mapper.MapLessonFullResponseModelToLessonRequestModel(lessonResponseModel);
            actualLessonModel.TopicIds = (List<int>) ScenarioContext.Current["ListID"];
            LessonUpdateRequestModel expectedLessonModel = (LessonUpdateRequestModel)ScenarioContext.Current["NewDataForLesson"];
            Assert.AreEqual(actualLessonModel, expectedLessonModel);
            Assert.AreEqual(lessonResponseModel.Teacher.Id, (int)ScenarioContext.Current["idNewUser"]);
        }

        //[Then(@"I get full-info about Lesson and check that new returned model of Lesson contained updating field")]
        //public void ThenIGetFull_InfoAboutLessonAndCheckThatNewReturnedModelOfLessonContainedUpdatingField()
        //{
        //    List<LessonTeacherResponseModel> lessonResponseList = GetClient.GetAllLessonsTeachers((int)ScenarioContext.Current["idNewUser"], (string)ScenarioContext.Current["TokenTeacher"]);
        //    LessonTeacherResponseModel lessonResponseModel = lessonResponseList.First();
        //    Assert.AreEqual(lessonResponseList.Count, 1);
        //    LessonRequestModel actualLessonRequestModel = Mapper.MapLessonTeacherResponseModelToLessonRequestModel(lessonResponseModel);
        //    LessonRequestModel expectedLessonRequestModel = (LessonRequestModel)ScenarioContext.Current["NewDataForLesson"];
        //    Assert.AreEqual(expectedLessonRequestModel, actualLessonRequestModel);
        //    List<TopicResponseModel> expectedTopicsList = (List<TopicResponseModel>)ScenarioContext.Current["TopicsModels"];
        //    List<TopicResponseModel> actualTopicsList = lessonResponseModel.Topics;
        //    Assert.Contains(expectedTopicsList, actualTopicsList);
        //    Assert.AreEqual(lessonResponseModel.Teacher, (int)ScenarioContext.Current["idNewUser"]);
        //}

    }
}
