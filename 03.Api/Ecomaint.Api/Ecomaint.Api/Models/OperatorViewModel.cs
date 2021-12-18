using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Ecomaint.Api.Models
{
    public class OperatorViewModel
    {
        public Int64 ID_NV { get; set; }
        public string TEN_NV { get; set; }
    }

    public class DowtimeViewModel
    {
        public int MS_NGUYEN_NHAN { get; set; }
        public string TEN_NGUYEN_NHAN { get; set; }
    }
    public class DowtimeTypeViewModel
    {
        public int MS_LOAI { get; set; }
        public string TEN_LOAI { get; set; }
    }
    public class ResulstViewModel
    {
        public int MS_TRANG_THAI{ get; set;}
        public string TEN_TRANG_THAI{ get; set;}
        public int SO_DONG { get; set; }
    }

    public class PhoneMailViewModel
    {
        public Int64 ID_Operator { get; set; }
        public string MAIL { get; set; }
        public string PHONE { get; set; }
        public string TEN_MAY { get; set; }
    }
}