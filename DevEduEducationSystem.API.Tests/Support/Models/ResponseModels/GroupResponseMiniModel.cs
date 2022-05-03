using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models.ResponseModels
{
    public class GroupResponseMiniModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("groupStatus")]
        public string GroupStatus { get; set; }
    }
}
