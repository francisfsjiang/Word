using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word
{
    class addwordclass
    {
        private static ObservableCollection<userwords> wordslist = new ObservableCollection<userwords>();
        //private userwords AddOne=new userwordsnew userwords("explain", "ɪkˈsplen","vt.& vi. 讲解，解释  vt. 说明…的原因，辩解 vi. 说明，解释，辩解");
        public addwordclass()
        {
        }
        public void add(userwords addone)
        {
            wordslist.Add(addone);
        }
        public void removeat(int Index)
        {
            wordslist.RemoveAt(Index);
        }
        public void edit(int Index,userwords editone)
        {
            wordslist[Index]=editone;
        }
        public userwords elementat(int Index)
        {
            return wordslist[Index];
        }
        public ObservableCollection<userwords> relist()
        {
            return wordslist;
        }
    }
}
