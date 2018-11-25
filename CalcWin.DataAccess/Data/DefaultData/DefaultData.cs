using System;
using CalcWin.DataAccess.Model;
using System.Collections.Generic;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Identity;

namespace CalcWin.DataAccess.Data.DefaultData
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

      [XmlArray]
      public List<Supplement> Supplements { get; set; }

      [XmlArray]
      public List<IdentityRole> Roles { get; set; }
   }
}
