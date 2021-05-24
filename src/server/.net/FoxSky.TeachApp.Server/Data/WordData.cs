using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoxSky.TeachApp.BO;

namespace FoxSky.TeachApp.Service.Data
{
    public class WordData
    {
        public int WordId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        //public int TagId { get; set; }
        public string Phrase { get; set; }
        public string Translation { get; set; }
        public string Note { get; set; }
    }
}
