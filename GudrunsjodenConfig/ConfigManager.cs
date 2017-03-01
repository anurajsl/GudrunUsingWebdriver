using System;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using System.Configuration;
using Enum;

namespace GudrunsjodenConfig
{
    public sealed class ConfigManager
    {
        public static string GetAppConfigValue(string key)
        {

            if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
            {
                return ConfigurationManager.AppSettings[key];
            }
            return string.Empty;
        }

        public static string GetConfigValue(string key)
        {
            return GetAppConfigValue(key);
        }

        public static string GetTestData(string key)
        {
            return ConfigManager.GetTestData(EnumTypes.TestData.Common, key);
        }

        public static string GetTestData(EnumTypes.TestData testDataType, string ValueToGet)
        {
            XDocument xmlDocument = GetXDocument(testDataType);

            if (xmlDocument == null)
            {
                return string.Empty;
            }

            var query = (from item in xmlDocument.Descendants("TestData")
                         where (item.FirstAttribute.Value == ValueToGet)
                         select item.LastAttribute.Value).ToList();

            if (query.Count > 1)
            {
                throw new Exception("Duplicate Key Found");
            }
            else if (query.Count == 1)
            {
                return query[0].ToString();
            }
            return string.Empty;
        }

        private static XDocument GetXDocument(EnumTypes.TestData testDataType)
        {
            try 
            {
                string xmlFileName = GetXMLFileName(testDataType);
                string path = Directory.GetCurrentDirectory().Replace("Gudrunsjoden\\Gudrunsjoden\\bin\\Debug", "Gudrunsjoden\\GudrunsjodenConfig") + "\\" + xmlFileName;
                return XDocument.Load(path);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        private static string GetXMLFileName(EnumTypes.TestData testDataType)
        {
            string xmlFileName = string.Empty;
            string environment = GetAppConfigValue("Environment");

            switch ((EnumTypes.TestData)testDataType)
            {
                case EnumTypes.TestData.Common:
                    xmlFileName = string.Format("TestData\\Common\\TestData.{0}.xml", environment);
                    break;
                case EnumTypes.TestData.Events:
                    xmlFileName = "TestData\\Events\\EventTests.xml";
                    break;
                case EnumTypes.TestData.MyHome:
                    xmlFileName = "TestData\\MyHome\\MyHomeTests.xml";
                    break;
            }
            return xmlFileName;
        }

    }
}