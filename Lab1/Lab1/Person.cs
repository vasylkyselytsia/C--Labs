using System;

namespace Lab1
{
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
            return String.Format("Person: {0}  {1},\n\tBirthDay => {2}" ,first_name , last_name, birthday.ToString("yyyy/MM/dd"));
        }

        public virtual String ToShortString() {
            return this.first_name + " " + this.last_name;
        }

        /*        static void Main(string[] args)
                {
                    Console.WriteLine("Input N and M in format <N**M>");
                    String str = Console.ReadLine();
                    Console.WriteLine(str);
                    String[] res = str.Split(new string[] { "**" }, StringSplitOptions.None);

                    int n = Int32.Parse(res[0]),
                        m = Int32.Parse(res[1]);

                    Console.WriteLine(n.ToString() + m.ToString());
                    Console.Read();
                }*/
    }

}