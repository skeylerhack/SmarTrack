using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OEE.Models
{
    public class ViewModel
    {
        public string cotmaunen { get; set; }
        public string cot1 { get; set; }
        public string cot2 { get; set; }
        public int cot3 { get; set; }
        public string cot4 { get; set; }
        public int cot5 { get; set; }
        public string cot6 { get; set; }
        public string cot7 { get; set; }
        public int cot8 { get; set; }
        public string cot9 { get; set; }
        public int cot10 { get; set; }
        public int trangthai { get; set; }
        public ViewModel(string c1, string c2, int c3, string c4, int c5, string c6, string c7, int c8, string c9, int c10, string mn)
        {
            //string str = cotmaunen;
            //string[] str1 = str.Split(';');
           
            cot1 = c1; cot2 = c2; cot3 = c3; cot4 = c4; cot5 = c5; cot6 = c6; cot7 = c7; cot8 = c8; cot9 = c9; cot10 = c10; cotmaunen = mn;
        }
    }
}