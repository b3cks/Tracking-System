using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using System.IO;
using ZedGraph;
using Renci.SshNet;
using Renci.SshNet.Common;
using System.Threading;

namespace gMapForNet
{
    public partial class Form1 : Form
    {
        public Random rand = new Random();
        List<Route> Routes = new List<Route>();
        // whether route set up in process
        Boolean beingSetUp = false;
        // list of GSP points used to muanally set up a route
        List<PointLatLng> settingUp = new List<PointLatLng>();
        // use to draw the route being set up on the map
        GMapRoute gMapSetUp;
        // Route for setup config file by auto get route
        Route myRoute;

        string privateKeyFilePath = "";
        string localDirectory = "";
        
        //icon bitmaps
        Bitmap colourScheme = null;
        Bitmap TempRed = null;
        Bitmap TempGreen = null;
        Bitmap PresRed = null;
        Bitmap PresGreen = null;
        Bitmap LumRed = null;
        Bitmap LumGreen = null;
        Bitmap AccRed = null;
        Bitmap AccGreen = null;

        public Form1()
        {
            InitializeComponent();
            this.routesOverlay = new GMapOverlay("Routes");
            this.markersOverlay = new GMapOverlay("Markers");
            this.heatmapOverlay = new GMapOverlay("Heatmap");
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; //disable editing
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList; //disable editing
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList; //disable editing
            passText.PasswordChar = '*';
            // WriteToConsole(Converter.VoltToC(3945).ToString());
            // load icons
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("gMapForNet.red-green6.PNG");
            colourScheme = new Bitmap(myStream);
            pictureBox1.Image = colourScheme;
            myStream = myAssembly.GetManifestResourceStream("gMapForNet.newTempGreen.jpg");
            TempGreen = new Bitmap(myStream);
            pictureTemp.Image = TempGreen;
            myStream = myAssembly.GetManifestResourceStream("gMapForNet.newTempRed.jpg");
            TempRed = new Bitmap(myStream);
            myStream = myAssembly.GetManifestResourceStream("gMapForNet.newPreGreen.jpg");
            PresGreen = new Bitmap(myStream);
            picturePre.Image = PresGreen;
            myStream = myAssembly.GetManifestResourceStream("gMapForNet.newPreRed.jpg");
            PresRed = new Bitmap(myStream);
            myStream = myAssembly.GetManifestResourceStream("gMapForNet.newLumGreen.jpg");
            LumGreen = new Bitmap(myStream);
            pictureLum.Image = LumGreen;
            myStream = myAssembly.GetManifestResourceStream("gMapForNet.newLumRed.jpg");
            LumRed = new Bitmap(myStream);
            myStream = myAssembly.GetManifestResourceStream("gMapForNet.newAccGreen.jpg");
            AccGreen = new Bitmap(myStream);
            pictureAccel.Image = AccGreen;
            myStream = myAssembly.GetManifestResourceStream("gMapForNet.newAccRed.jpg");
            AccRed = new Bitmap(myStream);
        }
        
        private void gMap_Load(object sender, EventArgs e)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMap.Position = new PointLatLng(-27.4957097372797, 153.009338378906);
            gMap.Zoom = 15;
            WriteToConsole("Welcome, happy demo day!");
            gMap.ShowCenter = false;
            gMap.Overlays.Add(routesOverlay);
            gMap.Overlays.Add(markersOverlay);
            gMap.Overlays.Add(heatmapOverlay);
        }

        /// <summary>
        /// Clear heatmap when change current map view
        /// </summary>
        private void gMap_MouseDrag()
        {
            heatmapOverlay.Markers.Clear();
        }

        /// <summary>
        /// Clear heatmap when change current map view
        /// </summary>
        private void gMap_ZoomChange()
        {
            heatmapOverlay.Markers.Clear();
        }

