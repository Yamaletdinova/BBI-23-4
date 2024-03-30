using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР7_2_уровень_3_задача
{
    abstract class Discipline
    {
        protected string _nameDiscipline;
        public Discipline(string nameDiscipline)
        {
            _nameDiscipline = nameDiscipline;
        }
        public abstract void PrintResults();
        public string NameDiscipline { get { return _nameDiscipline; } }
    }
    class LongJump : Discipline
    {
        public LongJump(string _nameDiscipline) : base(_nameDiscipline) { }

        public override void PrintResults()
        {
            Console.WriteLine($"Название дисциплины: {NameDiscipline}");  // Вывод результатов прыжков в длину
        }
    }
    class HighJump : Discipline
    {
        public HighJump(string _nameDiscipline) : base(_nameDiscipline) { }

        public override void PrintResults()
        {
            Console.WriteLine($"Название дисциплины: {NameDiscipline}"); // Вывод результатов прыжков в высоту
        }
    }


    public class Sportsmen
    {
        private string _surname;
        private double rez_1, rez_2, rez_3;
        public Sportsmen(string surname, double rez1, double rez2, double rez3)
        {
            rez_1 = rez1;
            rez_2 = rez2;
            rez_3 = rez3;
            _surname = surname;
        }
        public double Getrez1
        {
            get => rez_1;
        }
        public double Getrez2
        {
            get => rez_2;
        }
        public double Getrez3
        {
            get => rez_3;
        }
        public void Print(Sportsmen players, double rez) => Console.WriteLine("Фамилия: {0,10} Результат: {1,10}", _surname, rez);
        public void PoiskBest(double a, double b, double c, ref double maxim)
        {
            double maxx = 0;
            double[] tec = new double[3] { a, b, c };
            for (int i = 0; i < 3; i++)
            {
                if (tec[i] > maxx)
                {
                    maxx = tec[i];
                }
            }
            maxim = maxx;
        }
        class Program
        {
            static void Main(string[] args)
            {
                Sportsmen[] players = new Sportsmen[5];
                players[0] = new Sportsmen("Иванов", 5, 4, 3);
                players[1] = new Sportsmen("Лебедев", 6, 4, 7);
                players[2] = new Sportsmen("Андреев", 9, 8, 9);
                double[] end = new double[3];
                for (int i = 0; i < 3; i++)
                {
                    players[i].PoiskBest(players[i].Getrez1, players[i].Getrez2, players[i].Getrez3, ref end[i]);
                }
                for (int i = 0; i < 3; i++)
                {
                    players[i].Print(players[i], end[i]);
                }
                Sort(players);

                Discipline longJump = new LongJump("Прыжки в длину"); // экземпляры классов для дисциплин
                Discipline highJump = new HighJump("Прыжки в длину");


                Discipline[] disciplines = new Discipline[2];
                disciplines[0] = new LongJump("Прыжки в длину");
                disciplines[1] = new HighJump("Прыжки в длину");
                for (int i = 0; i < disciplines.Length; i++)
                {
                    disciplines[i].PrintResults();
                    for (int j = 0; j < players.Length; j++)
                    {
                        players[j].Print(players[j], end[j]);
                    }
                    Console.WriteLine();
                }

            }
            static void Sort(Sportsmen[] players)
            {
                for (int i = 0; i < players.Length; i++)
                {
                    for (int j = 0; j < players.Length - 1 - i; j++)
                    {
                        if (players[j].Getrez1 > players[j + 1].Getrez1)
                        {
                            Sportsmen temp = players[j];
                            players[j] = players[j + 1];
                            players[j + 1] = temp;
                        }
                    }
                }
            }


        }
    }
}
