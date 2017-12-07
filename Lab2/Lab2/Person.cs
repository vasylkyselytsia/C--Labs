using System;

namespace Lab2
{

    interface IRateAndCopy {
        Double Rating { get; }
        Object DeepCopy();
    }

    class Person
    {
        private String first_name;
        private String last_name;
        private DateTime birthday;

        public Person(String f_n, String l_n, DateTime bd) {
            this.first_name = f_n;
            this.last_name = l_n;
            this.birthday = bd;
        }

        public Person() {
            this.first_name = "Vasok";
            this.last_name = "Kiselicya";
            this.birthday = new DateTime(1996, 10, 2);
        }

        public string getFirstName() {return this.first_name;}
        public void setFirstName(String value) {this.first_name = value;}

        public DateTime getBirthday() { return this.birthday; }
        public void setBirthday(DateTime value) { this.birthday = value; }

        public string getLastName() { return this.last_name; }
        public void setLastName(String value) { this.last_name = value; }

        public int Age {
            get { return birthday.Year; }
            set { birthday = new DateTime(value, birthday.Month, birthday.Day); }
        }

        public override String ToString() {
            return String.Format("Person: {0}  {1},\n\tBirthDay => {2}", first_name, last_name, birthday.ToString("yyyy/MM/dd"));
        }

        public virtual String ToShortString() {
            return this.first_name + " " + this.last_name;
        }

        public override bool Equals(Object obj) {
            if (!(obj is Person)) return false;

            Person p = new Person();
            p = (Person)obj;
            return first_name == p.first_name && last_name == p.last_name && birthday == p.birthday;
        }

        public override int GetHashCode() {
            return first_name.GetHashCode() ^ last_name.GetHashCode() ^ birthday.GetHashCode();
        }

        public static bool operator == (Person person1, Person person2) {
            if (object.ReferenceEquals(person1, null))
                return object.ReferenceEquals(person2, null);
            return person1.Equals(person2);
        }

        public static bool operator != (Person person1, Person person2) {
            return !(person1 == person2);
        }

        public Person DeepCopy() {
            return (Person)this.MemberwiseClone();
        }

    }

}