        /// <summary>
        /// Select way points
        /// </summary>
        private void gMap_LeftMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (beingSetUp)
                {
                    double lat = gMap.FromLocalToLatLng(e.X, e.Y).Lat;
                    double lng = gMap.FromLocalToLatLng(e.X, e.Y).Lng;
                    routesOverlay.Routes.Remove(gMapSetUp);
                    settingUp.Add(new PointLatLng(lat, lng));
                    gMapSetUp = new GMapRoute(settingUp, "Manual Setting");
                    routesOverlay.Routes.Add(gMapSetUp);
                }
            }
        }

        /// <summary>
        /// Start manual setting
        /// </summary>
        private void setUpRoute_Click(object sender, EventArgs e)
        {
            if (beingSetUp)
            {
                Form2 inputForm = new Form2(settingUp, this);
                inputForm.Show();
                beingSetUp = false;
                setUpRoute.Text = "Start Munual Set Up";
                this.Enabled = false;
            }
            else
            {
                settingUp.Clear();
                beingSetUp = true;
                setUpRoute.Text = "Done";
                routesOverlay.Routes.Remove(gMapSetUp);
                gMapSetUp = new GMapRoute(settingUp, "Manual Setting");
                routesOverlay.Routes.Add(gMapSetUp);
            }
        }

        /// <summary>
        /// get center location
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetLocation_Click(object sender, EventArgs e)
        {
            double Lat = gMap.Position.Lat;
            double Lng = gMap.Position.Lng;
            WriteToConsole("Lat: " + Lat.ToString());
            WriteToConsole("Lng: " + Lng.ToString());
        }

        /// <summary>
        /// auto get route
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void get_route_Click(object sender, EventArgs e)
        {
            try
            {
                string start = textStart.Text;
                string end = textEnd.Text;
                MapRoute route = GMap.NET.MapProviders.GoogleMapProvider.Instance.GetRoute(start, end, false, false, 15);
                Color c = Color.FromArgb(rand.Next(50)*5, rand.Next(50)*5,rand.Next(50)*5);
                List<double> Temp = new List<double>();
                List<Sample> samples = new List<Sample>();
                for (int i = 0; i < route.Points.Count; i++)
                {
                    samples.Add(new Sample(route.Points.ElementAt(i).Lat, route.Points.ElementAt(i).Lng));
                }
                myRoute = new Route(samples, new Metadata("my route", textStart.Text, textEnd.Text), c);
                AddToList(myRoute);
                routesOverlay.Routes.Add(myRoute.gMapRoute);
            }
            catch (Exception exp)
            {
                WriteToConsole(exp.Message);
            }
        }

        /// <summary>
        /// write config from auto route
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void writeConfig_Click(object sender, EventArgs e)
        {
            if (myRoute != null)
            {
                Form2 inputForm = new Form2(myRoute.getPoints(), this);
                inputForm.Show();
                this.Enabled = false;
            }
            else
            {
                WriteToConsole("Get a route before writing a config");
            }
        }

        /// <summary>
        /// Write a standard YAML
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void writeFile_Click(object sender, EventArgs e)
        {
            try
            {
                Route selectedRoute = (Route)listView.SelectedItems[0].Tag;
                DialogResult result = saveFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    IOModule.GenerateFile(saveFileDialog1.FileName, selectedRoute);
                    WriteToConsole("Generated");
                }
            }
            catch
            {
                WriteToConsole("Please select a Route in the list to generate");
            }
        }

        /// <summary>
        /// Import a file to GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void parseFile_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string line;
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    line = sr.ReadToEnd();
                }
                Route newRoute = null;
                try
                {
                    newRoute = IOModule.ParseFile(line, ref progressBar1);
                }
                catch
                {
                    WriteToConsole("Wrong format file");
                }
                if (newRoute != null)
                {
                    Routes.Add(newRoute);
                    AddToList(newRoute);
                    routesOverlay.Routes.Add(newRoute.gMapRoute);
                    gMap.ZoomAndCenterRoute(newRoute.gMapRoute);
                }
            }
        }

        /// <summary>
        /// Add a route to list view
        /// </summary>
        /// <param name="myRoute"></param>
        private void AddToList(Route myRoute)
        {
            ListViewItem item = new ListViewItem(myRoute.metadata.starting);
            item.SubItems.Add(myRoute.metadata.destination);
            item.BackColor = myRoute.c;
            item.Tag = myRoute;
            listView.Items.Add(item);
        }

        /// <summary>
        /// For cross thread calling
        /// </summary>
        /// <param name="str">String to write</param>
        private delegate void WriteDelegate(string str);
        
        /// <summary>
        /// Write to GUI system message box
        /// </summary>
        /// <param name="str">String to write</param>
        private void WriteToConsole(string str)
        {
            richTextBox1.Text += str + "\n";
            richTextBox1.Select(richTextBox1.Text.Length - 1, richTextBox1.Text.Length - 1);
            richTextBox1.ScrollToCaret();
        }

        /// <summary>
        /// Clear route in list view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listView.SelectedItems)
            {
                listView.Items.Remove(eachItem);
                Route selectedRoute = (Route)eachItem.Tag;
                for (int i = 0; i < selectedRoute.samples.Count; i++)
                {
                    if (selectedRoute.samples.ElementAt(i).marker != null)
                    {
                        markersOverlay.Markers.Remove(selectedRoute.samples.ElementAt(i).marker);
                    }
                }
                routesOverlay.Routes.Remove(selectedRoute.gMapRoute);
            }
        }

        /// <summary>
        /// Graph display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showGraphButton_Click(object sender, EventArgs e)
        {
            zedGraphControl1.IsEnableVZoom = false;
            zedGraphControl1.IsEnableVPan = false;
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            GraphPane myPane = zedGraphControl1.GraphPane;
            PointPairList list = new PointPairList();
            Route selectedRoute = null;
            try
            {
                selectedRoute = (Route)listView.SelectedItems[0].Tag;
                try
                {
                    if (comboBox1.Text.Equals("Temperature"))
                    {
                        myPane.Title.Text = "Temperature";
                        myPane.XAxis.Title.Text = "Samples";
                        myPane.XAxis.Scale.Min = 1;
                        myPane.YAxis.Title.Text = "°C";
                        for (int i = 0; i < selectedRoute.samples.Count; i++)
                        {
                            list.Add(i + 1, selectedRoute.samples.ElementAt(i).temperature);
                        }
                        LineItem curve = myPane.AddCurve("temperature", list, Color.Green, SymbolType.Circle);
                        curve.Line.Width = 0.5F;
                        curve.Symbol.Fill = new Fill(Color.Red);
                        curve.Symbol.Size = 5;
                    }
                    if (comboBox1.Text.Equals("Luminosity"))
                    {
                        myPane.Title.Text = "Luminosity";
                        myPane.XAxis.Title.Text = "Samples";
                        myPane.XAxis.Scale.Min = 1;
                        myPane.YAxis.Title.Text = "Lux";
                        for (int i = 0; i < selectedRoute.samples.Count; i++)
                        {
                            list.Add(i + 1, selectedRoute.samples.ElementAt(i).luminosity);
                        }
                        LineItem curve = myPane.AddCurve("Luminosity", list, Color.Green, SymbolType.Circle);
                        curve.Line.Width = 0.5F;
                        curve.Symbol.Fill = new Fill(Color.Red);
                        curve.Symbol.Size = 5;
                    }
                    if (comboBox1.Text.Equals("Pressure"))
                    {
                        myPane.Title.Text = "Pressure";
                        myPane.XAxis.Title.Text = "Samples";
                        myPane.XAxis.Scale.Min = 1;
                        myPane.YAxis.Title.Text = "Pa";
                        for (int i = 0; i < selectedRoute.samples.Count; i++)
                        {
                            list.Add(i + 1, selectedRoute.samples.ElementAt(i).pressure);
                        }
                        LineItem curve = myPane.AddCurve("Pressure", list, Color.Green, SymbolType.Circle);
                        curve.Line.Width = 0.5F;
                        curve.Symbol.Fill = new Fill(Color.Red);
                        curve.Symbol.Size = 5;
                    }
                    if (comboBox1.Text.Equals("Acceleration"))
                    {
                        myPane.Title.Text = "Acceleration";
                        myPane.XAxis.Title.Text = "Samples";
                        myPane.XAxis.Scale.Min = 1;
                        myPane.YAxis.Title.Text = "m/s²";
                        for (int i = 0; i < selectedRoute.samples.Count; i++)
                        {
                            list.Add(i + 1, selectedRoute.samples.ElementAt(i).getAccMagnitude());
                        }
                        LineItem curve = myPane.AddCurve("Acceleration", list, Color.Green, SymbolType.Circle);
                        curve.Line.Width = 0.5F;
                        curve.Symbol.Fill = new Fill(Color.Red);
                        curve.Symbol.Size = 5;
                    }
                    if (comboBox1.Text.Equals("Velocity"))
                    {
                        myPane.Title.Text = "Velocity";
                        myPane.XAxis.Title.Text = "Minute";
                        myPane.XAxis.Scale.Min = 1;
                        myPane.YAxis.Title.Text = "Km/h";
                        double lat1;
                        double lat2;
                        double lng1;
                        double lng2;
                        double d = 0;
                        int count = 0;
                        for (int i = 0; i < selectedRoute.samples.Count - 1; i++)
                        {
                            lat1 = selectedRoute.samples.ElementAt(i).latitude;
                            lat2 = selectedRoute.samples.ElementAt(i + 1).latitude;
                            lng1 = selectedRoute.samples.ElementAt(i).longitude;
                            lng2 = selectedRoute.samples.ElementAt(i + 1).longitude;
                            d += Converter.GetDistanceBetweenPoints(lat1, lng1, lat2, lng2);
                            count++;
                            if (count == 59)
                            {
                                list.Add(i/60, d / 1000.0 * 60.0);
                                count = 0;
                                d = 0;
                            }
                        }
                        LineItem curve = myPane.AddCurve("Velocity", list, Color.Green, SymbolType.Circle);
                        curve.Line.Width = 0.5F;
                        curve.Symbol.Fill = new Fill(Color.Red);
                        curve.Symbol.Size = 5;
                    }
                    myPane.XAxis.Scale.BaseTic = 1;
                    myPane.Chart.Fill = new Fill(Color.Black, Color.Navy, 45.0F);
                    zedGraphControl1.AxisChange();
                    Refresh();
                    string information = "";
                    information += selectedRoute.metadata.ToString();
                    information += "Number of samples: " + selectedRoute.samples.Count.ToString() + "\n";
                    TimeSpan duration = selectedRoute.samples.ElementAt(selectedRoute.samples.Count - 1).time.Subtract(selectedRoute.samples.ElementAt(0).time);
                    information += "Log duration: " + duration.ToString();
                    infoText.Text = information;
                }
                catch
                {
                    WriteToConsole("Threshold value is not in correct format");
                }
            }
            catch
            {
                WriteToConsole("Please select a Route in the list");
            }
            
        }

        /// <summary>
        /// Graph display with threshold lines
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void applyButton_Click(object sender, EventArgs e)
        {
            zedGraphControl1.IsEnableVZoom = false;
            zedGraphControl1.IsEnableVPan = false;
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            GraphPane myPane = zedGraphControl1.GraphPane;
            PointPairList list = new PointPairList();
            Route selectedRoute = null;
            try
            {
                selectedRoute = (Route)listView.SelectedItems[0].Tag;
            }
            catch
            {
                WriteToConsole("Please select a Route in the list");
            }
            try
            {
                if (comboBox1.Text.Equals("Temperature"))
                {
                    myPane.Title.Text = "Temperature";
                    myPane.XAxis.Title.Text = "Samples";
                    myPane.XAxis.Scale.Min = 1;
                    myPane.YAxis.Title.Text = "°C";
                    for (int i = 0; i < selectedRoute.samples.Count; i++)
                    {
                        list.Add(i + 1, selectedRoute.samples.ElementAt(i).temperature);
                    }
                    LineItem curve = myPane.AddCurve("temperature", list, Color.Green, SymbolType.Circle);
                    curve.Line.Width = 0.5F;
                    curve.Symbol.Fill = new Fill(Color.Red);
                    curve.Symbol.Size = 5;
                    PointPairList pair1 = new PointPairList();
                    pair1.Add(1, Double.Parse(maxTemp.Text));
                    pair1.Add(selectedRoute.samples.Count, Double.Parse(maxTemp.Text));
                    LineItem line1 = myPane.AddCurve("MaxTemp", pair1, Color.Red, SymbolType.Circle);
                    line1.Line.Width = 0.5F;
                    line1.Symbol.Fill = new Fill(Color.Red);
                    line1.Symbol.Size = 0;
                    PointPairList pair2 = new PointPairList();
                    pair2.Add(1, Double.Parse(minTemp.Text));
                    pair2.Add(selectedRoute.samples.Count, Double.Parse(minTemp.Text));
                    LineItem line2 = myPane.AddCurve("MinTemp", pair2, Color.Red, SymbolType.Circle);
                    line2.Line.Width = 0.5F;
                    line2.Symbol.Fill = new Fill(Color.Red);
                    line2.Symbol.Size = 0;
                }
                if (comboBox1.Text.Equals("Luminosity"))
                {
                    myPane.Title.Text = "Luminosity";
                    myPane.XAxis.Title.Text = "Samples";
                    myPane.XAxis.Scale.Min = 1;
                    myPane.YAxis.Title.Text = "Lux";
                    for (int i = 0; i < selectedRoute.samples.Count; i++)
                    {
                        list.Add(i + 1, selectedRoute.samples.ElementAt(i).luminosity);
                    }
                    LineItem curve = myPane.AddCurve("Luminosity", list, Color.Green, SymbolType.Circle);
                    curve.Line.Width = 0.5F;
                    curve.Symbol.Fill = new Fill(Color.Red);
                    curve.Symbol.Size = 5;
                    PointPairList pair1 = new PointPairList();
                    pair1.Add(1, Double.Parse(maxLum.Text));
                    pair1.Add(selectedRoute.samples.Count, Double.Parse(maxLum.Text));
                    LineItem line1 = myPane.AddCurve("MaxLum", pair1, Color.Red, SymbolType.Circle);
                    line1.Line.Width = 0.5F;
                    line1.Symbol.Fill = new Fill(Color.Red);
                    line1.Symbol.Size = 0;
                    PointPairList pair2 = new PointPairList();
                    pair2.Add(1, Double.Parse(minLum.Text));
                    pair2.Add(selectedRoute.samples.Count, Double.Parse(minLum.Text));
                    LineItem line2 = myPane.AddCurve("MinLum", pair2, Color.Red, SymbolType.Circle);
                    line2.Line.Width = 0.5F;
                    line2.Symbol.Fill = new Fill(Color.Red);
                    line2.Symbol.Size = 0;
                }
                if (comboBox1.Text.Equals("Pressure"))
                {
                    myPane.Title.Text = "Pressure";
                    myPane.XAxis.Title.Text = "Samples";
                    myPane.XAxis.Scale.Min = 1;
                    myPane.YAxis.Title.Text = "Pa";
                    for (int i = 0; i < selectedRoute.samples.Count; i++)
                    {
                        list.Add(i + 1, selectedRoute.samples.ElementAt(i).pressure);
                    }
                    LineItem curve = myPane.AddCurve("Pressure", list, Color.Green, SymbolType.Circle);
                    curve.Line.Width = 0.5F;
                    curve.Symbol.Fill = new Fill(Color.Red);
                    curve.Symbol.Size = 5;
                    PointPairList pair1 = new PointPairList();
                    pair1.Add(1, Double.Parse(maxPre.Text) * 1000);
                    pair1.Add(selectedRoute.samples.Count, Double.Parse(maxPre.Text) * 1000);
                    LineItem line1 = myPane.AddCurve("Max Pressure", pair1, Color.Red, SymbolType.Circle);
                    line1.Line.Width = 0.5F;
                    line1.Symbol.Fill = new Fill(Color.Red);
                    line1.Symbol.Size = 0;
                    PointPairList pair2 = new PointPairList();
                    pair2.Add(1, Double.Parse(minPre.Text) * 1000);
                    pair2.Add(selectedRoute.samples.Count, Double.Parse(minPre.Text) * 1000);
                    LineItem line2 = myPane.AddCurve("Min Pressure", pair2, Color.Red, SymbolType.Circle);
                    line2.Line.Width = 0.5F;
                    line2.Symbol.Fill = new Fill(Color.Red);
                    line2.Symbol.Size = 0;
                }
                if (comboBox1.Text.Equals("Acceleration"))
                {
                    myPane.Title.Text = "Acceleration";
                    myPane.XAxis.Title.Text = "Samples";
                    myPane.XAxis.Scale.Min = 1;
                    myPane.YAxis.Title.Text = "m/s²";
                    for (int i = 0; i < selectedRoute.samples.Count; i++)
                    {
                        list.Add(i + 1, selectedRoute.samples.ElementAt(i).getAccMagnitude());
                    }
                    LineItem curve = myPane.AddCurve("Acceleration", list, Color.Green, SymbolType.Circle);
                    curve.Line.Width = 0.5F;
                    curve.Symbol.Fill = new Fill(Color.Red);
                    curve.Symbol.Size = 5;
                    PointPairList pair1 = new PointPairList();
                    pair1.Add(1, Double.Parse(maxAccel.Text));
                    pair1.Add(selectedRoute.samples.Count, Double.Parse(maxAccel.Text));
                    LineItem line1 = myPane.AddCurve("Max Acceleration", pair1, Color.Red, SymbolType.Circle);
                    line1.Line.Width = 0.5F;
                    line1.Symbol.Fill = new Fill(Color.Red);
                    line1.Symbol.Size = 0;
                }
                myPane.XAxis.Scale.BaseTic = 1;
                myPane.Chart.Fill = new Fill(Color.Black, Color.Navy, 45.0F);
                zedGraphControl1.AxisChange();
                Refresh();
                string information = "";
                information += selectedRoute.metadata.ToString();
                information += "Number of samples: " + selectedRoute.samples.Count.ToString() + "\n";
                TimeSpan duration = selectedRoute.samples.ElementAt(selectedRoute.samples.Count - 1).time.Subtract(selectedRoute.samples.ElementAt(0).time);
                information += "Log duration: " + duration.ToString();
                infoText.Text = information;
            }
            catch
            {
                WriteToConsole("Check you input format");
            }
        }

        /// <summary>
        /// Check status of single route
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkButton_Click(object sender, EventArgs e)
        {
            markersOverlay.Markers.Clear();
            double max = 0;
            double min = 0;
            foreach (ListViewItem eachItem in listView.SelectedItems)
            {
                Route selectedRoute = (Route)eachItem.Tag;
                max = Double.Parse(maxTemp.Text);
                min = Double.Parse(minTemp.Text);
                pictureTemp.Image = TempGreen;
                for (int i = 0; i < selectedRoute.samples.Count; i++)
                {
                    if (selectedRoute.samples.ElementAt(i).temperature > max || selectedRoute.samples.ElementAt(i).temperature < min)
                    {
                        pictureTemp.Image = TempRed;
                        break;
                    }
                }

                max = Double.Parse(maxPre.Text)*1000;
                min = Double.Parse(minPre.Text)*1000;
                picturePre.Image = PresGreen;
                for (int i = 0; i < selectedRoute.samples.Count; i++)
                {
                    if (selectedRoute.samples.ElementAt(i).pressure > max || selectedRoute.samples.ElementAt(i).pressure < min)
                    {
                        picturePre.Image = PresRed;
                        break;
                    }
                }

                max = Double.Parse(maxLum.Text);
                min = Double.Parse(minLum.Text);
                pictureLum.Image = LumGreen;
                for (int i = 0; i < selectedRoute.samples.Count; i++)
                {
                    if (selectedRoute.samples.ElementAt(i).luminosity > max || selectedRoute.samples.ElementAt(i).luminosity < min)
                    {
                        pictureLum.Image = LumRed;
                        break;
                    }
                }

                max = Double.Parse(maxAccel.Text);
                pictureAccel.Image = AccGreen;
                for (int i = 0; i < selectedRoute.samples.Count; i++)
                {
                    if (selectedRoute.samples.ElementAt(i).getAccMagnitude() > max)
                    {
                        pictureAccel.Image = AccRed;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Generate heatmap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeatmapButton_Click(object sender, EventArgs e)
        {
            heatmapOverlay.Markers.Clear();
            double radius = 20;
            string text = comboBox2.Text;
            if (text.Equals("Massive")) radius = 5;
            if (text.Equals("Large")) radius = 10;
            if (text.Equals("Medium")) radius = 20;
            if (text.Equals("Small")) radius = 40;
            //Console.WriteLine(radius);
            List<GMarkerGoogle> markers = new List<GMarkerGoogle>();
            double left = gMap.ViewArea.Left;
            double right = gMap.ViewArea.Right;
            double top = gMap.ViewArea.Top;
            double bottom = gMap.ViewArea.Bottom;
            List<PointLatLng> points = new List<PointLatLng>();
            List<double> weights = new List<double>();
            double max = 0;
            double min = 0;
            bool forAccel = false;
            try
            {
                if (comboBox3.Text.Equals("Temperature"))
                {
                    max = Double.Parse(maxTemp.Text);
                    min = Double.Parse(minTemp.Text);
                    foreach (ListViewItem eachItem in listView.SelectedItems)
                    {
                        Route selectedRoute = (Route)eachItem.Tag;
                        foreach (Sample sample in selectedRoute.samples)
                        {
                            if (gMap.ViewArea.Contains(sample.point))
                            {
                                points.Add(sample.point);
                                weights.Add(sample.temperature);
                            }
                        }
                    }
                }
                if (comboBox3.Text.Equals("Acceleration"))
                {
                    forAccel = true;
                    max = Double.Parse(maxAccel.Text);
                    min = 0;
                    foreach (ListViewItem eachItem in listView.SelectedItems)
                    {
                        Route selectedRoute = (Route)eachItem.Tag;
                        foreach (Sample sample in selectedRoute.samples)
                        {
                            if (gMap.ViewArea.Contains(sample.point))
                            {
                                points.Add(sample.point);
                                weights.Add(sample.getAccMagnitude());
                            }
                        }
                    }
                }
                if (comboBox3.Text.Equals("Luminosity"))
                {
                    max = Double.Parse(maxLum.Text);
                    min = Double.Parse(minLum.Text);
                    foreach (ListViewItem eachItem in listView.SelectedItems)
                    {
                        Route selectedRoute = (Route)eachItem.Tag;
                        foreach (Sample sample in selectedRoute.samples)
                        {
                            if (gMap.ViewArea.Contains(sample.point))
                            {
                                points.Add(sample.point);
                                weights.Add(sample.luminosity);
                            }
                        }
                    }
                }
                if (comboBox3.Text.Equals("Pressure"))
                {
                    max = Double.Parse(maxPre.Text) * 1000;
                    min = Double.Parse(minPre.Text) * 1000;
                    foreach (ListViewItem eachItem in listView.SelectedItems)
                    {
                        Route selectedRoute = (Route)eachItem.Tag;
                        foreach (Sample sample in selectedRoute.samples)
                        {
                            if (gMap.ViewArea.Contains(sample.point))
                            {
                                points.Add(sample.point);
                                weights.Add(sample.pressure);
                            }
                        }
                    }
                }
                if (min < max)
                {
                    markers = HeatmapGenerator.getMarkers(left, right, top, bottom, points, weights, min, max, ref progressBar1, radius, forAccel);
                    for (int i = 0; i < markers.Count; i++)
                    {
                        heatmapOverlay.Markers.Add(markers.ElementAt(i));
                    }
                }
                else
                {
                    WriteToConsole("Min value must be smaller than Max value");
                }
            }
            catch
            {
                WriteToConsole("Check threshold input, don't leave it blank");
            }
        }

        /// <summary>
        /// Clear heatmap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearHeatmap_Click(object sender, EventArgs e)
        {
            heatmapOverlay.Markers.Clear();
        }

        /// <summary>
        /// Start syncing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Download_Click(object sender, EventArgs e)
        {
            if (SyncThread == null)
            {
                Download.Text = "Stop Syncing";
                SyncThread = new Thread(new ThreadStart(DownloadProcess));
                SyncThread.Start();
            }
            else
            {
                Download.Text = "Start Syncing";
                SyncThread.Abort();
                SyncThread = null;
            }
        }

        /// <summary>
        /// Syncing process
        /// </summary>
        private void DownloadProcess()
        {
            const string serverDirectory = "/home/groups/engg4810g";
            ConnectionInfo myConnectInfo = CreateConnectionInfo();
            using (var scp = new ScpClient(myConnectInfo))
            {
                if (localDirectory.Length != 0)
                {
                    try
                    {
                        while (true)
                        {
                            Invoke(new WriteDelegate(WriteToConsole), "[Sync Process] Connecting...");
                            scp.Connect();
                            Invoke(new WriteDelegate(WriteToConsole), "[Sync Process] Connected, start syncing...");
                            for (int i = 1; i <= 28; i++)
                            {
                                try
                                {
                                    string teamFolder = "engg4810g" + i.ToString("00");
                                    DirectoryInfo di = Directory.CreateDirectory(localDirectory + @"\" + teamFolder);
                                    scp.Download(serverDirectory + "/" + teamFolder, new DirectoryInfo(localDirectory + @"\" + teamFolder));
                                }
                                catch
                                {
                                    continue;
                                }
                            }
                            scp.Disconnect();
                            Invoke(new WriteDelegate(WriteToConsole), "[Sync Process] Synced on " + DateTime.Now.ToString());
                            for (int sec = 300; sec >= 0; sec--)
                            {
                                TimeSpan t = TimeSpan.FromSeconds(sec);
                                string timer = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
                                Invoke(new setTimerLableDelegate(setTimerLable), "Next Sycn: " + timer);
                                Thread.Sleep(1000);
                            }
                            Invoke(new WriteDelegate(WriteToConsole), "[Sync Process] Start syncing");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Invoke(new WriteDelegate(WriteToConsole), "Sorry, authorization failed. Check authentication information");
                    }
                }
                else
                {
                    Invoke(new WriteDelegate(WriteToConsole), "Specify local directory before syncing");
                }
            }
        }

        /// <summary>
        /// Upload file to team folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Upload_Click(object sender, EventArgs e)
        {
            Thread newThread = new Thread(new ThreadStart(UploadProcess));
            newThread.Start();
        }

        /// <summary>
        /// Upload process
        /// </summary>
        private void UploadProcess()
        {
            using (var sftp = new SftpClient(CreateConnectionInfo()))
            {
                try
                {
                    Invoke(new WriteDelegate(WriteToConsole), "[Upload Process] Connecting...");
                    sftp.Connect();
                    Invoke(new WriteDelegate(WriteToConsole), "[Upload Process] Connected");
                    sftp.ChangeDirectory("/home/groups/engg4810g/engg4810g28");
                    DialogResult result = STAShowDialog(openFileDialog1);
                    if (result == DialogResult.OK)
                    {
                        using (var fileStream = new FileStream(openFileDialog1.FileName, FileMode.Open))
                        {
                            sftp.BufferSize = 4 * 1024;
                            Invoke(new WriteDelegate(WriteToConsole), "[Upload Process] Uploading...");
                            try
                            {
                                sftp.UploadFile(fileStream, Path.GetFileName(openFileDialog1.FileName));
                            }
                            catch (Exception e)
                            {
                                Invoke(new WriteDelegate(WriteToConsole), "[Upload Process] " + e.Message);
                            }
                            Invoke(new WriteDelegate(WriteToConsole), "[Upload Process] Upload completed");
                        }
                    }
                    sftp.Disconnect();
                }
                catch
                {
                    Invoke(new WriteDelegate(WriteToConsole), "[Upload Process] Sorry, authorization failed. Check authentication information");
                }
            }
        }

        /// <summary>
        /// SSH command exe
        /// </summary>
        /// <param name="cmd">Command to exe</param>
        /// <param name="myConnectInfo"></param>
        /// <returns></returns>
        public string SshCmdExe(string cmd, ConnectionInfo myConnectInfo)
        {
            SshClient ssh = new SshClient(myConnectInfo);
            ssh.Connect();
            SshCommand command = ssh.CreateCommand("cd /home/groups/engg4810g/");
            command.Execute();
            command = ssh.CreateCommand(cmd);
            string result = command.Execute();
            ssh.Disconnect();
            return result;
        }

        /// <summary>
        /// Create Connection Info
        /// </summary>
        /// <returns></returns>
        public ConnectionInfo CreateConnectionInfo()
        {
            string username = userName.Text;
            ConnectionInfo connectionInfo = null;
            AuthenticationMethod authenticationMethod = null;
            if (checkBox1.Checked)
            {
                if (privateKeyFilePath.Length != 0)
                {
                    using (var stream = new FileStream(privateKeyFilePath, FileMode.Open, FileAccess.Read))
                    {
                        var privateKeyFile = new PrivateKeyFile(stream);
                        authenticationMethod = new PrivateKeyAuthenticationMethod(username, privateKeyFile);
                        connectionInfo = new ConnectionInfo("moss.labs.eait.uq.edu.au", username, authenticationMethod);
                    }
                }
                else
                {
                    Invoke(new WriteDelegate(WriteToConsole), "Click Load Key to load private key first");
                }
            }
            else
            {
                authenticationMethod = new PasswordAuthenticationMethod(username, passText.Text);
            }
            connectionInfo = new ConnectionInfo("moss.labs.eait.uq.edu.au", username, authenticationMethod);
            return connectionInfo;
        }

        /// <summary>
        /// For cross thread calling
        /// </summary>
        /// <param name="str"></param>
        private delegate void setTimerLableDelegate(string str);

        /// <summary>
        /// Set text for count down timer
        /// </summary>
        /// <param name="str"></param>
        private void setTimerLable(string str)
        {
            timerLable.Text = str;
        }

        /// <summary>
        /// Dialog for cross thread
        /// </summary>
        /// <param name="dialog"></param>
        /// <returns></returns>
        private DialogResult STAShowDialog(OpenFileDialog dialog)
        {
            DialogState state = new DialogState();
            state.dialog = dialog;
            System.Threading.Thread t = new
                   System.Threading.Thread(state.ThreadProcShowDialog);
            t.SetApartmentState(System.Threading.ApartmentState.STA);
            t.Start();
            t.Join();
            return state.result;
        }

        /// <summary>
        /// Support STAShowDialog
        /// </summary>
        public class DialogState
        {
            public DialogResult result;
            public OpenFileDialog dialog;


            public void ThreadProcShowDialog()
            {
                result = dialog.ShowDialog();
            }
        }

        /// <summary>
        /// Load private key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadKey_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                privateKeyFilePath = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Set local directory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void localSet_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dia = new FolderBrowserDialog();
            DialogResult result = dia.ShowDialog();
            if (result == DialogResult.OK)
            {
                localDirectory = dia.SelectedPath;
            }
        }

        /// <summary>
        /// Temperature sensor check
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureTemp_Click(object sender, EventArgs e)
        {
            markersOverlay.Markers.Clear();
            Route selectedRoute = null;
            try
            {
                selectedRoute = (Route)listView.SelectedItems[0].Tag;
                try
                {
                    double max = Double.Parse(maxTemp.Text);
                    double min = Double.Parse(minTemp.Text);
                    List<PointLatLng> addedList = new List<PointLatLng>();
                    for (int i = 0; i < selectedRoute.samples.Count; i++)
                    {
                        if (selectedRoute.samples.ElementAt(i).temperature > max || selectedRoute.samples.ElementAt(i).temperature < min)
                        {
                            if (!existClosedMaker(addedList, selectedRoute.samples.ElementAt(i).point)){
                                markersOverlay.Markers.Add(selectedRoute.samples.ElementAt(i).createMarker("Temperature threshold exceeded"));
                                addedList.Add(selectedRoute.samples.ElementAt(i).point);
                            }
                        }
                    }
                }
                catch
                {
                    WriteToConsole("Check threshold format");
                }
            }
            catch
            {
                WriteToConsole("Please select a route in list view");
            }
        }

        /// <summary>
        /// Pressure sensor check
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picturePre_Click(object sender, EventArgs e)
        {
            markersOverlay.Markers.Clear();
            Route selectedRoute = null;
            try
            {
                selectedRoute = (Route)listView.SelectedItems[0].Tag;
                try
                {
                    double max = Double.Parse(maxPre.Text) * 1000;
                    double min = Double.Parse(minPre.Text) * 1000;
                    List<PointLatLng> addedList = new List<PointLatLng>();
                    for (int i = 0; i < selectedRoute.samples.Count; i++)
                    {
                        if (selectedRoute.samples.ElementAt(i).pressure > max || selectedRoute.samples.ElementAt(i).pressure < min)
                        {
                            if (!existClosedMaker(addedList, selectedRoute.samples.ElementAt(i).point))
                            {
                                markersOverlay.Markers.Add(selectedRoute.samples.ElementAt(i).createMarker("Pressure threshold exceeded"));
                                addedList.Add(selectedRoute.samples.ElementAt(i).point);
                            }
                        }
                    }
                }
                catch
                {
                    WriteToConsole("Check threshold format");
                }
            }
            catch
            {
                WriteToConsole("Please select a route in list view");
            }
        }

        /// <summary>
        /// Luminosity sensor check
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureLum_Click(object sender, EventArgs e)
        {
            markersOverlay.Markers.Clear();
            Route selectedRoute = null;
            try
            {
                selectedRoute = (Route)listView.SelectedItems[0].Tag;
                try
                {
                    double max = Double.Parse(maxLum.Text);
                    double min = Double.Parse(minLum.Text);
                    List<PointLatLng> addedList = new List<PointLatLng>();
                    for (int i = 0; i < selectedRoute.samples.Count; i++)
                    {
                        if (selectedRoute.samples.ElementAt(i).luminosity > max || selectedRoute.samples.ElementAt(i).luminosity < min)
                        {
                            if (!existClosedMaker(addedList, selectedRoute.samples.ElementAt(i).point))
                            {
                                markersOverlay.Markers.Add(selectedRoute.samples.ElementAt(i).createMarker("Luminosity threshold exceeded"));
                                addedList.Add(selectedRoute.samples.ElementAt(i).point);
                            }
                        }
                    }
                }
                catch
                {
                    WriteToConsole("Check threshold format");
                }
            }
            catch
            {
                WriteToConsole("Please select a route in list view");
            }
        }

        /// <summary>
        /// Acceleration sensor check
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureAccel_Click(object sender, EventArgs e)
        {
            markersOverlay.Markers.Clear();
            Route selectedRoute = null;
            try
            {
                selectedRoute = (Route)listView.SelectedItems[0].Tag;
                try
                {
                    double max = Double.Parse(maxAccel.Text);
                    List<PointLatLng> addedList = new List<PointLatLng>();
                    for (int i = 0; i < selectedRoute.samples.Count; i++)
                    {
                        if (selectedRoute.samples.ElementAt(i).getAccMagnitude() > max)
                        {
                            if (!existClosedMaker(addedList, selectedRoute.samples.ElementAt(i).point))
                            {
                                markersOverlay.Markers.Add(selectedRoute.samples.ElementAt(i).createMarker("Acceleration threshold exceeded"));
                                addedList.Add(selectedRoute.samples.ElementAt(i).point);
                            }
                        }
                    }
                }
                catch
                {
                    WriteToConsole("Check threshold format");
                }
            }
            catch
            {
                WriteToConsole("Please select a route in list view");
            }
        }

        /// <summary>
        /// Help
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 helpWindows = new Form3();
            helpWindows.Show();
        }

        bool existClosedMaker(List<PointLatLng> markers, PointLatLng point)
        {
            double lat1 = point.Lat;
            double lng1 = point.Lng;
            foreach (PointLatLng marker in markers)
            {
                double mapSize = Converter.GetDistanceBetweenPoints(gMap.ViewArea.Top, gMap.ViewArea.Left, gMap.ViewArea.Top, gMap.ViewArea.Right);
                double lat2 = marker.Lat;
                double lng2 = marker.Lng;
                double distance = Converter.GetDistanceBetweenPoints(lat1, lng1, lat2, lng2);
                if (distance < mapSize / 50)
                {
                    return true;
                }
            }
            return false;
        }

        private void parseConverted_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string line;
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    line = sr.ReadToEnd();
                }
                Route newRoute = null;
                try
                {
                    newRoute = IOModule.ParseConvertedFile(line, ref progressBar1);
                }
                catch
                {
                    WriteToConsole("Wrong format file");
                }
                if (newRoute != null)
                {
                    Routes.Add(newRoute);
                    AddToList(newRoute);
                    routesOverlay.Routes.Add(newRoute.gMapRoute);
                    gMap.ZoomAndCenterRoute(newRoute.gMapRoute);
                }
            }
        }
       
    }
}