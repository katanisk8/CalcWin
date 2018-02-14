using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CalcWin.Data.DefaultData
{
   public static class GenerateDefaultData
   {
      public static T LoadXml<T>(byte[] file) where T : DefaultData
      {
         var xrs = new XmlReaderSettings
         {
            ConformanceLevel = ConformanceLevel.Document,
            CloseInput = true,
            IgnoreComments = true,
            IgnoreProcessingInstructions = true,
            IgnoreWhitespace = true,
         };

         using (var stream = new MemoryStream(file))
         {
            using (XmlReader reader = XmlReader.Create(stream, xrs))
            {
               XmlSerializer serialiser = new XmlSerializer(typeof(T));
               var obj = (T)serialiser.Deserialize(reader);

               if (obj.Version != "3.0")
                  throw new NotSupportedException("Wersja pliku '" + obj.Version + "' nie jest obslugiwana.");

               return obj;
            }
         }
      }

      private static void SaveXml<T>(T xml, string filePath) where T : DefaultData
      {
         var xws = new XmlWriterSettings
         {
            ConformanceLevel = ConformanceLevel.Document,
            CloseOutput = true,
            Encoding = Encoding.UTF8,
            Indent = true,
         };

         using (var writer = XmlWriter.Create(filePath, xws))
         {
            var serialiser = new XmlSerializer(typeof(T));
            serialiser.Serialize(writer, xml);
         }
      }
   }
}
