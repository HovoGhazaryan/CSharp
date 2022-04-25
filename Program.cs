using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ISwitchable> arr = new List<ISwitchable>();
            arr.Add(new Phone());
            while (true)
            {
                Console.WriteLine("Enter computer name");
                string computerName = Console.ReadLine();
                arr.Add(new Comp(computerName));
                Console.WriteLine("Wanna continue? 0-no, enter-yes");
                if (Console.ReadLine() == "0")
                {
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("Control cumputers or phone? 1-comps, 2-phone, enter-exit");
                string point = Console.ReadLine();
                if (point == "1")
                {
                    Console.Clear();
                    Console.WriteLine("This is our PC's");
                    foreach (ISwitchable item in arr)
                    {
                        if (item is Comp)
                        {
                            Console.WriteLine($"\tComputer {(item as Comp).Name}.");
                        }
                    }
                    Console.WriteLine(new string('-', 8));
                    while (true)
                    {
                        Console.WriteLine("Enter name of PC to control it");
                        string pc_name = Console.ReadLine();
                        foreach (ISwitchable item in arr)
                        {
                            if (item is Comp && (item as Comp).Name == pc_name)
                            {
                                Console.WriteLine(new string('-', 4));
                                Console.WriteLine("Turn it on or off? 1-on, 2-off");
                                string option = Console.ReadLine();
                                if (option == "1")
                                    item.On();
                                else if (option == "2")
                                    item.Off();
                            }
                        }
                        Console.WriteLine("Press 0 for exit, press enter to continue...");
                        if (Console.ReadLine() == "0")
                        {
                            break;
                        }
                    }
                }
                else if (point == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Turn phone on or off? 1-on, 2-off");
                    string option = Console.ReadLine();
                    if (option == "1")
                    {
                        arr[0].On();
                    }
                    else if (option == "2")
                    {
                        arr[0].Off();
                    }
                }
                else
                    break;
            }
            Console.ReadKey();
        }
    }
    interface ISwitchable
    {
        void On();
        void Off();
    }
    class Comp : ISwitchable
    {
        public string Name { get; private set; }
        public Comp(string name)
        {
            Name = name;
        }
        public void On()
        {
            Console.WriteLine($"Computer {Name} is turned on.");
        }
        public void Off()
        {
            Console.WriteLine($"Computer {Name} is turned off.");
        }
    }
    class Phone : ISwitchable
    {
        public void On()
        {
            Console.WriteLine($"Phone is turned on.");
        }
        public void Off()
        {
            Console.WriteLine($"Phone is turned off.");
        }
    }
}
