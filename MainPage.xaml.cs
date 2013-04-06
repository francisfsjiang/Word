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
        addwordclass wordlist=new addwordclass();
        AutoComplete filereader = new AutoComplete();
        //filereader.readfromfile();
        //wordlist.readmyfile();
        public MainPage()
        {
            this.InitializeComponent();
            //wordlist.add(new userwords("explain", "ɪkˈsplen","vt.& vi. 讲解，解释  vt. 说明…的原因，辩解 vi. 说明，解释，辩解"));
            //wordlist.add(new userwords("explain", "ɪkˈsplen", "vt.& vi. 讲解，解释  vt. 说明…的原因，辩解 vi. 说明，解释，辩解"));
            UserWordBox.DataContext=wordlist.relist();
            
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

        private void DeleteWord(object sender, RoutedEventArgs e)
        {
            if(UserWordBox.SelectedItems.Count<1)return ;
            for(int i=UserWordBox.SelectedItems.Count-1;i>=0;i--)
                wordlist.removeat(UserWordBox.SelectedIndex);
        }

        private void selectd(object sender, SelectionChangedEventArgs e)
        {
            WordDisplay.DataContext = "True";
            PsDisplay.DataContext = "True";
            ExplainDisplay.DataContext = "True";
            SpeechDisplay.DataContext="True";
            if(UserWordBox.SelectedItems.Count<1)return ;
                var sel=wordlist.elementat(UserWordBox.SelectedIndex);
                WordDisplay.Text=sel.word;
                PsDisplay.Text=sel.ps;
                ExplainDisplay.Text=sel.explain;
                SpeechDisplay.Text = sel.speech;
        }

        

        private void EditClick(object sender, RoutedEventArgs e)
        {
            WordDisplay.DataContext = "False";
            PsDisplay.DataContext = "False";
            ExplainDisplay.DataContext = "False";
            SpeechDisplay.DataContext="False";
        }

        public ListViewSelectionMode SelectionMode { get; set; }
        private void LotsChecked(object sender, RoutedEventArgs e)
        {
            
            UserWordBox.SelectionMode = SelectionMode + 2;
            
        }

        private void LotsUnChecked(object sender, RoutedEventArgs e)
        {
            UserWordBox.SelectionMode = SelectionMode+1;
        }

        private void savechange(object sender, RoutedEventArgs e)
        {
            if (UserWordBox.SelectedItems.Count < 1) return;
            userwords edit = new userwords(WordDisplay.Text, PsDisplay.Text, SpeechDisplay.Text, ExplainDisplay.Text);
            wordlist.edit(UserWordBox.SelectedIndex,edit);
            wordlist.savemyfile();
        }

        //public RelativeSource

    }
}
