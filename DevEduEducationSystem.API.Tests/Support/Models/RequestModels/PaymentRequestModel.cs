using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevEduEducationSystem.API.Tests.Support.Models.RequestModels
{
    public class PaymentRequestModel
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("sum")]
        public decimal Sum { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("isPaid")]
        public bool IsPaid { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is PaymentRequestModel model &&
                   Date == model.Date &&
                   Sum == model.Sum &&
                   UserId == model.UserId &&
                   IsPaid == model.IsPaid;
        }
    }
}
