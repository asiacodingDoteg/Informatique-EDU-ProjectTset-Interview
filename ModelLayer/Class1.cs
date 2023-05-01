using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class CheckUserModesl
    {
        public int id { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
        public bool IsEnabled { get; set; }
        public int TeamLeader { get; set; }
        public System.DateTime date { get; set; }
    }
}
