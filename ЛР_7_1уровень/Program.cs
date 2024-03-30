using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР_7_1уровень
{
    abstract class Runner
    {
        protected string _surname, _group, _surnameTrainer;
        protected double _rezult;

        public Runner(string surname, string group, string surnameTrainer, double rezult)
        {
            _surname = surname;
            _group = group;
            _surnameTrainer = surnameTrainer;
            _rezult = rezult;

        }
        public abstract double Run();
        public double Rezult { get { return _rezult; } }
        public string Surname { get { return _surname; } }
        public string Group { get { return _group; } }
        public string SurnameTrainer { get { return _surnameTrainer; } }
        private static int counter = 0;
        public void Print()
        {
            Console.WriteLine("100м");
            Console.WriteLine("Фамилия: {0, 10}" + " Группа: {1, 10}" + "Тренер: {2,10}" + " Результат: {3,10}", Surname, Group, SurnameTrainer, Rezult);
            if (Rezult <= 2.5)
            {
                Console.WriteLine("норматив сдан");
                counter++;
            }
            else
            {
                Console.WriteLine("норматив не сдан");
            }

            Console.WriteLine("Количество сдавших норматив", counter);
        }


    }
    class Running100m : Runner
    {
        public Running100m(string surname, string group, string surnameTrainer, double rezult) : base(surname, group, surnameTrainer, rezult)
        { }

        public override double Run()
        {
            Console.WriteLine($"Фамилия: {_surname}, Дистанция: 100м, Результат: {_rezult}");
            return _rezult;
        }
    }

    class Running500m : Runner
    {
        public Running500m(string surname, string group, string surnameTrainer, double rezult) : base(surname, group, surnameTrainer, rezult)
        { }

        public override double Run()
        {
            Console.WriteLine($"Фамилия: {_surname}, Дистанция: 500м, Результат: {_rezult}");
            return _rezult;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Runner[] uchastniki = new Runner[5];
            uchastniki[0] = new Running100m("Иванова ", "1", "Трунева", 2.2);
            uchastniki[1] = new Running100m("Петрова ", "2", "Сергеева", 2.1);
            uchastniki[2] = new Running500m("Николева ", "3", "Агапова", 2.5);
            uchastniki[3] = new Running500m("Цветаева ", "4", "Авдеева", 3);
            uchastniki[4] = new Running500m("Лебедева ", "5", "Ерёмина", 4.16);

            Sort(uchastniki);
            int counter = 0;
            for (int i = 0; i < uchastniki.Length; i++)
            {
                uchastniki[i].Print();
                if (uchastniki[i].Rezult <= 2.5)
                {
                    counter++;
                }
                Console.WriteLine();
            }

        }
        static void Sort(Runner[] uchastniki)
        {
            for (int i = 0; i < uchastniki.Length; i++)
            {
                for (int j = 0; j < uchastniki.Length - 1 - i; j++)
                {
                    if (uchastniki[j].Rezult > uchastniki[j + 1].Rezult)
                    {
                        Runner temp = uchastniki[j];
                        uchastniki[j] = uchastniki[j + 1];
                        uchastniki[j + 1] = temp;
                    }
                }
            }
        }

    }
}
