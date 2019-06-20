using System;
using System.Collections.Generic;
using System.Linq;
namespace structApp
{
    class Program
    {
        static void MultipleLegs(PetStruct petStruct, PetClass petClass)
        {
            petStruct.Legs = petStruct.Legs * 2;
            petClass.Legs = petClass.Legs * 2;

            Console.WriteLine("Internal Method - A " + petStruct.Type + " Has " + petStruct.Legs + " Legs");
            Console.WriteLine("Internal Method - A " + petClass.Type + " Has " + petClass.Legs + " Legs");
        }
        static void Main(string[] args)
        {
            /*
            int[] intArray = new int[5];
            string[] stringArray = new string[5];

            int[] populatedIntArray = new int[] { 0, 1, 2, 3, 4, 5 };

            intArray[0] = 5;
            intArray[2] = 15;
            //int firstValue = intArray[0];

            //####### Lists
            //not working for some reason
            System.Collections.Generic.List<string> listOfStrings = new System.Collections.Generic.List<string>();
            listOfStrings.Add("first String");
            listOfStrings.Insert(0, "Inserted String");

            listOfStrings.Remove("first String");
            listOfStrings.RemoveAt(0);

            listOfStrings.Sort();

            var theFirstStringIs = listOfStrings[0];
            */
            Dictionary<string, string> names = new Dictionary<string, string>();
            names.Add("James", "Bond");
            names.Add("Money", "Penny");

            Console.WriteLine("The name is " + names["James"]);
            names.Remove("James");
            //###############
            PetStruct dog = new PetStruct();
            dog.Type = PetType.Dog;
            dog.HasFur = true;
            dog.Legs = 4;

            PetClass duck = new PetClass();
            duck.Type = PetType.Duck;
            duck.HasFur = false;
            duck.Legs = 2;

            Console.WriteLine("a " + dog.Type + " has " + dog.Legs + " Legs");
            Console.WriteLine("a " + duck.Type + " has " + duck.Legs + " Legs");


            MultipleLegs(dog, duck);

            Console.WriteLine("a " + dog.Type + " has " + dog.Legs + " Legs");
            Console.WriteLine("a " + duck.Type + " has " + duck.Legs + " Legs");



            // more List stuff
            // linq query
            List<PetClass> pets = new List<PetClass>();
            pets.Add(new PetClass { HasFur = false, Legs = 2, Name = "Donald", Type = PetType.Duck });
            pets.Add(new PetClass { HasFur = false, Legs = 2, Name = "Trump", Type = PetType.Dog });

            List<PetClass> results = (from p in pets
                                      where p.Type == PetType.Dog
                                      select p).ToList();

            Console.WriteLine("found " + results.Count + " Dogs");

            // lambda query
            PetClass result = pets.FirstOrDefault(p => p.Type == PetType.Dog);
            Console.ReadLine();
        }
    }

    class PetClass
    {
        public int Legs;
        public PetType Type;
        public string Name;
        public bool HasFur;
    }

    struct PetStruct
    {
        public int Legs;
        public PetType Type;
        public string Name;
        public bool HasFur;
    }

    enum PetType
    {
        Dog,
        Duck
    }
}
