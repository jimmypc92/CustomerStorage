using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Threading.Tasks;

namespace CustomerStorage
{
    public class ItemStore
    {
        private string _defaultStoragePath = @".\customerstorage.xml";
        private XmlDocument _storageDoc;

        public ItemStore()
        {
            ensureStoreExists(_defaultStoragePath);
            _storageDoc = new XmlDocument();
            _storageDoc.Load(_defaultStoragePath);
        }

        private void ensureStoreExists(string path)
        {
            if(!File.Exists(path))
            {
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.CloseOutput = true;
                using (XmlWriter writer = XmlWriter.Create(File.Create(_defaultStoragePath), xmlWriterSettings)) {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Store");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                }
            }
        }

        private void refreshStorage(string path)
        {
            _storageDoc.Load(path);
        }

        public void Store(IStorableDict keyValuePairs)
        {
            XmlElement root = _storageDoc.DocumentElement;
            root.AppendChild(_storageDoc.CreateElement(keyValuePairs.StorableTypeName()));
            XmlNode newElement = root.LastChild;
            foreach(KeyValuePair<string, string> kvp in keyValuePairs.ToStorable()) {
                newElement.AppendChild(_storageDoc.CreateElement(kvp.Key));
                newElement.LastChild.InnerText = kvp.Value;
            }
            using (XmlWriter writer = XmlWriter.Create(_defaultStoragePath))
            {
                _storageDoc.WriteContentTo(writer);
            }
        }

        public async Task<object> invoke(object input)
        {
            return "success";
        }
    }
}
