using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CalcWin.Models
{
    [Serializable]
    [XmlRoot("WineCalculator")]
    public class DataFile
    {
        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlArray]
        public List<Fruit> Fruits { get; set; }

        [XmlArray]
        public List<Flavor> Flavors { get; set; }

        [XmlElement]
        public Supplements Suplements { get; set; }


        public DataFile()
        {
            Version = "2.1";
            Fruits = new List<Fruit>();
            Flavors = new List<Flavor>();
            Suplements = new Supplements();
        }
    }
}
