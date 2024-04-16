using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР7_уровень_1
{
    abstract class Runner
    {
        protected string _surname, _group, _surnameTrainer;
        protected double _rezult;
        public abstract bool Check();

        public Runner(string surname, string group, string surnameTrainer, double rezult)//конструктор класса с аргументами
        {
            _surname = surname;
            _group = group;
            _surnameTrainer = surnameTrainer;
            _rezult = rezult;


        }
        public abstract double Run();
        private static int counter = 0;


        public void Print()
        {
            Console.WriteLine("100м");
            Console.WriteLine("Фамилия: {0, 10}" + " Группа: {1, 10}" + "Тренер: {2,10}" + " Результат: {3,10}", _surname, _rezult);
            if (Check())
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
        static void Sort(Runner[] uchastniki)
        {
            if (uchastniki.Length <= 1)
            {
                return;
            }


            int middle = uchastniki.Length / 2;

            Runner[] left = new Runner[middle];
            Runner[] right = new Runner[uchastniki.Length - middle];

            for (int i = 0; i < middle; i++)
            {
                left[i] = uchastniki[i];
            }

            for (int i = middle; i < uchastniki.Length; i++)
            {
                right[i - middle] = uchastniki[i];
            }

            Sort(left);
            Sort(right);

            Merge(uchastniki, left, right);
        }

        private static void Merge(Runner[] uchastniki, Runner[] left, Runner[] right)
        {
            int i = 0;
            int j = 0;
            int k = 0;

            while (i < left.Length && j < right.Length)
            {
                if (left[i]._rezult <= right[j]._rezult)
                {
                    uchastniki[k] = left[i];
                    i++;
                }
                else
                {
                    uchastniki[k] = right[j];
                    j++;
                }

                k++;
            }

            while (i < left.Length)
            {
                uchastniki[k] = left[i];
                i++;
                k++;
            }

            while (j < right.Length)
            {
                uchastniki[k] = right[j];
                j++;
                k++;
            }
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
        public override bool Check() { return _rezult <= 2.5; }
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
        public override bool Check() { return _rezult <= 2.5; }
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
            int counter = 0;
            for (int i = 0; i < uchastniki.Length; i++)
            {
                uchastniki[i].Print();
                if (uchastniki[i].Check())
                {
                    counter++;
                }
                Console.WriteLine();
            }

        }
    }
}
