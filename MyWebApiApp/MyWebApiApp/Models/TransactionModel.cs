using System;

namespace MyWebApiApp.Models
{
    public class TransactionModel
    {
        public double amount { get; set; }
        public string description { get; set; }
        public DateTime created_at { get; set; } = DateTime.Now;
        public int category_id { get; set; }
        public int type_id { get; set; }
    }
}
