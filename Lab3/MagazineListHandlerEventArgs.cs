using System.Text;

namespace lab1._2
{
    public class MagazineListHandlerEventArgs
    {
        public string collectionName { get; set; }
        public string changeType { get; set; }
        public int indexOfChangedElement { get; set; }

        public MagazineListHandlerEventArgs(string colName, string chType, int index)
        {
            collectionName = colName;
            changeType = chType;
            indexOfChangedElement = index;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(collectionName);
            sb.Append(changeType);
            sb.Append(indexOfChangedElement);
            return sb.ToString();
        }
    }
}