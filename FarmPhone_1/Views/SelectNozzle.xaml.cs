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

namespace FarmPhone_1.Views
{
    public partial class SelectNozzle : PhoneApplicationPage
    {
        private string selectedNozzle = "00";

        public SelectNozzle()
        {
            InitializeComponent();
            //ReturnButton.Click += new RoutedEventHandler(ReturnButton_Click); 
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // return without making a selection
            NavigationService.GoBack();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            // Return the selected nozzle.
            selectedNozzle = "03";
        }

        // Using the ReturnButton to GoBack.
        void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            //PersistReturnDataToIsoStore();
            //NavigationService.GoBack();
        }

        // Back key press from within this child page. Need to have the same effect as pressing the ReturnButton.
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            //PersistReturnDataToIsoStore();
            // Note that we don't set e.Cancel=true, to enable back press to implement page Goback.
            base.OnBackKeyPress(e); // Call base
        }

        /*

         * This HowTo is provided via Microsoft’s Windows Phone 7 Developer Support team.
         * They are intended to serve as a guide in helping developers quickly find out
         * how to do common tasks in their Windows Phone 7 applications.  They are not
         * complete samples and often they are just demonstrating one of what could be
         * many possible approaches to solve a given problem or task.
         * 
         * Developers are free to incorporate any of the suggestions provided within their
         * own code, but please review the following standard sample disclaimer:
         * 
         * © 2011 Microsoft Corporation. All rights reserved. All sample code provided
         * is not supported under any Microsoft standard support program or service. 
         * The samples are provided AS IS without warranty of any kind. Microsoft 
         * disclaims all implied warranties including, without limitation, any implied 
         * warranties of merchantability or of fitness for a particular purpose. The entire
         * risk arising out of the use or performance of the samples and documentation
         * remains with you. In no event shall Microsoft, its authors, or anyone else 
         * involved in the creation, production, or delivery of the samples be liable
         * for any damages whatsoever (including, without limitation, damages for loss of
         * business profits, business interruption, loss of business information, or other
         * pecuniary loss) arising out of the use of or inability to use the samples or
         * documentation, even if Microsoft has been advised of the possibility of such damages.
         * 
         * How To Pass Data when Back Navigating in Silverlight
         * 
         * Sometimes you need to pass data from a child navigation page back to the
         * parent navigation page.
         * 
         * However, the NavigationService offers no way to pass data from a child page back 
         * to the parent page, because the NavigationService.GoBack method does not offer
         * a data passing mechanism.
         * 
         * You can avoid this problem completely by not creating a child Navigation page. 
         * Instead, use a Silverlight Popup control or use a Canvas control that contains
         * two or more overlapping user controls that you can programmatically hide or show.
         * 
         * If you still choose to use the child Navigation page, here is a workaround using
         * use global shared data; specifically, IsolatedStorage.
         * 
         * Assumptions
         * 
         *   

    You have a Silverlight application containing a parent Navigation page and another Navigation page that serves as a child page. The child page accepts text in a Textbox, whose text you need to return to the Silverlight page.

     
    Details

     
     

    1. Include the following namespace references in your navigation pages' code behind:

     

    using System.IO.IsolatedStorage;    // Added for isolated storage

    using System.Xml.Serialization;     // Added for serialization (also need to add this Reference: System.Xml.Serialization)

    using System.IO;                    // Added for stream support

     

    2. Add the following dll reference to your project:

     

    System.Xml.Serialization

     

    3. Add code to act upon the main PhoneApplicationPage click that Navigates to the child PhoneApplicationPage.

     

    void NavigateTest_Click(object sender, RoutedEventArgs e)

    {

        MethodUsed = 0;

        // Classic Silverlight page navigation

        NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + MethodUsed, UriKind.Relative));

        MethodUsed = -1;

    }

     

    4. Add code in the Main page to respond when navigating back to the main page. This code retrieves the return data that has been added to Isolated Storage by the child page.

     

    // When page is navigated to, set data context

    protected override void OnNavigatedTo(NavigationEventArgs e)

    {

        base.OnNavigatedTo(e);

     

        // Obtain desired return data (or any state data for that matter) found in (app-global) isolated storage.

        using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())

        {

            XmlSerializer xs = new XmlSerializer(typeof(string)); // Simple string for this demo.

                   

            if (store.FileExists("MyAppIsoStoreFile"))

            {

                using (StreamReader reader = new StreamReader(store.OpenFile("MyAppIsoStoreFile", FileMode.Open)))

                {

                    ReturnedData.Text = (string)xs.Deserialize(reader); // Show the returned data on the Page.

                }

            }

            else

                ReturnedData.Text = "No return data received yet";

        }

    }

     

    5. The code in your child page code-behind should look similar to this:

     

    namespace WP7PassingDataWhenBackNavigating

    {

        public partial class DetailsPage : PhoneApplicationPage

        {

            // Constructor

            public DetailsPage()

            {

                InitializeComponent();

                ReturnButton.Click += new RoutedEventHandler(ReturnButton_Click);         

            }

     

            // Using the ReturnButton to GoBack.

            void ReturnButton_Click(object sender, RoutedEventArgs e)

            {

                PersistReturnDataToIsoStore();

                NavigationService.GoBack();

            }

   

            // Back key press from within this child page. Need to have the same effect as pressing the ReturnButton.

            protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)

            {

                PersistReturnDataToIsoStore();

                // Note that we don't set e.Cancel=true, to enable back press to implement page Goback.          

                base.OnBackKeyPress(e); // Call base

            }     

            // Save the return data to isolated storage, for later app-global access to it.
            void PersistReturnDataToIsoStore()
            {           
                using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    XmlSerializer xs = new XmlSerializer(typeof(string)); // Simple string for this demo.
                    if (store.FileExists("MyAppIsoStoreFile"))
                    {
                        store.DeleteFile("MyAppIsoStoreFile");
                    }     

                    using (StreamWriter writer = new StreamWriter(store.OpenFile("MyAppIsoStoreFile", FileMode.CreateNew)))
                    {
                        xs.Serialize(writer, ReturnData.Text);
                    }
                }
            }
*/

    }
}