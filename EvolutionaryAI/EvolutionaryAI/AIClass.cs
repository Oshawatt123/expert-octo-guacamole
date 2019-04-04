using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EvolutionaryAI
{
    public class AIClass
    {

        private string TargetString;
        public AIClass(string String)
        {
            TargetString = String;
            for (int i = 0; i < TargetString.Length; i++)
            {
                characterList.Add(TargetString.Substring(i, 1).ToCharArray(0,1)[0]);
            }
        }

        List<Char> characterList = new List<Char>();

        public void printTargetList()
        {
            foreach (char character in characterList)
            {
                Console.WriteLine(character);
            }
        }

        private class Entity
        {
            private List<Char> characterList = new List<char>(5);

            Entity()
            {
                for (int i = 0; i < characterList.Count; i++)
                {
                    RandomHelper.RandInt(0, 5);
                }
            }
        }

    }
}
