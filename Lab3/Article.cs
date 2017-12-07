using System;

namespace Tlab._1
{
    class Article : IRateAndCopy 
    {
        public Person Author { get; set; }

        public string Title { get; set; }
    
        public double Rating { get; set; }

        public Article(Person author, string title, double rating)
        {
            Author = author;
            Title = title;
            Rating = rating;
        }

        public Article():this(new Person(), "Unknown", .0) { }

        public override string ToString()
        {
            return "Author: " + Author + "Title: " + Title + "Rating: " + Rating;
        }

        public virtual object DeepCopy()
        {
            Person author = (Person)this.Author.DeepCopy();
            object obj = new Article(author, this.Title, this.Rating);
            return obj;
        }

        IRateAndCopy IRateAndCopy.DeepCopy()
        {
            throw new NotImplementedException();
        }


    }
}
