using System.Net.Sockets;
using System.Threading.Channels;

namespace Async
{
    public class Program
    {
        static object locker = new object();

        public static int Start {  get; set; }
        public static int End { get; set; }

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Choose the number of exercise you want to execute(1-7): ");
                int.TryParse(Console.ReadLine(), out int val);
                switch (val)
                {
                    case 1:
                        Ex1();
                        break;
                    case 2:
                        Ex2();
                        break;
                    default:
                        Console.WriteLine("You really want to leave the program? y/n : ");
                        string choice = Console.ReadLine();
                        if (choice == "y")
                            return;
                        else
                            break;
                }
            }

        }

        public static void Ex1()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~EX1~~~~~~~~~~~~~~~~~~");
            var thr = new Thread(Print);
            thr.Start();
            thr.Join();
        }

        public static void Print()
        {
            for (int i = 0; i < 51; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
        }

        
        public static void Ex2()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~EX2~~~~~~~~~~~~~~~~~~");

            Console.WriteLine("Enter the beginning of range: ");
            int.TryParse(Console.ReadLine(), out var start);
            Start = start;
            

            Console.WriteLine("Enter the end of range: ");
            int.TryParse(Console.ReadLine(), out var end);
            End = end;

            //var thr = new Thread(() =>
            //{
            //    for (int i = Start; i < End; i++)
            //    {
            //        Console.WriteLine(i);
            //        Thread.Sleep(100);
            //    }
            //});

            var thr = new Thread(Print2);
            thr.Start();
        }
        public static void Print2()
        {
            for (int i = Start; i < End; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
        }
    }
}
