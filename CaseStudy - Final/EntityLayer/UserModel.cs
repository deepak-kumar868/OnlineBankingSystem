using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace EntityLayer
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public string Role { get; set; }
    }
}
