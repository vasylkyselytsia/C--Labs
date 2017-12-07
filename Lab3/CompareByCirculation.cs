using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlab._1;
//тираж
namespace lab1._2
{
    class CompareByCirculation: IComparer<Edition>
    {
        public bool Desc { get; set; }

        public int Compare(Edition ed1, Edition ed2)
        {
            return Desc ? ed2.Circulation.CompareTo(ed1.Circulation) : ed1.Circulation.CompareTo(ed2.Circulation);
        }
    }
}
