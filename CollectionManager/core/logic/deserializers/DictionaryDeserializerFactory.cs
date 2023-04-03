using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using CollectionManager.core.entities;
using CollectionManager.core.logic.deserializers.interfaces;

namespace CollectionManager.core.logic.deserializers
{
    internal class DictionaryDeserializerFactory : IDeserializerFactory<Dictionary<string, ICollection<Worker>>>
    {
        public IDeserializer<Dictionary<string, ICollection<Worker>>> CreateDeserializer(string fileExtension)
        {
            IDeserializer<Dictionary<string, ICollection<Worker>>> deserializer = null;
            switch (fileExtension)
            {
                case ".json":
                    deserializer = new JSONDeserializer<Dictionary<string, ICollection<Worker>>>();
                    break;
                case ".xml":
                    deserializer = new XMLDictDeserializer();
                    break;
                default:
                    deserializer = new BinaryDeserializer<Dictionary<string, ICollection<Worker>>>(new BinaryFormatter());
                    break;
            }
            return deserializer;
        }
    }
}
