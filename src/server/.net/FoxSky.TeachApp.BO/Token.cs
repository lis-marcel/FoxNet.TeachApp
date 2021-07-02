using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSky.TeachApp.BO
{
    public class Token
    {
        public int UserId { get; set; }
        public int TokenId { get; set; }
        public string Value { get; set; }

        public User User { get; set; }
    }
}
