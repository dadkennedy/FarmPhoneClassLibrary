using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySprayerUtilsLibrary.Sprayer
{
    public static class BCPC
    {
        /// <summary>
        /// The standard pressure at which nozzle reference flow rates are produced at.  Measured in bar.
        /// </summary>
        public const double STANDARDPRESSURE = 3.0f;

        public static string[] Colours = {"Orange", "Green", "Yellow", "Lilac", "Blue",
                                               "Brown-red", "Red", "Brown","Grey", "White",
                                               "Light-blue", "Light-Green", "Black"};
        public static string[] Codes = {"01", "015", "02", "025", "03",
                                             "035", "04", "05", "06", "08",
                                             "10", "15", "20"};
        public static float[] Flows = {0.4f, 0.6f, 0.8f, 1.0f, 1.2f,
                                            1.4f, 1.6f, 2.0f, 2.4f, 3.2f,
                                            4.0f, 6.0f, 8.0f};
    }
}
