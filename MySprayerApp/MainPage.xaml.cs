using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MySprayerApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /// <summary>
        /// 
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
        }


        private void btnGetSpeed_Click(object sender, RoutedEventArgs e)
        {
          
            Frame.Navigate(typeof(FarmPhone_1.Views.WhatSpeed));
        }

        private async void btnGetWaterRate_Click(object sender, RoutedEventArgs e)
        {
            //Creating instance for the MessageDialog Class  
            //and passing the message in it's Constructor   
           // MessageDialog msgbox = new MessageDialog("You clicked the GetWaterRate button.");
            //Calling the Show method of MessageDialog class  
            //which will show the MessageBox 
          //  await msgbox.ShowAsync();

            Frame.Navigate(typeof(FarmPhone_1.Views.WaterRate));
        }
    }
}
