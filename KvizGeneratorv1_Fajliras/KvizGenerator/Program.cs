using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace KvizGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string teszt3 = "                                                                                       \r\n                                                                                       \r\n                                                                                       \r\n                                                                                       \r\n                                                                                       \r\n                                                                                       \r\n                         ____       _       ___                          _             \r\n                        /___ \\_   _(_)____ / _ \\___ _ __   ___ _ __ __ _| |_ ___  _ __ \r\n                       //  / / | | | |_  // /_\\/ _ \\ '_ \\ / _ \\ '__/ _` | __/ _ \\| '__|\r\n                      / \\_/ /| |_| | |/ // /_\\\\  __/ | | |  __/ | | (_| | || (_) | |   \r\n                      \\___,_\\ \\__,_|_/___\\____/\\___|_| |_|\\___|_|  \\__,_|\\__\\___/|_|   \r\n                                                                                                                                                                                                                                     \r\n                                                                                                    \r\n                                          press enter to continue                              \r\n";
            
            Console.WriteLine(teszt3);

            Console.ReadKey();
            Console.Clear();

            List<kerdesek> questions = new List<kerdesek>();
            foreach(var k in File.ReadAllLines("tesztkeszlet1.txt"))
            {
                questions.Add(new kerdesek(k));
            }
            Console.WriteLine(questions[0].KerdesLeiras + "\n" + questions[0].Valasz1);
            Console.WriteLine(questions[1].KerdesLeiras + "\n" + questions[1].Valasz1 + "\n" + questions[1].Valasz2);

            Console.ReadKey();
            // 120 x 60, tehát 2:1 a képarány
        }
   }
}
