using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gMapForNet
{
    /// <summary>
    /// Object to store info of a sample
    /// </summary>
    class Sample
    {
        public DateTime time;
        public double latitude;
        public double longitude;
        public PointLatLng point;
        public double temperature;
        public double pressure;
        public double luminosity;
        public double accX;
        public double accY;
        public double accZ;
        public GMarkerGoogle marker = null;

        public Sample(DateTime t, double lat, double longi, double temp, double pre, 
            double lum, double x, double y, double z)
        {
            this.time = t;
            this.latitude = lat;
            this.longitude = longi;
            this.point = new PointLatLng(lat, longi);
            this.temperature = temp;
            this.pressure = pre;
            this.luminosity = lum;
            this.accX = x;
            this.accY = y;
            this.accZ = z;
        }

        public Sample(double lat, double longi)
        {
            this.latitude = lat;
            this.longitude = longi;
            this.point = new PointLatLng(lat, longi);
        }

        /// <summary>
        /// Maker for problem location
        /// </summary>
        /// <param name="problem">Problem message</param>
        /// <returns></returns>
        public GMarkerGoogle createMarker(string problem)
        {
            this.marker = new GMarkerGoogle(this.point, GMarkerGoogleType.red_small);
            this.marker.ToolTipText = problem;
            return this.marker;
        }

        public double getAccMagnitude()
        {
            return Math.Abs(Math.Sqrt(Math.Pow(accX, 2) + Math.Pow(accY, 2) + Math.Pow(accZ, 2)) - Converter.GaussToAccel(250));
        }
    }
}
