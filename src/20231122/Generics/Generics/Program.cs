using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int elementCount = 23;


            var myValues = CreateIntArray(elementCount, -1);

            var myOtherValues = CreateArray<bool>(5, true);


            var myOtherValues2 = CreateArray<DateTime>(50, DateTime.MinValue);

            var zahl = ReadNumeric<int>("Bitte Anzahl eingeben: ");
            var gehalt = ReadNumeric<decimal>("Stergehalt eingeben: ");

            var gewicht = ReadNumeric<double>("Gewicht eingeben: ");

            var name = ReadNumeric<DateTime>("Name eingeben: ");
        }

        public static T ReadNumeric<T>(string inputPrompt) where T : struct
        {
            string input = string.Empty;
            T inputValue = default(T);
            Type type = typeof(T);
            

            bool inputIsValid = false;

            do
            {
                Console.Write(inputPrompt);
                input = Console.ReadLine();

                try
                {
                    var methodInfo = type.GetMethod("Parse", new Type[] { typeof(string) });
                    if( methodInfo != null )
                    {
                        inputValue = (T) methodInfo.Invoke(null, new object[] { input });
                        inputIsValid = true;
                    }                                        
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);

                    inputValue = default(T);
                    inputIsValid = false;
                }
            }
            while (!inputIsValid);

            return inputValue;
        }


        private static T[] CreateArray<T>(int elementCount, T initValue)
        {
            var array = new T[elementCount];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = initValue;
            }

            return array;
        }

        private static int[] CreateIntArray(int elementCount, int initValue)
        {
            var array = new int[elementCount];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = initValue;
            }

            return array;
        }
    }
}
