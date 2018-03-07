using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace CalcWin.Models.User
{
    public class Role
   {
      [XmlAttribute("name")]
      [Required]
      public string Name { get; set; }

      [XmlAttribute("normalizedName")]
      [Required]
      public string NormalizedName { get; set; }
   }
}
