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
    public partial class WaterRate : PhoneApplicationPage
    {
        public WaterRate()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            float _TankCapacity = 0.0f;
            float _Area = 0.0f;
            float _result;
            string _resultText = "Could not compute spray rate.";

            if (string.IsNullOrWhiteSpace(tbTankCapacity.Text))
            {
                MessageBox.Show("The tank capacityg is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbArea.Text))
            {
                MessageBox.Show("The area value is required.");
                return;
            }

            if (!float.TryParse(tbTankCapacity.Text, out _TankCapacity))
            {
                MessageBox.Show("The tank capacity could not be converted to a number.\nEnter the value in litres");
                return;
            };

            if (!float.TryParse(tbArea.Text, out _Area))
            {
                MessageBox.Show("The area to be sprayed could not be converted to a number.\nEnter the value in ha");
                return;
            };

            if (_Area <= 0)
            {
                MessageBox.Show("The area to be sprayed must be greater than zero.\nEnter the value in ha");
                return;
            }
            else
            {
                if (_TankCapacity <= 0)
                {
                    MessageBox.Show("The tank size must be greater than zero.\nEnter the value in litres");
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