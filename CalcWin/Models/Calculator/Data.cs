using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalcWin.Models.Calculator
{
    public class Data
    {
        public class DataFile
        {
            public string Version { get; set; }
            
            public List<Fruit> Fruits { get; set; }
            
            public List<Flavor> Flavors { get; set; }
            
            public Supplements Suplements { get; set; }
            
            public DataFile()
            {
                Version = "3.0";
                Fruits = new List<Fruit>();
                Flavors = new List<Flavor>();
                Suplements = new Supplements();
            }
        }
    }
}
