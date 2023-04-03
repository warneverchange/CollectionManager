using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CollectionManager.core.logic.deserializers.interfaces;

namespace CollectionManager.core.logic.deserializers
{
    public class BinaryDeserializer<T> : IDeserializer<T>
    {
        private IFormatter _formatter;

        public BinaryDeserializer(IFormatter formatter)
        {
            _formatter = formatter;
        }

        public T Deserialize(Stream stream)
        {
#pragma warning disable SYSLIB0011 // Тип или член устарел
            return (T)_formatter.Deserialize(stream)
                ?? throw new ArgumentException("Invalid deserialization source");
#pragma warning restore SYSLIB0011 // Тип или член устарел
        }
    }
}
