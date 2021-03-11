using System;

namespace AppSimples
{
    class Program
    {
        static SeriesRepository repository = new SeriesRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while(userOption.ToUpper() != "S")
            {
                switch(userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSeries();
                        break;
                    case "3":
                        UpdateSeries();
                        break;
                    case "4":
                        DeleteSeries();
                        break;
                    case "5": 
                        ViewSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = GetUserOption();
                Console.ReadLine();
            }
        }

        private static void ViewSeries()
        {
            Console.WriteLine("Enter the ID of the series: ");
            int indexSeries = int.Parse(Console.ReadLine());

            var series = repository.ReturnByID(indexSeries);
            Console.WriteLine(series);
        }

        private static void DeleteSeries()
        {
            Console.WriteLine("Enter the ID of the series: ");
            int indexSeries = int.Parse(Console.ReadLine());

            repository.Delete(indexSeries);
        }

        private static void UpdateSeries()
        {
            Console.WriteLine("Enter the ID of the series: ");
            int indexSeries = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Series)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Series),i));
            }
            Console.Write("Enter the genre between the options above: ");
            int enterGenre = int.Parse(Console.ReadLine());

            Console.Write("Enter the title: ");
            string enterTitle = Console.ReadLine();

            Console.Write("Enter the year of the series: ");
            int enterYear = int.Parse(Console.ReadLine());

            Console.Write("Enter the description: ");
            string enterDescription = Console.ReadLine();

            Series updateSeries = new Series( id: repository.NextID(),
                                            genre: (Genre)enterGenre,
                                            title: enterTitle,
                                            year: enterYear,
                                            description: enterDescription);
        
            repository.Update(indexSeries, updateSeries);

        }

        private static void InsertSeries()
        {
            foreach(int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }

            Console.Write("Enter the genre between the options above: ");
            int enterGenre = int.Parse(Console.ReadLine());

            Console.Write("Enter the title: ");
            string enterTitle = Console.ReadLine();

            Console.Write("Enter the year of the series: ");
            int enterYear = int.Parse(Console.ReadLine());

            Console.Write("Enter the description: ");
            string enterDescription = Console.ReadLine();

            Series newSeries = new Series( id: repository.NextID(),
                                            genre: (Genre)enterGenre,
                                            title: enterTitle,
                                            year: enterYear,
                                            description: enterDescription);

            repository.Insert(newSeries);
        }

        private static void ListSeries()
        {
            Console.WriteLine("List series");
            var list = repository.ListSeries();

            if(list.Count == 0)
            {
                Console.WriteLine("There is no record of series");
                return;
            }
            foreach(var series in list)
            {
                Console.WriteLine("#ID: {0} - {1}", series.returnID(), series.returnTitle());
            }
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Avaliable Series");
            Console.WriteLine("Enter the disered option: ");
            Console.WriteLine("1- Series list");
            Console.WriteLine("2- Insert new series");
            Console.WriteLine("3- Update series");
            Console.WriteLine("4- Delete series");
            Console.WriteLine("5- View series");
            Console.WriteLine("C- Clean screen");
            Console.WriteLine("S- Exit");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
