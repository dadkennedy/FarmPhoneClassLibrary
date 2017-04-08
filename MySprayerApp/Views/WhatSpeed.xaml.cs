using System;
using MySprayerUniversalLibrary.Spraying;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;

namespace FarmPhone_1.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WhatSpeed : Page
    {
      //  Nozzle _nozzle;
      //  private string _ReturnedData;
        /// <summary>
        /// 
        /// </summary>
        public WhatSpeed()
        {
            InitializeComponent();            
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            //txtOutputSpeed.Text = "The answer goes here!";
            Calculate();
        }

        //private void appbarbtnClear_Click(object sender, EventArgs e)
        //{
        //    txtInputPressure.Text = "";
        //    txtInputRate.Text = "";
        //}

        private async void Calculate()
        {
            double _Pressure = 0.0f;
            double _Rate = 0.0f;
            double stdFlowRateOfNozzle = 0f;
            double flowRate = 0f;
            double _result;
            string _resultText = "Could not compute spray rate.";

            if (string.IsNullOrWhiteSpace(txtNozzleCode.Text))
            {
                //Creating instance for the MessageDialog Class  
                //and passing the message in it's Constructor   
                MessageDialog msgbox = new MessageDialog("A nozzle code is required.\nE.G.: 03 or 025 etc..");
                //Calling the Show method of MessageDialog class  
                //which will show the MessageBox 
                await msgbox.ShowAsync();
               // return focus to text box
               // txtNozzleCode.GotFocus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtInputPressure.Text))
            {
                //Creating instance for the MessageDialog Class  
                //and passing the message in it's Constructor   
                MessageDialog msgbox = new MessageDialog("The spraying pressure is required.");
                //Calling the Show method of MessageDialog class  
                //which will show the MessageBox 
                await msgbox.ShowAsync();
               // MessageBox.Show("The spraying pressure is required.");
               // txtInputPressure
                return;
            }

            if (string.IsNullOrWhiteSpace(txtInputRate.Text))
            {
                //Creating instance for the MessageDialog Class  
                //and passing the message in it's Constructor   
                MessageDialog msgbox = new MessageDialog("The required spray rate is required.");
                //Calling the Show method of MessageDialog class  
                //which will show the MessageBox 
                await msgbox.ShowAsync();
                //                txtInputRate.Focus();
                return;
            }

            if (!double.TryParse(txtInputPressure.Text, out _Pressure))
            {
                //Creating instance for the MessageDialog Class  
                //and passing the message in it's Constructor   
                MessageDialog msgbox = new MessageDialog("The pressure could not be converted to a number.\nEnter the value in bar.");
                //Calling the Show method of MessageDialog class  
                //which will show the MessageBox 
                await msgbox.ShowAsync();
                //                txtInputPressure.Focus();
                return;
            };

            if (!double.TryParse(txtInputRate.Text, out _Rate)) 
            {
                //Creating instance for the MessageDialog Class  
                //and passing the message in it's Constructor   
                MessageDialog msgbox = new MessageDialog("The required spray rate could not be converted to a number.\nEnter the value in litres / ha.");
                //Calling the Show method of MessageDialog class  
                //which will show the MessageBox 
                await msgbox.ShowAsync();
                //                txtInputRate.Focus();
                return;
            };

            if (_Rate <= 0)
            {
                //Creating instance for the MessageDialog Class  
                //and passing the message in it's Constructor   
                MessageDialog msgbox = new MessageDialog("The spray rate must be greater than zero.\nEnter the value in litres / ha.");
                //Calling the Show method of MessageDialog class  
                //which will show the MessageBox 
                await msgbox.ShowAsync();
                //                txtInputRate.Focus();
                return;
            }
            else
            {
                if (_Pressure <= 0)
                {
                    //Creating instance for the MessageDialog Class  
                    //and passing the message in it's Constructor   
                    MessageDialog msgbox = new MessageDialog("The pressure must be greater than zero.\nEnter the value for the required pressure in bar.");
                    //Calling the Show method of MessageDialog class  
                    //which will show the MessageBox 
                    await msgbox.ShowAsync();
                    
                   // txtInputPressure.Focus();
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
           // this.Focus();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtOutputSpeed.Text = "";
        }
      //  private int MethodUsed;

      // See: https://social.msdn.microsoft.com/Forums/windowsapps/en-US/89f4cc5b-ee4c-4f0b-85dc-1ffee7abf13d/how-to-pass-data-when-back-navigating-in-silverlight?forum=wphowto

        private async void btnSelectNozzle_Click(object sender, RoutedEventArgs e)
        {
            //Creating instance for the MessageDialog Class  
            //and passing the message in it's Constructor   
            MessageDialog msgbox = new MessageDialog("This function has not yet been implemented.");
            //Calling the Show method of MessageDialog class  
            //which will show the MessageBox 
            await msgbox.ShowAsync();
        }


        //protected override void OnNavigatedFrom(NavigationEventArgs e)
        //{
        //    this.SaveState("NozzleCode", txtNozzleCode.Text);
        //    this.SaveState("InputPressure", txtInputPressure.Text);
        //    this.SaveState("InputRate", txtInputRate.Text);
        //}

        
        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    base.OnNavigatedTo(e);
        //    try
        //    {
        //        txtNozzleCode.Text = this.LoadState<string>("NozzleCode");
        //        txtInputPressure.Text = this.LoadState<string>("InputPressure");
        //        txtInputRate.Text = this.LoadState<string>("InputRate");
        //    }
        //    catch { }
        //}

        

        //private void appbarbtnNext_Click(object sender, EventArgs e)
        //{
        //    var focusedElement = FocusManager.GetFocusedElement();
        //    var focusedTextBox = focusedElement as TextBox;            

        //    if (focusedTextBox != null)
        //    {
        //        switch (focusedTextBox.Name.ToString())
        //        {
        //            case "txtNozzleCode":
        //             //   txtInputPressure.Focus();
        //                break;
        //            case "txtInputPressure":
        //            //    txtInputRate.Focus();
        //                break;                    
        //            case "txtInputRate":
        //           //     txtNozzleCode.Focus();
        //                break;
        //            default:
        //            //    txtNozzleCode.Focus();
        //                break;
        //        }                
        //    }
        //    else
        //    {
        //       // txtNozzleCode.Focus();
        //    }
        //}

        //private void appbarbtnPrevious_Click(object sender, EventArgs e)
        //{
        //    var focusedElement = FocusManager.GetFocusedElement();
        //    var focusedTextBox = focusedElement as TextBox;

        //    if (focusedTextBox != null)
        //    {
        //        switch (focusedTextBox.Name.ToString())
        //        {
        //            case "txtNozzleCode":
        //              //  txtInputRate.Focus();
        //                break;
        //            case "txtInputPressure":
        //            //    txtNozzleCode.Focus();
        //                break;
        //            case "txtInputRate":
        //              //  txtInputPressure.Focus();
        //                break;
        //            default:
        //               // txtNozzleCode.Focus();
        //                break;
        //        }
        //    }
        //    else
        //    {
        //      //  txtNozzleCode.Focus();
        //    }
        //}

       
    }
}