using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models.ResponseModels
{
    public class StudentRequestModelForCheckAttendance
    {
        [JsonPropertyName("id")]
        public int IdStudent { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("attendanceType")]
        public string AttendanceType { get; set; }

    }
}
