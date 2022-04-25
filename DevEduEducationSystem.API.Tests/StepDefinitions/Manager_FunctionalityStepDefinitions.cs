
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace DevEduEducationSystem.API.Tests.StepDefinitions
{
    [Binding]
    public class Manager_FunctionalityStepDefinitions
    {
        [Given(@"Create future manadger")]
        public void GivenCreateFutureManadger(Table table)
        {
            List<RegisterRequestModel> user = table.CreateSet<RegisterRequestModel>().ToList();
            AuthClient registr = new AuthClient();
            List<RegistrationResponsesModel> userResponses = registr.Registration(user);
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
            FeatureContext.Current["AdminToken"] = AuthClient.AuthUser(email, password);
        }

        [Given(@"Assing Minevra ""([^""]*)""")]
        public void GivenAssingMinevra(string manager)
        {
            string token = (string)FeatureContext.Current["AdminToken"];
            List<int> listId = new List<int>();
            listId.Add((int)ScenarioContext.Current["IdManager"]);
            int id = listId[0];
            AddRoleUsers.AddRole(manager, id, token);
        }

        [Given(@"Create new users for our roles")]
        public void GivenCreateNewUsersForOurRoles(Table table)
        {
            List<RegisterRequestModel> user = table.CreateSet<RegisterRequestModel>().ToList();
            AuthClient registr = new AuthClient();
            List<RegistrationResponsesModel> userResponses = registr.Registration(user);
            ScenarioContext.Current["Users"] = user;
            for (int i = 0; i < userResponses.Count; i++)
            {
                ScenarioContext.Current["IdUser"] = userResponses[i].Id;
            }
        }


        [When(@"Autorized by manager")]
        public void WhenAutorizedByManager()
        {
            List<RegisterRequestModel> user = (List<RegisterRequestModel>)ScenarioContext.Current["Manager"];
            string email = user[0].Email;
            string password = user[0].Password;
            ScenarioContext.Current["ManagerToken"] = AuthClient.AuthUser(email, password);
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
            List<RegistrationResponsesModel> getUsersActual = new List<RegistrationResponsesModel>();
            string token = (string)ScenarioContext.Current["ManagerToken"];
            int id = (int)ScenarioContext.Current["IdUser"];
            getUsersActual = GetClient.GetUserById(token, id);
            RoleModel roleExpected = (RoleModel)ScenarioContext.Current["Roles"];
            for (int i = 0; i < getUsersActual.Count; i++)
            {
                Assert.AreEqual(roleExpected.NameRole, getUsersActual[i].Roles[1]);
            }

        }

        // new Scenario 

        [Given(@"Create future manadger and methodist")]
        public void GivenCreateFutureManadgerAndMethodist(Table table)
        {
            List<int> idList = new List<int>();
            List<RegisterRequestModel> users = table.CreateSet<RegisterRequestModel>().ToList();
            AuthClient register = new AuthClient();
            List<RegistrationResponsesModel> a = register.Registration(users);
            ScenarioContext.Current["UserRequestModel"] = users;
            for(int i = 0; i < a.Count; i++)
            {
                idList.Add(a[i].Id); 
            }
            ScenarioContext.Current["UsersId"] = idList;
        }

        [Given(@"Assing Minevra and Methodist roles")]
        public void GivenAssingMinevraAndMethodistRoles(Table table)
        {
            List<RoleModel> roles = table.CreateSet<RoleModel>().ToList();
            string token = (string)FeatureContext.Current["AdminToken"];
            List<int> idUsers = (List<int>)ScenarioContext.Current["UsersId"];
            for (int i = 0; i < roles.Count; i++)
            {
                AddRoleUsers.AddRole(roles[i].NameRole, idUsers[i], token);
            }
        }

        [When(@"Autorized by methodist")]
        public void WhenAutorizedByMethodist()
        {
            var requestModel = (List<RegisterRequestModel>)ScenarioContext.Current["UserRequestModel"];
            string email = requestModel[1].Email;
            string password = requestModel[1].Password;
            ScenarioContext.Current["MethodistToken"] = AuthClient.AuthUser(email, password);
        }

        [Given(@"Create Course by methodist")]
        public void GivenCreateCourseByMethodist(Table table)
        {

            CourseRequestModel course = table.CreateSet<CourseRequestModel>().ToList().First();
            string token = (string)ScenarioContext.Current["MethodistToken"];
            CourseResponsesModel courseReturn = AddEntitysClients.CreateCourse(token, course);
            ScenarioContext.Current["CourseId"] = courseReturn.Id;
        }

        [Given(@"Autorized by manager")]
        public void GivenAutorizedByManager()
        {
            var requestModel = (List<RegisterRequestModel>)ScenarioContext.Current["UserRequestModel"];
            string email = requestModel[0].Email;
            string password = requestModel[0].Password;
            ScenarioContext.Current["ManagerToken"] = AuthClient.AuthUser(email, password);
        }

        [When(@"Create Groupe")]
        public void WhenCreateGroupe(Table table)
        {
            var group = table.CreateSet<GroupRequestModel>().ToList().First();
            group.CourseId = (int)ScenarioContext.Current["CourseId"];
            string token = (string)ScenarioContext.Current["ManagerToken"];
            GroupResponsesModel groupReturn = AddEntitysClients.CreateGroupe(token, group);
            ScenarioContext.Current["GroupReturnActual"] = groupReturn;
        }

        [When(@"Get group by id")]
        public void WhenGetGroupById()
        {
            string token = (string)ScenarioContext.Current["ManagerToken"];
            GroupResponsesModel groupReturn = (GroupResponsesModel)ScenarioContext.Current["GroupReturnActual"];
            HttpResponseMessage httpResponse = GetClient.GetGroupById(groupReturn.Id, token);
            ScenarioContext.Current["StatusCode"] = httpResponse.StatusCode;
        }

        [Then(@"Compare group status code (.*)")]
        public void ThenCompareGroupStatusCode(int statusCode)
        {
            HttpStatusCode expected = (HttpStatusCode)statusCode;
            HttpStatusCode actual = (HttpStatusCode)ScenarioContext.Current["StatusCode"];
            Assert.AreEqual(expected, actual);
        }


    }
}
