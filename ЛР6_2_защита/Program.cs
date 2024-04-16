using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР6_2_защита
{
    struct Sportsmen
    {
        private string _surname;
        private double _bestResult;
        public Sportsmen(string surname, double rez1, double rez2, double rez3) 
        {

            _surname = surname;
            _bestResult = 0;

            double maxx = 0;
            double[] tec = new double[3] { rez1, rez2, rez3 };
            for (int i = 0; i < 3; i++)
            {
                if (tec[i] > maxx)
                {
                    maxx = tec[i];
                }
            }
            _bestResult = maxx;

        }
        public double BestResult 
        {
            get => _bestResult;
        }

        public void Print() => Console.WriteLine("Фамилия: {0,10} Результат: {1,10}", _surname, _bestResult); 

        internal class Program
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
                    players[i].Print();
                }
            }

        }
    }
}
