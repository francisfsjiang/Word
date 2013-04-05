using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word
{
    public class userwords : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string Word;
        private string Speech;
        private string Ps;
        private string Explain;

        public userwords(string word, string ps, string speech, string explain)
        {
            Word = word;
            Ps = ps;
            Explain = explain;
            Speech=speech;
        }
        public userwords(string word, string explain)
        {
            Word = word;
            Ps = " ";
            Explain = explain;
            Speech=" ";
        }
        public string word
        {
            get
            {
                return Word;
            }
            set
            {
                Word = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(word));
                }
            }
        }
        public string ps
        {
            get
            {
                return Ps;
            }
            set
            {
                Ps = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(ps));
                }
            }
        }
        public string explain
        {
            get
            {
                return Explain;
            }
            set
            {
                Explain = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(explain));
                }
            }
        }
        public string speech
        {
            get
            {
                return Speech;
            }
            set
            {
                Speech = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(speech));
                }
            }
        }
    }
}
