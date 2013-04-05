using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word
{
    class AutoCompleteList
    {
        private static ObservableCollection<userwords> autocompletelist = new ObservableCollection<userwords>();
        public AutoCompleteList()
        {
        }
        public void add(userwords addone)
        {
            autocompletelist.Add(addone);
        }
        public void removeat(int Index)
        {
            autocompletelist.RemoveAt(Index);
        }
        public void edit(int Index,userwords editone)
        {
            autocompletelist[Index] = editone;
        }
        public userwords elementat(int Index)
        {
            return autocompletelist[Index];
        }
        public ObservableCollection<userwords> relist()
        {
            return autocompletelist;
        }
        public void clear()
        {
            autocompletelist.Clear();
        }
    }
}
