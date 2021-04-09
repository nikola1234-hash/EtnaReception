using System;
using System.Collections.Generic;
using System.Text;

namespace Home.Models
{
    public class Weather
    {
        public DateTime Date { get; set; }
        public Dictionary<string,Degrees> Temparature { get; set; }
    }

    public class Degrees
    {
        public decimal Value { get; set; }
    }


}
