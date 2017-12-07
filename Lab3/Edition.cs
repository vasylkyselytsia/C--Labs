using System;
using System.Collections.Generic;

namespace Tlab._1
{
    internal class Edition: IComparable, IComparer<Edition>
    {
        protected string _title;
        protected DateTime _release;
        protected int _edition;
        private int _circulation;

        public Edition()
        {
            _title = "no title";
            _release = DateTime.MinValue;
            _edition = 0;
        }

        public Edition(string title, DateTime release, int edition)
        {
            Title = title;
            Release = release;
            EditioN = edition;
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }
        public DateTime Release
        {
            get
            {
                return _release;
            }
            set
            {
                _release = value;
            }
        }
        public int EditioN
        {
            get
            {
                return _edition;
            }
            set
            {
                if (value < 0)
                {
                    ArgumentException argEx = new ArgumentException("\nEdition can not be negative.");
                    throw argEx;
                }
                else
                {
                    _edition = value;
                }
            }
        }

        //public int Edition { get; internal set; }
        public int Circulation
        {
            get
            {
                return _circulation;
            }
            set
            {
                if (value < 0)
                {
                    ArgumentException argEx = new ArgumentException("\nCirculation can not be negative.");
                    throw argEx;
                }
                else
                {
                    _circulation = value;
                }
            }
        }

            //public int EditioN { get; private set; }

            public virtual object DeepCopy()
        {
            object obj = new Edition(this._title, this._release, this._edition);
            return obj;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Edition ob = obj as Edition;
            return ob != null && ob.EditioN == this.EditioN && ob.Title == this.Title && ob.Release == this.Release;
        }

        public static bool operator ==(Edition ed1, Edition ed2)
        {
            if (Object.ReferenceEquals(ed1, ed2))
                return true;
            if ((object)ed1 == null || (object)ed2 == null)
                return false;
            return ed1.Equals(ed2);
        }

        public static bool operator !=(Edition ed1, Edition ed2)
        {
            return !(ed1 == ed2);
        }

        public override string ToString()
        {
            return Title + " " + Release.ToShortDateString() + " " + EditioN + ".\n";
        }
        public int CompareTo(object ob)
        {
            Edition ed = ob as Edition;
            if (String.Compare(this.Title, ed.Title, true) > 0)
                return 1;
            else
                if (String.Compare(this.Title, ed.Title, true) < 0)
                return -1;
            else
                return 0;
        }

        public int Compare(Edition ed1, Edition ed2)
        {

            return ed1.Release.CompareTo(ed2.Release);
        }
    }
}