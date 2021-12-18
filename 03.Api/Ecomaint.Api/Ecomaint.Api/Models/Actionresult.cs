using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecomaint.Api.Models
{
    public class Actionresult
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string RefCode { get; set; }

    }
}