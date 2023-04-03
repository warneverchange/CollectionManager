using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CollectionManager.core.entities;
using CollectionManager.core.logic.deserializers.interfaces;

namespace CollectionManager.core.logic.deserializers
{
    internal class XMLDictDeserializer : IDeserializer<Dictionary<string, ICollection<Worker>>>
    {
        public Dictionary<string, ICollection<Worker>> Deserialize(Stream stream)
        {
            XElement doc = XDocument.Load(stream).Element("Dictionary");
            var dict = new Dictionary<string, ICollection<Worker>>();
            foreach (var keyElement in doc.Elements())
            {
                string keyName = keyElement.Name.ToString();
                ICollection<Worker> collection = new LinkedList<Worker>();
                foreach (var worker in keyElement.Elements())
                {
                    collection.Add(
                        new Worker(
                            worker.Attribute("FirstName").Value,
                            worker.Attribute("LastName").Value,
                            worker.Attribute("PhoneNumber").Value));
                }
                dict.Add(keyName, collection);
            }
            return dict;
        }
    }
}
