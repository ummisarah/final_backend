using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Models.Service
{
    public class Address
    {
        public int id { get; set; }

        public string address { get; set; } = string.Empty;

        public string post_code { get; set; } = string.Empty;

        public int user_id { get; set; }
    }
}