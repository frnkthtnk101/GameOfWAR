using GameOfWAR.Interfaces;
using System;

namespace GameOfWAR.Helper
{
    public class ScreenHelper : IWriter
    {
        public string Read(string message)
        {
            Write(message);
            return Console.ReadLine();
        }

        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
