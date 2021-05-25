using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FoxSky.TeachApp.BO
{
    public class Word
    {
        public int WordId { get; set; }
        public int UserId { get; set; }
        public int? CategoryId { get; set; }
        //public int TagId { get; set; }
        public string Phrase { get; set; }
        public string Translation { get; set; }
        public string Note { get; set; }

        public User User { get; set; }
    }
}
