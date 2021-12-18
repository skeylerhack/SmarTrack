using Ecomaint.Api.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ecomaint.Api.Controllers
{
    public class SendInformationController : ApiController
    {
        [HttpGet]
        public string GetValue()
        {
            return "aa";
        }
        [HttpPost]
        public void PostSendInfor(string CardID,string HanhDong)
        {

        }
    }
}
