using ProtoBuf;
using System;
using System.Xml.Serialization;
using SerializersLibrary;
using System.Text.Json.Serialization;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;

namespace Lab
{
    [ProtoInclude(5, typeof(Running100m))]
    [ProtoInclude(6, typeof(Running500m))]

    [Serializable, ProtoContract,
     XmlInclude(typeof(Running100m)), XmlInclude(typeof(Running500m)), XmlInclude(typeof(Runner))]

    public abstract class Runner
    {
        [ProtoMember(1)]
        [JsonInclude]
        [XmlAttribute("Surname")]
        public string Surname { set; get; }

        [ProtoMember(2)]
        [JsonInclude]
        [XmlAttribute("Group")]
        public string Group { set; get; }

        [ProtoMember(3)]
        [JsonInclude]
        [XmlAttribute("TrainerSurname")]
        public string SurnameTrainer { set; get; }

        [ProtoMember(4)]
        [JsonInclude]
        [XmlAttribute("Rezult")]
        public double Rezult { set; get; }

        public abstract bool Check();
        public Runner() { }
        [JsonConstructor]
        public Runner(string surname, string group, string surnameTrainer, double rezult)
        {
            Surname = surname;
            Group = group;
            SurnameTrainer = surnameTrainer;
            Rezult = rezult;
        }


        public abstract double Run();
        private static int counter = 0;
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
                if (left[i].Rezult <= right[j].Rezult)
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

    [Serializable, ProtoContract]
    public class Running100m : Runner
    {
        public Running100m(string surname, string group, string surnameTrainer, double rezult) : base(surname, group, surnameTrainer, rezult)
        { }
        public Running100m() : base() { }
        public override double Run()
        {
            Console.WriteLine($"Фамилия: {Surname}, Дистанция: 100м, Результат: {Rezult}");
            return Rezult;
        }

        public override string ToString()
        {
            return Surname + " " + Group + " " + SurnameTrainer + " " + Rezult.ToString();
        }
        public override bool Check() { return Rezult <= 2.5; }
    }

    [Serializable, ProtoContract]
    public class Running500m : Runner
    {

        public Running500m(string surname, string group, string surnameTrainer, double rezult) : base(surname, group, surnameTrainer, rezult)
        { }
        public Running500m() : base() { }
        public override double Run()
        {
            Console.WriteLine($"Фамилия: {Surname}, Дистанция: 500м, Результат: {Rezult}");
            return Rezult;
        }

        public override string ToString()
        {
            return Surname + " " + Group + " " + SurnameTrainer + " " + Rezult.ToString();
        }
        public override bool Check() { return Rezult <= 2.5; }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Running100m[] uchastniki = new Running100m[5];
            uchastniki[0] = new Running100m("Иванова ", "1", "Трунева", 2.2);
            uchastniki[1] = new Running100m("Петрова ", "2", "Сергеева", 2.1);
            uchastniki[2] = new Running100m("Николева ", "3", "Агапова", 2.5);
            uchastniki[3] = new Running100m("Цветаева ", "4", "Авдеева", 3);
            uchastniki[4] = new Running100m("Лебедева ", "5", "Ерёмина", 4.16);
            int counter = 0;

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
                mySerializers[i].Write(uchastniki, Path.Combine(path, file_names[i]));
            }


            for (int i = 0; i < mySerializers.Length; i++)
            {
                var answer = mySerializers[i].Read<Running100m[]>(Path.Combine(path, file_names[i]));
                foreach (var p in answer)
                {
                    Console.WriteLine(p);
                }
            }

        }
    }
}

//static void Sort(Runner[] uchastniki)
//{
//    for (int i = 0; i < uchastniki.Length; i++)
//    {
//        for (int j = 0; j < uchastniki.Length - 1 - i; j++)
//        { 
//            if (uchastniki[j].Rezult > uchastniki[j + 1].Rezult)
//            {
//                Runner temp = uchastniki[j];
//                uchastniki[j] = uchastniki[j + 1];
//                uchastniki[j + 1] = temp;
//            }
//        }
//    }
//}








