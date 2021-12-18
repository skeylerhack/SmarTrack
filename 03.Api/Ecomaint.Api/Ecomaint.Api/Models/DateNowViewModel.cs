using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Ecomaint.Api.Models
{
    public class DateNowViewModel
    {
        public int DATE { get; set; }
        public int MONTH { get; set; }
        public int YEAR { get; set; }

        public int HOUR { get; set; }
        public int MINUTE { get; set; }
        public int SECOND { get; set; }
    }
}