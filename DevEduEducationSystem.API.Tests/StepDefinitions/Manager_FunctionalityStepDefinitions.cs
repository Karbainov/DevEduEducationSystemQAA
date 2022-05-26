
using DevEduEducationSystem.API.Tests.Support.Models.RequestModels;
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
        private List<int> _idUser = new List<int>();

        [Given(@"Create user")]
        public void GivenCreateUser(Table table)
        {
            List<RegistrationRequestModel> user = table.CreateSet<RegistrationRequestModel>().ToList();
            List<RegistrationResponseModel> userResponses = AuthClient.Registration(user);
            FeatureContext.Current["UserRequestModel"] = user;
            ScenarioContext.Current["Manager"] = user;
            for (int i = 0; i < userResponses.Count; i++)
            {
                ScenarioContext.Current["IdManager"] = userResponses[i].Id;
            }
            for (int i = 0; i < userResponses.Count; i++)
            {
                _idUser.Add(userResponses[i].Id);
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
            List<RegistrationResponseModel> userResponses = AuthClient.Registration(user);
            ScenarioContext.Current["Users"] = user;
            for (int i = 0; i < userResponses.Count; i++)
            {
                ScenarioContext.Current["IdUser"] = userResponses[i].Id;
            }
        }

        [Given(@"Autorized by manager")]
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

        [Given(@"Assing Manager and Methodist roles")]
        public void GivenAssingMinevraAndMethodistRoles(Table table)
        {
            List<RoleModel> roles = table.CreateSet<RoleModel>().ToList();
            string token = _tokenAdmin;
            List<int> idUsers = _idUser;

            for (int i = 0; i < roles.Count; i++)
            {
                AddRoleUsers.AddRole(roles[i].NameRole, idUsers[i], token);
            }
        }
        
        [When(@"Autorized by methodist")]
        public void WhenAutorizedByMethodist()
        {
            var requestModel = (List<RegistrationRequestModel>)FeatureContext.Current["UserRequestModel"];
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
        

        [When(@"Create Groupe")]
        public void WhenCreateGroupe(Table table)
        {
            var group = table.CreateSet<GroupRequestModel>().ToList().First();
            ScenarioContext.Current["GroupRequestModel Expected"] = group;
            group.CourseId = (int)ScenarioContext.Current["CourseId"];
            string token = _tokenManager;
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
            string token = _tokenManager;
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
            Assert.AreEqual(expected.PaymentsCount, actual.PaymentsCount);
        }

        // new Scenario 

        [Given(@"Create Groupe")]
        public void GivenCreateGroupe(Table table)
        {
           GroupRequestModel group = table.CreateSet<GroupRequestModel>().ToList().First();
           ScenarioContext.Current["CourseId"] = _curseId;
           group.CourseId = _curseId;
           string token = _tokenManager;
           ScenarioContext.Current["Group Response Model"] = AddEntitysClients.CreateGroupe(token, group);
           ScenarioContext.Current["Group Request Model"] = group;
        }

        [Given(@"Create three users")]
        public void GivenCreateThreeUsers(Table table)
        {
            List<RegistrationRequestModel> users = table.CreateSet<RegistrationRequestModel>().ToList();
            ScenarioContext.Current["UsersRequest"] = users;
            ScenarioContext.Current["UsersResponse"] = AuthClient.Registration(users);
        }

        [Given(@"Assign two students roles ""([^""]*)"" and ""([^""]*)""")]
        public void GivenAssignTwoStudentsRolesAnd(string teacher, string tutor)
        {
            string token = _tokenManager;
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
            string token = _tokenManager;
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
            string token = _tokenManager;
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
            string token = _tokenManager;
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
            UserResponseModel teacher = new UserResponseModel()
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
               Teachers = new List<UserResponseModel>() { teacher },
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

        // new Scenario (Delete)

        [Given(@"Assign manager role to user ""([^""]*)""")]
        public void GivenAssignManagerRoleToUser(string manager)
        {
            AddRoleUsers.AddRole(manager, _idUser[0], _tokenAdmin);
        }


        [Given(@"Create course")]
        public void GivenCreateCourse(Table table)
        {
            CourseRequestModel course = table.CreateSet<CourseRequestModel>().ToList().First();
            CourseResponseModel courseResponse = AddEntitysClients.CreateCourse(_tokenAdmin,course);
            ScenarioContext.Current["IdCourse"] = courseResponse.Id;
            _curseId = courseResponse.Id;
        }

        [Given(@"Create Groupe QAA")]
        public void GivenCreateGroupeQAA(Table table)
        {
            GroupRequestModel groupRequest = table.CreateSet<GroupRequestModel>().ToList().First();
            groupRequest.CourseId = (int)ScenarioContext.Current["IdCourse"];
            ScenarioContext.Current["TokenManager"] = _tokenManager;
            GroupResponseModel groupResponse = AddEntitysClients.CreateGroupe(_tokenManager, groupRequest);
            ScenarioContext.Current["iDGroup"] = groupResponse.Id;
            ScenarioContext.Current["Group expected"] = groupRequest;
        }


        [When(@"Delete group by id")]
        public void WhenDeleteGroupById()
        {
            int id = (int)ScenarioContext.Current["iDGroup"];
            string token = (string)ScenarioContext.Current["TokenManager"];
            DeleteClient.DeleteGroupeById(token,id);
        }

        [When(@"Get all groups")]
        public void WhenGetAllGroups()
        {
            string token = (string)ScenarioContext.Current["TokenManager"];
            ScenarioContext.Current["Expected group model"] = GetClient.GetAllGroups(token);
        }

        [Then(@"Deleted group should disappear")]
        public void ThenDeletedGroupShouldDisappear()
        {
            List<GroupResponseModel> actual = (List<GroupResponseModel>)ScenarioContext.Current["Expected group model"];
            GroupRequestModel expected = (GroupRequestModel)ScenarioContext.Current["Group expected"];
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreNotEqual(expected.Name, actual[i].Name);
                Assert.AreNotEqual(expected.EndDate, actual[i].EndDate);
                Assert.AreNotEqual(expected.StartDate, actual[i].StartDate);
                Assert.AreNotEqual(expected.PaymentPerMonth, actual[i].PaymentPerMonth);
                Assert.AreNotEqual(expected.CourseId, actual[i].Course.Id);
                Assert.AreNotEqual(expected.GroupStatusId, actual[i].GroupStatus); 
            }
        }

        // new Scenario (change Group Status)

        [Given(@"Create Groupe Back")]
        public void GivenCreateGroupeBack(Table table)
        {
            GroupRequestModel groupRequest = table.CreateSet<GroupRequestModel>().ToList().First();
            groupRequest.CourseId = _curseId;
           ScenarioContext.Current["Group Response"] = AddEntitysClients.CreateGroupe(_tokenManager,groupRequest);
        }

        [When(@"Change group status by id")]
        public void WhenChangeGroupStatusById(Table table)
        {
            GroupStatusRequestModel groupStatus = table.CreateInstance<GroupStatusRequestModel>();
            ScenarioContext.Current["GroupStatus"] = groupStatus;
            GroupResponseModel groupResponse = (GroupResponseModel)ScenarioContext.Current["Group Response"];
            ScenarioContext.Current["group actual"] = UpdateClient.UpdateGroupStatus(groupResponse.Id, groupStatus.GroupStatusName,_tokenManager);
        }

        [Then(@"Group Status should changed")]
        public void ThenGroupStatusShouldChanged()
        {
            GroupResponseMiniModel actual = (GroupResponseMiniModel)ScenarioContext.Current["group actual"];
            GroupStatusRequestModel expected = (GroupStatusRequestModel)ScenarioContext.Current["GroupStatus"];
            Assert.AreEqual(expected.GroupStatusName, actual.GroupStatus);
        }

        // new Scenario

        [Given(@"Assign role")]
        public void GivenAssignRole(Table table)
        {
            List<RoleModel> roles = table.CreateSet<RoleModel>().ToList();
            for (int i = 0; i < roles.Count; i++)
            {
                AddRoleUsers.AddRole(roles[i].NameRole, _idUser[i], _tokenAdmin);
            }
        }

        [Given(@"Сreate a group to remove a user from it")]
        public void GivenСreateAGroupToRemoveAUserFromIt(Table table)
        {
            GroupRequestModel groupRequest = table.CreateSet<GroupRequestModel>().ToList().First();
            groupRequest.CourseId = _curseId;
            FeatureContext.Current["Group Response"] = AddEntitysClients.CreateGroupe(_tokenManager, groupRequest);
            FeatureContext.Current["Group Request"] = groupRequest;
        }

        [Given(@"Add Users in group")]
        public void GivenAddUsersInGroup()
        {
            GroupResponseModel groupResponse = (GroupResponseModel)FeatureContext.Current["Group Response"];
            for (int i = 1; i < _idUser.Count; i++) 
            {
                    AddEntitysClients.AddUserInGroup(groupResponse.Id, _idUser[i], "Student", _tokenManager);
            }
        }

        [When(@"Delete adding user from a group")]
        public void WhenDeleteUserFromAGroup()
        {
            GroupResponseModel groupResponse = (GroupResponseModel)FeatureContext.Current["Group Response"];
            DeleteClient.DeleteUserFromGroup(_tokenManager, groupResponse.Id, _idUser[3]);
        }

        [When(@"Get group  by id")]
        public void WhenGet_GroupById()
        {
            GroupResponseModel groupResponse = (GroupResponseModel)FeatureContext.Current["Group Response"];
            FeatureContext.Current["Group Full"] = GetClient.GetGroupById(groupResponse.Id, _tokenManager);
        }

        [Then(@"Check that student have left the group")]
        public void ThenCheckThatStudentHaveLeftTheGroup(Table table)
        {
            List<RegistrationRequestModel> srudentExpected = table.CreateSet<RegistrationRequestModel>().ToList();
            List<UserResponseModel> teacher = new List<UserResponseModel>();
            GroupRequestModel expected = (GroupRequestModel)FeatureContext.Current["Group Request"];
            ReturnByIdGroupModel groupFull = (ReturnByIdGroupModel)FeatureContext.Current["Group Full"];
            Assert.AreEqual(groupFull.Students.Count, 2);
            for (int i = 0; i < groupFull.Students.Count; i++)
            {
                Assert.AreNotEqual(srudentExpected[2].Username, groupFull.Students[i].Username);
                Assert.AreNotEqual(srudentExpected[2].LastName, groupFull.Students[i].LastName);
                Assert.AreNotEqual(srudentExpected[2].FirstName, groupFull.Students[i].FirstName);
                Assert.AreNotEqual(srudentExpected[2].Email, groupFull.Students[i].Email);
                Assert.AreNotEqual(srudentExpected[2].Patronymic, groupFull.Students[i].Patronymic);
            }
            Assert.AreEqual(teacher, groupFull.Teachers);
            Assert.AreEqual(expected.CourseId, groupFull.Course.Id);
            Assert.AreEqual(expected.Name, groupFull.Name);
        }

        // new Scenario

        [Given(@"Add Users in group as teacher")]
        public void GivenAddUsersInGroupAsTeacher()
        {
            GroupResponseModel groupResponse = (GroupResponseModel)FeatureContext.Current["Group Response"];
            for (int i = 1; i < _idUser.Count; i++)
            {
                AddEntitysClients.AddUserInGroup(groupResponse.Id, _idUser[i], "Teacher", _tokenManager);
            }
        }

        [When(@"Delete adding teacher from a group")]
        public void WhenDeleteAddingTeacherFromAGroup()
        {
            GroupResponseModel groupResponse = (GroupResponseModel)FeatureContext.Current["Group Response"];
            DeleteClient.DeleteUserFromGroup(_tokenManager, groupResponse.Id, _idUser[3]);
        }

        [Then(@"Check that teacher have left the group")]
        public void ThenCheckThatTeacherHaveLeftTheGroup(Table table)
        {
            List<RegistrationRequestModel> teacherExpected = table.CreateSet<RegistrationRequestModel>().ToList();
            List<StudentModel> student = new List<StudentModel>();
            GroupRequestModel expected = (GroupRequestModel)FeatureContext.Current["Group Request"];
            ReturnByIdGroupModel groupFull = (ReturnByIdGroupModel)FeatureContext.Current["Group Full"];
            Assert.AreEqual(groupFull.Teachers.Count, 2);
            for (int i = 0; i < groupFull.Teachers.Count; i++)
            {
                Assert.AreNotEqual(teacherExpected[2].Username, groupFull.Teachers[i].LastName);
                Assert.AreNotEqual(teacherExpected[2].FirstName, groupFull.Teachers[i].FirstName);
                Assert.AreNotEqual(teacherExpected[2].Email, groupFull.Teachers[i].Email);
            }
            Assert.AreEqual(student, groupFull.Students);
            Assert.AreEqual(expected.CourseId, groupFull.Course.Id);
            Assert.AreEqual(expected.Name, groupFull.Name);
        }

        // new Scenario

        [Given(@"Create Groupe all group")]
        public void GivenCreateGroupeAllGroup(Table table)
        {
            List<GroupResponseModel> groupsResponse = new List<GroupResponseModel>();
            List<GroupRequestModel> groupsRequest = table.CreateSet<GroupRequestModel>().ToList();
            for (int i = 0; i < groupsRequest.Count; i++) 
            {
                groupsRequest[i].CourseId = _curseId;
                groupsResponse.Add(AddEntitysClients.CreateGroupe(_tokenManager,groupsRequest[i]));
            }
            ScenarioContext.Current["Groups Request"] = groupsRequest;
            ScenarioContext.Current["Groups Response"] = groupsResponse;
        }

        [When(@"Get all  groups")]
        public void WhenGetGroupAllGroups()
        {
           ScenarioContext.Current["All Groups"] = GetClient.GetAllGroups(_tokenManager);
        }

        [Then(@"Check that all groups should have returned")]
        public void ThenCheckThatAllGroupsShouldHaveReturned()
        {
            List<GroupResponseModel> actualGroups = (List<GroupResponseModel>)ScenarioContext.Current["All Groups"];
            List<GroupRequestModel> actual = new List<GroupRequestModel>();
            List<GroupRequestModel> expected = (List<GroupRequestModel>)ScenarioContext.Current["Groups Request"];
            for (int i = 0; i < actualGroups.Count; i++)
            {
                actual.Add(Mapper.MapGroupResponseModelToGroupRequestModel(actualGroups[i]));
            }
            for(int i = 0;i<actual.Count;i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        // new Scenario PAYMENT
        [Given(@"Create one payment")]
        [When(@"Create one payment")]
        public void WhenCreateOnePayment(Table table)
        {
            PaymentRequestModel paymentRequest = table.CreateSet<PaymentRequestModel>().ToList().First();
            paymentRequest.UserId = _idUser[1];
            PaymentResponseModel paymentResponse = AddEntitysClients.CreateOnePayment(_tokenManager, paymentRequest);
            ScenarioContext.Current["Payment Response"] = paymentResponse;
            ScenarioContext.Current["Payment Request"] = paymentRequest;
            FeatureContext.Current["IdPayment"] = paymentResponse.Id;
        }

        [When(@"Get payment by id")]
        public void WhenGetPaymentById()
        {
            PaymentResponseModel paymentResponse = (PaymentResponseModel)ScenarioContext.Current["Payment Response"];
           ScenarioContext.Current["Payment Get By Id"] = GetClient.GetPaymentById(paymentResponse.Id,_tokenManager);
        }

        [Then(@"Created payment should be returned")]
        public void ThenCreatedPaymentShouldBeReturned()
        {
            PaymentResponseModel paymentResponse = (PaymentResponseModel)ScenarioContext.Current["Payment Response"];
            PaymentResponseModel actual = (PaymentResponseModel)ScenarioContext.Current["Payment Get By Id"];
            PaymentRequestModel paymentRequest = (PaymentRequestModel)ScenarioContext.Current["Payment Request"];
            PaymentResponseModel expected = Mapper.MapPaymentRequestModelToPaymentResponseModel(paymentRequest);
            UserResponseModel student = new UserResponseModel()
            {
                Id = _idUser[1],
                FirstName = "Максим",
                LastName = "Опаздун",
                Email = "Opazd@mail.ru",
                Photo = null
            };
            expected.User = student;
            expected.Id = paymentResponse.Id;
            Assert.AreEqual(expected, actual); // не возвращает Email y User
        }

        // Payment negative

        [Then(@"Should return Status code (.*)")]
        public void ThenShouldReturnStatusCode(int statusCode)
        {
            HttpResponseMessage httpResponse = AddEntitysClients.CreateOnePayment();
            HttpStatusCode expected = (HttpStatusCode)statusCode;
            HttpStatusCode actual = httpResponse.StatusCode;
            Assert.AreEqual(expected, actual);
        }

        // Scenario PAYMENT CHANGE

        [When(@"Change payment")]
        public void WhenChangePayment(Table table)
        {
            int idPayment = (int)FeatureContext.Current["IdPayment"];
            PaymentRequestModel changePayment = table.CreateSet<PaymentRequestModel>().ToList().First();
            UpdateClient.UpdatePayment(changePayment,idPayment,_tokenManager);
            ScenarioContext.Current["Change payment Request"] = changePayment;
        }

        [When(@"Get a modified payment by")]
        public void WhenGetAModifiedPaymentBy()
        {
            int idPayment = (int)FeatureContext.Current["IdPayment"];
           ScenarioContext.Current["Change payment return by id"] = GetClient.GetPaymentById(idPayment, _tokenManager);
        }

        [Then(@"Changed payment should be returned by id")]
        public void ThenChangedPaymentShouldBeReturnedById()
        {
            PaymentRequestModel expected = (PaymentRequestModel)ScenarioContext.Current["Change payment Request"];
            expected.UserId = _idUser[1];
            PaymentResponseModel a = (PaymentResponseModel)ScenarioContext.Current["Change payment return by id"];
            PaymentRequestModel actual = Mapper.MapPaymentResponseModelToPaymentRequestModel(a);
            Assert.AreEqual(expected, actual);
        }


        // Scenario PAYMENT DELETE and GET ALL PAYMENT


        [Given(@"Create payments")]
        public void GivenCreatePayments(Table table)
        {
            List<PaymentRequestModel> payments = table.CreateSet<PaymentRequestModel>().ToList();
            for(int i = 0;i<payments.Count;i++)
            {
                payments[i].UserId = _idUser[1];
            }
            ScenarioContext.Current["List Payment Response"] = AddEntitysClients.CreatePayments(payments, _tokenManager);
            ScenarioContext.Current["List Payment Request"] = payments;
        }


        [When(@"Delete payment")]
        public void WhenDeletePayment()
        {
            List<PaymentResponseModel> payments = (List<PaymentResponseModel>)ScenarioContext.Current["List Payment Response"];
            int idPayment = payments[0].Id;
            DeleteClient.DeletePayment(_tokenManager, idPayment);
        }

        [When(@"Get all payments by")]
        public void WhenGetAllPaymentsBy()
        {
            ScenarioContext.Current["List All Payments"] = GetClient.GetAllPaymentsByUserId(_idUser[1],_tokenManager);
        }

        [Then(@"Remote payment should not return")]
        public void ThenRemotePaymentShouldNotReturn()
        {
            List<PaymentRequestModel> expected = (List<PaymentRequestModel>)ScenarioContext.Current["List Payment Request"];
            List<PaymentResponseModel> tmp = (List<PaymentResponseModel>)ScenarioContext.Current["List All Payments"];
            List<PaymentRequestModel> actual = new List<PaymentRequestModel>();
            for(int i = 0; i < tmp.Count; i++)
            {
               actual.Add(Mapper.MapPaymentResponseModelToPaymentRequestModel(tmp[i]));
            }
            Assert.AreEqual(2,actual.Count);
            for(int i = 0; i < actual.Count; i++)
            {
                Assert.AreNotEqual(expected[0], actual[i]);
            }

        }



    }
}
