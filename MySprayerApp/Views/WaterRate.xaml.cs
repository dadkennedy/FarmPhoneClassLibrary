using System;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace FarmPhone_1.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WaterRate : Page
    {
        /// <summary>
        /// 
        /// </summary>
        public WaterRate()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnGetWaterRate_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            float _TankCapacity = 0.0f;
            float _Area = 0.0f;
            float _result;
            string _resultText = "Could not compute spray rate.";

            if (string.IsNullOrWhiteSpace(inputTankCapacity.Text))
            {
                //Creating instance for the MessageDialog Class  
                //and passing the message in it's Constructor   
                MessageDialog msgbox = new MessageDialog("The tank capacityg is required..");
                //Calling the Show method of MessageDialog class  
                //which will show the MessageBox 
                await msgbox.ShowAsync();

                return;
            }

            if (string.IsNullOrWhiteSpace(inputArea.Text))
            {
                //Creating instance for the MessageDialog Class  
                //and passing the message in it's Constructor   
                MessageDialog msgbox = new MessageDialog("The area value is required.");
                //Calling the Show method of MessageDialog class  
                //which will show the MessageBox 
                await msgbox.ShowAsync();

                return;
            }

            if (!float.TryParse(inputTankCapacity.Text, out _TankCapacity))
            {
                //Creating instance for the MessageDialog Class  
                //and passing the message in it's Constructor   
                MessageDialog msgbox = new MessageDialog("The tank capacity could not be converted to a number.\nEnter the value in litres.");
                //Calling the Show method of MessageDialog class  
                //which will show the MessageBox 
                await msgbox.ShowAsync();

                return;
            };

            if (!float.TryParse(inputArea.Text, out _Area))
            {
                //Creating instance for the MessageDialog Class  
                //and passing the message in it's Constructor   
                MessageDialog msgbox = new MessageDialog("The area to be sprayed could not be converted to a number.\nEnter the value in ha.");
                //Calling the Show method of MessageDialog class  
                //which will show the MessageBox 
                await msgbox.ShowAsync();

                return;
            };

            if (_Area <= 0)
            {
                //Creating instance for the MessageDialog Class  
                //and passing the message in it's Constructor   
                MessageDialog msgbox = new MessageDialog("The area to be sprayed must be greater than zero.\nEnter the value in ha.");
                //Calling the Show method of MessageDialog class  
                //which will show the MessageBox 
                await msgbox.ShowAsync();

                return;
            }
            else
            {
                if (_TankCapacity <= 0)
                {
                    //Creating instance for the MessageDialog Class  
                    //and passing the message in it's Constructor   
                    MessageDialog msgbox = new MessageDialog("The tank size must be greater than zero.\nEnter the value in litres.");
                    //Calling the Show method of MessageDialog class  
                    //which will show the MessageBox 
                    await msgbox.ShowAsync();

                    return;
                }
                else
                {
                    _result = _TankCapacity / _Area;
                }
            }
            _resultText = String.Format("The required spray rate is {0:f0} litres/ha.", _result);

            tbkOutputString.Text = _resultText;

        }

        private void btnClearFields_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            inputArea.Text = "";
            tbkOutputString.Text = "";
        }
    }
}