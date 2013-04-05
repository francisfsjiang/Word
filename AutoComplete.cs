using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.ApplicationModel.Resources.Core;


namespace Word
{
    class  AutoComplete
    {
        private string Temp;
        private static IList<string> stringlist;
        private static ObservableCollection<userwords> completelist = new ObservableCollection<userwords>();
        public AutoComplete()
        {
        }

        public async void readfromfile()
        {
            var folders=await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("UserData");
            StorageFile userdatafile =await folders.GetFileAsync("Dictionary.txt");
            stringlist = await FileIO.ReadLinesAsync(userdatafile);
            string tempword,tempps,tempspeech,tempexplain;
            string breaker="--------";
            for(int i=0;i<stringlist.Count();)
            {
                tempword=stringlist[i];
                tempps=stringlist[i+1];
                if(tempps[0]!='&')
                {
                    i+=2;
                    while(stringlist[i]!=breaker)
                    {
                        tempps+=stringlist[i];
                        i++;
                    }
                    completelist.Add(new userwords(tempword,tempps));
                    i++;
                }
                else
                {
                    i+=2;
                    tempspeech=stringlist[i];
                    i++;
                    tempexplain=stringlist[i];
                    i++;
                    while (stringlist[i] != breaker)
                    {
                        tempexplain += stringlist[i];
                        i++;
                    }
                    completelist.Add(new userwords(tempword,tempps,tempspeech,tempexplain));
                    i++;
                }
            }
        }

        public void complete(string target)
        {
            AutoCompleteList adder=new AutoCompleteList();
            //int point=await int;
            for(int i=0;i<completelist.Count;i++)
            {
                if(compare(target,completelist[i].word))
                {
                    adder.add(completelist[i]);
                }
            }
        }
        private  bool compare(string s1,string s2)
        {
            for(int i=0;i<s1.Length&&i<s2.Length;i++)
            {
                if(s1[i]!=s2[i])return false;
            }
            return true;
        }
        //public string getstring()
        //{
        //    return stringlist.First();
        //    /*if(Temp.Length==0)return "Wrong";
        //    else return Temp;*/
        //}
    }
}
