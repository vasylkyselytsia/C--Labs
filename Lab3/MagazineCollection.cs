using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlab._1;

namespace lab1._2
{
    class MagazineCollection
    {
        private List<Magazine> _magazines;
        public string collectionName { get; set; }

        public delegate void MagazineListHandler(object source, MagazineListHandlerEventArgs args);
        public event MagazineListHandler MagazineAdded;
        public event MagazineListHandler MagazineReplaced;


        public Magazine this[int index]
        {
            get
            {
                if (index < _magazines.Count && index > -1)
                    return _magazines[index];
                return null;
            }
            set
            {
                Replace(index, value);
            }
        }

        public MagazineCollection()
        {
            this._magazines = new List<Magazine>();
        }

        public bool Replace(int j, Magazine magazine)
        {
            if (j < _magazines.Count && j >= 0)
            {
                _magazines[j] = magazine;
                if (MagazineReplaced != null)
                    MagazineReplaced(this, new MagazineListHandlerEventArgs(collectionName, "replaced", j));
                return true;
            }
            return false;
        }

        public double maxAverageRating
        {
            get
            {
                if (_magazines.Count != 0)
                    return _magazines.Max(m => m.Rating);
                return 0;
            }
        }

        public IEnumerable<Magazine> GetMonthly
        {
            get
            {
                var magazines = from m in _magazines
                           where m.Rate == Frequency.Monthly
                           select m;
                return magazines;
            }
        }

        public List<Magazine> RatingGroup(double value)
        {
            //var mags = from m in _magazines
            //		   where m.Rating >= value
            //		   group m by m.Rating into g
            //		   ToList();
            var mags = _magazines
                       .Where(m => m.Rating >= value)
                       //.GroupBy(m => m.Rate)
                       //.SelectMany(m => m)
                       .ToList();

            return mags;
        }

        public void AddDefaults()
        {
            Person p1 = new Person("First", "Stone", new DateTime(1880, 12, 02));
            Person p2 = new Person("Mia", "Humlight", new DateTime(1930, 7, 25));
            Person p3 = new Person("Toma", "Faithful", new DateTime(1945, 2, 27));

            Article[] arts1 = new Article[2];
            arts1[0] = new Article(new Person(), "Title ", 89);
            arts1[1] = new Article(new Person(), "Title 0", 100);
            Article[] arts2 = new Article[2];
            arts2[0] = new Article(p1, "Title 1", 99.9);
            arts2[1] = new Article(p2, "Title 2", 78);
            Article[] arts3 = new Article[2];
            arts3[0] = new Article(p2, "Title 3", 99.9);
            arts3[1] = new Article(p3, "Title 4", 56.9);
            Article[] arts4 = new Article[2];
            arts4[0] = new Article(p1, "Title 5", 76.1);
            arts4[1] = new Article(p2, "Title 6", 66.4);
            Magazine m1 = new Magazine("Some title", Frequency.Weekly, new DateTime(1950, 1, 1), 1200);
            Magazine m2 = new Magazine("Magazine", Frequency.Yearly, new DateTime(1990, 5, 4), 200);
            Magazine m3 = new Magazine("Some other magazine", Frequency.Monthly, new DateTime(2010, 11, 20), 5000);
            Magazine m4 = new Magazine();

            m1.AddArticles(arts3);
            m2.AddArticles(arts2);
            m3.AddArticles(arts4);
            m4.AddArticles(arts1);

            AddToList(m1);
            AddToList(m2);
            AddToList(m3);
            AddToList(m4);
        }

        void AddToList(Magazine m)
        {
            _magazines.Add(m);
            if (MagazineAdded != null)
                MagazineAdded(this, new MagazineListHandlerEventArgs(collectionName, "added", _magazines.Count - 1));
        }

        public void AddMagazines(Magazine[] magazines)
        {
            for (int i = 0; i < magazines.Length; i++)
            {
                AddToList(magazines[i]);
            }
        }

        public List<Magazine> SortByTitle()
        {
            this._magazines.Sort();
            return this._magazines;
        }

        public List<Magazine> SortByReleaseDate()
        {
            Edition c = new Edition();
            this._magazines.Sort(c);

            return this._magazines;
        }

        public void SortByCiculation(bool desc)
        {
            CompareByCirculation CirculationComparer = new CompareByCirculation(); //параметр сортування
            CirculationComparer.Desc = desc;
            this._magazines.Sort(new CompareByCirculation());
         
        }

        public override string ToString()
        {
            StringBuilder magString = new StringBuilder();
            for (int i = 0; i < this._magazines.Count; i++)
            {
                magString.Append(_magazines[i].ToString());
            }
         
            return (magString.ToString());
        }

        public virtual string ToShortString()
        {
            StringBuilder magString = new StringBuilder();
            for (int i = 0; i < this._magazines.Count; i++)
            {
                magString.Append(_magazines[i].ToShortString());
            }
            return magString.ToString();
        }
    }
}
