using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlab._1;

namespace lab1._2
{
    class MagazineEnumerator : IEnumerator
    {
        public Magazine _magazine;

        int position = -1;

        public bool MoveNext()
        {
            position++;

            while (position < _magazine.ArticlesList.Count)
            {
                Article a = (Article)_magazine.ArticlesList[position];
                if (_magazine.Editors.Contains(a.Author))
                    position++;
                else
                    return true;
            }
            return false;
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public object Current { get; private set; }
    }
}
