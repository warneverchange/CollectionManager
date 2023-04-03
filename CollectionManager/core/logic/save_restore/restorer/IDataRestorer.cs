using CollectionManager.core.logic.deserializers.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManager.core.logic.save_restore.save
{
    public interface IDataRestorer<T>
    {
        public T Restore(IDeserializerFactory<T> deserializerFactory, string filePath);
    }
}
