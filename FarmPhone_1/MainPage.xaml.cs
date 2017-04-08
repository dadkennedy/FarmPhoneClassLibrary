using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using FarmPhoneClassLibrary.Spraying;

namespace FarmPhone_1
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnGetWaterRate_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/WaterRate.xaml", UriKind.Relative));            
        }

        private void btnGetSpeed_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/WhatSpeed.xaml", UriKind.Relative));
        }
    }
}