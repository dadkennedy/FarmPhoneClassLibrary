using System;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media.Imaging;

// See http://developer.nokia.com/community/wiki/How_to_use_Pop-Ups_in_Windows_Phone
// for explination about pop=ups

namespace FarmPhone_1.Views
{
    public partial class PopupTest : Page
    {

        Windows.UI.Xaml.Controls.Primitives.Popup my_popup_cs = new Popup();

        public PopupTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // Show pop-up from xaml
            if (my_popup_cs.IsOpen && !my_popup_xaml.IsOpen)
            {
                my_popup_cs.IsOpen = false;
                my_popup_xaml.IsOpen = true;
            }
            else
            {
                my_popup_xaml.IsOpen = true;
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            // Show pop-up from .cs code
            if (my_popup_xaml.IsOpen && !my_popup_cs.IsOpen)
            {
                my_popup_xaml.IsOpen = false;
                display_cspopup();
            }
            else
            {
                display_cspopup();
            }
        }

        private void btn_continue_Click(object sender, RoutedEventArgs e)
        {
            if (my_popup_xaml.IsOpen)
            {
                my_popup_xaml.IsOpen = false;
            }

            else if (my_popup_cs.IsOpen)
            {
                my_popup_cs.IsOpen = false;
            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            if (my_popup_xaml.IsOpen)
            {
                my_popup_xaml.IsOpen = false;
            }

            else if (my_popup_cs.IsOpen)
            {
                my_popup_cs.IsOpen = false;
            }
        }


        public void display_cspopup()
        {
            Border border = new Border();
            border.BorderBrush = new SolidColorBrush(Colors.Green);
            border.BorderThickness = new Thickness(2);
            border.Margin = new Thickness(10, 10, 10, 10);

            StackPanel skt_pnl_outter = new StackPanel();
            skt_pnl_outter.Background = new SolidColorBrush(Colors.LightGray);
            skt_pnl_outter.Orientation = Windows.UI.Xaml.Controls.Orientation.Vertical;

            Image img_disclaimer = new Image();
            img_disclaimer.HorizontalAlignment = HorizontalAlignment.Center;
            img_disclaimer.Stretch = Stretch.Fill;
            img_disclaimer.Margin = new Thickness(0, 15, 0, 5);
            Uri uriR = new Uri("Images/disclaimer.png", UriKind.Relative);
            BitmapImage imgSourceR = new BitmapImage(uriR);
            img_disclaimer.Source = imgSourceR;
            skt_pnl_outter.Children.Add(img_disclaimer);

            TextBlock txt_blk1 = new TextBlock();
            txt_blk1.Text = "Disclaimer";
            txt_blk1.TextAlignment = TextAlignment.Center;
            txt_blk1.FontSize = 40;
            txt_blk1.Margin = new Thickness(10, 0, 10, 0);
            txt_blk1.Foreground = new SolidColorBrush(Colors.White);

            TextBlock txt_blk2 = new TextBlock();
            txt_blk2.Text = "This is a pop-up window to display disclaimer";
            txt_blk2.TextAlignment = TextAlignment.Center;
            txt_blk2.FontSize = 21;
            txt_blk2.Margin = new Thickness(10, 0, 10, 0);
            txt_blk2.Foreground = new SolidColorBrush(Colors.White);


            skt_pnl_outter.Children.Add(txt_blk1);
            skt_pnl_outter.Children.Add(txt_blk2);

            StackPanel skt_pnl_inner = new StackPanel();
            skt_pnl_inner.Orientation = Orientation.Horizontal;

            Button btn_continue = new Button();
            btn_continue.Content = "continue";
            btn_continue.Width = 215;
            btn_continue.Click += new RoutedEventHandler(btn_continue_Click);

            Button btn_cancel = new Button();
            btn_cancel.Content = "cancel";
            btn_cancel.Width = 215;
            btn_cancel.Click += new RoutedEventHandler(btn_cancel_Click);

            skt_pnl_inner.Children.Add(btn_continue);
            skt_pnl_inner.Children.Add(btn_cancel);


            skt_pnl_outter.Children.Add(skt_pnl_inner);

            border.Child = skt_pnl_outter;
            my_popup_cs.Child = border;

            my_popup_cs.VerticalOffset = 400;
            my_popup_cs.HorizontalOffset = 10;

            my_popup_cs.IsOpen = true;
        }

        //protected override void OnBackKeyPress(CancelEventArgs e)
        //{
        //    if (this.my_popup_cs.IsOpen)
        //    {
        //        my_popup_cs.IsOpen = false;
        //        e.Cancel = true;
        //    }
        //    else if (this.my_popup_xaml.IsOpen)
        //    {
        //        my_popup_xaml.IsOpen = false;
        //        e.Cancel = true;
        //    }

        //}
    }
}