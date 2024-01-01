using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApiApp.Data
{
    [Table("transaction")]
    public class Transaction
    {
        [Key]
        public Guid transaction_id { get; set; }
        public double amount { get; set; }
        public string description { get; set; }
        public DateTime created_at { get; set; } = DateTime.Now;

        public Guid user_id { get; set; }
        [ForeignKey("user_id")]
        public User user { get; set; }

        public int category_id { get; set; }
        [ForeignKey("category_id")]
        public Category category { get; set; }

        public int type_id { get; set; }
        [ForeignKey("type_id")]
        public Type type { get; set; }
    }
}
