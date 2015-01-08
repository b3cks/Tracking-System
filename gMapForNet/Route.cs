using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using System.Drawing;

namespace gMapForNet
{
    /// <summary>
    /// Route object to store logging info
    /// </summary>
    class Route
    {
        public Metadata metadata;
        public List<Sample> samples;
        public GMapRoute gMapRoute;
        public Color c;

        public Route(List<Sample> samples, Metadata data, Color c)
        {
            this.samples = samples;
            this.metadata = data;
            this.c = c;
            this.gMapRoute = new GMapRoute(this.getPoints(), this.metadata.name);
            this.gMapRoute.Stroke = new Pen(this.c, 4);
        }

        public List<PointLatLng> getPoints()
        {
            List<PointLatLng> result = new List<PointLatLng>();
            if (this.samples.Count > 0)
            {
                for (int i = 0; i < samples.Count; i++)
                {
                    result.Add(samples.ElementAt(i).point);
                }
            }
            else
            {
                return null;
            }
            return result;
        }

        override public string ToString()
        {
            return this.metadata.name;
        }
    }
}
