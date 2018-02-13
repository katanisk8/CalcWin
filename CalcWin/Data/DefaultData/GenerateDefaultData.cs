using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CalcWin.Data.DefaultData
{
    public static class GenerateDefaultData
    {
        public static T LoadXml<T>(string filePath) where T : DefaultData
        {
            var xrs = new XmlReaderSettings
            {
                ConformanceLevel = ConformanceLevel.Document,
                CloseInput = true,
                IgnoreComments = true,
                IgnoreProcessingInstructions = true,
                IgnoreWhitespace = true,
            };

            using (XmlReader reader = XmlReader.Create(filePath, xrs))
            {
                XmlSerializer serialiser = new XmlSerializer(typeof(T));
                var obj = (T)serialiser.Deserialize(reader);

                if (obj.Version != "2.0")
                    throw new NotSupportedException("Wersja pliku '" + obj.Version + "' nie jest obslugiwana.");

                return obj;
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
