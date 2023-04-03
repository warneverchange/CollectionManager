using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManager.core.logic.serializers.interfaces
{
    public interface ISerializer<T>
    {
        public void Serialize(Stream stream, T obj);
    }
}
