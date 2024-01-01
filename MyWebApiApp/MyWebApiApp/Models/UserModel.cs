using System.ComponentModel.DataAnnotations;
using System;

namespace MyWebApiApp.Models
{
    public class UserModel
    {
        public Guid user_id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
    }
}
