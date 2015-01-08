using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gMapForNet
{
    static class Converter
    {
        /// <summary>
        /// Gauss to Acceleration m/s2
        /// </summary>
        /// <param name="guass"></param>
        /// <returns></returns>
        static public double GaussToAccel(int guass)
        {
            return (double)guass * 4.0 * Math.Pow(10.0, -3.0) * 9.80665;
        }

        /// <summary>
        /// m/s2 to Gauss
        /// </summary>
        /// <param name="accel"></param>
        /// <returns></returns>
        static public int AccelToGauss(double accel)
        {
            return (int) (accel / (4.0 * Math.Pow(10.0, -3.0) * 9.80665));
        }

        /// <summary>
        /// Volt to C degree
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        static public double VoltToC(int v)
        {
            double rescale = (double)v / 4096.0 * 3.3;
            double A = 0.9116311 - rescale / (3.3 * 1.248716303);
            double Z = 7970.0 * A / (1.0 - A);
            double T = 1.0 / (1.0 / 298.15 + Math.Log(Z / 10000.0) / 3460.0) - 273.15;
            if (T > 60)
            {
                T += -1.19793859 * 0.0001 * Math.Pow(T, 3) + 2.037838014 * 0.01 * Math.Pow(T, 2)
                    - 1.090039295 * T + 20.18016843;
            }
            if (T >= 40 && T <= 60)
            {
                T += 0.7;
            }
            if (T >= -20 && T <= -14)
            {
                T -= 1.1;
            }
            return T;
        }

        /// <summary>
        /// C degree to Volt
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        static public int CToVolt(double c)
        {
            if (c > 60)
            {
                c -= -1.19793859 * 0.0001 * Math.Pow(c, 3) + 2.037838014 * 0.01 * Math.Pow(c, 2)
                    - 1.090039295 * c + 20.18016843;
            }
            if (c >= 40 && c <= 60)
            {
                c -= 0.7;
            }
            if (c >= -20 && c <= -14)
            {
                c += 1.1;
            }
            c = c + 273.15;
            double Z = Math.Pow(Math.E, 3460.0 * (1.0 / c - 1.0 / 298.15)) * 10000.0; // e^(B*(1/T - 1/298.15)
            double A = 0.9116311 - Z/(Z + 7970.0);        
            double V = A*1.248716303;
            int rescale = (int)(V * 4096.0);
            if (rescale < 0 || rescale > 4096)
            {
                return -1;
            }
            else
            {
                return rescale;
            }
        }

        /// <summary>
        /// Get distance between two given GPS points
        /// </summary>
        /// <param name="lat1"></param>
        /// <param name="lng1"></param>
        /// <param name="lat2"></param>
        /// <param name="lng2"></param>
        /// <returns></returns>
        static public double GetDistanceBetweenPoints(double lat1, double lng1,
            double lat2, double lng2)
        {
            double R = 6371;
            double dLat = Converter.DegToRad(lat2 - lat1);
            double dLng = Converter.DegToRad(lng2 - lng1);
            double a = Math.Sin(dLat / 2.0) * Math.Sin(dLat / 2.0) +
                Math.Cos(Converter.DegToRad(lat1)) * Math.Cos(Converter.DegToRad(lat2)) *
                Math.Sin(dLng / 2.0) * Math.Sin(dLng / 2.0);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double d = R * c;
            return d * 1000.0;  //meter
        }

        /// <summary>
        /// Degree -> Radian
        /// </summary>
        /// <param name="deg"></param>
        /// <returns></returns>
        static public double DegToRad(double deg)
        {
            return deg*(Math.PI/180.0);
        }
    }
}
