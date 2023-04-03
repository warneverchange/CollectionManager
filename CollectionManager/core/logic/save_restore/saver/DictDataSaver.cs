using CollectionManager.core.logic.serializers.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManager.core.logic.save_restore.saver
{
    public class DictDataSaver<T> : IDataSaver<T>
    {
        public void Save(ISerializer<T> serializer, string filePath, T obj)
        {
            serializer.Serialize(new FileStream(filePath,FileMode.OpenOrCreate),obj);
        }
    }
}
