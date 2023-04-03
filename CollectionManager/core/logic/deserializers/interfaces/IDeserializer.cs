using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManager.core.logic.deserializers.interfaces
{
    public interface IDeserializer<T>
    {
        public T Deserialize(Stream stream);
    }
}
