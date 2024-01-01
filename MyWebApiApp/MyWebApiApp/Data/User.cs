using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApiApp.Data
{
    [Table("user")]
    public class User
    {
        [Key]
        public Guid user_id { get; set; }
        [Required]
        public string user_name { get; set; }
        public string password { get; set;}


        public virtual ICollection<Transaction> transactions { get; set; }
        public User()
        {
            transactions = new List<Transaction>();
        }
    }
}
