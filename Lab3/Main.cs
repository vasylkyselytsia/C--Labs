using System;

namespace Tlab._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Magazine magazine = 
                new Magazine("How to find...", Frequency.Yearly, new DateTime(2016, 11, 12), 1, new Article[] {new Article()});


            Console.WriteLine("Yarly: " + magazine[Frequency.Yearly]);
            Console.WriteLine("Monthly: " + magazine[Frequency.Montly]);
            Console.WriteLine("Weekly: " + magazine[Frequency.Weekly]);

            magazine.Shedule = Frequency.Yearly;
            magazine.Articles = new Article[] {new Article(new Person("Poll", "Tripp", new DateTime(1,1,1)), "Word's war", 6.7)};
            magazine.Edition = 500;
            magazine.Release = DateTime.Now;
            magazine.Title = "Last hope";
            
            Console.WriteLine(magazine);

            Article[] articles = new Article[]
            {
                new Article(new Person("Poll", "Tripp", new DateTime(1,1,1)), "Word's war", 6.7),
                new Article(new Person("Mia", "Ogliche", new DateTime(1,1,1)), "Girl with lovely heart", 4.3),
                new Article(new Person("Stiv", "Nesh", new DateTime(1,1,1)), "Evangelism", 9.1)
           
            };

            magazine.AddArticles(articles);

            Console.WriteLine(magazine);

            TMethod();
       
            Console.ReadLine();

        }


        static void TMethod()
        {
            //ввід налаштувань
            Console.WriteLine("Input row and colomn: (separators ' ', ',', '.')");
            string[] req = Console.ReadLine().Split(',', '.', ' ');
            int nRows = Int32.Parse(req[0]);
            int nColomns = Int32.Parse(req[1]);


            #region 1

            //ініціалізація одновимірного масива
            Person[] arr = new Person[nRows * nColomns];

            int time = Environment.TickCount;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Person();
            }
            Console.WriteLine("1-demension array's time: " + (Environment.TickCount - time));

            #endregion

            #region 2
            //ініціалізація двовимірного масива

            Person[,] matrix = new Person[nRows, nColomns];

            time = Environment.TickCount;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = new Person();
                }
            }
            Console.WriteLine("2-demension array's time: " + (Environment.TickCount - time));

            #endregion

            #region 3
            //зубчатий масив

            Person[][] juggedMatrix = new Person[nRows][];
            for (int i = 0; i < nRows; i++)
            {
                juggedMatrix[i] = new Person[nColomns];
            }

            time = Environment.TickCount;
            for (int i = 0; i < juggedMatrix.Length; i++)
            {
                for (int j = 0; j < juggedMatrix[i].Length; j++)
                {
                    juggedMatrix[i][j] = new Person();
                }
            }
            Console.WriteLine("Jugged array's time: " + (Environment.TickCount - time));

            #endregion
        }
    }
}
