using System;

namespace Lab1
{
    enum Frequency { Weekly, Montly, Yearly };
    class Article {
        public Person author;
        public String title;
        public Double rating;

        public Article(Person p, String t, Double r)
        {
            this.author = p;
            this.title = t;
            this.rating = r;
        }

        public Article()
        {
            this.author = new Person();
            this.title = "Basic Article";
            this.rating = 10.0;
        }

        public override String ToString()
        {
            return String.Format(
                    "Article Info:\n\tAuthor: {0},\n\tTitle: {1},\n\tRating: {2}\n", 
                    author.ToShortString(), 
                    title, 
                    rating.ToString()
                );
        }

    }
}
