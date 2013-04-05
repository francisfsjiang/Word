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
        IList<string> stringlist;
        public AutoComplete()
        {
        }

        public async void readfromfile()
        {
            //StorageFile  = await storageFolder.CreateFileAsync("sample.txt");
            //StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            //StorageFile userfile = await StorageFile.GetFileFromApplicationUriAsync ("ms-appdata:///UserData/UserData.txt");
            //var userfilesteam =await userfile (Windows.Storage.FileAccessMode.Read);
            var folders=await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("UserData");
            StorageFile userdatafile =await folders.GetFileAsync("Dictionary.txt");
            //if(userdatafile!=null)Temp="Accsee";
            //else Temp = "Wrong";
            //userdatafile.
            stringlist = await FileIO.ReadLinesAsync(userdatafile);
            AutoCompleteList adder=new AutoCompleteList();
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
                    adder.add(new userwords(tempword,tempps));
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
                    adder.add(new userwords(tempword,tempps,tempspeech,tempexplain));
                    i++;
                }
                
            }
        }
        //public string getstring()
        //{
        //    return stringlist.First();
        //    /*if(Temp.Length==0)return "Wrong";
        //    else return Temp;*/
        //}
    }
}
