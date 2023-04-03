using CollectionManager.core.logic.deserializers.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManager.core.logic.save_restore.save
{
    public class DictDataRestorer<T> : IDataRestorer<T>
    {
        public T Restore(IDeserializerFactory<T> deserializerFactory, string filePath)
        {
            IDeserializer<T> deserializer =
                        deserializerFactory.CreateDeserializer(Path.GetExtension(filePath));
            return deserializer.Deserialize(new FileStream(filePath, FileMode.Open));
        }
    }
}
