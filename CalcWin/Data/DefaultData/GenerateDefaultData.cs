using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using CalcWin.Models;

namespace CalcWin.Data.DefaultData
{
    public static class GenerateDefaultData
    {
        private static string dataFilePath;

        static GenerateDefaultData()
        {
            var folder = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
            dataFilePath = Path.Combine(folder, "data.xml");
        }

        public static DataFile ImportData()
        {
            return LoadXml<DataFile>(dataFilePath);
        }

        private static string GetLoadPath()
        {
            

            return null;
        }



        private static T LoadXml<T>(string filePath) where T : DataFile
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException(filePath);
            
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

        private static void SaveXml<T>(T xml, string filePath) where T : DataFile
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
