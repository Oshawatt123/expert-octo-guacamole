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
            // Warning : Recursive
            AIClass stringBoi = new AIClass("Smol");
            stringBoi.Start();
            Console.ReadLine();
        }
    }
}
