using GameOfWAR.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfWAR.Tests.Helper
{
    class FakeWriter : IWriter
    {
        public string Read(string message)
        {
            return "rubber ducks";
        }

        public void Write(string message)
        {
        }
    }
}
