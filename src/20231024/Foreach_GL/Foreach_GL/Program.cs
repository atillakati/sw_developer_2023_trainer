using System;

namespace Foreach_GL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Deklaration, Dimensionierung, Initialisierung
            string[] names = new string[]
            {
                "Gandalf", "Sauron", "Eomer", "Alf", "Alice"
            };

            for(int i = 0; i<names.Length; i++)
            {
                Console.WriteLine(names[i]);
                //names[i] = string.Empty;
            }

            foreach(string name in names)
            {
                Console.WriteLine(name);
                //name = string.Empty;
            }


        }
    }
}
