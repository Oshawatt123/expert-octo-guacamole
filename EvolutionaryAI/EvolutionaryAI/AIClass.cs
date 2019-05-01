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

        private int NoEntities = 10;
        private static List<Entity> EntityList = new List<Entity>();

        private Entity topEntity1 = null;
        private Entity topEntity2 = null;

        private static string TargetString;
        List<Char> characterList = new List<Char>();

        private int generation = 1;

        /// <summary>
        /// Creates an instance of an Evolutionary AI.
        /// </summary>
        /// <param name="String">The target string for the AI.</param>
        public AIClass(string String)
        {
            TargetString = String.ToUpper();
            for (int i = 0; i < TargetString.Length; i++)
            {
                characterList.Add(TargetString.Substring(i, 1).ToCharArray(0,1)[0]);
            }
        }

        public void printTargetList()
        {
            foreach (char character in characterList)
            {
                Console.WriteLine(character);
            }
        }

        private class Entity
        {
            public List<Char> characterList = new List<char>();
            public int Strength = 0;

            public Entity()
            {
                //Console.WriteLine("Starting Entity Constructor");
                for (int i = 0; i < TargetString.Length; i++)
                {
                    // assign a random letter to the list
                    int randomInt = RandomHelper.RandInt(65, 91);
                    characterList.Add((char)randomInt);
                }
                calculateStrength();
            }

            public Entity(List<Char> preMadeList)
            {
                characterList = preMadeList;

                calculateStrength();
            }

            private void calculateStrength()
            {
                for (int i = 0; i < TargetString.Length-1; i++)
                {
                    if (TargetString.Contains(characterList[i])) // contains
                    {
                        Strength += 2;
                    }
                    if (characterList[i].ToString() == TargetString.Substring(i, 1)) // is in correct place
                    {
                        Strength += 5;
                    }
                }
            }
            // override the base ToString() behaviour for easy debugging
            public override string ToString()
            {
                try
                {
                    string ReturnString = "";
                    foreach (Char character in characterList)
                    {
                        ReturnString += character;
                    }
                    return ReturnString;
                }
                catch
                {
                    return base.ToString();
                }
            }
        }

        public void Start()
        {
            Console.WriteLine("The first roster:");
            Console.WriteLine();
            for (int i = 0; i < NoEntities; i++)
            {
                Entity newEntity = new Entity();
                EntityList.Add(newEntity);
            }

            getNewTopDogs();

            Breed();

            Evolve();

            Console.WriteLine("HA!");
            Console.WriteLine("Got Em!");
        }

        private void getNewTopDogs()
        {
            foreach (Entity entity in EntityList)
            {
                Console.Write(entity.ToString());
                Console.WriteLine(" : " + entity.Strength);

                // first time checks
                if (topEntity1 == null)
                {
                    topEntity1 = entity;
                }
                else if (topEntity2 == null)
                {
                    topEntity2 = entity;
                }
                else
                {
                    // setting the better entities to breed
                    if (entity.Strength > topEntity1.Strength)
                    {
                        topEntity1 = entity;
                    }
                    else if (entity.Strength > topEntity2.Strength)
                    {
                        topEntity2 = entity;
                    }
                }
            }
        }

        private void Breed()
        {
            Console.WriteLine();
            Console.WriteLine("The Breeding process: ");
            EntityList[0] = topEntity1;
            EntityList[1] = topEntity2;

            Console.WriteLine("Top Entity 1: " + topEntity1.ToString());
            Console.WriteLine("Top Entity 2: " + topEntity2.ToString());

            // First Breed
            List<char> tempList = new List<char>();

            for (int i = 0; i < topEntity1.characterList.Count/2; i++)
            {
                tempList.Add(topEntity1.characterList[i]);
            }
            for (int i = topEntity2.characterList.Count/2; i < topEntity2.characterList.Count; i++)
            {
                tempList.Add(topEntity2.characterList[i]);
            }

            EntityList[2] = new Entity(tempList);
            Console.WriteLine("Bred Top entities to produce : " + EntityList[2].ToString());
            // Second Breed
            tempList = new List<char>();

            for (int i = 0; i < topEntity2.characterList.Count / 2; i++)
            {
                tempList.Add(topEntity2.characterList[i]);
            }
            for (int i = topEntity1.characterList.Count / 2; i < topEntity1.characterList.Count; i++)
            {
                tempList.Add(topEntity1.characterList[i]);
            }

            EntityList[3] = new Entity(tempList);
            Console.WriteLine("Bred Top entities to produce : " + EntityList[3].ToString());


            // Mutations
            for (int i = 4; i < NoEntities; i++)
            {
                Console.WriteLine("--------------------");

                foreach (Entity entity in EntityList)
                {
                    Console.WriteLine("Entity list: " + string.Join(",", entity.characterList.ToArray()));
                }

                Console.WriteLine("--------------------");

                // copy all characters over to avoid references to entity 3 ([2])
                tempList = new List<char>();
                foreach (char character in EntityList[2].characterList)
                {
                    tempList.Add(character);
                }

                // for a random number of letters
                for (int j = 0; j < 1; j++)
                {
                    int randomInt = RandomHelper.RandInt(32, 123);
                    tempList[RandomHelper.RandInt(0, TargetString.Length)] = (char)randomInt; // set a random old letter to a new random letter
                }
                Console.WriteLine("Mutated entity " + i + " to : " + string.Join(",", tempList.ToArray()));
                EntityList[i] = new Entity(tempList);
                Console.WriteLine(EntityList[i].characterList.ToString());
            }
        }
        
        // Warning: recursive
        private void Evolve()
        {
            Console.WriteLine();
            for (int i = 0; i < NoEntities; i++)
            {
                Console.WriteLine("Entity " + i + " : " + EntityList[i].ToString());
                if (EntityList[i].ToString() == TargetString)
                {
                    Console.WriteLine("AAYYYYYYYYYYYYYYYYYYYYYYY BOOOOOOIIIIIIIIIIIII");
                    return;
                }
            }

            getNewTopDogs();

            Breed();

            Console.WriteLine("Generation " + generation + " has failed to meet requirements.");
            generation += 1;

            Evolve();

        }
    }
}
