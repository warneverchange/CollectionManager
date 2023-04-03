using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CollectionManager.core.logic.deserializers.interfaces;

namespace CollectionManager.core.logic.deserializers
{
    public class JSONDeserializer<T> : IDeserializer<T>
    {
        public T Deserialize(Stream stream)
        {
            return JsonSerializer.Deserialize<T>(stream) ?? throw new ArgumentException("Invalid source json.");
        }

    }
}
