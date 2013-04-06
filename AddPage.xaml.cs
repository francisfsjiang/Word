using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Net.Http;
using Windows.Data.Xml.Dom;
using Windows.Storage;
using Windows.Networking.BackgroundTransfer;

// “基本页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234237 上有介绍

namespace Word
{
    /// <summary>
    /// 基本页，提供大多数应用程序通用的特性。
    /// </summary>
    public sealed partial class AddPage : Word.Common.LayoutAwarePage
    {
        //public ObservableCollection<userwords> wordlist = new ObservableCollection<userwords>();
        AutoCompleteList lister = new AutoCompleteList();
        AutoComplete completer = new AutoComplete();
        private HttpClient httpclient=new HttpClient();
        public AddPage()
        {
            
            this.InitializeComponent();
            CompleteBox.DataContext=lister.relist();
            httpclient.MaxResponseContentBufferSize=512*1024;
            httpclient.DefaultRequestHeaders.Add("user-agent","Mozilla");
        }
        

        /// <summary>
        /// 使用在导航过程中传递的内容填充页。在从以前的会话
        /// 重新创建页时，也会提供任何已保存状态。
        /// </summary>
        /// <param name="navigationParameter">最初请求此页时传递给
        /// <see cref="Frame.Navigate(Type, Object)"/> 的参数值。
        /// </param>
        /// <param name="pageState">此页在以前会话期间保留的状态
        /// 字典。首次访问页面时为 null。</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// 保留与此页关联的状态，以防挂起应用程序或
        /// 从导航缓存中放弃此页。值必须符合
        /// <see cref="SuspensionManager.SessionState"/> 的序列化要求。
        /// </summary>
        /// <param name="pageState">要使用可序列化状态填充的空字典。</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }
        
        addwordclass words=new addwordclass();
        private void addword(object sender, RoutedEventArgs e)
        {
            if(AddWordDisplay.Text.Length==0)return ;
            userwords newone = new userwords(AddWordDisplay.Text, AddPsDisplay.Text, AddSpeechDisplay.Text, AddExplainDisplay.Text);
            words.add(newone);
            words.savemyfile();
        }

        
        private void Keyup(object sender, KeyRoutedEventArgs e)
        {
            lister.clear();
            completer.complete(SearchBar.Text);
        }

        private void choseone(object sender, SelectionChangedEventArgs e)
        {
            if(CompleteBox.SelectedItems.Count<1)return ;
                var sel = lister.elementat  (CompleteBox.SelectedIndex);
                AddWordDisplay .Text=sel.word;
                AddPsDisplay.Text = sel.ps;
                AddExplainDisplay.Text = sel.explain;
                AddSpeechDisplay.Text = sel.speech;
        }



        List<DownloadOperation>  activeDownloads = new List<DownloadOperation>();

        
        private async void playps(object sender, RoutedEventArgs e)
        {
            // XML获取
            string address = "http://dict-co.iciba.com/api/dictionary.php?w=";
            address += AddWordDisplay.Text;
            string result;
            if (address.Length == 0) return;
            else
            {
                try
                {
                    HttpResponseMessage response = await httpclient.GetAsync(address);
                    response.EnsureSuccessStatusCode();
                    //AddPsDisplay.Text = response.StatusCode + " " + response.ReasonPhrase;
                    result = await response.Content.ReadAsStringAsync();
                    //AddExplainDisplay.Text = result;
                }
                catch (HttpRequestException hre)
                {
                    AddExplainDisplay.Text = "Error1" + hre.ToString();
                    return;
                }
                catch (Exception ex)
                {
                    AddExplainDisplay.Text = "Error1" + ex.ToString();
                    return;
                }
            }
            //XML解析
            string node;
            if(result.Length!=0)
            {
                try
                {
                    XmlDocument xmler = new XmlDocument();
                    xmler.LoadXml(result);
                    XmlNodeList nodelist;
                    nodelist = xmler.SelectNodes("/dict");
                    node= nodelist[0].SelectSingleNode("pron").InnerText;
                }
                catch
                {
                    return ;
                }
            }
            else return ;
            //AddPsDisplay.Text = node;
            //Download
            StorageFile destination = await KnownFolders.DocumentsLibrary.CreateFileAsync("TempVoice.mp3", CreationCollisionOption.ReplaceExisting);
            if (node.Length != 0)
            {
                try
                {
                    Uri url = new Uri(node.Trim());
                    BackgroundDownloader downloader = new BackgroundDownloader();
                    DownloadOperation load = downloader.CreateDownload(url, destination);
                    await load.StartAsync();
                }
                catch
                {
                    return ;
                }
            }
            else return ;
            //play
            if (destination != null)
            {
                try
                {
                    var stream=await destination.OpenAsync(Windows.Storage.FileAccessMode.Read);
                    outputmedia.SetSource(stream,destination.ContentType);
                    outputmedia.AutoPlay=true;
                }
                catch
                {
                    return ;
                }
            }
            else return ;
        }


    }
}
