using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Models
{
    public class Token
    {
        public int id { get; set; }
        public string token { get; set; } = string.Empty;
        public string expired_at { get; set; } = string.Empty;
    }
}