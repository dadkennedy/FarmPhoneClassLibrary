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
    public static class Spraying
    {
        /// <summary>
        /// Calculate speed given the time (in seconds) to cover 100m.
        /// </summary>
        /// <param name="time">Time in seconds</param>
        /// <returns>Speed in kph.</returns>
        public static double Speed100inKPH(double time)
        {
            double ans = 0;
            ans = 360.0f / time;
            return ans;
        }

        public static double getSpeed(double rqdSprayRate, double nozzleFlowRate, double nozzleSpacing)
        {
            double ans = 0.0f;
            ans = (nozzleFlowRate * 600f) / (rqdSprayRate * nozzleSpacing);
            return ans;
        }

        public static string getSpeedTxt(double rqdSprayRate, double nozzleFlowRate, double nozzleSpacing)
        {
            double ans = 0.0;
            ans = (nozzleFlowRate * 600f) / (rqdSprayRate * nozzleSpacing);
            return String.Format("Required Speed: {0:d2} kph", ans);
        }


        public static double getFlowRate(double rqdPressure, double stdFlowRate)
        {
            return Math.Sqrt(rqdPressure / BCPC.STANDARDPRESSURE) * stdFlowRate;
        }

        public static double getReferenceApplicationRate(double targetApplicationRate, double specificGravity)
        {
            double correctionFactor = Math.Sqrt((1.0f / specificGravity));
            return targetApplicationRate / correctionFactor;
        }

        public static double getFieldWaterRate(double tankSize, double area)
        {            
            return tankSize / area;
        }
    }
}
