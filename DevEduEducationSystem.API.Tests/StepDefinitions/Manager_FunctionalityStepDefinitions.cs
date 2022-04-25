
using System;
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
            ScenarioContext.Current["AdminToken"] = AuthClient.AuthUser(email, password);
        }

        [Given(@"Assing Minevra ""([^""]*)""")]
        public void GivenAssingMinevra(string manager)
        {
            string token = (string)ScenarioContext.Current["AdminToken"];
            List<int> listId = new List<int>();
            //здесь закончила
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
    }
}
