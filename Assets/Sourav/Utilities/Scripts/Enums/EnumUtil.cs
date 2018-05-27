using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Sourav.Utilities.Scripts.Enums
{    
    public static class EnumUtil
    {
        public static List<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList<T>();
        }
    }
    
}
