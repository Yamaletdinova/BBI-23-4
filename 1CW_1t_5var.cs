using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp4
{
    struct Rectangle
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        public string Compare(Rectangle other)
        {
            string result = "";

            if (Length > other.Length)

                result += "Первый прямоугольник длиннее второго.\n";
            else if (Length < other.Length)
                result += "Второй прямоугольник длиннее первого.\n";
            else
                result += "Прямоугольники имеют одинаковую длину.\n";

            if (Width > other.Width)
                result += "Первый прямоугольник шире второго.\n";
            else if (Width < other.Width)
                result += "Второй прямоугольник шире первого.\n";
            else
                result += "Прямоугольники имеют одинаковую ширину.\n";

            double area1 = Length * Width;
            double area2 = other.Length * other.Width;

            if (area1 > area2)
                result += "Первый прямоугольник больше по площади.\n";
            else if (area1 < area2)
                result += "Второй прямоугольник больше по площади.\n";
            else
                result += "Прямоугольники имеют одинаковую площадь.\n";

            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle1 = new Rectangle(5, 10);
            Rectangle rectangle2 = new Rectangle(8, 6);
            Rectangle rectangle3 = new Rectangle(7, 9);

            Console.WriteLine("Сравнение прямоугольников:");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Прямоугольник 1: Длина = {0}, Ширина = {1}", rectangle1.Length, rectangle1.Width);
            Console.WriteLine("Прямоугольник 2: Длина = {0}, Ширина = {1}", rectangle2.Length, rectangle2.Width);
            Console.WriteLine("Прямоугольник 3: Длина = {0}, Ширина = {1}", rectangle3.Length, rectangle3.Width);
            Console.WriteLine("----------------------------");

            Console.WriteLine(rectangle1.Compare(rectangle2));
            Console.WriteLine(rectangle1.Compare(rectangle3));
            Console.WriteLine(rectangle2.Compare(rectangle3));                
        }
    }
}




