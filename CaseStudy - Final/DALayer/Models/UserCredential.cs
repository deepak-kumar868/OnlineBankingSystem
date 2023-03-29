using System;
using System.Collections.Generic;

#nullable disable

namespace DALayer.Models
{
    public partial class UserCredential
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public string AccountNo { get; set; }
        public string Role { get; set; }

        public virtual Account AccountNoNavigation { get; set; }
    }
}
