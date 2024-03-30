using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР7_3_уровень_1_задача
{
    public class Group
    {
        protected string _group;
        protected int _russian, _matanalys, _angem, _phisics, _programm;

        public Group(string group, int russian, int matanalys, int angem, int phisics, int programm)
        {
            _group = group;
            _russian = russian;
            _matanalys = matanalys;
            _angem = angem;
            _phisics = phisics;
            _programm = programm;
        }

        public virtual double Average()
        {
            double summ = _russian + _matanalys + _angem + _phisics + _programm;
            return summ / 5;
        }

        public void Print()
        {
            Console.WriteLine("Группа: {0}, Средний балл: {1}", _group, Average());
        }
    }

    public class Group1 : Group
    {
        private int _Exam1, _Exam2;

        public Group1(string group, int russian, int matanalys, int angem, int phisics, int programm, int Exam1, int Exam2)
            : base(group, russian, matanalys, angem, phisics, programm)
        {
            _Exam1 = Exam1;
            _Exam2 = Exam2;
        }

        public override double Average()
        {
            double summ = _russian + _matanalys + _angem + _phisics + _programm + _Exam1 + _Exam2;
            return summ / 7;
        }
    }

    public class Group2 : Group
    {
        private int _Exam3, _Exam4;

        public Group2(string group, int russian, int matanalys, int angem, int phisics, int programm, int Exam3, int Exam4)
            : base(group, russian, matanalys, angem, phisics, programm)
        {
            _Exam3 = Exam3;
            _Exam4 = Exam4;
        }

        public override double Average()
        {
            double summ = _russian + _matanalys + _angem + _phisics + _programm + _Exam3 + _Exam4;
            return summ / 7;
        }
    }

    public class Group3 : Group
    {
        private int _Exam5, _Exam6;

        public Group3(string group, int russian, int matanalys, int angem, int phisics, int programm, int Exam5, int Exam6)
            : base(group, russian, matanalys, angem, phisics, programm)
        {
            _Exam5 = Exam5;
            _Exam6 = Exam6;
        }

        public override double Average()
        {
            double summ = _russian + _matanalys + _angem + _phisics + _programm + _Exam5 + _Exam6;
            return summ / 7;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Group[] groupi = new Group[5];
            groupi[0] = new Group1("numb1", 5, 2, 5, 4, 3, 5, 2);
            groupi[1] = new Group2("numb2", 4, 3, 3, 5, 3, 5, 5);
            groupi[2] = new Group3("numb1", 3, 2, 1, 4, 3, 1, 2);
            groupi[3] = new Group1("numb1", 5, 4, 5, 3, 3, 5, 3);
            groupi[4] = new Group2("numb4", 5, 3, 5, 4, 4, 3, 3);
            sort(groupi);
            foreach (Group group in groupi)
            {
                group.Print();
            }
        }
        static void sort(Group[] groupi)
        {
            for (int i = 0; i < groupi.Length; i++)
            {
                for (int j = 0; j < groupi.Length - 1 - i; j++)
                {
                    if (groupi[j].Average() < groupi[j + 1].Average())
                    {
                        Group tempPotok = groupi[j];
                        groupi[j] = groupi[j + 1];
                        groupi[j + 1] = tempPotok;
                    }
                }
            }
        }
    }
}
