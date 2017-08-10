using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalcWin.Models.Calculator
{
    public class WineProject
    {
        public List<Ingedient> Elements { get; set; }
        
        public string FlavorId { get; set; }

        public double AlcoholQuantity { get; set; }
        
        public WineProject()
        {
            Elements = new List<Ingedient>();
            FlavorId = "";
            AlcoholQuantity = 0;
        }
    }
}
