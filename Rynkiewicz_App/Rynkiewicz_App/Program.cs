using System;
using System.IO;
using System.Threading;

namespace Rynkiewicz_App
{
    class Program
    {

        public static string myDirectory = "";

        static void Main(string[] args)
        {
            Start();
        }

        private static void Start()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter 1, 2 or 3 to load program you wish (or just 4 to exit)\n1. FizzBuzz\n2. DeepDive\n3. DrownItDown\n4. Exit");
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            string input = Console.ReadLine();
            int program = 0;

            try
            {
                program = Convert.ToInt32(input);
            }
            catch
            {
                InputBug();
                Start();
            }

            switch (program)
            {
                case 1:
                    FizzBuzz();
                    break;

                case 2:
                    DeepDive();
                    break;

                case 3:
                    DrownItDown();
                    break;

                case 4:
                    break;

                default:
                    InputBug();
                    Start();
                    break;
            }
        }

        public static void FizzBuzz()
        {
            Console.Clear();
            Console.WriteLine("Enter number from 0 to 1000 :)");
            uint input = 0;
            string result = "Number indivisible by 2 and 3.";

            try { 
            input = Convert.ToUInt32(Console.ReadLine());
            }
            catch
            {
                InputBug();
                FizzBuzz();
            }

            if(input > 1000)
            {
                InputBug();
                FizzBuzz();
            }

            if(input % 2 == 0)
            {
                result = "Fizz!";
            }
            if (input % 3 == 0)
            {
                result = "Buzz!";
            }
            if (input % 3 == 0 & input % 2 == 0)
            {
                result = "FizzBuzz!";
            }

            result += "\nThanks you.";
            Console.WriteLine(result);
            BackToMenu();
        }

        public static void DeepDive()
        {
            Console.Clear();
            Console.WriteLine("Tell me how many nested folders you want me to create (up to 5)");
            
            uint input = 0;
            string result = "Number indivisible by 2 and 3.";

            try
            {
                input = Convert.ToUInt32(Console.ReadLine());
            }
            catch
            {
                InputBug();
                DeepDive();
            }

            if (input > 5)
            {
                InputBug();
                DeepDive();
            }

            if(!Directory.Exists(myDirectory))
            {
                var directoryPath = AppDomain.CurrentDomain.BaseDirectory;
                while (input != 0)
                {
                    directoryPath += Convert.ToString(Guid.NewGuid()) + "/";
                    input--;
                }
                Directory.CreateDirectory(directoryPath);
                Console.WriteLine("Directory created!");
                myDirectory = directoryPath;
            }
            else
            {
                Console.WriteLine("Directory already exist");
            }


            BackToMenu();
        }

        public static void DrownItDown()
        {
            Console.Clear();
            Console.WriteLine("So how deep should i create file? Enter number (up to 5)");

            uint input = 0;
            string result = "Number indivisible by 2 and 3.";

            try
            {
                input = Convert.ToUInt32(Console.ReadLine());
            }
            catch
            {
                InputBug();
                DrownItDown();
            }

            if (input > 5)
            {
                InputBug();
                DrownItDown();
            }

            var directoryPath = AppDomain.CurrentDomain.BaseDirectory;

            BackToMenu();
        }

        public static void InputBug()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter correct value.");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1500);
        }

        public static void BackToMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Entering menu in 3");
            Thread.Sleep(1000);
            Console.WriteLine("Entering menu in 2");
            Thread.Sleep(1000);
            Console.WriteLine("Entering menu in 1");
            Thread.Sleep(1000);
            Start();
        }

    }
}
