using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР_8
{
    abstract class Task
    {
        protected string text;
        public Task(string text)
        {
            this.text = text;
            Text(text);// вызываем метод для обработки текста при создании 
        }
        protected abstract void Text(string text);

    }
    class Task_1 : Task //1
    {
        private int[] letter_chastota = new int[33];
        private int totalLetters = 0;
        private string result = "";
        public Task_1(string text) : base(text) { }
        public override string ToString()
        {
            for (int i = 0; i < 33; i++) // частота встречаемости букв
            {
                double frequency = (double)letter_chastota[i] / totalLetters;
                char letter = (char)('А' + i);
                result += $"{letter}: {frequency:P2}\n";
            }
            return result;
        }
        protected override void Text(string text)
        {
            foreach (char c in text)
            {
                if (char.IsLetter(c)) // только заглавные буквы
                {
                    int index = char.ToUpper(c) - 'А'; // Индекс буквы в русском алфавите
                    if (index >= 0 && index < 33)
                    {
                        letter_chastota[index]++;
                        totalLetters++;
                    }
                }
            }
        }
    }

    class Task_3 : Task //3
    {
        private string ResultText;
        public Task_3(string text) : base(text) { }

        public override string ToString()
        {
            return ResultText;
        }
        protected override void Text(string text)
        {
            string result = "";
            int startIndex = 0;
            int currentIndex = 0;

            while (currentIndex < text.Length)
            {
                if (currentIndex - startIndex >= 50)
                {
                    int lastSpaceIndex = text.LastIndexOf(' ', currentIndex - 1, 50);
                    if (lastSpaceIndex != -1)
                    {
                        result += text.Substring(startIndex, lastSpaceIndex - startIndex) + "\n";
                        startIndex = lastSpaceIndex + 1;
                    }
                    else
                    {
                        result += text.Substring(startIndex, 50) + "\n";
                        startIndex += 50;
                    }
                }
                currentIndex++;
            }

            if (startIndex < text.Length)
            {
                result += text.Substring(startIndex);
            }

            ResultText = result;
        }
    }
    class Task_6 : Task //6
    {
        private int[] SyllableCount = new int[10];
        public Task_6(string text) : base(text)
        {

        }
        public override string ToString()
        {
            string result = "";
            for (int i = 1; i < SyllableCount.Length; i++)
            {
                if (SyllableCount[i] > 0)
                {
                    result += $"{SyllableCount[i]} слов с {i} слогами\n";
                }
            }
            return result;
        }
        protected override void Text(string text)
        {
            string[] words = text.Split(new char[] { ' ', ',', '.', '!', '?' });
            foreach (string word in words)
            {
                int syllables = CountSyllables(word);
                if (syllables > 0 && syllables < 10)
                {
                    SyllableCount[syllables]++;
                }
            }
        }
        private int CountSyllables(string word)
        {
            int count = 0;
            char[] vowels = { 'а', 'е', 'ё', 'и', 'о', 'у', 'ю', 'я', 'ы', 'э' };
            foreach (char c in word.ToLower())
            {
                if (vowels.Contains(c))
                {
                    count++;
                }
            }
            return count;
        }
    }

    class Task_12 : Task
    {
        private string decodedText;
        public Task_12(string text) : base(text)
        {

        }
        public override string ToString()
        {

            return decodedText;
        }

        protected override void Text(string text)
        {
            decodedText = "";
            string currentWord = "";

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (char.IsLetter(c))
                {
                    currentWord += c; // накапливаем символы слова
                }
                else
                {
                    if (currentWord.Length > 0)
                    {
                        string code = EncodeWord(currentWord); // код для слова
                        decodedText += code + " "; // добавляем код в результат
                        currentWord = ""; // сбрасываем текущее слово
                    }

                    decodedText += c; // Добавляем небуквенный символ
                }
            }
            // Обработка последнего слова
            if (currentWord.Length > 0)
            {
                string code = EncodeWord(currentWord);
                decodedText += code + " ";
            }
        }
        private string EncodeWord(string word)
        {
            // генерация кода слова
            int hashCode = word.GetHashCode();
            return hashCode.ToString();
        }
    }

    class Task_13 : Task //13
    {
        public Task_13(string text) : base(text) { }
        public override string ToString()
        {
            return text;
        }

        protected override void Text(string text)
        {
            string[] words = text.Split(new char[] { ' ', ',', '.', ':', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            int totalWords = words.Length;

            HashSet<char> uniqueStartingLetters = new HashSet<char>(); // хранение уникальных начальных букв

            foreach (string word in words)
            {
                char firstLetter = char.ToUpper(word[0]);
                uniqueStartingLetters.Add(firstLetter);
            }

            Console.WriteLine("Доли слов, начинающихся на разные буквы:");

            foreach (char letter in uniqueStartingLetters)
            {
                int count = 0;
                foreach (string word in words)
                {
                    if (char.ToUpper(word[0]) == letter)
                    {
                        count++;
                    }
                }
                double percentage = (double)count / totalWords * 100;
                Console.WriteLine($"{letter}: {percentage:F2}%");
            }
        }
    }
    class Task_15 : Task //15
    {
        private int sum;
        public Task_15(string text) : base(text) { }
        public override string ToString()
        {
            return sum.ToString();
        }
        protected override void Text(string text)
        {

            sum = 0;
            string currentNumber = "";
            bool inNumber = false;

            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    currentNumber += c;
                    inNumber = true;
                }
                else
                {
                    if (inNumber)
                    {
                        sum += int.Parse(currentNumber);
                        currentNumber = "";
                        inNumber = false;
                    }

                }
            }
            if (inNumber)
            {
                sum += int.Parse(currentNumber);
            }
        }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Task1");
            Task_1 task1 = new Task_1
                ("После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии." +
                " Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность.");

            Console.WriteLine(task1);
            Console.WriteLine();

            Console.WriteLine("Task3");
            Task_3 task2 = new Task_3
                ("После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии." +
                " Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность.");

            Console.WriteLine(task2);
            Console.WriteLine();

            Console.WriteLine("Task6");
            Task_6 task3 = new Task_6
                ("После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии." +
                " Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность.");

            Console.WriteLine(task3);
            Console.WriteLine();

            Console.WriteLine("Task12");
            Task_12 task4 = new Task_12
                ("После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии." +
                " Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность.");

            Console.WriteLine(task4);
            Console.WriteLine();

            Console.WriteLine("Task13");
            Task_13 task5 = new Task_13
                ("После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии." +
                " Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность.");

            Console.WriteLine(task5);
            Console.WriteLine();

            Console.WriteLine("Task15");
            Task_15 task6 = new Task_15
                ("После многолетних исследований 8 ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии." +
                " Анализ  12 данных показал, что основной участник разрушения 7 лесного покрова – человеческая деятельность.");

            Console.WriteLine(task6);
            Console.WriteLine();

        }
    }
}
