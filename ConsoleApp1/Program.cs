using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var onehunderd = 100;
            for(int i =0; i < onehunderd; i++)
            {
                if(i % 3 == 0)
                {
                    stringBuilder.Append("foo,");
                }
                else if (i % 5 == 0)
                {
                    stringBuilder.Append("bar,");
                }
                else
                {
                    stringBuilder.Append($"{i},");
                }
            }
            Console.WriteLine(stringBuilder.ToString());
            Console.ReadLine();
        }
    }
}
