using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Ecomaint.Api.Models
{
    public class ProductionViewModel
    {
        public string ORDER { get; set; }
        public int QTY { get; set; }
        public int PLAN { get; set; }
        public int Actual { get; set; }
        public int RUN { get; set; }
        public int DataCollectionCycle { get; set; }
        public int WorkingCycle { get; set; }
        public Int64 ItemID { get; set; }
        public Int64 PROID { get; set; }
    }
}