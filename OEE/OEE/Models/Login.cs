using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OEE.Models
{
    public class Login
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string MS_NX { get; set; }
        public string NgonNgu { get; set; }
        public bool RememberUser { get; set; }
        public bool RememberLogin { get; set; }

    }
}