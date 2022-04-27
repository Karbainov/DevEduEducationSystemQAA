
using DevEduEducationSystem.API.Tests.Support.Models.StudentModelClassesForModel;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace DevEduEducationSystem.API.Tests.StepDefinitions
{
    [Binding]
    public class Manager_FunctionalityStepDefinitions
    {

        private int _curseId;
        private string _tokenManager;
        private string _tokenAdmin;

        [Given(@"Create user")]
        public void GivenCreateUser(Table table)
        {
            List<RegistrationRequestModel> user = table.CreateSet<RegistrationRequestModel>().ToList();
            AuthClient registr = new AuthClient();
            List<RegistrationResponseModel> userResponses = registr.Registration(user);
            ScenarioContext.Current["Manager"] = user;
            for (int i = 0; i < userResponses.Count; i++)
            {
                ScenarioContext.Current["IdManager"] = userResponses[i].Id;
            }
        }


        [Given(@"Autorized as admin")]
        public void GivenAutorizedAsAdmin()
        {
            string email = "user@example.com";
            string password = "stringst";
            ScenarioContext.Current["AdminToken"] = AuthClient.AuthUser(email, password);
            _tokenAdmin = (string)ScenarioContext.Current["AdminToken"];
        }

        [Given(@"Assing User ""([^""]*)""")]
        public void GivenAssingUser(string manager)
        {
            string token = (string)ScenarioContext.Current["AdminToken"];
            List<int> listId = new List<int>();
            listId.Add((int)ScenarioContext.Current["IdManager"]);
            int id = listId[0];
            AddRoleUsers.AddRole(manager, id, token);
        }

        [Given(@"Create new users for our roles")]
        public void GivenCreateNewUsersForOurRoles(Table table)
        {
            List<RegistrationRequestModel> user = table.CreateSet<RegistrationRequestModel>().ToList();
            AuthClient registr = new AuthClient();
            List<RegistrationResponseModel> userResponses = registr.Registration(user);
            ScenarioContext.Current["Users"] = user;
            for (int i = 0; i < userResponses.Count; i++)
            {
                ScenarioContext.Current["IdUser"] = userResponses[i].Id;
            }
        }


        [When(@"Autorized by manager")]
        public void WhenAutorizedByManager()
        {
            List<RegistrationRequestModel> user = (List<RegistrationRequestModel>)ScenarioContext.Current["Manager"];
            string email = user[0].Email;
            string password = user[0].Password;
            ScenarioContext.Current["ManagerToken"] = AuthClient.AuthUser(email, password);
            _tokenManager = (string)ScenarioContext.Current["ManagerToken"];
        }

        [When(@"Assing users role methodist, teacher, tutor")]
        public void WhenAssingUsersRoleMethodistTeacherTutor(Table table)
        {
            RoleModel role = table.CreateSet<RoleModel>().ToList().First();
            ScenarioContext.Current["Roles"] = role;
            string token = (string)ScenarioContext.Current["ManagerToken"];
            int id = (int)ScenarioContext.Current["IdUser"];
            AddRoleUsers.AddRole(role.NameRole, id, token);
        }

        [Then(@"Сheck user roles")]
        public void ThenСheckUserRoles()
        {
            string token = (string)ScenarioContext.Current["ManagerToken"];
            int id = (int)ScenarioContext.Current["IdUser"];
            RegistrationResponseModel getUsersActual = GetClient.GetUserById(token, id);
            RoleModel roleExpected = (RoleModel)ScenarioContext.Current["Roles"];
            Assert.AreEqual(roleExpected.NameRole, getUsersActual.Roles[1]);
        }

        // new Scenario 



        [Given(@"Create users")]
        public void GivenCreateFutureManadgerAndMethodist(Table table)
        {
            List<int> idList = new List<int>();
            List<RegistrationRequestModel> users = table.CreateSet<RegistrationRequestModel>().ToList();
            AuthClient register = new AuthClient();
            List<RegistrationResponseModel> a = register.Registration(users);
            ScenarioContext.Current["UserRequestModel"] = users;
            for(int i = 0; i < a.Count; i++)
            {
                idList.Add(a[i].Id); 
            }
            ScenarioContext.Current["UsersId"] = idList;
        }

        [Given(@"Assing Manager and Methodist roles")]
        public void GivenAssingMinevraAndMethodistRoles(Table table)
        {
            List<RoleModel> roles = table.CreateSet<RoleModel>().ToList();
            string token = _tokenAdmin;
            List<int> idUsers = (List<int>)ScenarioContext.Current["UsersId"];
            for (int i = 0; i < roles.Count; i++)
            {
                AddRoleUsers.AddRole(roles[i].NameRole, idUsers[i], token);
            }
        }

        [When(@"Autorized by methodist")]
        public void WhenAutorizedByMethodist()
        {
            var requestModel = (List<RegistrationRequestModel>)ScenarioContext.Current["UserRequestModel"];
            string email = requestModel[1].Email;
            string password = requestModel[1].Password;
            ScenarioContext.Current["MethodistToken"] = AuthClient.AuthUser(email, password);
        }

        [Given(@"Create Course by methodist")]
        public void GivenCreateCourseByMethodist(Table table)
        {

            CourseRequestModel course = table.CreateSet<CourseRequestModel>().ToList().First();
            string token = (string)ScenarioContext.Current["MethodistToken"];
            CourseResponseModel courseReturn = AddEntitysClients.CreateCourse(token, course);
            ScenarioContext.Current["CourseId"] = courseReturn.Id;
            _curseId = courseReturn.Id;
        }

        [Given(@"Autorized by manager")]
        public void GivenAutorizedByManager()
        {
            var requestModel = (List<RegistrationRequestModel>)ScenarioContext.Current["UserRequestModel"];
            string email = requestModel[0].Email;
            string password = requestModel[0].Password;
            ScenarioContext.Current["ManagerToken"] = AuthClient.AuthUser(email, password);
            _tokenManager = (string)ScenarioContext.Current["ManagerToken"];
        }

        [When(@"Create Groupe")]
        public void WhenCreateGroupe(Table table)
        {
            var group = table.CreateSet<GroupRequestModel>().ToList().First();
            ScenarioContext.Current["GroupRequestModel Expected"] = group;
            group.CourseId = (int)ScenarioContext.Current["CourseId"];
            string token = (string)ScenarioContext.Current["ManagerToken"];
            GroupResponseModel groupReturn = AddEntitysClients.CreateGroupe(token, group);
            ScenarioContext.Current["GroupReturnActual"] = groupReturn;
            HttpResponseMessage httpResponse = AddEntitysClients.CreateGroupe();
            ScenarioContext.Current["StatusCode"] = httpResponse.StatusCode;

        }

        [Then(@"Compare group status code (.*)")]
        public void ThenCompareGroupStatusCode(int statusCode)
        {
            HttpStatusCode expected = (HttpStatusCode)statusCode;
            HttpStatusCode actual = (HttpStatusCode)ScenarioContext.Current["StatusCode"];
            Assert.AreEqual(expected, actual);
        }

        [When(@"Get group by id")]
        public void WhenGetGroupById()
        {
            string token = (string)ScenarioContext.Current["ManagerToken"];
            GroupResponseModel groupReturn = (GroupResponseModel)ScenarioContext.Current["GroupReturnActual"];
            ReturnByIdGroupModel returnGroupById = GetClient.GetGroupById(groupReturn.Id,token);
            ScenarioContext.Current["Return Group By Id Actual"] = returnGroupById;
        }

        [Then(@"Compare the resulting group by id with group request")]
        public void ThenCompareTheResultingGroupByIdWithGroupRequest()
        {
            ReturnByIdGroupModel actual = (ReturnByIdGroupModel)ScenarioContext.Current["Return Group By Id Actual"];
            GroupRequestModel expected = (GroupRequestModel)ScenarioContext.Current["GroupRequestModel Expected"];
            if(actual.GroupStatus == "Forming")
            {
                actual.GroupStatus = "1";
            }
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.CourseId, actual.Course.Id);
            Assert.AreEqual(expected.GroupStatusId, actual.GroupStatus);
            Assert.AreEqual(expected.StartDate, actual.StartDate);
            Assert.AreEqual(expected.EndDate, actual.EndDate);
            Assert.AreEqual(expected.Timetable, actual.Timetable);
            Assert.AreEqual(expected.PaymentPerMonth, actual.PaymentPerMonth);
        }

        // new Scenario 

        [Given(@"Create Groupe")]
        public void GivenCreateGroupe(Table table)
        {
           GroupRequestModel group = table.CreateSet<GroupRequestModel>().ToList().First();
           ScenarioContext.Current["CourseId"] = _curseId;
           group.CourseId = _curseId;
           ScenarioContext.Current["TokenManager"] = _tokenManager;
           string token = (string)ScenarioContext.Current["TokenManager"];
           ScenarioContext.Current["Group Response Model"] = AddEntitysClients.CreateGroupe(token, group);
           ScenarioContext.Current["Group Request Model"] = group;
        }

        [Given(@"Create three users")]
        public void GivenCreateThreeUsers(Table table)
        {
            List<RegistrationRequestModel> users = table.CreateSet<RegistrationRequestModel>().ToList();
            ScenarioContext.Current["UsersRequest"] = users;
            AuthClient register = new AuthClient();
            ScenarioContext.Current["UsersResponse"] = register.Registration(users);
        }

        [Given(@"Assign two students roles ""([^""]*)"" and ""([^""]*)""")]
        public void GivenAssignTwoStudentsRolesAnd(string teacher, string tutor)
        {
            string token = (string)ScenarioContext.Current["TokenManager"];
            var responseUser = (List<RegistrationResponseModel>)ScenarioContext.Current["UsersResponse"];
            int idTeacher = responseUser[1].Id;
            int idTutor = responseUser[2].Id;
            AddRoleUsers.AddRole(teacher, idTeacher, token);
            AddRoleUsers.AddRole(tutor, idTutor, token);
            List<int> idUsers = new List<int>(){ responseUser[0].Id,idTeacher,idTutor};
            ScenarioContext.Current["IdUsers"] = idUsers;
         }

        [Given(@"Get Users by id")]
        public void GivenGetUsersById()
        {
            string token = (string)ScenarioContext.Current["ManagerToken"];
            List<RegistrationResponseModel> getUsers = new List<RegistrationResponseModel>();
            List<int> idUsers = (List<int>)ScenarioContext.Current["IdUsers"];
            for (int i = 0; i < idUsers.Count; i++)
            {
                 RegistrationResponseModel a = GetClient.GetUserById(token, idUsers[i]);
                getUsers.Add(a);
            }
            List<string> rolesUsers = new List<string>() { getUsers[0].Roles[0], getUsers[1].Roles[1], getUsers[2].Roles[1] };
            ScenarioContext.Current["IdStringRolesUsers"] = rolesUsers;
        }


        [When(@"Add three users Student, Teacher and Tutor in group")]
        public void WhenAddThreeUsersStudentTeacherAndTutorInGroup()
        {
            GroupResponseModel groupResponse = (GroupResponseModel)ScenarioContext.Current["Group Response Model"];
            int idGroup = groupResponse.Id;
            string token = (string)ScenarioContext.Current["ManagerToken"];
            List<int> idUsers = (List<int>)ScenarioContext.Current["IdUsers"];
            List<string> idRoles = (List<string>)ScenarioContext.Current["IdStringRolesUsers"];
            for (int i = 0; i <idUsers.Count; i++)
            {
                AddEntitysClients.AddUserInGroup(idGroup, idUsers[i],idRoles[i], token);
            }
        }

        [When(@"Get my group by id")]
        public void WhenGetMyGroupById()
        {
            string token = (string)ScenarioContext.Current["ManagerToken"];
            GroupResponseModel groupResponse = (GroupResponseModel)ScenarioContext.Current["Group Response Model"];
            int idGroup = groupResponse.Id;
            ScenarioContext.Current["Return By Id Model Actual"] = GetClient.GetGroupById(idGroup, token); // ReturnByIdGroupModel
        }

        [Then(@"Compare the resulting filled group by id with group request")]
        public void ThenCompareTheResultingFilledGroupByIdWithGroupRequest()
        {
            ReturnByIdGroupModel actual = (ReturnByIdGroupModel)ScenarioContext.Current["Return By Id Model Actual"];
            GroupRequestModel a = (GroupRequestModel)ScenarioContext.Current["Group Request Model"];
            GroupResponseModel groupResponse = (GroupResponseModel)ScenarioContext.Current["Group Response Model"];
            int idGroup = groupResponse.Id;
            List<int> idUsers = (List<int>)ScenarioContext.Current["IdUsers"];
            List<RegistrationRequestModel> users = (List<RegistrationRequestModel>)ScenarioContext.Current["UsersRequest"];
            TutorModel tutor = new TutorModel()
            {
                Id = idUsers[2],
                FirstName = users[2].FirstName,
                LastName = users[2].LastName,
                Email = users[2].Email,
                Photo = null
            };
            TeacherModel teacher = new TeacherModel()
            {
                Id = idUsers[1],
                FirstName = users[1].FirstName,
                LastName= users[1].LastName,
                Email = users[1].Email,
                Photo = null
            };
            StudentModel student = new StudentModel()
            {
                Id = idUsers[0],
                FirstName = users[0].FirstName,
                LastName = users[0].LastName,
                Email= users[0].Email,
                Photo = null
            };
            Course course = new Course()
            {
                Id = _curseId,
                Name = "Дрязяшки",
                IsDeleted = false,
            };
            ReturnByIdGroupModel expected = new ReturnByIdGroupModel()
           {
               Students = new List<StudentModel>() { student },
               Teachers = new List<TeacherModel>() { teacher },
               Tutors = new List<TutorModel>() { tutor },
               Id = idGroup,
               Name = a.Name,
               Course = course,
               GroupStatus = "Forming", 
               StartDate = a.StartDate,
               EndDate = a.EndDate,
               Timetable = a.Timetable,
               PaymentPerMonth = a.PaymentPerMonth
           };
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.GroupStatus, actual.GroupStatus);
            Assert.AreEqual(expected.StartDate, actual.StartDate);
            Assert.AreEqual(expected.EndDate, actual.EndDate);
            Assert.AreEqual(expected.Timetable, actual.Timetable);
            Assert.AreEqual(expected.PaymentPerMonth, actual.PaymentPerMonth);
            Assert.AreEqual(expected.Course.Name, actual.Course.Name);
            Assert.AreEqual(expected.Course.Id, actual.Course.Id);
            Assert.AreEqual(expected.Course.IsDeleted, actual.Course.IsDeleted);
            Assert.AreEqual(expected.Students[0].LastName,actual.Students[0].LastName);
            Assert.AreEqual(expected.Students[0].FirstName, actual.Students[0].FirstName);
            Assert.AreEqual(expected.Students[0].Id, actual.Students[0].Id);
            Assert.AreEqual(expected.Students[0].Email, actual.Students[0].Email);
            Assert.AreEqual(expected.Students[0].Photo, actual.Students[0].Photo);
            Assert.AreEqual(expected.Teachers[0].FirstName,actual.Teachers[0].FirstName);
            Assert.AreEqual(expected.Teachers[0].LastName, actual.Teachers[0].LastName);
            Assert.AreEqual(expected.Teachers[0].Id, actual.Teachers[0].Id);
            Assert.AreEqual(expected.Teachers[0].Email, actual.Teachers[0].Email);
            Assert.AreEqual(expected.Teachers[0].Photo, actual.Teachers[0].Photo);
            Assert.AreEqual(expected.Tutors[0].LastName,actual.Tutors[0].LastName);
            Assert.AreEqual(expected.Tutors[0].FirstName, actual.Tutors[0].FirstName);
            Assert.AreEqual(expected.Tutors[0].Id, actual.Tutors[0].Id);
            Assert.AreEqual(expected.Tutors[0].Email, actual.Tutors[0].Email);
            Assert.AreEqual(expected.Tutors[0].Photo, actual.Tutors[0].Photo);
        }

        // new Scenario (update)

        [Given(@"Create Groupe number three")]
        public void GivenCreateGroupeNumberThree(Table table)
        {
            ScenarioContext.Current["TokenManadger"] = _tokenManager;
            string tokenManager = (string)ScenarioContext.Current["TokenManadger"];
            GroupRequestModel groupRequest = table.CreateSet<GroupRequestModel>().ToList().First();
            groupRequest.CourseId = _curseId;
            ScenarioContext.Current["Group Response Model"] = AddEntitysClients.CreateGroupe(tokenManager, groupRequest);
        }

        [When(@"chanche group")]
        public void WhenChancheGroup(Table table)
        {
            GroupRequestModel groupChange = table.CreateSet<GroupRequestModel>().ToList().First();
            groupChange.CourseId = _curseId;
            ScenarioContext.Current["Update Request Model"] = groupChange;
            GroupResponseModel groupResponse = (GroupResponseModel)ScenarioContext.Current["Group Response Model"];
            int idGroup = groupResponse.Id;
            string token = (string)ScenarioContext.Current["TokenManadger"];
            UpdateClient.UpdateGroup(idGroup, groupChange,token);
        }

        [When(@"Get group number three by id")]
        public void WhenGetGroupNumberThreeById()
        {
            GroupResponseModel groupResponse = (GroupResponseModel)ScenarioContext.Current["Group Response Model"];
            int idGroup = groupResponse.Id;
            string token = (string)ScenarioContext.Current["TokenManadger"];
            ScenarioContext.Current["Group Actual"] = GetClient.GetGroupById(idGroup,token);
        }

        [Then(@"Сompare changed group and returned group")]
        public void ThenCompareTheResultingGroupChenchGroupNumberThree()
        {
            GroupRequestModel expected = (GroupRequestModel)ScenarioContext.Current["Update Request Model"];
            ReturnByIdGroupModel actual = (ReturnByIdGroupModel)ScenarioContext.Current["Group Actual"];
            if (actual.GroupStatus == "Forming")
            {
                actual.GroupStatus = "1";
            }
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.CourseId, actual.Course.Id);
            Assert.AreEqual(expected.GroupStatusId, actual.GroupStatus);
            Assert.AreEqual(expected.StartDate, actual.StartDate);
            Assert.AreEqual(expected.EndDate, actual.EndDate);
            Assert.AreEqual(expected.Timetable, actual.Timetable);
            Assert.AreEqual(expected.PaymentPerMonth, actual.PaymentPerMonth);
        }

    }
}
