using lab1._2;
using System;
using System.Collections.Generic;
using Tlab._1;

namespace Tlab._2
{
    class Program
    {
        static void Main(string[] args)
        {
            //===============================lab1=================================
            /*Magazine magazine = 
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

            Method();
       
            Console.ReadLine();*/

            //================================Lab2=====================
            Edition ed1 = new Edition();
            Edition ed2 = new Edition();
            Console.WriteLine("ed1 equals ed2 {0}\n{1} - reference equals.", ed1.Equals(ed2), Object.ReferenceEquals(ed1, ed2));
            try
            {
                ed1.Edition = -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Circulation can not be negative!\n" + ex.Message);
            }

            Article[] arts3 = new Article[2];
            arts3[0] = new Article(p1, "Title 1", 99.9);
            arts3[1] = new Article();
            Article[] arts4 = new Article[2];
            arts4[0] = new Article(p1, "Title 2", 59.9);
            arts4[1] = new Article(p2, "Title 4", 66.4);
            Person[] edtrs = new Person[3];
            edtrs[0] = new Person("Name1", "LastName1", new DateTime(1966, 10, 10));
            edtrs[1] = new Person("Name2", "LastName2", new DateTime(1982, 12, 31));
            edtrs[2] = new Person();

            Magazine m4 = new Magazine("Magazine 1", Frequency.Monthly, new DateTime(2000, 1, 1), 1000);
            m4.AddEditors(edtrs);
            m4.AddArticles(arts3);
            Console.WriteLine("{0},\n{1}", m4.ToString(), m4.EditionProp);

            var deepCopy = (Magazine)m4.DeepCopy();
            m4.Edition = 2000;
            m4.Release = new DateTime(1999, 12, 12);
            m4.AddArticles(arts4);

            Console.WriteLine("m4:\n{0}\nDeep copy:\n{1}", m4.ToString(), deepCopy.ToString());
            Console.WriteLine("Top articles:");
            foreach (Article m in m4.TopArticles(60))
                Console.WriteLine(m.ToString());
            Console.WriteLine("Similar articles:");
            foreach (Article m in m4.SimilarArticles("title"))
                Console.WriteLine(m.ToString());



            Console.WriteLine("\nMagazineEnumerator:");
            foreach (Article art in m4.ArticlesList)
            {
                Console.WriteLine("{0}", art.ToString());
            }

            Console.WriteLine("\nArticles by editors:");
            foreach (Article art in m4.ArticlesByEditors())
                Console.WriteLine(art.ToString());

            Console.WriteLine("\nEditors without articles:");
            foreach (Person p in m4.EditorsWithoutArticles())
                Console.WriteLine(p.ToString());

            //=====================================lab3=================================
          
            MagazineCollection mc = new MagazineCollection();
            mc.AddDefaults();
            //Console.WriteLine("\nMagazines:");
            //mc.ToString();
            Console.WriteLine("\nBy title:");
            mc.SortByTitle();
            Console.WriteLine(mc.ToString());
            Console.WriteLine("By release date:");
            mc.SortByReleaseDate();
            Console.WriteLine(mc.ToString());
            Console.WriteLine("By circulation:");
            mc.SortByCiculation(true);
            Console.WriteLine(mc.ToString());

            Console.WriteLine(mc.maxAverageRating);
            IEnumerable monthly = mc.GetMonthly;
            foreach (Magazine m in monthly)
                Console.WriteLine(m.ToString());
            double minrate = 70;
            Console.WriteLine("rating more than {0}:", minrate);
            List<Magazine> l = mc.RatingGroup(minrate);
            foreach (Magazine m in l)
                Console.WriteLine(m.ToString());
            int quantity = 1000;
            TestCollections collections = new TestCollections(quantity);
            Edition e1 = new Edition();
            e1.Title = e1.Title + "-0";
            Edition e2 = new Edition();
            e2.Title = e2.Title + "-" + (quantity - 1);
            Edition e3 = new Edition();
            e3.Title = e3.Title + "-" + quantity / 2;
            Edition e4 = new Edition();
            e4.Title = e4.Title + "10";

            /*Console.WriteLine("The first: {0}",collections.SearchingTime(e1));
			Console.WriteLine("The last: {0}", collections.SearchingTime(e2));
			Console.WriteLine("The middle: {0}", collections.SearchingTime(e3));
			Console.WriteLine("Not belongs to list: {0}", collections.SearchingTime(e4));*/
            Console.WriteLine("///////////////////////////Lab 4////////////////////");
      
            //==============================lab4=============================================

            MagazineCollection col1 = new MagazineCollection();
            MagazineCollection col2 = new MagazineCollection();

            Listener l1 = new Listener();
            Listener l2 = new Listener();
            col1.MagazineAdded += l1.EventHandler;
            col1.MagazineReplaced += l1.EventHandler;

            col2.MagazineAdded += l2.EventHandler;
            col2.MagazineReplaced += l2.EventHandler;
            col1.MagazineAdded += l2.EventHandler;
            col1.MagazineReplaced += l2.EventHandler;

            col1.collectionName = "Collection 1";
            col2.collectionName = "Collection 2";

            col1.AddDefaults();
            col2.AddDefaults();
            col2[1] = new Magazine();
            col1[3] = new Magazine();
            col1.Replace(2, new Magazine());
            Console.WriteLine("First listener:\n{0}", l1.ToString());

            Console.WriteLine("Second listener:\n{0}", l2.ToString());


            Console.WriteLine("///////////////////////////Lab 5////////////////////");
          
            //=================================lab5=========================

            Magazine mag1 = new Magazine();

            mag1.AddEditors(edtrs);
            mag1.AddArticles(arts3);
            mag1.Title = "Magazine to save";
            mag1.Circulation = 100500;
            mag1.Rate = Frequency.Monthly;
            Magazine mag1Copy = Magazine.DeepCopy(mag1);
            Console.WriteLine("Original object: {0}", mag1.ToString());
            Console.WriteLine("Deepcopy object: {0}", mag1Copy.ToString());
            Console.WriteLine("Type in a name of the file:");
            string file = Console.ReadLine();
            mag1.Load(file);
            Console.WriteLine(mag1.ToString());
            mag1.AddFromConsole();
            mag1.Save(file);
            Console.WriteLine(mag1.ToString());
            Magazine.Load(file, mag1);
            mag1.AddFromConsole();
            Magazine.Save(file, mag1);
            //mag1.Save("mag1.txt");
            /*Magazine mag2 = new Magazine();
			mag2.Load("mag1.txt");
			
			
			Console.WriteLine("Saved object: {0}", mag1.ToString());
			Console.WriteLine("Object from file: {0}", mag2.ToString());

			Magazine mag3 = new Magazine();
			mag3.AddFromConsole();
			*/

            Console.ReadLine();
        }

    }
    }
}
