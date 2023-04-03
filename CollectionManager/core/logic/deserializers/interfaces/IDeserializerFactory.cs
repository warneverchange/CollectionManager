using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManager.core.logic.deserializers.interfaces
{
    public interface IDeserializerFactory<T>
    {
        public IDeserializer<T> CreateDeserializer(string fileExtension);
    }
}
