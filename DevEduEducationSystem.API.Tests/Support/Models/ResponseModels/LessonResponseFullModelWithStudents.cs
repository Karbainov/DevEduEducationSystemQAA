﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models.ResponseModels
{
    public class LessonResponseFullModelWithStudents
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("additionalMaterials")]
        public string AdditionalMaterials { get; set; }

        [JsonPropertyName("teacher")]
        public UserResponseModel Teacher { get; set; }

        [JsonPropertyName("linkToRecord")]
        public string LinkToRecord { get; set; }

        [JsonPropertyName("topics")]
        public List<TopicResponseModel> Topics { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("students")]
        public List<StudentResponseModelForLesson> Students { get; set; }

    }
}
