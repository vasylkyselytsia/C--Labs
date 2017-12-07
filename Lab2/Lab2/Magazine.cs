using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab2
{
    class Magazine : Edition, IRateAndCopy, IEnumerable {
        private Frequency frequency;
        private List<Article> articles = new List<Article>();
        private List<Person> editors = new List<Person>();

        public Magazine(String n, Frequency f, DateTime d, int c): base(n, d, c) {
            this.frequency = f;
        }

        public Magazine():this("Forbes", Frequency.Montly, DateTime.Today, 1) {}

        public Frequency getFrequency() {
            return this.frequency;
        }
        public void setFrequency(Frequency f) {
            this.frequency = f;
        }

        public double AvgRating {
            get {
                Double total = 0;
                int length = this.articles.Count;
                if (length == 0) return 0;
                foreach(Article a in this.articles) {
                    total += a.rating;
                }
                return total / length;
            }
        }

        public List<Article> ArticlesList {
            get { return this.articles; }
        }

        public List<Person> EditorsList {
            get { return this.editors; }
        }

        public double Rating => AvgRating;

        public void addArticles(List<Article> new_articles) {
            foreach (Article a in new_articles)
                this.articles.Add(a);
        }

        public void addEditors(List<Person> new_editors) {
            foreach (Person p in new_editors)
                this.editors.Add(p);
        }

        public override String ToString() {
            String res = base.ToString();
            res += $"Frequency={frequency}\nArticles=>\n";
            foreach (Article a in articles)
                res += $"\t{a.ToString()}\n";
            res += "Editors=>\n";
            foreach (Person e in editors)
                res += $"\t{e.ToString()}\n";
            return res;
        }

        object IRateAndCopy.DeepCopy() {
            return (Magazine)this.MemberwiseClone();
        }

        public virtual String ToShortString() {
            String res = base.ToString();
            res += $"Frequency={frequency}\nAverage Rating={AvgRating}\n";
            return res;
        }

        public IEnumerable<Article> ByRating(double rating) {
            foreach (Article a in this.articles) {
                if (a.rating >= rating) yield return a;
            }
        }


        public IEnumerable<Article> ByNameSubstring(string SubString) {
            foreach (Article a in this.articles)  {
                if (a.title.IndexOf(SubString) > -1)
                    yield return a;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new MagazineEnumerator(this);
        }

        private class MagazineEnumerator : IEnumerator {
            private Magazine magazine;
            private int index = -1;

            public MagazineEnumerator(Magazine mag) {
                magazine = (Magazine)mag.DeepCopy();
            }

            public bool IsEditor(Person author) {
                bool res = false;
                foreach (Person p in this.magazine.editors) {
                    if (p.ToShortString() == author.ToShortString() && !res) res = true;
                }
                return res;
            }

            public bool MoveNext() {
                while (++index < magazine.articles.Count && IsEditor(magazine.articles[index].author)) ;
                return index < magazine.articles.Count;
            }
            public object Current {
                get { return magazine.articles[index]; }
            }
            public void Reset() {index = -1;}
        }

        static void Main(string[] args) {
            Magazine m = new Magazine();
            List<Article> articles = new List<Article> { new Article() };
            List<Person> editors = new List<Person> { new Person() };
            m.addArticles(articles);
            m.addEditors(editors);
            Console.WriteLine("Article By Rating => ");
            foreach (var a in m.ByRating(5)) {
                Console.WriteLine(a.ToString() + "\n");
            }

            foreach (var l in m) {
                Console.WriteLine("HERE");
                Console.WriteLine(l.ToString());
            }

            Console.WriteLine("Article By Name Icontains => ");
            foreach (var a in m.ByNameSubstring("Basic")) {
                Console.WriteLine(a.ToString() + "\n");
            }

            Edition e1 = new Edition();
            Edition e2 = new Edition();

            Console.WriteLine(e1 == e2);
            Console.WriteLine(e1.GetHashCode());
            Console.WriteLine(e2.GetHashCode());
            Console.WriteLine("ReferenceEquals(e1, e1) = {0}", Object.ReferenceEquals(e1, e2));

            try {
                m.Circulation = -1;
                Console.WriteLine("Its OK");
            } catch(Exception e) {
                Console.WriteLine("Error Happens {0}", e);
            }

            Console.WriteLine(m.ToShortString());
            Console.WriteLine(m.ToString());

            Magazine m_copy = (Magazine)m.DeepCopy();
            m.Circulation = 5;
            Console.WriteLine(m.ToString());
            Console.WriteLine(m_copy.ToString());
            Console.ReadLine();

        }

    }
}
