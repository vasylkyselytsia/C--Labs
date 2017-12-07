using System;

namespace Lab1
{
    class Magazine {
        private String name;
        private Frequency frequency;
        private DateTime publication_date;
        private Int16 edition;
        private Article[] articles = new Article[] { new Article() };


        public Magazine(String n, Frequency f, DateTime d, Int16 e) {
            this.name = n;
            this.frequency = f;
            this.publication_date = d;
            this.edition = e;
        }

        public Magazine():this("Forbes", Frequency.Montly, DateTime.Today, 1) {
          /*        
            this.name = "Forbes";
            this.frequency = Frequency.Montly;
            this.publication_date = new DateTime();
            this.edition = 1;
          */
        }

        public String getName() {
            return this.name;
        }

        public void setName(String n) {
            this.name = n;
        }

        public Frequency getFrequency() {
            return this.frequency;
        }
        public void setFrequency(Frequency f) {
            this.frequency = f;
        }
        public DateTime getPublicationDate() {
            return this.publication_date;
        }

        public void setPublicationDate(DateTime d) {
            this.publication_date = d;
        }
        public Int16 getEdition() {
            return this.edition;
        }

        public void setEdition(Int16 e) {
            this.edition = e;
        }
        public Article[] getArticles() {
            return this.articles;
        }

        public void setArticles(Article[] a_s) {
            this.articles = a_s;
        }

        public double AvgRating {
            get {
                Double total = 0;
                int length = this.articles.Length;
                if (length == 0) return 0;
                foreach(Article a in this.articles) {
                    total += a.rating;
                }
                return total / length;
            }
        }

        public void addArticles(Article[] a_s) {
            int articles = this.articles.Length, 
                new_articles = a_s.Length;
            Array.Resize(ref this.articles, articles + new_articles);
            for(int i=0; i < new_articles; i ++) {
                this.articles[articles + i] = a_s[i];
            }
        }

        public bool this[Frequency fr] => fr == frequency;

        public override string ToString() {
            String res = $"Magazine => \nName={name}\nFrequency={frequency}";
            res += $"\nDate of publication={publication_date.ToString("yyyy-MM-dd")}\nEdition={edition.ToString()}";
            res += "\nArticles => ";
            foreach (Article a in this.articles)
                res += $"\n\t{a.ToString()}\n";
            return res;
        }

        public virtual String ToShortString() {
            String res = $"Magazine => \n\tName={name}\n\tFrequency={frequency}";
            res += $"\n\tDate of publication={publication_date.ToString("yyyy-MM-dd")}\n\tEdition={edition.ToString()}";
            res += $"\n\tAverage Rating={AvgRating}";
            return res;
        }

        static void Main(string[] args) {
            Magazine m = new Magazine();
            Console.WriteLine(m.ToShortString());
            Console.WriteLine($"\n{Frequency.Yearly} => {m[Frequency.Yearly]}");
            Console.WriteLine($"{Frequency.Montly} => {m[Frequency.Montly]}");
            Console.WriteLine($"{Frequency.Weekly} => {m[Frequency.Weekly]}\n");
            m.addArticles(new Article[] {
                new Article(new Person("First Name", "Last Name", new DateTime(1990, 1, 15)), "Most Popular", 7.4)
            });
            m.setName("New Name");
            m.setPublicationDate(new DateTime(2017, 1, 1));
            m.setEdition(2);
            m.setFrequency(Frequency.Weekly);
            Console.WriteLine(m.ToString());

            Console.ReadLine();

        }

    }
}
