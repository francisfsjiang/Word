using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Word
{
    class addwordclass
    {
        private static ObservableCollection<userwords> wordslist = new ObservableCollection<userwords>();
        private static IList<string> stringlist;
        //private static StorageFile userdatafile;
        public async void readmyfile()
        {
            //var folders = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("UserData");
            //userdatafile = await folders.GetFileAsync("UserWords.txt");
            StorageFolder readfolder=KnownFolders.DocumentsLibrary;
            StorageFile userdatafile=await readfolder.CreateFileAsync("UserData.txt",CreationCollisionOption.OpenIfExists);
            stringlist = await FileIO.ReadLinesAsync(userdatafile);
            string tempword, tempps, tempspeech, tempexplain;
            string breaker = "--------";
            for (int i = 0; i < stringlist.Count()-3;)
            {
                tempword = stringlist[i++];
                tempps = stringlist[i++];
                tempspeech = stringlist[i++];
                tempexplain = stringlist[i++];
                wordslist.Add(new userwords(tempword, tempps, tempspeech, tempexplain));
            }
            //await userdatafile.DeleteAsync();
        }
        public async void savemyfile()
        {
            //var folders = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("UserData");
            //StorageFile savedatafile = await folders.CreateFileAsync("UserWordssss.txt",CreationCollisionOption.ReplaceExisting);
            //StorageFile saver =await folders.GetFileAsync("UserWordssss.txt");
            StorageFolder savefolder =KnownFolders.DocumentsLibrary;
            StorageFile saver= await savefolder.CreateFileAsync("UserData.txt",CreationCollisionOption.OpenIfExists);
            //string tempword, tempps, tempspeech, tempexplain;
            //string breaker = "--------";
            string outer="";
            for(int i=0;i<wordslist.Count(); i++)
            {
                outer+=wordslist[i].word;
                outer+="\r\n";
                outer+=wordslist[i].ps;
                outer += "\r\n";
                outer += wordslist[i].speech;
                outer += "\r\n";
                outer+=wordslist[i].explain;
                outer += "\r\n";
            }
            Windows.Storage.Streams.UnicodeEncoding code=new Windows.Storage.Streams.UnicodeEncoding();
           await  FileIO.WriteTextAsync(saver,outer,code);
            //await  Windows.Storage.FileIO.WriteLinesAsync(userdatafile,stringlist);
            //await FileIO.WriteLinesAsync(userdatafile, stringlist);
        }

        public addwordclass()
        {
        }
        public void add(userwords addone)
        {
            int i;
            for( i=0;i<wordslist.Count();)
            {
                if(addone.word.CompareTo(wordslist[i].word)>0)i++;
                else break;
            }
            if(i<wordslist.Count())wordslist.Insert(i,addone);
            else wordslist.Add(addone);
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
        //private  bool compare(string s1,string s2)
        //{
        //    int i;
        //    for(i=0;i<s1.Length&&i<s2.Length;i++)
        //    {
        //        if(s1[i]<s2[i])return true;
        //    }
        //    if(i==s1.Length)return true;
        //    else return false;
        //}
    }
}
