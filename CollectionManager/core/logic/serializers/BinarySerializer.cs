using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using CollectionManager.core.logic.serializers.interfaces;

namespace CollectionManager.core.logic.serializers
{
    public class BinarySerializer<T> : ISerializer<T>
    {
        private IFormatter _formatter;

        public BinarySerializer(IFormatter formatter)
        {
            _formatter = formatter;
        }

        public void Serialize(Stream stream, T obj)
        {
#pragma warning disable SYSLIB0011 // Тип или член устарел
            _formatter.Serialize(stream, obj);
#pragma warning restore SYSLIB0011 // Тип или член устарел
        }
    }
}
