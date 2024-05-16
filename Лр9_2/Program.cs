using ProtoBuf;
using SerializersLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ЛР_7_2
{
    [Serializable]
    [ProtoContract]
    [XmlInclude(typeof(Discipline)), ProtoInclude(10, typeof(Discipline))]
    [XmlInclude(typeof(LongJump)), ProtoInclude(12, typeof(LongJump))]
    [XmlInclude(typeof(HighJump)), ProtoInclude(13, typeof(HighJump))]
    public class Sportsmen
    {
        private string _surname;
        private double rez_1, rez_2, rez_3, _bestResult;
        public Sportsmen(string surname, double rez1, double rez2, double rez3)
        {
            rez_1 = rez1;
            rez_2 = rez2;
            rez_3 = rez3;
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
        public Sportsmen() { }
        [XmlAttribute("BestResult")]
        [ProtoMember(1)]
        public double BestResult // свойства для доступа к приватным полям результатов
        {
            get => _bestResult;
            set => _bestResult = value;
        }
        [XmlAttribute("GetRez1")]
        [ProtoMember(2)]
        public double Getrez1
        {
            get => rez_1;
            set => rez_1 = value;
        }
        [XmlAttribute("Surname")]
        [ProtoMember(3)]
        public string Surname
        {
            get => _surname;
            set => _surname = value;
        }
        public override string ToString()
        {
            return Surname + " " + BestResult.ToString();
        }
    }
    [ProtoContract]
    [Serializable]
    public abstract class Discipline
    {
        protected string disciplineName;
        protected Sportsmen[] sportsmens;
        [XmlAttribute("Discipline Name")]
        [ProtoMember(5)]
        public string DisciplineName { get; set; }
        [XmlArray("Sportmens")]
        [ProtoMember(6)]
        public Sportsmen[] Sportsmens { get; set; }
        public Discipline(string disciplineName, Sportsmen[] sportsmens)
        {
            this.disciplineName = disciplineName;
            this.sportsmens = sportsmens;
        }
        public Discipline() { }
        public abstract void Print();
        public abstract void Sort();
    }

    [ProtoContract]
    [Serializable]
    public class LongJump : Discipline
    {
        public LongJump(Sportsmen[] sportsmens) : base("Прыжки в длину", sportsmens)
        { }
        public LongJump() { }
        public override void Print()
        {
            foreach (var s in sportsmens)
            {
                Console.WriteLine("Дисциплина: {0}", disciplineName);
                Console.WriteLine("Фамилия: {0,-10} Лучший результат:{1,-10}", s.Surname, s.BestResult);
                Console.WriteLine();
            }
        }
        public override void Sort()
        { }
    }

    [ProtoContract]
    [Serializable]
    public class HighJump : Discipline
    {
        public HighJump(Sportsmen[] sportsmens) : base("Прыжки в высоту", sportsmens) { }
        public HighJump() { }
        public override void Print()
        {
            foreach (var s in sportsmens)
            {
                Console.WriteLine("Дисциплина: {0}", disciplineName);
                Console.WriteLine("Фамилия: {0,-10} Лучший результат:{1,-10}", s.Surname, s.BestResult);
                Console.WriteLine();
            }

        }
        public override void Sort() { }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Sportsmen[] long_players = new Sportsmen[3];
            long_players[0] = new Sportsmen("Белов", 5, 4, 3);
            long_players[1] = new Sportsmen("Иванов", 6, 5, 7);
            long_players[2] = new Sportsmen("Сидоров", 9, 8, 9);
            Sort(long_players);

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
                mySerializers[i].Write(long_players, Path.Combine(path, file_names[i]));
            }


            for (int i = 0; i < mySerializers.Length; i++)
            {
                var answer = mySerializers[i].Read<Sportsmen[]>(Path.Combine(path, file_names[i]));
                foreach (var p in answer)
                {
                    Console.WriteLine(p);
                }
            }

            LongJump longJump = new LongJump(long_players);
            longJump.Print();


            Sportsmen[] high_players = new Sportsmen[3];
            high_players[0] = new Sportsmen("Петров", 7, 8, 9);
            high_players[1] = new Sportsmen("Лебедев", 6, 5, 6);
            high_players[2] = new Sportsmen("Краснов", 9, 5, 9);
            Sort(high_players);

            for (int i = 0; i < mySerializers.Length; i++)
            {
                mySerializers[i].Write(high_players, Path.Combine(path, file_names[i]));
            }


            for (int i = 0; i < mySerializers.Length; i++)
            {
                var answer = mySerializers[i].Read<Sportsmen[]>(Path.Combine(path, file_names[i]));
                foreach (var p in answer)
                {
                    Console.WriteLine(p);
                }
            }

            HighJump highJump = new HighJump(high_players);
            highJump.Print();

        }
        static void Sort(Sportsmen[] long_players)
        {
            for (int i = 0; i < long_players.Length; i++)
            {
                for (int j = 0; j < long_players.Length - 1 - i; j++)
                {
                    if (long_players[j].Getrez1 > long_players[j + 1].Getrez1)
                    {
                        Sportsmen temp = long_players[j];
                        long_players[j] = long_players[j + 1];
                        long_players[j + 1] = temp;
                    }
                }
            }
        }


    }


}


