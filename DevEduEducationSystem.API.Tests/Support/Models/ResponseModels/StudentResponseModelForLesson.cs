﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models.ResponseModels
{
    public class StudentResponseModelForLesson
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("student")]
        public UserResponseModel Student { get; set; }

        [JsonPropertyName("feedback")]
        public string Feedback { get; set; }

        [JsonPropertyName("attendanceType")]
        public string AttendanceType { get; set; }

        [JsonPropertyName("absenceReason")]
        public string AbsenceReason { get; set; }
    }
}
