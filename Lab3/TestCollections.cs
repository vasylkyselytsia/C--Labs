using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlab._1;

namespace lab1._2
{
    class TestCollections
    {
        List<Edition> editionList;
        List<string> stringList;
        Dictionary<Edition, Magazine> dict1;
        Dictionary<string, Magazine> dict2;

        public TestCollections(int quantity)
        {
            editionList = new List<Edition>();
            stringList = new List<string>();
            dict1 = new Dictionary<Edition, Magazine>();
            dict2 = new Dictionary<string, Magazine>();

            for (int i = 0; i < quantity; i++)
            {
                Edition e = new Edition();
                e.Title = e.Title + "-" + i;
                editionList.Add(e);
                stringList.Add(e.ToString());

                Magazine m = CollectionsGenerator(i);
                m.EditionProp = e;
                dict1.Add(e, m);
                dict2.Add(e.ToString(), m);
            }
        }
        public static Magazine CollectionsGenerator(int id)
        {
            Magazine m = new Magazine("Title-" + id, Frequency.Monthly, new DateTime(1900, 10, 12), 100 * id);
            return m;
        }

        public Tuple<int, int, int, int> SearchingTime(Edition ed)
        {
            int time, res1, res2, res3, res4;
            time = Environment.TickCount;
            for (int i = 0; i < 100; i++)
                this.editionList.Find(item => item == ed);

            res1 = Environment.TickCount - time;
            string s = ed.ToString();
            time = Environment.TickCount;

            for (int i = 0; i < 100; i++)
                this.stringList.Find(item => item == s);
            res2 = Environment.TickCount - time;


            Magazine value = new Magazine();
            time = Environment.TickCount;
            for (int i = 0; i < 100; i++)
                this.dict1.TryGetValue(ed, out value);
            res3 = Environment.TickCount - time;


            value = new Magazine();
            time = Environment.TickCount;
            for (int i = 0; i < 100; i++)
                this.dict2.TryGetValue(s, out value);
            res4 = Environment.TickCount - time;

            return Tuple.Create(res1, res2, res3, res4);
        }
    }
    }
