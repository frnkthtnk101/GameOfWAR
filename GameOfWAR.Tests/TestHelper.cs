using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfWAR.Tests
{
    public class TestHelper
    {
        internal IEnumerable<T> GetEnumList<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
