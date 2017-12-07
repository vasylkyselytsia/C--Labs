using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1._2
{
    class ListEntry
    {
        public string ColName { get; set; }
        public string EventType { get; set; }
        int indexOfChangedElement;

        public ListEntry(string collection, string e, int index)
        {
            indexOfChangedElement = index;
            EventType = e;
            ColName = collection;
        }

        public override string ToString()
        {
            StringBuilder strb = new StringBuilder();
            strb.Append(ColName + " ");
            strb.Append(EventType + " ");
            strb.Append(indexOfChangedElement);
            return strb.ToString();
        }
    }
}
