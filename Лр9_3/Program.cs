using ProtoBuf;
using SerializersLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace ЛР7_3
{
    [Serializable]
    [ProtoContract]
    [XmlInclude(typeof(Group1)), ProtoInclude(10, typeof(Group1))]
    [XmlInclude(typeof(Group2)), ProtoInclude(11, typeof(Group2))]
    [XmlInclude(typeof(Group3)), ProtoInclude(12, typeof(Group3))]
    [XmlInclude(typeof(Group4)), ProtoInclude(13, typeof(Group4))]
    public class Group
    {
        protected string _group, _potok, _surname;
        protected int _matanalys, _angem, _phisics;

        public Group() { }
        [JsonConstructor]
        public Group(string group, string potok, string surname, int matanalys, int angem, int phisics)
        {
            _group = group;
            _potok = potok;
            _surname = surname;
            _matanalys = matanalys;
            _angem = angem;
            _phisics = phisics;
        }
        [ProtoMember(1)]
        [XmlAttribute("Surname")]
        public string surname { set { _surname = value; } get { return _surname; } }
        [ProtoMember(2)]
        [XmlAttribute("Potok")]
        public string potok { set { _potok = value; } get { return _potok; } }
        [ProtoMember(3)]
        [XmlAttribute("Group")]
        public string group { set { _group = value; } get { return _group; } }
        [ProtoMember(4)]
        [XmlAttribute("Matanalys")]
        public int matanalys { set { _matanalys = value; } get { return _matanalys; } }
        [ProtoMember(5)]
        [XmlAttribute("Angem")]
        public int angem { set { _angem = value; } get { return _angem; } }
        [ProtoMember(6)]
        [XmlAttribute("Phisics")]
        public int phisics { set { _phisics = value; } get { return _phisics; } }
        public virtual void Average(Group groups, ref double sred_) { }
        public virtual void Print(Group groups, ref double sredn_)
        {
            Console.WriteLine("Фамилия: {0, 10} Поток: {1, 10} Группа: {2,10} Средний результат: {3,10}", surname, potok, group, sredn_);
        }

        public void Sred_rez(double[][] a, ref double[] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                double sum = 0, n = 5;
                for (int j = 0; j < n; j++)
                {
                    sum += a[i][j];
                }
                b[i] = sum / n;
            }

        }

        public override string ToString()
        {
            return surname + " " + potok + " " + group + "\nMatanalys: " + matanalys.ToString() + "\n" +
                "Angem: " + angem.ToString() + "\n" +
                "Phisics: " + phisics.ToString() + "\n";
        }
    }

    [Serializable]
    [ProtoContract]
    public class Group1 : Group
    {
        private int _Exam1;
        private int _Exam2;
        public Group1() { }
        [JsonConstructor]
        public Group1(string group, string potok, string surname, int matanalys, int angem, int phisics, int Exam1, int Exam2)
            : base(group, potok, surname, matanalys, angem, phisics)
        {
            _Exam1 = Exam1;
            _Exam2 = Exam2;
        }

        public override void Average(Group groups, ref double sred_)
        {
            double summ = 0;
            int n = 5;
            summ = groups.matanalys + groups.angem + groups.phisics + _Exam1 + _Exam2;
            sred_ = summ / n;
        }
    }

    [Serializable]
    [ProtoContract]
    public class Group2 : Group
    {
        private int _Exam3, _Exam4;
        public Group2() { }
        [JsonConstructor]
        public Group2(string group, string potok, string surname, int matanalys, int angem, int phisics, int Exam3, int Exam4)
            : base(group, potok, surname, matanalys, angem, phisics)
        {
            _Exam3 = Exam3;
            _Exam4 = Exam4;
        }

        public override void Average(Group groups, ref double sred_)
        {
            double summ = 0;
            int n = 5;
            summ = groups.matanalys + groups.angem + groups.phisics + _Exam3 + _Exam4;
            sred_ = summ / n;
        }
    }

    [Serializable]
    [ProtoContract]
    public class Group3 : Group
    {
        private int _Exam5, _Exam6;
        public Group3() { }
        [JsonConstructor]
        public Group3(string group, string potok, string surname, int matanalys, int angem, int phisics, int Exam5, int Exam6)
            : base(group, potok, surname, matanalys, angem, phisics)
        {
            _Exam5 = Exam5;
            _Exam6 = Exam6;
        }

        public override void Average(Group groups, ref double sred_)
        {
            double summ = 0;
            int n = 5;
            summ = groups.matanalys + groups.angem + groups.phisics + _Exam5 + _Exam6;
            sred_ = summ / n;
        }
    }

    [Serializable]
    [ProtoContract]
    public class Group4 : Group
    {
        private int _Exam7, _Exam8;
        public Group4() { }
        [JsonConstructor]
        public Group4(string group, string potok, string surname, int matanalys, int angem, int phisics, int Exam7, int Exam8)
            : base(group, potok, surname, matanalys, angem, phisics)
        {
            _Exam7 = Exam7;
            _Exam8 = Exam8;
        }

        public override void Average(Group groups, ref double sred_)
        {
            double summ = 0;
            int n = 5;
            summ = groups.matanalys + groups.angem + groups.phisics + _Exam7 + _Exam8;
            sred_ = summ / n;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Group[] groups1 = new Group1[5];
            groups1[0] = new Group1("группа 1", "Fiz", "Смирнов", 5, 5, 5, 5, 5);
            groups1[1] = new Group1("группа 1", "Fiz", "Иванов", 4, 3, 3, 5, 3);
            groups1[2] = new Group1("группа 1", "Fiz", "Морозов", 3, 2, 1, 1, 1);
            groups1[3] = new Group1("группа 1", "Fiz", "Березкин", 5, 4, 5, 3, 3);
            groups1[4] = new Group1("группа 1", "Fiz", "Лавров", 5, 3, 5, 4, 4);
            Group[] groups2 = new Group2[5];
            groups2[0] = new Group2("группа 2", "Fiz", "Смирнов1", 1, 2, 5, 4, 3);
            groups2[1] = new Group2("группа 2", "Fiz", "Иванов1", 4, 3, 4, 5, 2);
            groups2[2] = new Group2("группа 2", "Fiz", "Морозов1", 2, 2, 5, 4, 3);
            groups2[3] = new Group2("группа 2", "Fiz", "Березкин1", 5, 2, 5, 3, 3);
            groups2[4] = new Group2("группа 2", "Fiz", "Лавров1", 1, 3, 5, 5, 4);
            Group[] groups3 = new Group3[5];
            groups3[0] = new Group3("группа 3", "Mat", "Смирнов2", 5, 4, 5, 4, 2);
            groups3[1] = new Group3("группа 3", "Mat", "Иванов2", 4, 3, 4, 5, 3);
            groups3[2] = new Group3("группа 3", "Mat", "Морозов2", 3, 3, 1, 4, 3);
            groups3[3] = new Group3("группа 3", "Mat", "Березкин2", 5, 5, 5, 3, 3);
            groups3[4] = new Group3("группа 3", "Mat", "Лавров2", 4, 3, 4, 4, 4);
            Group[] groups4 = new Group[5];
            groups4[0] = new Group4("группа 4", "Fiz", "Смирнов3", 4, 4, 4, 5, 3);
            groups4[1] = new Group4("группа 4", "Fiz", "Иванов3", 4, 3, 3, 3, 3);
            groups4[2] = new Group4("группа 4", "Fiz", "Морозов3", 4, 5, 1, 4, 3);
            groups4[3] = new Group4("группа 4", "Fiz", "Березкин3", 5, 5, 5, 4, 3);
            groups4[4] = new Group4("группа 4", "Fiz", "Лавров3", 5, 3, 5, 4, 4);

            Group[][] groups = new Group[][] { groups1, groups2, groups3, groups4 };

            Group[][] groupsFiz = new Group[3][];
            double[] sred_student1 = new double[5];
            double[] sred_student2 = new double[5];
            double[] sred_student3 = new double[5];
            double[][] sred = new double[][] { sred_student1, sred_student2, sred_student3 };
            double sr = 0;
            int k = 0; //элементы в Fiz
            for (int i = 0; i < groups.Length; i++)
            {
                string Fiz = "Fiz";
                if (groups[i][i].potok.Equals(Fiz))
                {
                    groupsFiz[k] = groups[i];
                    for (int j = 0; j < 5; j++)
                    {
                        groupsFiz[k][j].Average(groupsFiz[k][j], ref sr);
                        sred[k][j] = sr;
                    }
                    k++;
                }
            }
            double[] aver = new double[3];
            groupsFiz[0][0].Sred_rez(sred, ref aver);
            Sort(groupsFiz, aver);

            string path = @"C:\Users\user\Desktop"; //путь до рабочего стола
            string folderName = "Test";
            path = Path.Combine(path, folderName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            SerializersLibrary.MySerializer[] mySerializers = [
                   new MyJSONSerializer(),
                    new MyXmlSerializer(),
                    new MyBinSerializer()];
            string[] file_names = new string[]
            {
                "example.json",
                "example.xml",
                "example.bin"
            };

            for (int i = 0; i < mySerializers.Length; i++)
            {
                for (int j = 0; j < groupsFiz.Length; ++j)
                {
                    System.IO.File.WriteAllText(Path.Combine(path, file_names[i]), string.Empty);
                    mySerializers[i].Write(groupsFiz[j], Path.Combine(path, file_names[i]));
                    for (int p = 0; p < mySerializers.Length; p++)
                    {
                        var answer = mySerializers[i].Read<Group[]>(Path.Combine(path, file_names[i]));
                        foreach (var u in answer)
                        {
                            Console.WriteLine(u);
                        }
                    }

                }
            }

            for (int i = 0; i < groupsFiz.Length; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    groupsFiz[i][j].Print(groupsFiz[i][j], ref aver[i]);
                }
            }
        }
        static void Sort(Group[][] groups, double[] sr)
        {
            for (int i = 0; i < groups.Length; i++)
            {
                for (int j = 0; j < groups.Length - 1 - i; j++)
                {
                    if (sr[j] < sr[j + 1])
                    {
                        double temp = sr[j];
                        sr[j] = sr[j + 1];
                        sr[j + 1] = temp;
                        Group[] g = groups[j];
                        groups[j] = groups[j + 1];
                        groups[j + 1] = g;
                    }
                }
            }
        }
    }
}
