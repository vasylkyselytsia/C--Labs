using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Tlab._1
{
    class Magazine : Edition, IRateAndCopy
    {

        //private Person[] _editors;
        private List<Person> _editors;
        private List<Article> _articles;

        private string _title;
        private Frequency _shedule;
        private DateTime _release;
        private int _edition;
        //private Article[] _articles;

        public Magazine(string title, Frequency shedule, DateTime release, int edition, Article[] articles)
        {
            this._title = title;
            _shedule = shedule;
            _release = release;
            _edition = edition;
            _editors = new List<Person>();
            _articles = new List<Article>();
            //this._articles = articles;
            //this._editors = editors;
        }

        public Magazine()
        {
            _title = "unknown";
            _shedule = Frequency.Monthly;
            _release = new DateTime(1,1,1);
            _edition = 0;
            _editors = new List<Person>();
            _articles = new List<Article>();
            //_editors = new Person[] { new Person() };
            // _articles = new Article[] { new Article() };
        }

        public Magazine(string title, Frequency shedule, DateTime release, int edition)
        {
            Title = title;
            Shedule = shedule;
            Release = release;
            Edition = edition;
        }

        public List<Article> ArticlesList
        {
            get
            {
                return _articles;
            }
            set
            {
                _articles = value;
            }
        }

        public List<Person> Editors
        {
            get
            {
                return _editors;
            }
            set
            {
                _editors = value;
            }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public Frequency Shedule
        {
            get { return _shedule; }
            set { _shedule = value; }
        }

        public DateTime Release
        {
            get { return _release; }
            set { _release = value; }
        }

        public int Edition
        {
            get { return _edition; }
            set { _edition = value; }
        }

       /* public Article[] Articles
        {
            get { return _articles; }
            set { _articles = value; }
        }

        public Person[] editors
        {
            get { return _editors; }
            set { _editors = value; }
        }

        public double AvgRating
        {
            get { return ArticlesList.Average(x => x.Rating); }
        }*/
        public double Rating
        {
            get
            {
                double sum = 0;
                for (int i = 0; i < ArticlesList.Count; i++)
                    sum += (ArticlesList[i]).Rating;
                if (ArticlesList.Count > 0)
                    return sum / ArticlesList.Count;
                return 0;
            }
        }


        public Article[] Articles { get; internal set; }
        public int EditionProp { get; internal set; }
        public Frequency Rate { get; internal set; }


        /*public double Rating
{
get
{
throw new NotImplementedException();
}
}*/

        public bool this[Frequency shedule]
        {
            get { return Shedule == shedule; }
        }



        /*public void AddArticles(params Article[] articles)
        {
            Article[] act = Articles.Concat(articles).ToArray();
            Articles = act;
        }*/

        public void AddArticles(Article[] articles)
        {
            if (articles.Length != 0)
            {
                foreach (Article a in articles)
                {
                    ArticlesList.Add(a);
                }
            }
        }

        public void AddEditors(Person[] editors)
        {
            if (editors.Length != 0)
            {
                foreach (Person p in editors)
                {
                    Editors.Add(p);
                }
            }
        }

        /* public override string ToString()
         {
             StringBuilder article = new StringBuilder();
             foreach (var item in Articles)
             {
                 article.Append(item.ToString() + "\n");
             }

             return " magasine: " + Title 
                    + "\nfrequency: " + Shedule + " \nrelease: " + Release.ToShortDateString() + " \nedition: " + Edition
                    + "\n\narticles: " + article;
         }

         public virtual string ToShortString()
         {
             return " magasine: " + Title
                    + "\nfrequency: " + Shedule + " \nrelease: " + Release.ToShortDateString() + " \nedition: " + Edition
                    + "\navgRating: " + AvgRating;
         }*/

        public override string ToString()
        {
            var sb = new StringBuilder();

            string str = Title + " " + Shedule + " " + Release.ToString("dd/MM/yyyy") + " " + Edition + ";\n";
            if (ArticlesList.Count == 0)
                str += " No articles\n";
            else
                for (int i = 0; i < ArticlesList.Count; i++)
                {
                    str += (ArticlesList[i]).ToString() + "\n";
                }

            for (int i = 0; i < Editors.Count; i++)
            {
                str += (Editors[i]).ToString() + "\n";
            }
            return str;
        }

        public virtual string ToShortString()
        {
            string str = Title + " " + Shedule + " " + _release.ToString("dd/MM/yyyy") + " " + _edition + " " + Rating + "\n";
            return str;
        }

      
        public static Magazine DeepCopy(Magazine m)
        {
            MemoryStream s = new MemoryStream();
            BinaryFormatter formater = new BinaryFormatter();
            try
            {
                formater.Serialize(s, m);
                s.Position = 0;
                return (Magazine)formater.Deserialize(s);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                s.Close();
            }
        }
        public override object DeepCopy()
        {
            Magazine obj = new Magazine(Title, Shedule, Release, Edition);
            Article[] a = new Article[ArticlesList.Count];
            for (int i = 0; i < ArticlesList.Count; i++)
                a[i] = new Article((ArticlesList[i]).Author, (ArticlesList[i]).Title, (ArticlesList[i]).Rating);

            obj.AddArticles(a);

            Person[] p = new Person[Editors.Count];
            for (int i = 0; i < Editors.Count; i++)
                p[i] = new Person((Editors[i]).Name, (Editors[i]).Surname, (Editors[i]).Birthday);

            obj.AddEditors(p);
            return obj;
        }

        public IEnumerable TopArticles(double minRating)
        {
            for (int i = 0; i < ArticlesList.Count; i++)
            {
                if ((ArticlesList[i]).Rating >= minRating)
                    yield return ArticlesList[i];
            }
        }

        public IEnumerable SimilarArticles(string partOfTitle)
        {
            for (int i = 0; i < ArticlesList.Count; i++)
            {
                if ((ArticlesList[i]).Title.Contains(partOfTitle))
                    yield return ArticlesList[i];
            }
        }

        public IEnumerable ArticlesByEditors()
        {
            for (int i = 0; i < ArticlesList.Count; i++)
            {
                if (Editors.Contains((ArticlesList[i]).Author))
                    yield return ArticlesList[i];
            }
        }

        public IEnumerable EditorsWithoutArticles()
        {
            for (int i = 0; i < Editors.Count; i++)
            {
                bool has = false;
                for (int j = 0; j < ArticlesList.Count; j++)
                {
                    if (((ArticlesList[j]).Author).Equals(Editors[i]))
                        has = true;
                }
                if (!has)
                    yield return Editors[i];
            }
        }

        IRateAndCopy IRateAndCopy.DeepCopy()
        {
            throw new NotImplementedException();
        }
        public static bool Save(string filename, Magazine m)
        {
            BinaryFormatter binFormat = new BinaryFormatter();

            try
            {
                FileStream s = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
                binFormat.Serialize(s, m);
                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            return true;
        }

        public static bool Load(string filename, Magazine m)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            try
            {
                FileStream s = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);
                m = (Magazine)binFormat.Deserialize(s);
                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            return true;
        }
        public bool Save(string filename)
        {
            BinaryFormatter binFormat = new BinaryFormatter();

            try
            {
                FileStream s = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
                binFormat.Serialize(s, this);
                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            return true;
        }

        public bool Load(string filename)
        {
            BinaryFormatter binFormat = new BinaryFormatter();

            try
            {
                FileStream s = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);
                Magazine m = (Magazine)binFormat.Deserialize(s);
                this.Circulation = m.Circulation;
                this.EditionProp = m.EditionProp;
                this.Rate = m.Rate;
                this.Release = m.Release;
                this.Title = m.Title;
                //this.Title = this.Title;
                this.AddArticles(m.ArticlesList.ToArray());
                this.AddEditors(m.Editors.ToArray());

                s.Close();
            }
            catch
            {
                if (filename != "")
                {
                    FileStream s = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite, FileShare.None);//write smth
                    Console.WriteLine("File not found! Created that file.");
                    s.Close();
                }
                return false;
            }
            return true;
        }
        public bool AddFromConsole()
        {
            Console.WriteLine("Type information about an article\n (title, editor(first name, second name, date of birth), article rating (separate information with semicolons - ';' or commas - ','. )):");
            IFormatProvider culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            string inputInfo = Console.ReadLine();
            char[] separators = new char[2];
            separators[1] = ',';
            separators[0] = ';';
            string[] info;
            Person ed = new Person();
            Article ar = new Article();
            try
            {
                info = inputInfo.Split(separators);
                ar.Title = info[0];
                ed.Name = info[1];
                ed.Surname = info[2];
                ed.Birthday = DateTime.Parse(info[3], culture, System.Globalization.DateTimeStyles.AssumeLocal);
                ar.Rating = Int32.Parse(info[4]);
                ar.Author = ed;
                this.ArticlesList.Add(ar);
                //Console.WriteLine("You have entered this:\n{0}, {1}", ar.ToString(), ar.Author.birthDate);
                //this.ToString();
                return true;
            }
            catch
            {
                Console.WriteLine("You have typed in an incorrect data!");

            }
            return false;

        }
    }
}
