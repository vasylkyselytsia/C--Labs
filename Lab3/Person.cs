using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tlab._1
{
    internal class Person : IRateAndCopy
    {
        private string _name;
        private string _surname;
        private DateTime _birthday;
        public double _rating;


        public Person(string name, string surname, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
        }

        public Person()
        {
            Name = "name";
            Surname = "surname";
            Birthday = new DateTime(1, 2, 3);
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        public int Year
        {
            get { return _birthday.Year; }
            set
            {
                DateTime now = new DateTime(value, _birthday.Month, _birthday.Day);
                _birthday = now;
            }
        }

        public double Rating
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("Name: " + Name + "\nsurname: " + _surname + "\nbirthday: " + _birthday.ToShortDateString());
            return str.ToString();
        }

        public string ToShortString()
        {
            return "Name: " + _name + "\nsurname: " + _surname;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            Person p = (Person)obj;
            if (this == p)
                return true;
            return Name.Equals(p.Name) && Surname.Equals(p.Surname) && Birthday.Equals(p.Birthday);
        }

        public static bool operator ==(Person p1, Person p2)
        {
            return p1.Equals(p2);
        }

        public static Boolean operator !=(Person p1, Person p2)
        {
            return !p1.Equals(p2);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Surname.GetHashCode() ^ Birthday.GetHashCode();
            //return new { Name, Surname, Birthday }.GetHashCode();
            //return base.GetHashCode();
        }

        public virtual object DeepCopy()
        {
            object obj = MemberwiseClone();// new Person(FirstName, this.lastName, this.birthDate);
            return obj;
        }

        IRateAndCopy IRateAndCopy.DeepCopy()
        {
            IRateAndCopy other = (IRateAndCopy)MemberwiseClone();
            return other;
        }
    }
}
