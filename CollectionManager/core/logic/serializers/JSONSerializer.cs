using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CollectionManager.core.logic.serializers.interfaces;

namespace CollectionManager.core.logic.serializers
{
    public class JSONSerializer<T> : ISerializer<T>
    {
        public void Serialize(Stream stream, T obj)
        {
            JsonSerializer.Serialize(stream, obj);
        }
    }
}
