using System;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace FarmPhone_1.Views
{
    public partial class WaterRate : Page
    {
        public WaterRate()
        {
            InitializeComponent();
        }

        private async void CalculateButton_Click(object sender, EventArgs e)
        {
            float _TankCapacity = 0.0f;
            float _Area = 0.0f;
            float _result;
            string _resultText = "Could not compute spray rate.";

            if (string.IsNullOrWhiteSpace(tbTankCapacity.Text))
            {
                //Creating instance for the MessageDialog Class  
                //and passing the message in it's Constructor   
                MessageDialog msgbox = new MessageDialog("The tank capacityg is required..");
                //Calling the Show method of MessageDialog class  
                //which will show the MessageBox 
                await msgbox.ShowAsync();
                
                return;
            }

            if (string.IsNullOrWhiteSpace(tbArea.Text))
            {
                //Creating instance for the MessageDialog Class  
                //and passing the message in it's Constructor   
                MessageDialog msgbox = new MessageDialog("The area value is required.");
                //Calling the Show method of MessageDialog class  
                //which will show the MessageBox 
                await msgbox.ShowAsync();
            
                return;
            }

            if (!float.TryParse(tbTankCapacity.Text, out _TankCapacity))
            {
                //Creating instance for the MessageDialog Class  
                //and passing the message in it's Constructor   
                MessageDialog msgbox = new MessageDialog("The tank capacity could not be converted to a number.\nEnter the value in litres.");
                //Calling the Show method of MessageDialog class  
                //which will show the MessageBox 
                await msgbox.ShowAsync();
               
                return;
            };

            if (!float.TryParse(tbArea.Text, out _Area))
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

      
    }
}