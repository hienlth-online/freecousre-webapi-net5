using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApiApp.Data
{
    [Table("category")]
    public class Category
    {
        [Key]
        public int category_id { get; set; }
        public string category_name { get; set;}
        public virtual ICollection<Transaction> transactions { get; set; }
    }
}
