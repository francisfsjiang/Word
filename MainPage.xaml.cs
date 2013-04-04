﻿using System;
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

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace Word
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
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

        public class Customer
        {
            public String FirstName { get; set; }
            public String LastName { get; set; }
            public String Address { get; set; }

            public Customer(String firstName, String lastName, String address)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Address = address;
            }

        }

        public class Customers : ObservableCollection<Customer>
        {
            public Customers()
            {
                Add(new Customer("Michael", "Anderberg",
                        "12 North Third Street, Apartment 45"));
                Add(new Customer("Chris", "Ashton",
                        "34 West Fifth Street, Apartment 67"));
                Add(new Customer("Cassie", "Hicks",
                        "56 East Seventh Street, Apartment 89"));
                Add(new Customer("Guido", "Pica",
                        "78 South Ninth Street, Apartment 10"));
            }

        }


    }
}