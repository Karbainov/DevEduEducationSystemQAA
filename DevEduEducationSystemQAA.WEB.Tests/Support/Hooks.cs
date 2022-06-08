using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEduEducationSystemQAA.WEB.Tests.Support
{
    [Binding]
    public class Hooks
    {

        public static bool isCheck = false;
        public static string forDelete = null;


        [AfterScenario]
         public void AfterScenarioDelete()
         {
            if (isCheck)
            {
                string email = "userTestStudent@example.com";
                string password = "userTestStudent";
                string token = IOHelper.AuthUser(email, password);
                UserModel user = IOHelper.GetUserByToken(token);
                List<StudentHomework> listAnswer = IOHelper.GetAllStudenHomeworkById(user.Id, token);
                int idStudentHomework = -1;
                for (int i = 0; i < listAnswer.Count; i++)
                {
                    if (listAnswer[i].Answer == forDelete)
                    {
                        idStudentHomework = listAnswer[i].Id;
                        break;
                    }
                }
                IOHelper.DeleteStudentHomework(idStudentHomework);
            }
         }
    }
}
