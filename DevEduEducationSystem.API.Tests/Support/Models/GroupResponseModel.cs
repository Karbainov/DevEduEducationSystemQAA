﻿using DevEduEducationSystem.API.Tests.Support.Models.StudentModelClassesForModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models
{
    public class GroupResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("course")]
        public Course Course { get; set; }

        [JsonPropertyName("groupStatus")]
        public string GroupStatus { get; set; }

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; }

        [JsonPropertyName("timetable")]
        public string Timetable { get; set; }

        [JsonPropertyName("paymentPerMonth")]
        public int PaymentPerMonth { get; set; }
    }
}