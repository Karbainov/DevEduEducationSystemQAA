using DevEduEducationSystem.API.Tests.Support.MethodForTests;
using DevEduEducationSystem.API.Tests.Support.Models;
using DevEduEducationSystem.API.Tests.Support.Models.CourseResponseModelForAdd;
using DevEduEducationSystem.API.Tests.Support.Models.RequestModels;
using System;
using System.Net;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace DevEduEducationSystem.API.Tests.StepDefinitions
{
    [Binding]
    public class MethodistCheckBaseFunctionalStepDefinitions
    {
        [Given(@"I create new user")]
        public void GivenICreateNewUserAndGetHisToken(Table table)
        {
            ScenarioContext.Current["NewUser"] = table.CreateSet<RegistrationRequestModel>().ToList().First();
            RegistrationRequestModel newUser = (RegistrationRequestModel)ScenarioContext.Current["NewUser"];
            RegistrationResponseModel newUserModel = AuthClient.RegistrationReturnModel(newUser);
            ScenarioContext.Current["idNewUser"] = newUserModel.Id;
        }

        [Given(@"I login as an admin and give new user role (.*)")]
        public void GivenILoginAsAnAdminAndGiveNewUserRoleMethodist(string role)
        {
            LoginRequestModel adminEnterRequestModel = new LoginRequestModel()
            {
                Email = "user@example.com",
                Password = "stringst"
            };
            string tokenAdmin = AuthClient.AuthUser(adminEnterRequestModel.Email, adminEnterRequestModel.Password);
            AddRoleUsers.AddRole(role, (int)ScenarioContext.Current["idNewUser"], tokenAdmin);
            ScenarioContext.Current["TokenAdmin"] = tokenAdmin;
            RegistrationRequestModel userModelForTokinMethodist = (RegistrationRequestModel)ScenarioContext.Current["NewUser"];
            string token = AuthClient.AuthUser(userModelForTokinMethodist.Email, userModelForTokinMethodist.Password);
            ScenarioContext.Current["TokenMethodist"] = token;
            ScenarioContext.Current["TokenTeacher"] = token;
        }

        [When(@"I login as an Methodist and create new course")]
        public void WhenILoginAsAnMethodistAndCreateNewCourse(Table table)
        {

            ScenarioContext.Current["NewCourse"] = table.CreateSet<CourseRequestModel>().ToList().First();
            CourseRequestModel courseModel = (CourseRequestModel)ScenarioContext.Current["NewCourse"];
            CourseResponseModel newCourse = AddEntitysClients.CreateCourse((string)ScenarioContext.Current["TokenMethodist"], courseModel);
            ScenarioContext.Current["idNewCourse"] = newCourse.Id;
        }

        [When(@"I login as an Methodist and create new courses")]
        public void WhenILoginAsAnMethodistAndCreateNewCourses(Table table)
        {
            ScenarioContext.Current["SetCourses"] = table.CreateSet<CourseRequestModel>().ToList();
            List<CourseRequestModel> courses = (List<CourseRequestModel>)ScenarioContext.Current["SetCourses"];
            List<CourseResponseModel> newCourses = new List<CourseResponseModel>();
            foreach (CourseRequestModel course in courses)
            {
                newCourses.Add(AddEntitysClients.CreateCourse((string)ScenarioContext.Current["TokenMethodist"], course));
            }
            ScenarioContext.Current["NewCourses"] = newCourses;
        }

        [When(@"I get all courses")]
        public void WhenIGetAllCourses()
        {
            List<CourseResponseModel> listCourses = GetClient.GetAllCourses((string)ScenarioContext.Current["TokenMethodist"]);
            ScenarioContext.Current["ListCourses"] = listCourses;
        }

        [When(@"I create topics under login Methodist")]
        public void WhenIAddTopics(Table table)
        {
            ScenarioContext.Current["NewTopics"] = table.CreateSet<TopicRequestModel>().ToList();
            List<TopicRequestModel> topics = (List<TopicRequestModel>)ScenarioContext.Current["NewTopics"];
            List<TopicResponseModel> newTopics = new List<TopicResponseModel>();
            foreach (TopicRequestModel topic in topics)
            {
                newTopics.Add(AddEntitysClients.CreateTopic((string)ScenarioContext.Current["TokenMethodist"], topic));
            }
            ScenarioContext.Current["TopicsModels"] = newTopics;
        }

        [When(@"I add course topics on position")]
        public void WhenIAddCourseTopicsOnPosition(Table table)
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
                (modelCourseWithPositionList, (int)ScenarioContext.Current["idNewCourse"], (string)ScenarioContext.Current["TokenMethodist"]);
        }

        [When(@"I am changing the positions of the topics of the course")]
        public void WhenIAmChangingThePositionsOfTheTopicsOfTheCourse(Table table)
        {
            ScenarioContext.Current["TopicsNamesAndPositions"] = table.CreateSet<CourseAndTopicRequestModel>().ToList();
            List<CourseAndTopicRequestModel> positionTopics = (List<CourseAndTopicRequestModel>)ScenarioContext.Current["TopicsNamesAndPositions"];
            List<TopicResponseModel> newTopics = (List<TopicResponseModel>)ScenarioContext.Current["TopicsModels"];
            List<CourseAndTopicRequestModelADD> modelCourseWithPositionList = new List<CourseAndTopicRequestModelADD>();
            foreach (CourseAndTopicRequestModel positionTopic in positionTopics)
            {
                TopicResponseModel courseModel = newTopics.FirstOrDefault(C => C.Name == positionTopic.Name);
                CourseAndTopicRequestModelADD modelCourseWithPosition = new CourseAndTopicRequestModelADD();
                modelCourseWithPosition.TopicID = courseModel.Id;
                modelCourseWithPosition.Position = positionTopic.Position;
                modelCourseWithPositionList.Add(modelCourseWithPosition);
            }
            List<CourseResponseModel> listCourses = UpdateClient.UpdateCourseAddTopic
               (modelCourseWithPositionList, (int)ScenarioContext.Current["idNewCourse"], (string)ScenarioContext.Current["TokenMethodist"]);
        }

        [When(@"I add ""([^""]*)"" topics on position")]
        public void WhenIAddTopicsOnPosition(string courseName, Table table)
        {
            List<CourseResponseModel> courses = (List<CourseResponseModel>)ScenarioContext.Current["NewCourses"];
            CourseResponseModel course = courses.FirstOrDefault(C => C.Name == courseName);
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
                (modelCourseWithPositionList, course.Id, (string)ScenarioContext.Current["TokenMethodist"]);
        }

        [Then(@"I get course ""([^""]*)"" and check that he containes topics")]
        public void ThenIGetCourseAndCheckThatHeContainesTopics(string courseName)
        {
            List<CourseResponseModel> courses = (List<CourseResponseModel>)ScenarioContext.Current["NewCourses"];
            CourseResponseModel course = courses.FirstOrDefault(C => C.Name == courseName);
            CourseResponseFullModel actualModelCourseWithTopics = GetClient.GetCourseByIdCourseFullModel((string)ScenarioContext.Current["TokenMethodist"],
                course.Id);
            List<TopicRequestModel> actual = Mapper.MapCourseRequestAndTopicRequestModelToCourseResponseModel(actualModelCourseWithTopics);
            List<TopicRequestModel> expected = (List<TopicRequestModel>)ScenarioContext.Current["NewTopics"];
            foreach (TopicRequestModel model in expected)
            {
                CollectionAssert.Contains(actual, model);
            }
        }

        [Then(@"I get course ""([^""]*)"" and check that he doesn't containes topics")]
        public void ThenIGetCourseAndCheckThatHeDoesntContainesTopics(string courseName)
        {
            List<CourseResponseModel> courses = (List<CourseResponseModel>)ScenarioContext.Current["NewCourses"];
            CourseResponseModel course = courses.FirstOrDefault(C => C.Name == courseName);
            CourseResponseFullModel actualModelCourseWithTopics = GetClient.GetCourseByIdCourseFullModel((string)ScenarioContext.Current["TokenMethodist"],
                course.Id);
            Assert.IsNull(actualModelCourseWithTopics.Topics);
        }


        [Then(@"I get a course by id and the returned model contains all the topics at a given position")]
        public void ThenIGetCourseByIdAndReturnModelContainAllTopics()
        {
            CourseResponseFullModel actualModelCourseWithTopics = GetClient.GetCourseByIdCourseFullModel((string)ScenarioContext.Current["TokenMethodist"],
                (int)ScenarioContext.Current["idNewCourse"]);
            List<TopicRequestModel> actual = Mapper.MapCourseRequestAndTopicRequestModelToCourseResponseModel(actualModelCourseWithTopics);
            List<TopicRequestModel> expected = (List<TopicRequestModel>)ScenarioContext.Current["NewTopics"];
            foreach (TopicRequestModel model in expected)
            {
                CollectionAssert.Contains(actual, model);
            }
            List<CourseAndTopicRequestModel> positionTopics = (List<CourseAndTopicRequestModel>)ScenarioContext.Current["TopicsNamesAndPositions"];
            foreach (CourseAndTopicRequestModel positionTopic in positionTopics)
            {
                TopicRequestModel topic = actual[positionTopic.Position - 1];
                Assert.AreEqual(topic.Name, positionTopic.Name);
            }
        }

        [When(@"I deleting new course")]
        public void WhenIDeletingNewCourse()
        {
            DeleteClient.DeleteCourseById((string)ScenarioContext.Current["TokenMethodist"], (int)ScenarioContext.Current["idNewCourse"]);
        }

        [When(@"I get new course by id full models")]
        public void WhenIGetNewCourseByIdFullModels()
        {
            CourseResponseFullModel fullCourseModel = GetClient.GetCourseByIdCourseFullModel((string)ScenarioContext.Current["TokenMethodist"], (int)ScenarioContext.Current["idNewCourse"]);
            ScenarioContext.Current["NewCourseFullModel"] = fullCourseModel;
        }


        [When(@"I update new course")]
        public void WhenIUpdateNewCourse(Table table)
        {
            ScenarioContext.Current["NewModelUpdateCourse"] = table.CreateSet<CourseRequestModel>().ToList().First();
            CourseResponseModel newUpdatedCourse = UpdateClient.UpdateCourse((CourseRequestModel)ScenarioContext.Current["NewModelUpdateCourse"],
                (int)ScenarioContext.Current["idNewCourse"], (string)ScenarioContext.Current["TokenMethodist"]);
            ScenarioContext.Current["NewUpdatedCourse"] = newUpdatedCourse;
        }

        [When(@"I login as an Methodist and get course by not existing Id (.*)")]
        public void WhenILoginAsAnMethodistAndGetCourseByNotExistingId(int id)
        {
            HttpResponseMessage resoponseCode = GetClient.GetClientByIdError(id, (string)ScenarioContext.Current["TokenMethodist"]);
            ScenarioContext.Current["StatusCode"] = resoponseCode.StatusCode;
        }

        [Then(@"Should return (.*) code response status")]
        public void ThenShouldReturnCodeResponseStatus(int statusCode)
        {
            HttpStatusCode expected = (HttpStatusCode)statusCode;
            HttpStatusCode actual = (HttpStatusCode)ScenarioContext.Current["StatusCode"];
            Assert.AreEqual(expected, actual);
        }

        [Then(@"Should Course Models coincide with the returned models of these entities")]
        [Then(@"Should course model coincide with the returned model")]
        public void ThenShouldCourseModelsCoincideWithTheReturnedModelsOfTheseEntities()
        {
            CourseResponseModel actualModelCourse = GetClient.GetCourseByIdCourseSimpleModel((string)ScenarioContext.Current["TokenMethodist"],
                (int)ScenarioContext.Current["idNewCourse"]);
            CourseRequestModel actualModelCourseNow = Mapper.MapCourseResponseModelToCourseRequestModel
                (actualModelCourse);
            CourseRequestModel excpectedModelCourse = (CourseRequestModel)ScenarioContext.Current["NewCourse"];

            Assert.AreEqual(excpectedModelCourse, actualModelCourseNow);
        }


        [Then(@"Should new course model coincide with the returned model of changes entities")]
        public void ThenShouldNewCourseModelCoincideWithTheReturnedModelOfChangesEntities()
        {
            CourseResponseModel actualModelCourse = GetClient.GetCourseByIdCourseSimpleModel((string)ScenarioContext.Current["TokenMethodist"],
                (int)ScenarioContext.Current["idNewCourse"]);
            CourseRequestModel actualModelCourseNow = Mapper.MapCourseResponseModelToCourseRequestModel
                (actualModelCourse);

            CourseResponseModel model = (CourseResponseModel)ScenarioContext.Current["NewUpdatedCourse"];
            CourseRequestModel excpectedModelCourse = Mapper.MapCourseResponseModelToCourseRequestModel(model);

            Assert.AreEqual(excpectedModelCourse, actualModelCourseNow);
        }


        [Then(@"Field IsDeleted full models course must be true")]
        public void ThenFieldIsDeletedFullModelsCourseMustBeTrue()
        {
            CourseResponseFullModel actualFullCourseModel = (CourseResponseFullModel)ScenarioContext.Current["NewCourseFullModel"];
            bool actualField = actualFullCourseModel.IsDeleted;
            bool expectedField = true;
            Assert.AreEqual(actualField, expectedField);
        }

        [Then(@"In the list of all courses can't be a remote course")]
        public void ThenInTheListOfAllCoursesCantBeARemoteCourse()
        {
            List<CourseResponseModel> listCourses = (List<CourseResponseModel>)ScenarioContext.Current["ListCourses"];
            foreach (CourseResponseModel course in listCourses)
            {
                Assert.AreNotEqual(course.Id, (int)ScenarioContext.Current["idNewCourse"]);
            }
        }

        [Then(@"The list contains all created courses")]
        public void ThenTheListContainsAllCreatedCourses()
        {
            List<CourseResponseModel> actualAllCourses = GetClient.GetAllCourses((string)ScenarioContext.Current["TokenMethodist"]);
            List<CourseResponseModel> expectedCourses = (List<CourseResponseModel>)ScenarioContext.Current["NewCourses"];
            foreach (CourseResponseModel course in expectedCourses)
            {
                CourseResponseModel actualModel = actualAllCourses.FirstOrDefault(C => C.Id == course.Id);
                Assert.IsNotNull(actualModel);
                Assert.AreEqual(course.Name, actualModel.Name);
                Assert.AreEqual(course.Description, actualModel.Description);
            }
        }

        [Then(@"I get all topics of courses by Id and the returned model contains all the topics at a given new positions")]
        public void ThenIGetAllTopicsOfCoursesById()
        {
            List<CourseResponseModelWithPosition> actualAllTopics = GetClient.GetAllTopicsOfCoursesById
                ((string)ScenarioContext.Current["TokenMethodist"], (int)ScenarioContext.Current["idNewCourse"]);
            List<CourseAndTopicRequestModel> positionTopics = (List<CourseAndTopicRequestModel>)ScenarioContext.Current["TopicsNamesAndPositions"];
            foreach (CourseAndTopicRequestModel positionTopic in positionTopics)
            {
                CourseResponseModelWithPosition topic = actualAllTopics.FirstOrDefault(C=>C.Position == positionTopic.Position);
                Assert.IsNotNull(topic);
                Assert.IsNotNull(topic.Topic);
                Assert.AreEqual(topic.Topic.Name, positionTopic.Name);
            }
        }

        [When(@"I delete ""([^""]*)""")]
        public void WhenIDelete(string topicName)
        {
            int courseId = (int)ScenarioContext.Current["idNewCourse"];
            List<TopicResponseModel> listTopics = (List<TopicResponseModel>)ScenarioContext.Current["TopicsModels"];
            TopicResponseModel topic = listTopics.FirstOrDefault(C => C.Name == topicName);
            DeleteClient.DeleteTopicOfCourseById((string)ScenarioContext.Current["TokenMethodist"], courseId, topic.Id);
        }    

        [Then(@"I get course by id and check that he doesn't containes deleted topics")]
        public void ThenIGetCourseCourseByIdAndCheckThatHeDoesntContainesDeletedTopics(Table table)
        {
            List<string> topicNames = table.Rows[0]["Name"].Split(',').Select(str => str).ToList();
            int courseId = (int)ScenarioContext.Current["idNewCourse"];
            List<CourseResponseModelWithPosition> allCoursesWithTopics = GetClient.GetAllTopicsOfCoursesById((string)ScenarioContext.Current["TokenMethodist"], courseId);
            foreach (string topicName in topicNames)
            {
                Assert.False(allCoursesWithTopics.Any(C => C.Topic.Name == topicName));
            } 
        }
    }
}
