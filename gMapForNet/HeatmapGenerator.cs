using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gMapForNet
{
    static class HeatmapGenerator
    {
        /// <summary>
        /// For corss thread calling
        /// </summary>
        /// <param name="value"></param>
        private delegate void ChangeProgressBarValue(int value);
        
        /// <summary>
        /// Generate a list of colour weighted marker for heatmap overlay
        /// </summary>
        /// <param name="left">Lng of left</param>
        /// <param name="right">Lng of right</param>
        /// <param name="top">Lat of top</param>
        /// <param name="bottom">Lat of bottom</param>
        /// <param name="points">list of GPS points</param>
        /// <param name="weights">list of weight value</param>
        /// <param name="min">min threshold</param>
        /// <param name="max">max threshold</param>
        /// <param name="progressBar">progress bar indicator</param>
        /// <param name="R">Radius</param>
        /// <param name="forAccel">is for acceleration sensor</param>
        /// <returns></returns>
        static public List<GMarkerGoogle> getMarkers(double left, double right, double top, double bottom, 
            List<PointLatLng> points, List<double> weights, double min, double max, ref ProgressBar progressBar, double R, bool forAccel)
        {
            List<GMarkerGoogle> results = new List<GMarkerGoogle>();
            
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("gMapForNet.red-green6.PNG");
            Bitmap image = new Bitmap(myStream);
            
            double cellWidth = (right - left) / 250;
            double cellHeight = (bottom - top) / 250;
            double[,] gridWeight = new double[250, 250];        // calculated weight
            double[,] gridDensity = new double[250, 250];
            double range = max - min;
            double minDangerRangeBound = min + range / 5.0;     // within 20% of the range
            double maxDangerRangeBound = max - range / 5.0;     // within 80% of the range
            double mapSize = Converter.GetDistanceBetweenPoints(top, left, top, right);
            double radius = mapSize / R;
            double weightest = 0;
            double percent = 0;
            progressBar.Value = 0;
            progressBar.Maximum = 250 + points.Count;

            // improve performance
            for (int k = 0; k < points.Count; k++)
            {
                bool takeIntoAccount;
                if (!forAccel)
                {
                    takeIntoAccount = weights.ElementAt(k) < minDangerRangeBound || weights.ElementAt(k) > maxDangerRangeBound;
                }
                else
                {
                    takeIntoAccount = weights.ElementAt(k) > maxDangerRangeBound;
                }
                if (takeIntoAccount)
                {
                    if (weights.ElementAt(k) > maxDangerRangeBound)
                    {
                        percent = (weights.ElementAt(k) - maxDangerRangeBound) / range / 5.0;
                    }
                    else
                    {
                        percent = (minDangerRangeBound - weights.ElementAt(k)) / range / 5.0;
                    }
                    int x = (int)((points.ElementAt(k).Lng - left) / cellWidth);
                    int y = (int)((points.ElementAt(k).Lat - top) / cellHeight);
                    int z = 250 / (int)R;
                    for (int i = x - z; i <= x + z; i++)
                    {
                        for (int j = y - z; j <= y + z; j++)
                        {
                            if (i > -1 && i < 250 && j > -1 && j < 250)
                            {
                                double centerLng = left + cellWidth * i;
                                double centerLat = top + cellHeight * j;
                                double d = Converter.GetDistanceBetweenPoints(centerLat, centerLng,
                                    points.ElementAt(k).Lat, points.ElementAt(k).Lng);
                                if (d <= radius)
                                {
                                    gridWeight[i, j] += (-1 / radius * d + 1) * percent;
                                    gridDensity[i, j]++;
                                    if (gridWeight[i, j] > weightest) weightest = gridWeight[i, j];
                                }
                            }
                        }
                    }
                }
                progressBar.Value++;
            }

            if (weightest != 0)
            {
                for (int i = 0; i <= 249; i++)
                {
                    for (int j = 0; j <= 249; j++)
                    {
                        int scale = 0;
                        scale = (int)(((gridWeight[i, j]) / (weightest) * 507.0));
                        if (scale > 507 || scale < 0) scale = 507;
                        int redvalue = image.GetPixel(0, 507 - scale).R;
                        int greenvalue = image.GetPixel(0, 507 - scale).G;
                        int bluevalue = image.GetPixel(0, 507 - scale).B;
                        int apha = (int)((scale) / 507.0 * 255);
                        if (apha < 50) apha = 50;
                        double lng = left + cellWidth * i;
                        double lat = top + cellHeight * j;
                        Bitmap dot = new Bitmap(2, 2);
                        using (Graphics gfx = Graphics.FromImage(dot))
                        using (SolidBrush brush = new SolidBrush(Color.FromArgb(apha, redvalue, greenvalue, bluevalue)))
                        {
                            gfx.FillRectangle(brush, 0, 0, 2, 2);
                        }
                        GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(lat, lng),
                            dot, true);
                        results.Add(marker);
                    }
                    progressBar.Value++;
                }
            }
            else
            {

                for (int i = 0; i <= 249; i++)
                {
                    for (int j = 0; j <= 249; j++)
                    {
                        double lng = left + cellWidth * i;
                        double lat = top + cellHeight * j;
                        Bitmap dot = new Bitmap(2, 2);
                        using (Graphics gfx = Graphics.FromImage(dot))
                        using (SolidBrush brush = new SolidBrush(Color.FromArgb(50, 0, 100, 0)))
                        {
                            gfx.FillRectangle(brush, 0, 0, 2, 2);
                        }
                        GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(lat, lng),
                            dot, true);
                        results.Add(marker);
                    }
                    progressBar.Value++;
                }
            }
            progressBar.Value = 0;
            return results;
        }
    }
}
