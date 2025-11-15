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

            string teszt3 = @"                                                                                       
                                                                                       
                                                                                       
                                                                                       
               ____       _       ___                          _             
              /___ \_   _(_)____ / _ \___ _ __   ___ _ __ __ _| |_ ___  _ __ 
             //  / / | | | |_  // /_\/ _ \ '_ \ / _ \ '__/ _` | __/ _ \| '__|
            / \_/ /| |_| | |/ // /_\\  __/ | | |  __/ | | (_| | || (_) | |   
            \___,_\ \__,_|_/___\____/\___|_| |_|\___|_|  \__,_|\__\___/|_|   
                                                                                                                                                                                                                                      
                                                                                                    
                              press enter to continue                              
";


            Console.WriteLine(teszt3);

            Console.ReadKey();
            Console.Clear();
            
            List<kerdesek> questions = new List<kerdesek>();
            bool fajlolvasas = false;
            char[] tiltolista = @"\/:*?""<>|".ToCharArray(); // ez a  fajlnev ellenorzesehez koll
            string input = "";
            do
            {
                Console.Write("Szeretnél kvízkérdéseket írni, vagy már van egy kész txt fájlod a merénylethez??\n \t[1]: Írni szeretnék \t [2]: Olvasni szeretnék\n\t");
                input = Console.ReadLine();
            }
            while (input != "1" && input != "2");
            if (input == "1") { fajlolvasas = false; } else if (input == "2") { fajlolvasas = true; }
            //lusta vagyok atkonvertlni mosoly

            if (fajlolvasas)
            {
                Console.Write("Kérlek add meg a txt fájlod nevét!");
                Console.ForegroundColor = ConsoleColor.Magenta;
                string olvasottfajlnev = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                while (olvasottfajlnev.IndexOfAny(tiltolista) != -1)
                {
                    Console.Write(@"ez a fajlnev nem megengedett!! 
nem lehet benne \, /, :, *, ?, "", <, >, |
gondolj ki egy masik fajlnevet!!!
    ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    olvasottfajlnev = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (!olvasottfajlnev.Contains(".txt"))
                {
                    olvasottfajlnev += ".txt";
                }
                foreach (var k in File.ReadAllLines(olvasottfajlnev))
                {
                    questions.Add(new kerdesek(k));
                }
            }
            else
            {
                Console.Write("okidoki ^_^ hogy mentsem el a fajlodat? (fajlnevet adj meg marmint) \n\t");
                Console.ForegroundColor = ConsoleColor.Magenta;
                string megirtfajlnev = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                while (megirtfajlnev.IndexOfAny(tiltolista) != -1)
                {
                    Console.Write(@"ez a fajlnev nem megengedett!! 
nem lehet benne \, /, :, *, ?, "", <, >, |
gondolj ki egy masik fajlnevet!!!
    ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    megirtfajlnev = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (!megirtfajlnev.Contains(".txt"))
                {
                    megirtfajlnev += ".txt";
                }

                Fajliras(megirtfajlnev);
                
                foreach (var k in File.ReadAllLines(megirtfajlnev))
                {
                    questions.Add(new kerdesek(k));
                }
            }
            Console.Clear();
            Console.Write("elvileg midnen rendben!\n indulhat is a banzáj??\n \t[1]: essen szét a ház!!!! \t [2]: nyem valyami nyem lyo\n\t");


            Console.ReadKey();
            // 120 x 60, tehát 2:1 a képarány
        }


        static void SzinesSzoveg(string szoveg, ConsoleColor szin)
        {
            Console.ForegroundColor = szin;
            Console.Write(szoveg);
            Console.ForegroundColor = ConsoleColor.White;
        }



        static void Fajliras(string fajlnev)
        {
            Console.Clear();

            List<string> fajlirashoz = new List<string>();

            while (true)
            {
                string mostani = "";
                string input = "";
                do
                {
                    Console.Write("Rendben, milyen típusú kérdést szeretnél írni?\n \t[1]: 4 válaszlehetőség \t [2]: Igaz / Hamis\n\t");
                    input = Console.ReadLine();
                }
                while (input != "1" && input != "2");

                int tipus = int.Parse(input);
                    

                if (tipus == 1)
                {
                    Console.Clear();

                    mostani += "4q;";

                    Console.Write("Mi a kérdésed?\n \t");
                    mostani += Console.ReadLine()+";";
                    Console.Clear();

                    Console.Write("Mi az ");SzinesSzoveg("első válaszlehetőség?", ConsoleColor.Red);Console.Write("\n\t");
                    string valasz1 = Console.ReadLine();
                    mostani += valasz1 + ";";
                    Console.Clear();

                    Console.Write("Mi a "); SzinesSzoveg("második válaszlehetőség?", ConsoleColor.Yellow); Console.Write("\n\t");
                    string valasz2 = Console.ReadLine();
                    mostani += valasz2 + ";";
                    Console.Clear();

                    Console.Write("Mi a "); SzinesSzoveg("harmadik válaszlehetőség?", ConsoleColor.Green); Console.Write("\n\t");
                    string valasz3 = Console.ReadLine();
                    mostani += valasz3 + ";";
                    Console.Clear();

                    Console.Write("Mi a "); SzinesSzoveg("negyedik válaszlehetőség?", ConsoleColor.Blue); Console.Write("\n\t");
                    string valasz4 = Console.ReadLine();
                    mostani += valasz4 + ";";
                    Console.Clear();


                    input = "";
                    do
                    {
                        Console.Write($"És melyik a helyes válasz?\n");
                        Console.Write("\t[1]:"); SzinesSzoveg(valasz1, ConsoleColor.Red); Console.WriteLine();
                        Console.Write("\t[2]:"); SzinesSzoveg(valasz2, ConsoleColor.Yellow); Console.WriteLine();
                        Console.Write("\t[3]:"); SzinesSzoveg(valasz3, ConsoleColor.Green); Console.WriteLine();
                        Console.Write("\t[4]:"); SzinesSzoveg(valasz4, ConsoleColor.Blue); Console.Write("\n\t");

                        input = Console.ReadLine();
                    }
                    while (input != "1" && input != "2");
                    mostani += input;
                    Console.Clear();


                    fajlirashoz.Add(mostani);

                }
                else if (tipus == 2)
                {
                    Console.Clear();

                    mostani += "I/H;";

                    Console.Write("Mi az állításod?\n \t");
                    mostani += Console.ReadLine() + ";";
                    Console.Clear();


                    input = "";
                    do
                    {
                        Console.Write("És mi a helyes válasz?\n \t");
                        Console.Write("[1]:"); SzinesSzoveg("Igaz", ConsoleColor.Green); Console.Write("\t");
                        Console.Write("[2]:"); SzinesSzoveg("Hamis", ConsoleColor.Red); Console.Write("\n\t");

                        input = Console.ReadLine();
                    }
                    while (input != "1" && input != "2");
                    mostani += input;
                    Console.Clear();


                    fajlirashoz.Add(mostani);

                }
                Console.Write("Szeretnél még kérdést írni?\n \t[1]: igen \t [2]: nem\n\t");
                if(int.Parse(Console.ReadLine())==2)
                {
                    break;
                }


            }
            File.WriteAllLines(fajlnev, fajlirashoz);


        }
    }
}
