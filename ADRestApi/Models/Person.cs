using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADRestApi.Models
{
    public class Person
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string phone { get; set; }
        public string mobilePhone { get; set; }
        public string email { get; set; }
        public string department { get; set; }
        public string description { get; set; }
    }
}