using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CollectionManager.core.entities;
using CollectionManager.core.logic.serializers.interfaces;

namespace CollectionManager.core.logic.serializers
{
    public class XMLDictSerializer : ISerializer<Dictionary<string, ICollection<Worker>>>
    {

        public void Serialize(Stream stream, Dictionary<string, ICollection<Worker>> obj)
        {
            XElement root = new("Dictionary");
            foreach (KeyValuePair<string, ICollection<Worker>> kvp in obj)
            {
                string key = kvp.Key;
                XElement element = new(key.ToString());
                foreach (Worker worker in kvp.Value)
                {
                    XElement person = new XElement("Worker",
                        new XAttribute("FirstName", worker.FirstName),
                        new XAttribute("LastName", worker.LastName),
                        new XAttribute("PhoneNumber", worker.PhoneNumber));
                    element.Add(person);
                }

                root.Add(element);
            }

            XDocument doc = new();
            doc.Add(root);
            doc.Save(stream);
        }
    }
}
