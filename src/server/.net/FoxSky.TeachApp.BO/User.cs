using System;
using System.Collections.Generic;

namespace FoxSky.TeachApp.BO
{
    public class User
    {
        public int UserId { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }

        public List<Word> Word { get; set; }
    }
}
