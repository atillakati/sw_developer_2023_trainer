﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Events_GL
{
    internal delegate void DoSomethingDelegate(string message);

    internal class Program
    {
        static void Main(string[] args)
        {
            int i;
            DoSomethingDelegate doSomething;

            i = 0;

            doSomething = HelloWorld;
            doSomething("Gandalf");

            doSomething = PrintColoredMessage;            
            doSomething("Gandalf");
        }

        static void HelloWorld(string name)
        {
            Console.WriteLine($"Hello World, {name}...");
        }

        static void PrintColoredMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
