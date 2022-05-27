using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DevEduEducationSystem.API.Tests.Support
{
    [Binding]
    internal class Hooks
    {
        [AfterScenario]
        public void AfterScenario()
        {
            string connectionString = @"Data Source=80.78.240.16;Initial Catalog = DevEdu.Test; Persist Security Info=True;User ID = student;Password=qwe!23;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = "delete from dbo.[User_Role] where UserId <> 6";
                command.Connection = connection;
                var i = command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Group_Lesson]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Lesson_Topic]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Lesson]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Student_Homework]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Homework]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Task]";
                command.ExecuteNonQuery();          

               
                command.CommandText = "delete from dbo.[User_Group]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Group]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Course_Topic]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Topic]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Course_Task]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Course_Material]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Payment]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Course]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[User] where Id <> 6";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Comment]";
                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
