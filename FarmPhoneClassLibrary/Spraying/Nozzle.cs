using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace FarmPhoneClassLibrary.Spraying
{
    public class Nozzle
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Nozzle() {}
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="code"></param>
        /// <param name="flowRate"></param>
        public Nozzle(string colour, string code, double flowRate)
        {
            this.colour = colour;
            this.code = code;
            this.stdFlowRate = flowRate;
        }

        private string colour;
        /// <summary>
        /// BCP standard colour code for this nozzle.
        /// </summary>
        public string Colour
        {
            get {return colour;}            
        }

        private string code;
        /// <summary>
        /// BCPC code for this nozzle.
        /// </summary>
        public string Code
        {
            get { return colour; }            
        }
        
        private double stdFlowRate;
        /// <summary>
        /// Flow rate in litres per second at standard pressure.
        /// </summary>
        public double FlowRateAtStdPressure
        {
            get { return stdFlowRate; }        
        }




    }
}
