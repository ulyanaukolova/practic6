using System.Xml.Serialization;

namespace practic6
{
    internal class Program
    {

        public static void Main()
        {
            Class1 number260 = new();
            {
                number260.Name = 260;
                number260.Names = "София";
                number260.mzt = 7;
                number260.Familia = "Алексеевна";
            }

            Class1 number107 = new();
            {
                number107.Name = 107;
                number107.Names = "Самая";
                number107.mzt = 5;
                number107.Familia = "Крутая";
            }

            Class1 number209 = new();
            {
                number209.Name = 209;
                number209.Names = "В";
                number209.mzt = 10;
                number209.Familia = "МПТ";
            }
            List<Class1> buses = new() { number260, number107, number209 };

            ShowMenu(buses, number260, number107, number209);

        }
        public static void ShowMenu(List<Class1> buses, Class1 number260, Class1 number107, Class1 number209)
        {
            int position = 0;
            var key = Console.ReadKey();
            while (key.Key != ConsoleKey.Enter)
            {
                Console.Clear();
                Console.WriteLine(" Сереализовать ");
                Console.WriteLine(" Десереализовать ");
                Arrow(key, position);
                key = Console.ReadKey();
            }
            Console.Clear();

            switch (position)
            {
                case 0:
                    ShowSerealizeMenu(buses, number260, number107, number209);
                    break;
                case 1:
                    break;
            }

        }
        private static void Arrow(ConsoleKeyInfo key, int position)
        {
            Console.CursorVisible = false;
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    position--;
                    break;
                case ConsoleKey.DownArrow:
                    position++;
                    break;
                case ConsoleKey.Escape:
                    Console.Clear();
                    Console.WriteLine("Вы вышли");
                    Environment.Exit(Environment.ExitCode);
                    break;
            }

            Console.SetCursorPosition(0, position);
            Console.WriteLine("->");
        }

        private static void SeJson(List<Class1> buses)
        {
            string json = JsonConvert.SerializeObject(buses);

            File.WriteAllText("C:\\Users\\MASTER\\Desktop\\Buses.json", json);
        }

        public static void SeXml(List<Class1> buses)
        {
            XmlSerializer xml = new(typeof(List<Class1>));

            using FileStream fs = new("C:\\Users\\MASTER\\Desktop\\Buses.xml", FileMode.OpenOrCreate);

            xml.Serialize(fs, buses);
        }
        private static void ShowSerealizeMenu(List<Class1> buses, Class1 number260, Class1 number107, Class1 number209)
        {
            int position = 0;
            var key = Console.ReadKey();
            while (key.Key != ConsoleKey.Enter)
            {
                Console.Clear();
                Console.WriteLine(" .xml ");
                Console.WriteLine(" .json ");
                Console.WriteLine(" .txt ");
                Arrow(key, position);
                key = Console.ReadKey();
            }
            Console.Clear();

            switch (position)
            {
                case 0:
                    SeXml(buses);
                    break;
                case 1:
                    SeJson(buses);
                    break;
                case 2:
                    SeTxt(number260, number107, number209);
                    break;
            }

        }

        private static void SeTxt(Class1 number260, Class1 number107, Class1 number209)
        {
            string bus260 = number260.Name + "\n" + number260.Names + "\n" + number260.mzt + "\n" + number260.Familia + "\n\n";
            string bus107 = number107.Name + "\n" + number107.Names + "\n" + number107.mzt + "\n" + number107.Familia + "\n\n";
            string bus209 = number209.Name + "\n" + number209.Names + "\n" + number209.mzt + "\n" + number209.Familia + "\n\n";

            List<string> buses = new() { bus260, bus107, bus209 };

            File.AppendAllLines("C:\\Users\\MASTER\\Desktop\\Buses.txt", buses);
        }
    }
}
