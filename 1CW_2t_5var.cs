using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp5
{
    abstract class Embrasure
    {
        public string Name { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Thick { get; set; }

        public abstract double Calculate();
    }

    class Window : Embrasure
    {
        public int Sloy { get; set; }

        public override double Calculate()
        {
            return Width * Height * Sloy * 10; // цена окна
        }
    }
    class Door : Embrasure
    {
        public bool Pattern { get; set; }
        public bool Glass { get; set; }

        public override double Calculate()
        {
            double baseCost = Width * Height * 15;

            if (Pattern)
                baseCost += 50;

            if (Glass)
                baseCost += 100;

            return baseCost;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Embrasure[] embrasures = new Embrasure[10];

            embrasures[0] = new Window { Name = "Окно 1", Width = 100, Height = 120, Thick = 5, Sloy = 2 };
            embrasures[1] = new Window { Name = "Окно 2", Width = 80, Height = 100, Thick = 4, Sloy = 3 };
            embrasures[2] = new Window { Name = "Окно 3", Width = 150, Height = 150, Thick = 6, Sloy = 1 };
            embrasures[3] = new Window { Name = "Окно 4", Width = 90, Height = 110, Thick = 4, Sloy = 2 };
            embrasures[4] = new Window { Name = "Окно 5", Width = 120, Height = 130, Thick = 5, Sloy = 2 };

            embrasures[5] = new Door { Name = "Дверь 1", Width = 90, Height = 210, Thick = 8, Pattern = true, Glass = false };
            embrasures[6] = new Door { Name = "Дверь 2", Width = 80, Height = 200, Thick = 7, Pattern = false, Glass = true };
            embrasures[7] = new Door { Name = "Дверь 3", Width = 100, Height = 220, Thick = 9, Pattern = true, Glass = true };
            embrasures[8] = new Door { Name = "Дверь 4", Width = 85, Height = 205, Thick = 7, Pattern = false, Glass = false };
            embrasures[9] = new Door { Name = "Дверь 5", Width = 95, Height = 215, Thick = 8, Pattern = true, Glass = true };


            for (int i = 0; i < embrasures.Length - 1; i++)
            {
                for (int j = i + 1; j < embrasures.Length; j++)
                {
                    if (embrasures[i].Calculate() > embrasures[j].Calculate())
                    {
                        Embrasure temp = embrasures[i];
                        embrasures[i] = embrasures[j];
                        embrasures[j] = temp;
                    }
                }
            }

            Console.WriteLine("Сортировка окон и дверей по возрастанию цены:");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("{0,-10} | {1,-10} | {2,-10} | {3,-10} | {4,-10}", "Название", "Ширина", "Длина", "Толщина", "Цена");
            Console.WriteLine("-------------------------------------------------");
            foreach (Embrasure embrasure in embrasures)
            {
                Console.WriteLine("{0,-10} | {1,-10} | {2,-10} | {3,-10} | {4,-10}", embrasure.Name, embrasure.Width, embrasure.Height, embrasure.Thick, embrasure.Calculate());
            }
        }
    }
}




