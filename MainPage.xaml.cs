using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace Word
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<userwords> wordlist=new ObservableCollection<userwords>();
        public MainPage()
        {
            this.InitializeComponent();
            wordlist.Add(new userwords("explain", "ɪkˈsplen","vt.& vi. 讲解，解释  vt. 说明…的原因，辩解 vi. 说明，解释，辩解"));
            wordlist.Add(new userwords("explain", "ɪkˈsplen", "vt.& vi. 讲解，解释  vt. 说明…的原因，辩解 vi. 说明，解释，辩解"));
            UserWordBox.DataContext=wordlist;
        }

        /// <summary>
        /// 在此页将要在 Frame 中显示时进行调用。
        /// </summary>
        /// <param name="e">描述如何访问此页的事件数据。Parameter
        /// 属性通常用于配置页。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void AddWord(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddPage));
        }

        private void selectd(object sender, SelectionChangedEventArgs e)
        {
            var selectword=UserWordBox.SelectedItems;
            WordDisplay.Text=selectword.;
        }

        //public class userwords : INotifyPropertyChanged
        //{
        //    public event PropertyChangedEventHandler PropertyChanged;
        //    private string Word;
        //    private string Ps;
        //    private string Explain;
        //    public userwords(string word, string ps, string explain)
        //    {
        //        Word = word;
        //        Ps = ps;
        //        Explain = explain;
        //    }
        //    public string word
        //    {
        //        get
        //        {
        //            return Word;
        //        }
        //        set
        //        {
        //            Word = value;
        //            if (PropertyChanged != null)
        //            {
        //                PropertyChanged(this, new PropertyChangedEventArgs(word));
        //            }
        //        }
        //    }
        //}



    }
}
