using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySprayerUtilsLibrary.Sprayer
{
    public class Nozzles
    {
        public int numberOfNozzles = 7;

        public Nozzle[] nozzles = new Nozzle[7];

        private static String[] colours = new String[]{"Green", "Yellow", "Lilac",
            "Blue", "RedBrown", "Red", "Brown"};
        private static String[] codes = new String[]{"015", "02", "025",
            "03", "035", "04", "05"};
        private static double[] flows = new double[]{0.6, 0.8, 1.0,
            1.2, 1.4, 1.6, 2.0};

        /// <summary>
        /// Constructor
        /// </summary>
        public Nozzles()
        {
            for (int i = 0; i < numberOfNozzles; i++)
            {
                nozzles[i] = new Nozzle(colours[i], codes[i], flows[i]);
            }
        }

        /// <summary>
        /// Get an array of colour strings
        /// </summary>
        /// <returns>An array of nozzle colours as strings.</returns>
        public String[] getColours()
        {
            return colours;
        }

        public String getColour(int i)
        {
            return colours[i];
        }

        /// <summary>
        /// Returns the standard pressure that nozzles are tested at.  (i.e. 3.0 bar).
        /// </summary>
        /// <returns>The standard pressure of 3.0 bar</returns>
        public double getStandardPressure()
        {
            return 3.0;
        }

        /// <summary>
        /// Returns the flow rate for an individual nozzle at standard pressure.
        /// </summary>
        /// <param name="code">The nozzle code for required nozzle.</param>
        /// <returns>The flow rate in litres per minuite.</returns>
        public double getStdFlowRate(string code)
        {
            double ans = 0f;
            int count = 0;
            for (int j = 0; j < codes.Length; j++)
            {
                count = j;
                if (code == codes[j].ToString())
                    ans = (double)flows.GetValue(count);
            }
            return ans;
        }
    }
}
