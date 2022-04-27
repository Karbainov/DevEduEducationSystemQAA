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
                connection.OpenAsync();

                SqlCommand command = new SqlCommand();
                command.CommandText = "delete from dbo.[User_Role] where UserId<>6";
                command.Connection = connection;
                command.ExecuteNonQueryAsync();

                command.CommandText = "delete from dbo.[User_Group]";
                command.ExecuteNonQueryAsync();
                
                command.CommandText = "delete from dbo.[Student_Homework]";
                command.ExecuteNonQueryAsync();
                
                //command.CommandText = "delete from dbo.[Course]";
                //command.ExecuteNonQueryAsync();

                command.CommandText = "delete from dbo.[User] where Id<>6";
                command.ExecuteNonQueryAsync();

                connection.Close();
            }
        }
    }
}
