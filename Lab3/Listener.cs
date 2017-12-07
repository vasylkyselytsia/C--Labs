using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1._2
{
    class Listener
    {
        private List<ListEntry> changes;

        public Listener()
        {
            changes = new List<ListEntry>();
        }

        public void EventHandler(object source, MagazineListHandlerEventArgs args)
        {
            changes.Add(new ListEntry(args.collectionName, args.changeType, args.indexOfChangedElement));
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ListEntry entry in changes)
            {
                sb.Append("-" + entry.ToString() + "\n");
            }
            return sb.ToString();
        }
    }
}
