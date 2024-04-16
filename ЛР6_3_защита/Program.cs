using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР6_3_защита
{
    struct Potok
    {
        private string _group, _potok;
        private int _russian, _matanalys, _angem, _phisics, _programm;
        private double _sredn;
        public Potok(string group, string potok, int russian, int matanalys, int angem, int phisics, int programm)// констурктор, инициализация поля структуры
        {
            _group = group;
            _potok = potok;
            _russian = russian;
            _matanalys = matanalys;
            _angem = angem;
            _phisics = phisics;
            _programm = programm;
            _sredn = 0;
            Srednrezult();


        }
        public string group { get { return _group; } }
        public string potok { get { return _potok; } }

        private void Srednrezult() //метод, вычисляющий среднюю оценку по всем предметам в группе
        {
            double summ = 0, n = 5;
            summ = _russian + _matanalys + _angem + _phisics + _programm;
            _sredn = summ / n;
        }
        public double Sredn { get { return _sredn; } }
        public void Print() // Метод, который выводит информацию о потоке, группе и среднем значения
        {
            Console.WriteLine("Поток {0, 10} Группа {1, 10} Среднее значение {2, 10}", potok, group, _sredn);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Potok[] groupi = new Potok[5];
            groupi[0] = new Potok("1", "numb1", 5, 2, 5, 4, 3);
            groupi[1] = new Potok("2", "numb2", 4, 3, 3, 5, 3);
            groupi[2] = new Potok("4", "numb1", 3, 2, 1, 4, 3);
            groupi[3] = new Potok("1", "numb1", 5, 4, 5, 3, 3);
            groupi[4] = new Potok("3", "numb4", 5, 3, 5, 4, 4);
            Potok[] groupinumb1 = new Potok[3];
            int k = 0;

            for (int i = 0; i < groupi.Length; i++)
            {

                if (groupi[i].potok.Equals("numb1"))
                {
                    groupinumb1[k] = groupi[i];
                    k++;

                }
            }
            sort(groupinumb1);
            foreach (Potok item in groupinumb1)
            {
                item.Print();
            }
        }
        static void sort(Potok[] groupi) // метод, сортирующий массив по убыванию средней оценки с помощью пузырьковой сортировки
        {
            for (int i = 0; i < groupi.Length; i++)
            {
                for (int j = 0; j < groupi.Length - 1 - i; j++)
                {
                    if (groupi[j].Sredn < groupi[j + 1].Sredn)
                    {
                        Potok tempPotok = groupi[j];
                        groupi[j] = groupi[j + 1];
                        groupi[j + 1] = tempPotok;
                    }
                }
            }
        }
    }
}
