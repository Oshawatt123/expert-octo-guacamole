using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAI
{
    class Program
    {
        static void Main(string[] args)
        {
            AIClass stringBoi = new AIClass("Char is Awesome");
            stringBoi.Start();
            Console.ReadLine();
        }
    }
}
