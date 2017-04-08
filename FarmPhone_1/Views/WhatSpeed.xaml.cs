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
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Navigation;

using FarmPhoneClassLibrary.Spraying;

namespace FarmPhone_1.Views
{
    public partial class WhatSpeed : PhoneApplicationPage
    {
        Nozzle _nozzle;
        private string _ReturnedData;

        public WhatSpeed()
        {
            InitializeComponent();            
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            txtOutputSpeed.Text = "The answer goes here!";
        }

        private void appbarbtnClear_Click(object sender, EventArgs e)
        {
            txtInputPressure.Text = "";
            txtInputRate.Text = "";
        }

        private void appbarbtnCalculate_Click(object sender, EventArgs e)
        {
            double _Pressure = 0.0f;
            double _Rate = 0.0f;
            double stdFlowRateOfNozzle = 0f;
            double flowRate = 0f;
            double _result;
            string _resultText = "Could not compute spray rate.";

            if (string.IsNullOrWhiteSpace(txtNozzleCode.Text))
            {
                MessageBox.Show("A nozzle code is required.\nE.G.: 03 or 025 etc..");
                txtNozzleCode.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtInputPressure.Text))
            {
                MessageBox.Show("The spraying pressure is required.");
                txtInputPressure.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtInputRate.Text))
            {
                MessageBox.Show("The required spray rate is required.");
                txtInputRate.Focus();
                return;
            }

            if (!double.TryParse(txtInputPressure.Text, out _Pressure))
            {
                MessageBox.Show("The pressure could not be converted to a number.\nEnter the value in bar.");
                txtInputPressure.Focus();
                return;
            };

            if (!double.TryParse(txtInputRate.Text, out _Rate)) 
            {
                MessageBox.Show("The required spray rate could not be converted to a number.\nEnter the value in litres / ha");
                txtInputRate.Focus();
                return;
            };

            if (_Rate <= 0)
            {
                MessageBox.Show("The spray rate must be greater than zero.\nEnter the value in litres / ha");
                txtInputRate.Focus();
                return;
            }
            else
            {
                if (_Pressure <= 0)
                {
                    MessageBox.Show("The pressure must be greater than zero.\nEnter the value for the required pressure in bar");
                    txtInputPressure.Focus();
                    return;
                }
                else
                {
                    Nozzles _nozzles = new Nozzles();
                    stdFlowRateOfNozzle = _nozzles.getStdFlowRate(txtNozzleCode.Text);
                    flowRate = Spraying.getFlowRate(_Pressure, stdFlowRateOfNozzle);
                    _result = Spraying.getSpeed(_Rate, flowRate , 0.5f) ;
                }
            }
            _resultText = String.Format("The required spraying speed is {0:f1} kph.", _result);
            _resultText = _resultText + String.Format("\nStandard flow rate of the nozzle is {0:f3} l/min.", stdFlowRateOfNozzle);
            _resultText = _resultText + String.Format("\nFlow rate at {0:f1} bar is {1:f3} l/min.",_Pressure, flowRate);
            txtOutputSpeed.Text = _resultText;
            this.Focus();
        }
          
      private int MethodUsed;

      // See: https://social.msdn.microsoft.com/Forums/windowsapps/en-US/89f4cc5b-ee4c-4f0b-85dc-1ffee7abf13d/how-to-pass-data-when-back-navigating-in-silverlight?forum=wphowto

        private void btnSelectNozzle_Click(object sender, RoutedEventArgs e)
        {
           // NavigationService.Navigate(new Uri("/Views/ChooseNozzle.xaml", UriKind.Relative));
           //NavigationService.Navigate(new Uri("/Views/SelectNozzle.xaml", UriKind.Relative));

            MethodUsed = 0;

            // Classic Silverlight page navigation

            NavigationService.Navigate(new Uri("/Views/SelectNozzle.xaml?selectedItem=" + MethodUsed, UriKind.Relative));

            MethodUsed = -1;
        }


        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.SaveState("NozzleCode", txtNozzleCode.Text);
            this.SaveState("InputPressure", txtInputPressure.Text);
            this.SaveState("InputRate", txtInputRate.Text);
        }

        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            try
            {
                txtNozzleCode.Text = this.LoadState<string>("NozzleCode");
                txtInputPressure.Text = this.LoadState<string>("InputPressure");
                txtInputRate.Text = this.LoadState<string>("InputRate");
            }
            catch { }
        }

        

        private void appbarbtnNext_Click(object sender, EventArgs e)
        {
            var focusedElement = FocusManager.GetFocusedElement();
            var focusedTextBox = focusedElement as TextBox;            

            if (focusedTextBox != null)
            {
                switch (focusedTextBox.Name.ToString())
                {
                    case "txtNozzleCode":
                        txtInputPressure.Focus();
                        break;
                    case "txtInputPressure":
                        txtInputRate.Focus();
                        break;                    
                    case "txtInputRate":
                        txtNozzleCode.Focus();
                        break;
                    default:
                        txtNozzleCode.Focus();
                        break;
                }                
            }
            else
            {
                txtNozzleCode.Focus();
            }
        }

        private void appbarbtnPrevious_Click(object sender, EventArgs e)
        {
            var focusedElement = FocusManager.GetFocusedElement();
            var focusedTextBox = focusedElement as TextBox;

            if (focusedTextBox != null)
            {
                switch (focusedTextBox.Name.ToString())
                {
                    case "txtNozzleCode":
                        txtInputRate.Focus();
                        break;
                    case "txtInputPressure":
                        txtNozzleCode.Focus();
                        break;
                    case "txtInputRate":
                        txtInputPressure.Focus();
                        break;
                    default:
                        txtNozzleCode.Focus();
                        break;
                }
            }
            else
            {
                txtNozzleCode.Focus();
            }
        }
    }
}