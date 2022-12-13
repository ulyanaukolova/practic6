using System;
using System.Collections.Generic;
using System.IO;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace practic6
{
    class Program
    {
        public static List<MyDataFile> DataList = new List<MyDataFile>() {
            new MyDataFile("софия", 1),
            new MyDataFile("алексеевна", 1),
            new MyDataFile("вы крутая", 1),
            new MyDataFile("и топовая", 1)
        };

        public static void Close()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.White;
            Environment.Exit(0);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("типы файлов: .txt, .json, .xml");

            Console.Write($"\n{Filear.url} > ");
            string input = Console.ReadLine();
            PathToFile(input);
        }

        public static void PathToFile(string readLine)
        {
            Filear.dir = readLine;

            if (File.Exists(Filear.url + "/" + Filear.dir))
            {
                Console.Clear();
                Filear.Open();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Файл: {Filear.dir} - не нашлось");

                if (Filear.Create())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"новый файл: {Filear.url}/{Filear.dir}");
                }
                else Console.WriteLine($"Файл: {Filear.dir} - не создается");

                Close();
            }
        }
    }
}