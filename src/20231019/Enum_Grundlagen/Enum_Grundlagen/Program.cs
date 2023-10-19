using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enum_Grundlagen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleColor farbe = ConsoleColor.Red;

            TextFileFormat fileFormat = TextFileFormat.Xml;

            //SaveStudentsToFile(students, "myStudents_2023", TextFileFormat.Csv);
            //SaveStudentsToFile(students, "myStudents_2023", fileFormat);

            Console.WriteLine($"Farbe:      {farbe}");
            Console.WriteLine($"FileFormat: {fileFormat}");

            string[] types = Enum.GetNames(typeof(TextFileFormat));
            for(int i = 0; i < types.Length; i++)
            {
                Console.WriteLine(types[i]);
            }
        }
    }
}

