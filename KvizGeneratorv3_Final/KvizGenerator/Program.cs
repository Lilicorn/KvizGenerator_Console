using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Threading;

namespace KvizGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WindowWidth = 80;
            Console.WindowHeight = 15;
            string maintext = @"                                                                                       



          ____       _       ___                          _             
         /___ \_   _(_)____ / _ \___ _ __   ___ _ __ __ _| |_ ___  _ __ 
        //  / / | | | |_  // /_\/ _ \ '_ \ / _ \ '__/ _` | __/ _ \| '__|
       / \_/ /| |_| | |/ // /_\\  __/ | | |  __/ | | (_| | || (_) | |   
       \___,_\ \__,_|_/___\____/\___|_| |_|\___|_|  \__,_|\__\___/|_|   



                          press any key to continue


";


            Console.WriteLine(maintext);

            Console.ReadKey();
            Thread.Sleep(1000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(maintext);
            Thread.Sleep(100);
            Console.Clear();
            Console.Write($"\u001b[38;2;34;34;34m{maintext}[0m");
            Thread.Sleep(100);
            Console.Clear();
            Thread.Sleep(500);


            maintext = @"
       Megjegyzés:        
       Ettől a ponttól fogva a programot leginkább a számbillentyűkkel
       tudja majd irányítani.
       Megfelel?

            [1]: igenis kapitány
            [2]: yes of course
            [3]: ja natürlich
            [4]: oui

        ";
            Console.WriteLine("\n\n");
            Console.Write($"\u001b[38;2;34;34;34m{maintext}[0m");
            Thread.Sleep(100);
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Gray;


            string input = "";
            do
            {
                Console.WriteLine(maintext);

                input = Console.ReadLine();
                Console.Clear();

            }
            while (input != "1" && input != "2" && input != "3" && input != "4");
            Console.Clear();
            Thread.Sleep(100);
            Console.WriteLine();
            Console.Write($"\u001b[38;2;34;34;34m{maintext}[0m");
            Thread.Sleep(100);
            Console.Clear();
            Thread.Sleep(500);




            List<kerdesek> questions = new List<kerdesek>();

            IrasVagyOlvasasScreenThingy(questions);


            
            while (true)
            {
                maintext = @"                                                                                       


        Elvileg minden rendben!
        Mehet is a játék??

        [1]: Igen      [2]: Nem


";              
                do
                {
                    Console.Write(maintext);
                    input = Console.ReadLine();
                    Console.Clear();
                }
                while (input != "1" && input != "2");

                if (input == "1")
                {
                    Gameplay(questions);
                    break; // kész a játék, kilépünk
                }
                else if (input == "2")
                {
                    IrasVagyOlvasasScreenThingy(questions);
                }
            }

            // 120 x 60, tehát 2:1 a képarány
        }




        static void SzinesSzoveg(string szoveg, ConsoleColor szin)
        {
            Console.ForegroundColor = szin;
            Console.Write(szoveg);
            Console.ForegroundColor = ConsoleColor.White;
        }


        static void IrasVagyOlvasasScreenThingy(List<kerdesek> questions)
        {
            string maintext = @"                                                                                       


            Szeretné most megírni a kvízkérdéseit, vagy már rendelkezik
            egy txt fájllal a merénylethez?

             [1]: Írni szeretnék      [2]: Beolvasni szeretnék


";
            Console.WriteLine("\n");
            Console.Write($"\u001b[38;2;34;34;34m{maintext}[0m");
            Thread.Sleep(100);
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;

            bool fajlolvasas = false;
            char[] tiltolista = @"\/:*?""<>|".ToCharArray(); // ez a  fajlnev ellenorzesehez koll
            string input = "";
            do
            {
                Console.Write(maintext);
                input = Console.ReadLine();
            }
            while (input != "1" && input != "2");
            if (input == "1") { fajlolvasas = false; } else if (input == "2") { fajlolvasas = true; }
            //lusta vagyok atkonvertlni mosoly

            Console.Clear();
            Thread.Sleep(100);
            Console.WriteLine("\n");
            Console.Write($"\u001b[38;2;34;34;34m{maintext}[0m");
            Thread.Sleep(100);
            Console.Clear();
            Thread.Sleep(500);

            if (fajlolvasas)
            {
                Console.WriteLine("\n");
                Console.Write("\u001b[38;2;34;34;34m\n\n\tKérlek add meg a txt fájlod nevét!\n\t[0m");
                Thread.Sleep(100);
                Console.Clear();
                Console.ForegroundColor= ConsoleColor.White;
                Console.Write("\n\n\tKérlek add meg a txt fájlod nevét!\n\t");

                Console.ForegroundColor = ConsoleColor.Magenta;
                string olvasottfajlnev = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                if (olvasottfajlnev.IndexOf(".txt")==-1)
                {
                    olvasottfajlnev += ".txt";

                }
                while (olvasottfajlnev.IndexOfAny(tiltolista) != -1 || !File.Exists(olvasottfajlnev))
                {
                    Console.Write(@"        biztos hogy ez a neve??
        nezd meg megegyszer
        ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    olvasottfajlnev = Console.ReadLine();
                    if (olvasottfajlnev.IndexOf(".txt") == -1)
                    {
                        olvasottfajlnev += ".txt";

                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }

                questions.Clear();
                foreach (var k in File.ReadAllLines(olvasottfajlnev))
                {
                    questions.Add(new kerdesek(k));
                }
            }
            else
            {
                Console.WriteLine("\n");
                Console.Write("\u001b[38;2;34;34;34m\n\n\n\tokés ^_^ hogy mentsem el a fajlodat? \n\t(fajlnevet adj meg marmint) \n\t\t[0m");
                Thread.Sleep(100);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n\n\n\tokés ^_^ hogy mentsem el a fajlodat? \n\t(fajlnevet adj meg marmint) \n\t\t");

                Console.ForegroundColor = ConsoleColor.Magenta;
                string megirtfajlnev = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                while (megirtfajlnev.IndexOfAny(tiltolista) != -1)
                {
                    Console.Write(@"
                    ez a fajlnev nem megengedett!! 
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

                questions.Clear();

                foreach (var k in File.ReadAllLines(megirtfajlnev))
                {
                    questions.Add(new kerdesek(k));
                }
            }
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
                    Console.Write("\n\n\n\tRendben, milyen típusú kérdést szeretnél írni?\n \t\t[1]: 4 válaszlehetőség \t [2]: Igaz / Hamis\n\t\t");
                    input = Console.ReadLine();
                }
                while (input != "1" && input != "2");

                int tipus = int.Parse(input);


                if (tipus == 1)
                {
                    Console.Clear();

                    mostani += "4q;";

                    Console.Write("\n\n\n\tMi a kérdésed?\n \t\t");
                    mostani += Console.ReadLine() + ";";
                    Console.Clear();

                    Console.Write("\n\n\n\tMi az "); SzinesSzoveg("első válaszlehetőség?", ConsoleColor.Red); Console.Write("\n\t\t");
                    string valasz1 = Console.ReadLine();
                    mostani += valasz1 + ";";
                    Console.Clear();

                    Console.Write("\n\n\n\tMi a "); SzinesSzoveg("második válaszlehetőség?", ConsoleColor.Yellow); Console.Write("\n\t\t");
                    string valasz2 = Console.ReadLine();
                    mostani += valasz2 + ";";
                    Console.Clear();

                    Console.Write("\n\n\n\tMi a "); SzinesSzoveg("harmadik válaszlehetőség?", ConsoleColor.Green); Console.Write("\n\t\t");
                    string valasz3 = Console.ReadLine();
                    mostani += valasz3 + ";";
                    Console.Clear();

                    Console.Write("\n\n\n\tMi a "); SzinesSzoveg("negyedik válaszlehetőség?", ConsoleColor.Blue); Console.Write("\n\t\t");
                    string valasz4 = Console.ReadLine();
                    mostani += valasz4 + ";";
                    Console.Clear();


                    input = "";
                    do
                    {
                        Console.Write($"\n\n\n\tÉs melyik a helyes válasz?\n");
                        Console.Write("\t\t[1]:"); SzinesSzoveg(valasz1, ConsoleColor.Red); Console.WriteLine();
                        Console.Write("\t\t[2]:"); SzinesSzoveg(valasz2, ConsoleColor.Yellow); Console.WriteLine();
                        Console.Write("\t\t[3]:"); SzinesSzoveg(valasz3, ConsoleColor.Green); Console.WriteLine();
                        Console.Write("\t\t[4]:"); SzinesSzoveg(valasz4, ConsoleColor.Blue); Console.Write("\n\t\t");

                        input = Console.ReadLine();
                    }
                    while (input != "1" && input != "2" && input != "3" && input != "4");
                    mostani += input;
                    Console.Clear();


                    fajlirashoz.Add(mostani);

                }
                else if (tipus == 2)
                {
                    Console.Clear();

                    mostani += "I/H;";

                    Console.Write("\n\n\n\tMi az állításod?\n \t\t");
                    mostani += Console.ReadLine() + ";";
                    Console.Clear();


                    input = "";
                    do
                    {
                        Console.Write("\n\n\n\tÉs mi a helyes válasz?\n \t\t");
                        Console.Write("[1]:"); SzinesSzoveg("Igaz", ConsoleColor.Green); Console.Write("\t");
                        Console.Write("[2]:"); SzinesSzoveg("Hamis", ConsoleColor.Red); Console.Write("\n\t\t");

                        input = Console.ReadLine();
                    }
                    while (input != "1" && input != "2");
                    mostani += input;
                    Console.Clear();


                    fajlirashoz.Add(mostani);

                }
                Console.Write("\n\n\n\tSzeretnél még kérdést írni?\n \t[1]: igen \t [2]: nem\n\t");
                if (Console.ReadLine() == "2")
                {
                    break;
                }
            }
            File.WriteAllLines(fajlnev, fajlirashoz);
            

        }
        static void Gameplay(List<kerdesek> questions)
        {
            int correct = 0;
            foreach (kerdesek k in questions)
            { 
                if (k.KerdesTipus.ToUpper() == "I/H")
                {
                    
                    string myanswer;
                    do
                    {
                        Console.Write($"{k.KerdesLeiras}\n\t");
                        SzinesSzoveg($"[1]: {k.Valasz1}\t", ConsoleColor.Green);
                        SzinesSzoveg($"[2]: {k.Valasz2}\n\t", ConsoleColor.Red);
                        myanswer = Console.ReadLine();

                    }
                    while (myanswer != "1" && myanswer != "2");
                    if (int.Parse(myanswer) == k.HelyesValasz)
                    {
                        correct++;
                        Console.WriteLine("Helyes!");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        if (myanswer=="1")

                        {
                            Console.Write($"Helytelen!\nA helyes válasz ");
                            SzinesSzoveg(k.Valasz2, ConsoleColor.Red);
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.Write($"Helytelen!\nA helyes válasz ");
                            SzinesSzoveg(k.Valasz1, ConsoleColor.Green);
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                }
                else
                {
                    
                    string myanswer;
                    do
                    {
                        Console.Write($"{k.KerdesLeiras}\n\t");
                        SzinesSzoveg($"[1]: {k.Valasz1}\n\t", ConsoleColor.Red);
                        SzinesSzoveg($"[2]: {k.Valasz2}\n\t", ConsoleColor.Yellow);
                        SzinesSzoveg($"[3]: {k.Valasz3}\n\t", ConsoleColor.Green);
                        SzinesSzoveg($"[4]: {k.Valasz4}\n\t", ConsoleColor.Blue);
                        myanswer = Console.ReadLine();

                    }
                    while (myanswer != "1" && myanswer != "2" && myanswer != "3" && myanswer!="4");

                    if (int.Parse(myanswer) == k.HelyesValasz)
                    {
                        correct++;
                        Console.WriteLine("Helyes!");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.Write($"\n\n\n\tHelytelen!\n\tA helyes válasz: ");
                        switch (k.HelyesValasz)
                        {
                            case 1: SzinesSzoveg(k.Valasz1, ConsoleColor.Red); break;
                            case 2: SzinesSzoveg(k.Valasz2, ConsoleColor.Yellow); break;
                            case 3: SzinesSzoveg(k.Valasz3, ConsoleColor.Green); break;
                            case 4: SzinesSzoveg(k.Valasz4, ConsoleColor.Blue); break;
                            default:break;
                        }
                        
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
            Console.WriteLine("\n\n\n\tA teljesítményed: " + correct+"/"+questions.Count());
            Thread.Sleep(1000);
            string answer;
            do
            {
                Console.Write("\n\tKvíz vége!!\n \t");
                SzinesSzoveg("[1]: Újrapróbálkozás\n \t", ConsoleColor.Yellow);
                SzinesSzoveg("[2]: Új játék\n\t", ConsoleColor.Cyan);
                SzinesSzoveg("[3]: Kilépés\n\n\n\t", ConsoleColor.Red);
                answer = Console.ReadLine();
            }
            while (answer != "1" && answer != "2" && answer!="3");
            Console.Clear();
            switch (answer)
            {
                case "1": Gameplay(questions);break;

                case "2": IrasVagyOlvasasScreenThingy(questions); break;
                    
                case "3":
                    Console.Write("\n\n\n\tAkkor vége a mókának...\n\tTalélkozunk legközelebb!!\n\t");
                    Console.ReadKey(); break;

                default:break;
            }

            
            
        }
    
    }
}
