using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySprayerUniversalLibrary.Spraying
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

        /// <summary>
        /// Return the required speed (in kph) to apply the correct spray rate.
        /// </summary>
        /// <param name="rqdSprayRate">Required spray rate in litres/ha.</param>
        /// <param name="nozzleFlowRate">Nozzle flow rate in litres/min.</param>
        /// <param name="nozzleSpacing">Nozzle spacing along the boom iin meters.</param>
        /// <returns></returns>
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
