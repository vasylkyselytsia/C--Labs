using System;


namespace Lab2 {
    class Edition {
        protected String edition_name;
        protected DateTime release;
        protected int circulation;

        public Edition(String n, DateTime d, int c) {
            this.edition_name = n;
            this.release = d;
            this.circulation = c;
        }

        public int Circulation {
            get { return circulation; }
            set {
                if (value < 0) throw new TypeAccessException("Circulation value must be greater then 0 !");
                circulation = value;
            }
        }

        public Edition():this("Forbes", DateTime.Today, 1) {}

        public String getName() {return this.edition_name;}
        public void setName(String n) {this.edition_name = n;}
        public DateTime getReleaseDate() {return this.release;}
        public void setReleaseDate(DateTime d) {this.release = d;}
        public int getEdition() { return this.circulation;}
        public void setEdition(int c) {this.circulation = c;}

        public Edition DeepCopy() {
            return (Edition)this.MemberwiseClone();
        }

        public override bool Equals(Object obj) {
            if (!(obj is Edition)) return false;

            Edition e = new Edition();
            e = (Edition)obj;
            return edition_name == e.edition_name && circulation == e.circulation && release == e.release;
        }

        public override int GetHashCode() {
            return edition_name.GetHashCode() ^ circulation.GetHashCode() ^ release.GetHashCode();
        }

        public static bool operator ==(Edition e1, Edition e2) {
            if (object.ReferenceEquals(e1, null))
                return object.ReferenceEquals(e2, null);
            return e1.Equals(e2);
        }

        public static bool operator !=(Edition e1, Edition e2) {
            return !(e1 == e2);
        }

        public override String ToString() {
             return $"Edition => \nName={edition_name}\nCirculation={circulation}\nRelease Date={release.ToString("yyyy-MM-dd")}\n";
        }
    }
}
