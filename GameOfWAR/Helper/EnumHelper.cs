using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfWAR.Helper
{
    public static class EnumHelper
    {
        public static IEnumerable<T> GetEnumList<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
