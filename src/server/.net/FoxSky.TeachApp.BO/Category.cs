using System;
using System.Collections.Generic;

namespace FoxSky.TeachApp.BO
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<Word> Word { get; set; }
    }
}