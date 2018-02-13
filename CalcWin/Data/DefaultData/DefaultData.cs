﻿using System;
using Calculator.Models;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CalcWin.Data.DefaultData
{
    [Serializable]
    [XmlRoot("CalcWin")]
    public class DefaultData
    {
        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlArray]
        public List<Fruit> Fruits { get; set; }

        [XmlArray]
        public List<Flavor> Flavors { get; set; }

        [XmlElement]
        public Supplements Supplements { get; set; }
    }
}