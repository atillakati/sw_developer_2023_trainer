using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;


namespace Linq_Grundlagen
{
    public delegate void DoSomething(string data);

    public delegate bool FilterHandler(int value);
    public delegate bool FilterHandler<T>(T value);


    internal class Program
    {
        static void Main(string[] args)
        {                                    
            DoSomething doSomething = PrintMessage;
            doSomething("Dies ist ein Test..");

            //anonyme Methoden
            doSomething = delegate (string outputData)
            {
                Console.WriteLine("Anonyme Methode:");
                Console.WriteLine("\t" + outputData);
            };

            doSomething("Test anonyme Methode...");

            #region praktischer Einsatz von anonymen Methoden
            //Timer timer = new Timer();

            //timer.Interval = 1000; 
            //timer.Elapsed += delegate (object sender, ElapsedEventArgs e)
            //{
            //    Console.Write(".");
            //};

            //timer.Start();

            //while (true) ;
            #endregion

            //Lambda Expressions
            doSomething = (string outputData) =>
            {
                Console.WriteLine("Lambda Expression:");
                Console.WriteLine("\t" + outputData);
            };

            doSomething("Test Lambda...");

            doSomething = (outputData) =>
            {
                Console.WriteLine(outputData);
            };

            doSomething = (outputData) => Console.WriteLine(outputData);
            doSomething = outputData => Console.WriteLine(outputData);

            doSomething = x => Console.WriteLine(x);

            //Anwendung Lambda Expressions
            int[] myValues = { 2, 3, 4, 5, 8, 10, 13, 14, 16, 18, 19, 21 };

            //var filteredValues = Filter(myValues, FilterEvenValues);
            var filteredValues = Filter(myValues, x => x % 2 == 0);

            filteredValues = Filter(myValues, x => x > 5);
            filteredValues = Filter(myValues, x => x < 10);
            filteredValues = Filter(myValues, x => x > 10 && x < 20);

            var nameList = new string[] { "Gandalf", "Alf", "Sauron", "Eomer", "Golum" };

            var filteredNames = Filter(nameList, x => x.ToLower().Contains("alf"));
            var filteredNames2 = nameList.ToList().Where(x => x.ToLower().Contains("alf"));
            var nameStartingLetters = nameList.ToList()
                                            .Where(x => x.ToLower().Contains("alf"))
                                            .Select(x => x[0])
                                            .OrderBy(x => x);

            //filteredValues = Filter(myValues, (x, y) => x < 10 * y);

            //Action  ==> Methoden mit Rückgabetype = void 
            //Func    ==> Methoden mit Rückgabetype != void 
               //Predicate  ==>  Func mit Rückgabetype = bool 
        }

        

        private static bool FilterEvenValues(int value)
        {
            return value % 2 == 0;            
        }

        private static bool FilterOddValues(int value)
        {
            return value % 2 != 0;
        }

        private static T[] Filter<T>(T[] valueList, Func<T,bool> predicate)
        {
            var selectedValueList = new List<T>();

            foreach (var value in valueList)
            {
                if (predicate(value))
                {
                    selectedValueList.Add(value);
                }
            }

            return selectedValueList.ToArray();
        }

        //private static T[] Filter<T>(T[] valueList, FilterHandler<T> handler)
        //{
        //    var selectedValueList = new List<T>();

        //    foreach (var value in valueList)
        //    {
        //        if (handler(value))
        //        {
        //            selectedValueList.Add(value);
        //        }
        //    }

        //    return selectedValueList.ToArray();
        //}

        //private static int[] Filter(int[] valueList, FilterHandler handler)
        //{
        //    var selectedValueList = new List<int>();

        //    foreach (var value in valueList)
        //    {
        //        if (handler(value))
        //        {
        //            selectedValueList.Add(value);
        //        }
        //    }

        //    return selectedValueList.ToArray();
        //}

        private static void PrintMessage(string data)
        {
            Console.WriteLine(data);
        }
    }
}
