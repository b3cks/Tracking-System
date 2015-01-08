using GMap.NET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gMapForNet
{
    
    static class IOModule
    {
        private static Random rand = new Random();

        /// <summary>
        /// Generate YAML file
        /// </summary>
        /// <param name="directory">save to directory</param>
        /// <param name="myRoute"></param>
        public static void GenerateFile(string directory, Route myRoute)
        {
            string file = "";
            // metadata
            file += "metadata: " + System.Environment.NewLine;
            file += "    team_number: 28" + System.Environment.NewLine;
            file += "    route: my route" + System.Environment.NewLine;
            file += "    starting: " + myRoute.metadata.starting + System.Environment.NewLine;
            file += "    destination: " + myRoute.metadata.destination + System.Environment.NewLine;
            file += "    comment: standard YAML" + System.Environment.NewLine + System.Environment.NewLine;
            // samples
            file += "samples:" + "\n";
            for (int i = 0; i < myRoute.samples.Count; i++)
            {
                file += "    - time: " + myRoute.samples.ElementAt(i).time.ToString("yyyy-MM-ddTHH:mm:ss") + "\n";
                file += "      longitude: " + myRoute.samples.ElementAt(i).longitude + "\n";
                file += "      latitude: " + myRoute.samples.ElementAt(i).latitude + "\n";
                file += "      temperature: " + myRoute.samples.ElementAt(i).temperature.ToString() + "\n";
                file += "      acceleration: " + "[" + myRoute.samples.ElementAt(i).accX + ", " +
                                                        myRoute.samples.ElementAt(i).accY + ", " +
                                                        myRoute.samples.ElementAt(i).accZ + "]\n";
                file += "      pressure: " + myRoute.samples.ElementAt(i).pressure + "\n";
                file += "      luminosity: " + myRoute.samples.ElementAt(i).luminosity + "\n";
                file += "\n";
            }
            System.IO.File.WriteAllText(directory, file);
        }

        /// <summary>
        /// Parse a file to C# object from team 28 circuit
        /// </summary>
        /// <param name="file">file content</param>
        /// <param name="progressBar">Indicator bar</param>
        /// <returns></returns>
        public static Route ParseFile(string file, ref ProgressBar progressBar)
        {
            file = file.ToLower();
            Match match = Regex.Match(file, @"metadata:([\s\S]+)samples:([\s\S]+$)");
            string meta = match.Groups[1].Value;
            string sample = match.Groups[2].Value;
            // metadata
            string name = "";
            string starting = "";
            string destination = "";
            foreach (var line in meta.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                match = Regex.Match(line, @"[\s\S]*name:\s(.+)");
                if (match.Success)
                {
                    name = match.Groups[1].Value;
                    continue;
                }

                match = Regex.Match(line, @"[\s\S]*departure:\s(.+)");
                if (match.Success)
                {
                    starting = match.Groups[1].Value;
                    continue;
                }

                match = Regex.Match(line, @"[\s\S]*destination:\s(.+)");
                if (match.Success)
                {
                    destination = match.Groups[1].Value;
                    continue;
                }
            }
            if (starting.Length == 0) starting = "Not specified";
            if (destination.Length == 0) destination = "Not specified";
            Metadata data = new Metadata(name, starting, destination);
            // samples
            List<Sample> samples = new List<Sample>();
            DateTime t = System.DateTime.Now;
            double lat = 0;
            double longi = 0;
            double temp = 0;
            double pressure = 0;
            double luminosity = 0;
            double x = 0;
            double y = 0;
            double z = 0;
            Boolean frist = true;
            // int numLines = sample.Split('\n').Length;
            progressBar.Value = 0;
            string[] lines = sample.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            progressBar.Maximum = lines.Length;
            foreach (var line in lines)
            {
                match = Regex.Match(line, @"[\s\S]*time:\s(.+)");
                progressBar.Value += 1;
                if (match.Success)
                {
                    if (frist || longi == 0 || lat == 0)  // not yet collect enough information for the frist smaple
                    {
                        t = DateTime.Parse(match.Groups[1].Value);
                        frist = false;
                    }
                    else       // Add the pervious sample to the list, read the time tag for the next one
                    {
                        samples.Add(new Sample(t, lat, longi, temp, pressure, luminosity, x, y, z));
                        t = DateTime.Parse(match.Groups[1].Value);
                    }
                    continue;
                }

                match = Regex.Match(line, @"[\s\S]*latitude:\s([-]?\d+)\.(\d+)\.(\d+)");
                if (match.Success)
                {
                    lat = Double.Parse(match.Groups[1].Value + "." + match.Groups[2].Value + match.Groups[3].Value);
                    continue;
                }

                match = Regex.Match(line, @"[\s\S]*longitude:\s([-]?\d+)\.(\d+)\.(\d+)");
                if (match.Success)
                {
                    longi = Double.Parse(match.Groups[1].Value + "." + match.Groups[2].Value + match.Groups[3].Value);
                    continue;
                }

                match = Regex.Match(line, @"[\s\S]*latitude:\s(.+)");
                if (match.Success)
                {
                    lat = Double.Parse(match.Groups[1].Value);
                    continue;
                }

                match = Regex.Match(line, @"[\s\S]*longitude:\s(.+)");
                if (match.Success)
                {
                    longi = Double.Parse(match.Groups[1].Value);
                    continue;
                }

                match = Regex.Match(line, @"[\s\S]*temperature:\s(.+)");
                if (match.Success)
                {
                    temp = Converter.VoltToC((int)Double.Parse(match.Groups[1].Value));
                    continue;
                }

                match = Regex.Match(line, @"[\s\S]*acceleration:\s(.+)");
                if (match.Success)
                {
                    string acc = match.Groups[1].Value;
                    match = Regex.Match(acc, @"\[([-]?\d+),\s([-]?\d+),\s([-]?\d+)\]");
                    x = Converter.GaussToAccel((int)Double.Parse(match.Groups[1].Value));
                    y = Converter.GaussToAccel((int)Double.Parse(match.Groups[2].Value));
                    z = Converter.GaussToAccel((int)Double.Parse(match.Groups[3].Value));
                    continue;
                }

                match = Regex.Match(line, @"[\s\S]*pressure:\s(.+)");
                if (match.Success)
                {
                    pressure = Double.Parse(match.Groups[1].Value);
                    continue;
                }

                match = Regex.Match(line, @"[\s\S]*luminosity:\s(.+)");
                if (match.Success)
                {
                    luminosity = Double.Parse(match.Groups[1].Value);
                    continue;
                }
            }
            progressBar.Value = 0;
            // the last sample
            samples.Add(new Sample(t, lat, longi, temp, pressure, luminosity, x, y, z));
            // randomize a color for the route
            Color c = Color.FromArgb(rand.Next(50) * 5, rand.Next(50) * 5, rand.Next(50) * 5);
            return new Route(samples, data, c);
        }

        /// <summary>
        /// Parse the converted data
        /// </summary>
        /// <param name="file"></param>
        /// <param name="progressBar"></param>
        /// <returns></returns>
        public static Route ParseConvertedFile(string file, ref ProgressBar progressBar)
        {
            file = file.ToLower();
            Match match = Regex.Match(file, @"metadata:([\s\S]+)samples:([\s\S]+$)");
            string meta = match.Groups[1].Value;
            string sample = match.Groups[2].Value;
            // metadata
            string name = "";
            string starting = "";
            string destination = "";
            foreach (var line in meta.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                match = Regex.Match(line, @"[\s\S]*name:\s(.+)");
                if (match.Success)
                {
                    name = match.Groups[1].Value;
                    continue;
                }

                match = Regex.Match(line, @"[\s\S]*departure:\s(.+)");
                if (match.Success)
                {
                    starting = match.Groups[1].Value;
                    continue;
                }

                match = Regex.Match(line, @"[\s\S]*destination:\s(.+)");
                if (match.Success)
                {
                    destination = match.Groups[1].Value;
                    continue;
                }
            }
            if (starting.Length == 0) starting = "Not specified";
            if (destination.Length == 0) destination = "Not specified";
            Metadata data = new Metadata(name, starting, destination);
            // samples
            List<Sample> samples = new List<Sample>();
            DateTime t = System.DateTime.Now;
            double lat = 0;
            double longi = 0;
            double temp = 0;
            double pressure = 0;
            double luminosity = 0;
            double x = 0;
            double y = 0;
            double z = 0;
            Boolean frist = true;
            // int numLines = sample.Split('\n').Length;
            progressBar.Value = 0;
            string[] lines = sample.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            progressBar.Maximum = lines.Length;
            foreach (var line in lines)
            {
                match = Regex.Match(line, @"[\s\S]*time:\s(.+)");
                progressBar.Value += 1;
                if (match.Success)
                {
                    if (frist || longi == 0 || lat == 0)  // not yet collect enough information for the frist smaple
                    {
                        t = DateTime.Parse(match.Groups[1].Value);
                        frist = false;
                    }
                    else       // Add the pervious sample to the list, read the time tag for the next one
                    {
                        Console.WriteLine(match.Groups[1].Value);
                        samples.Add(new Sample(t, lat, longi, temp, pressure, luminosity, x, y, z));
                        try
                        {
                            t = DateTime.Parse(match.Groups[1].Value);
                        }
                        catch
                        {
                        }
                    }
                    continue;
                }

                match = Regex.Match(line, @"[\s\S]*latitude:\s(.+)");
                if (match.Success)
                {
                    lat = Double.Parse(match.Groups[1].Value);
                    continue;
                }

                match = Regex.Match(line, @"[\s\S]*longitude:\s(.+)");
                if (match.Success)
                {
                    longi = Double.Parse(match.Groups[1].Value);
                    continue;
                }

                match = Regex.Match(line, @"[\s\S]*temperature:\s(.+)");
                if (match.Success)
                {
                    temp = Double.Parse(match.Groups[1].Value);
                    continue;
                }

                match = Regex.Match(line, @"[\s\S]*acceleration:\s(.+)");
                if (match.Success)
                {
                    string acc = match.Groups[1].Value;

                    Console.WriteLine(match.Groups[1].Value);
                    match = Regex.Match(acc, @"\[([-+]?[0-9]*\.?[0-9]+),\s([-+]?[0-9]*\.?[0-9]+),\s([-+]?[0-9]*\.?[0-9]+)\]");
                    x = Double.Parse(match.Groups[1].Value);
                    y = Double.Parse(match.Groups[2].Value);
                    z = Double.Parse(match.Groups[3].Value);
                    continue;
                }

                match = Regex.Match(line, @"[\s\S]*pressure:\s(.+)");
                if (match.Success)
                {
                    pressure = Double.Parse(match.Groups[1].Value);
                    continue;
                }

                match = Regex.Match(line, @"[\s\S]*luminosity:\s(.+)");
                if (match.Success)
                {
                    luminosity = Double.Parse(match.Groups[1].Value);
                    continue;
                }
            }
            progressBar.Value = 0;
            // the last sample
            samples.Add(new Sample(t, lat, longi, temp, pressure, luminosity, x, y, z));
            // randomize a color for the route
            Color c = Color.FromArgb(rand.Next(50) * 5, rand.Next(50) * 5, rand.Next(50) * 5);
            return new Route(samples, data, c);
        }

        /// <summary>
        /// Write config file
        /// </summary>
        /// <param name="actThres"></param>
        /// <param name="inactTime"></param>
        /// <param name="tapThres"></param>
        /// <param name="tapDuaration"></param>
        /// <param name="confTrack"></param>
        /// <param name="confDebug"></param>
        /// <param name="confHighTemp"></param>
        /// <param name="confWakeOnMovement"></param>
        /// <param name="interpolate"></param>
        /// <param name="settingUp"></param>
        /// <returns></returns>
        public static string WriteConfig(int actThres, int inactTime, int tapThres, int tapDuaration,
            int confTrack, int confDebug, int confHighTemp, int confWakeOnMovement, double interpolate, List<PointLatLng> settingUp)
        {
            string file = "";
            // metadata
            file += "metadata: " + System.Environment.NewLine + "    ";
            file += "configuration_name: config.txt" + System.Environment.NewLine;
            file += "samples: " + System.Environment.NewLine + "    ";
            file += "- accelActThres: " + actThres + System.Environment.NewLine + "    ";
            file += "  accelInactTime: " + inactTime + System.Environment.NewLine + "    ";
            file += "  accelTapThres: " + tapThres + System.Environment.NewLine + "    ";
            file += "  accelTapDuration: " + tapDuaration + System.Environment.NewLine + "    ";
            file += "  confTracking: " + confTrack + System.Environment.NewLine + "    ";
            file += "  confDebug: " + confDebug + System.Environment.NewLine + "    ";
            file += "  confHighTemporalRes: " + confHighTemp + System.Environment.NewLine + "    ";
            file += "  confWakeOnMovement: " + confWakeOnMovement + System.Environment.NewLine + "    ";
            file += "  time: " + DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss") + System.Environment.NewLine;
            file += "route: " + System.Environment.NewLine + "    ";
            if (settingUp.Count != 0)
            {
                file += "- longitude: " + ReFormatCoord(settingUp.ElementAt(0).Lng) + System.Environment.NewLine + "    ";
                file += "  latitude: " + ReFormatCoord(settingUp.ElementAt(0).Lat) + System.Environment.NewLine + "    ";
                for (int i = 0; i < settingUp.Count - 1; i++)
                {
                    double d = Converter.GetDistanceBetweenPoints(settingUp.ElementAt(i).Lat, settingUp.ElementAt(i).Lng,
                        settingUp.ElementAt(i + 1).Lat, settingUp.ElementAt(i + 1).Lng);
                    int n = (int)d / (int)interpolate + 1;
                    double Lat;
                    double Lng;
                    for (int j = 1; j <= n; j++)
                    {
                        Lat = (settingUp.ElementAt(i + 1).Lat * j + settingUp.ElementAt(i).Lat * (n - j)) / n;
                        Lng = (settingUp.ElementAt(i + 1).Lng * j + settingUp.ElementAt(i).Lng * (n - j)) / n;
                        file += "  longitude: " + ReFormatCoord(Lng) + System.Environment.NewLine + "    ";
                        file += "  latitude: " + ReFormatCoord(Lat) + System.Environment.NewLine + "    ";
                    }
                }
                file += "  longitude: " + ReFormatCoord(settingUp.ElementAt(settingUp.Count - 1).Lng) + System.Environment.NewLine + "    ";
                file += "  latitude: " + ReFormatCoord(settingUp.ElementAt(settingUp.Count - 1).Lat);
            }
            return file;
        }

        /// <summary>
        /// Format lat lng to team 28 style
        /// </summary>
        /// <param name="coord"></param>
        /// <returns></returns>
        public static string ReFormatCoord(double coord)
        {
            string format = "";
            int temp = (int)(coord * 1000000);
            format = temp.ToString(@"###\.###\.###");
            return format;
        }

    }
}
