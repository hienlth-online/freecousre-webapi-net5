using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApiApp.Data
{
    [Table("type")]
    public class Type
    {
        [Key]
        public int type_id { get; set; }
        public string type_name { get; set; }
        public virtual ICollection<Transaction> transactions { get; set; }
    }
}
