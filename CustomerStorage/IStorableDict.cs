using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerStorage
{
    public interface IStorableDict
    {
        Dictionary<string, string> ToStorable();
        string StorableTypeName();
    }
}
