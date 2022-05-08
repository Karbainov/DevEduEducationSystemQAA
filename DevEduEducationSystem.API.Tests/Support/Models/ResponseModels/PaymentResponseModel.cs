using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models.ResponseModels
{
    public class PaymentResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("sum")]
        public decimal Sum { get; set; }

        [JsonPropertyName("user")]
        public UserResponseModel User { get; set; }

        [JsonPropertyName("isPaid")]
        public bool IsPaid { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is PaymentResponseModel model &&
                   Id == model.Id &&
                   Date == model.Date &&
                   Sum == model.Sum &&
                   EqualityComparer<UserResponseModel>.Default.Equals(User, model.User) &&
                   IsPaid == model.IsPaid;
        }
    }
}
