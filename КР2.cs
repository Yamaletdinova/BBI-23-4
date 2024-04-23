namespace ConsoleApp3
{
    abstract class Task
    {
        protected string Text;

        public Task(string text)
        {
            Text = text;
        }

        public abstract double CalculateAverage();

        public override string ToString()
        {
            return UniqueLetters();
        }

        protected abstract string UniqueLetters();
    }

    class Task1 : Task
    {
        public Task1(string text) : base(text) { }

        protected string Text2;

        public override double CalculateAverage()
        {
            string[] words = Text.Split(new char[] { ' ', ',', '.', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            int Length = 0;
            foreach (string word in words)
            {
                Length += word.Length;
            }
            return (double)Length / words.Length;
        }

        protected override string UniqueLetters()
        {
            string[] separators = { " ", ",", ".", ";", ":", "!", "?" };
            string[] words = Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string result = "";

            foreach (string word in words)
            {
                if (word.Length > 1 && HasDifferentLetters(word))
                {
                    result += word + " ";
                }
            }

            return result.Trim();
        }

        private bool HasDifferentLetters(string word)
        {
            for (int i = 0; i < word.Length - 1; i++)
            {
                for (int j = i + 1; j < word.Length; j++)
                {
                    if (char.ToLower(word[i]) == char.ToLower(word[j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }

    class Task2 : Task
    {
        public Task2(string text) : base(text) { }

        public override double CalculateAverage()
        {
            return 0;
        }

        protected override string UniqueLetters()
        {
            return "";
        }
    }

    class Program
    {
        static void Main()
        {

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Folder testFolder = new Folder(Path.Combine(desktopPath, "Test"));


            testFolder.CreateFile("cw2_1.json");
            testFolder.CreateFile("cw2_2.json");


            string text = "Контрольная работа по программированию. Ура!";
            Task[] tasks = { new Task1(text), new Task2(text) };

            Console.WriteLine(tasks[0].CalculateAverage());
            Console.WriteLine(tasks[0]);
        }
    }

    class Folder
    {
        private string path;

        public Folder(string folderPath)
        {
            path = folderPath;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Console.WriteLine($"Папка {path} создана");
            }
        }

        public void CreateFile(string fileName)
        {
            string filePath = Path.Combine(path, fileName);

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
                Console.WriteLine($"Файл {fileName} создан в папке {path}");
            }
            else
            {
                Console.WriteLine($"Файл {fileName} уже существует в папке {path}");
            }
        }
    }
}
