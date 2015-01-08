using System.Threading;
namespace gMapForNet
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gMap = new GMap.NET.WindowsForms.GMapControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.TemperLable1 = new System.Windows.Forms.Label();
            this.textStart = new System.Windows.Forms.TextBox();
            this.textEnd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.get_route = new System.Windows.Forms.Button();
            this.writeFile = new System.Windows.Forms.Button();
            this.parseFile = new System.Windows.Forms.Button();
            this.setUpRoute = new System.Windows.Forms.Button();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.writeConfig = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.showGraphButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.maxLum = new System.Windows.Forms.TextBox();
            this.maxPre = new System.Windows.Forms.TextBox();
            this.minPre = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.applyButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.maxAccel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.minLum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.maxTemp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.minTemp = new System.Windows.Forms.TextBox();
            this.listView = new System.Windows.Forms.ListView();
            this.Starting = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Destination = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.clearButton = new System.Windows.Forms.Button();
            this.checkButton = new System.Windows.Forms.Button();
            this.infoText = new System.Windows.Forms.RichTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.HeatmapButton = new System.Windows.Forms.Button();
            this.clearHeatmap = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lable1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.Radius = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.localSet = new System.Windows.Forms.Button();
            this.timerLable = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.loadKey = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.passText = new System.Windows.Forms.TextBox();
            this.Upload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.Download = new System.Windows.Forms.Button();
            this.pictureTemp = new System.Windows.Forms.PictureBox();
            this.picturePre = new System.Windows.Forms.PictureBox();
            this.pictureLum = new System.Windows.Forms.PictureBox();
            this.pictureAccel = new System.Windows.Forms.PictureBox();
            this.parseConverted = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAccel)).BeginInit();
            this.SuspendLayout();
            // 
            // gMap
            // 
            this.gMap.Bearing = 0F;
            this.gMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gMap.CanDragMap = true;
            this.gMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMap.GrayScaleMode = false;
            this.gMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMap.LevelsKeepInMemmory = 5;
            this.gMap.Location = new System.Drawing.Point(12, 12);
            this.gMap.MarkersEnabled = true;
            this.gMap.MaxZoom = 17;
            this.gMap.MinZoom = 2;
            this.gMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMap.Name = "gMap";
            this.gMap.NegativeMode = false;
            this.gMap.PolygonsEnabled = true;
            this.gMap.RetryLoadTile = 0;
            this.gMap.RoutesEnabled = true;
            this.gMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMap.ShowTileGridLines = false;
            this.gMap.Size = new System.Drawing.Size(500, 500);
            this.gMap.TabIndex = 0;
            this.gMap.Zoom = 10D;
            this.gMap.OnMapDrag += new GMap.NET.MapDrag(this.gMap_MouseDrag);
            this.gMap.OnMapZoomChanged += new GMap.NET.MapZoomChanged(this.gMap_ZoomChange);
            this.gMap.Load += new System.EventHandler(this.gMap_Load);
            this.gMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gMap_LeftMouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 530);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 83);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "System Message";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(452, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 57);
            this.button1.TabIndex = 1;
            this.button1.Text = "Help";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(440, 58);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // TemperLable1
            // 
            this.TemperLable1.AutoSize = true;
            this.TemperLable1.Location = new System.Drawing.Point(6, 22);
            this.TemperLable1.Name = "TemperLable1";
            this.TemperLable1.Size = new System.Drawing.Size(54, 13);
            this.TemperLable1.TabIndex = 10;
            this.TemperLable1.Text = "Min Temp";
            // 
            // textStart
            // 
            this.textStart.Location = new System.Drawing.Point(36, 9);
            this.textStart.Name = "textStart";
            this.textStart.Size = new System.Drawing.Size(153, 20);
            this.textStart.TabIndex = 15;
            // 
            // textEnd
            // 
            this.textEnd.Location = new System.Drawing.Point(36, 36);
            this.textEnd.Name = "textEnd";
            this.textEnd.Size = new System.Drawing.Size(153, 20);
            this.textEnd.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Start";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "End";
            // 
            // get_route
            // 
            this.get_route.Location = new System.Drawing.Point(7, 62);
            this.get_route.Name = "get_route";
            this.get_route.Size = new System.Drawing.Size(91, 23);
            this.get_route.TabIndex = 19;
            this.get_route.Text = "Get Route";
            this.get_route.UseVisualStyleBackColor = true;
            this.get_route.Click += new System.EventHandler(this.get_route_Click);
            // 
            // writeFile
            // 
            this.writeFile.Location = new System.Drawing.Point(4, 19);
            this.writeFile.Name = "writeFile";
            this.writeFile.Size = new System.Drawing.Size(64, 23);
            this.writeFile.TabIndex = 21;
            this.writeFile.Text = "Generate";
            this.writeFile.UseVisualStyleBackColor = true;
            this.writeFile.Click += new System.EventHandler(this.writeFile_Click);
            // 
            // parseFile
            // 
            this.parseFile.Location = new System.Drawing.Point(74, 19);
            this.parseFile.Name = "parseFile";
            this.parseFile.Size = new System.Drawing.Size(51, 23);
            this.parseFile.TabIndex = 22;
            this.parseFile.Text = "Raw";
            this.parseFile.UseVisualStyleBackColor = true;
            this.parseFile.Click += new System.EventHandler(this.parseFile_Click);
            // 
            // setUpRoute
            // 
            this.setUpRoute.Location = new System.Drawing.Point(7, 91);
            this.setUpRoute.Name = "setUpRoute";
            this.setUpRoute.Size = new System.Drawing.Size(182, 25);
            this.setUpRoute.TabIndex = 23;
            this.setUpRoute.Text = "Start Manual Set Up";
            this.setUpRoute.UseVisualStyleBackColor = true;
            this.setUpRoute.Click += new System.EventHandler(this.setUpRoute_Click);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.BackColor = System.Drawing.Color.Silver;
            this.zedGraphControl1.Location = new System.Drawing.Point(724, 12);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(393, 339);
            this.zedGraphControl1.TabIndex = 24;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.writeConfig);
            this.panel3.Controls.Add(this.textStart);
            this.panel3.Controls.Add(this.textEnd);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.setUpRoute);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.get_route);
            this.panel3.Location = new System.Drawing.Point(518, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 127);
            this.panel3.TabIndex = 26;
            // 
            // writeConfig
            // 
            this.writeConfig.Location = new System.Drawing.Point(98, 62);
            this.writeConfig.Name = "writeConfig";
            this.writeConfig.Size = new System.Drawing.Size(91, 23);
            this.writeConfig.TabIndex = 24;
            this.writeConfig.Text = "Write Config";
            this.writeConfig.UseVisualStyleBackColor = true;
            this.writeConfig.Click += new System.EventHandler(this.writeConfig_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.parseConverted);
            this.groupBox2.Controls.Add(this.writeFile);
            this.groupBox2.Controls.Add(this.parseFile);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox2.Location = new System.Drawing.Point(518, 144);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 56);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "YAML";
            // 
            // showGraphButton
            // 
            this.showGraphButton.Location = new System.Drawing.Point(724, 357);
            this.showGraphButton.Name = "showGraphButton";
            this.showGraphButton.Size = new System.Drawing.Size(74, 27);
            this.showGraphButton.TabIndex = 32;
            this.showGraphButton.Text = "Show";
            this.showGraphButton.UseVisualStyleBackColor = true;
            this.showGraphButton.Click += new System.EventHandler(this.showGraphButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.maxLum);
            this.groupBox3.Controls.Add(this.maxPre);
            this.groupBox3.Controls.Add(this.minPre);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.applyButton);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.maxAccel);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.minLum);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.maxTemp);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.minTemp);
            this.groupBox3.Controls.Add(this.TemperLable1);
            this.groupBox3.Location = new System.Drawing.Point(724, 390);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(173, 223);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Threshold Setting";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(128, 98);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(26, 13);
            this.label17.TabIndex = 42;
            this.label17.Text = "kPa";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(128, 73);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(26, 13);
            this.label16.TabIndex = 41;
            this.label16.Text = "kPa";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(130, 149);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(24, 13);
            this.label15.TabIndex = 40;
            this.label15.Text = "Lux";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 149);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 13);
            this.label14.TabIndex = 39;
            this.label14.Text = "Max Luminosity";
            // 
            // maxLum
            // 
            this.maxLum.Location = new System.Drawing.Point(85, 146);
            this.maxLum.Name = "maxLum";
            this.maxLum.Size = new System.Drawing.Size(41, 20);
            this.maxLum.TabIndex = 38;
            this.maxLum.Text = "100";
            // 
            // maxPre
            // 
            this.maxPre.Location = new System.Drawing.Point(84, 95);
            this.maxPre.Name = "maxPre";
            this.maxPre.Size = new System.Drawing.Size(41, 20);
            this.maxPre.TabIndex = 37;
            this.maxPre.Text = "110";
            // 
            // minPre
            // 
            this.minPre.Location = new System.Drawing.Point(84, 70);
            this.minPre.Name = "minPre";
            this.minPre.Size = new System.Drawing.Size(41, 20);
            this.minPre.TabIndex = 36;
            this.minPre.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 98);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 13);
            this.label13.TabIndex = 35;
            this.label13.Text = "Max Pressure";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "Min Pressure";
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(9, 194);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(150, 23);
            this.applyButton.TabIndex = 32;
            this.applyButton.Text = "Show threshold on Graph";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(130, 173);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "m/s ²";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(130, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Lux";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(128, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "°C";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(128, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "°C";
            // 
            // maxAccel
            // 
            this.maxAccel.Location = new System.Drawing.Point(85, 170);
            this.maxAccel.Name = "maxAccel";
            this.maxAccel.Size = new System.Drawing.Size(41, 20);
            this.maxAccel.TabIndex = 27;
            this.maxAccel.Text = "20";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Acceleration";
            // 
            // minLum
            // 
            this.minLum.Location = new System.Drawing.Point(85, 121);
            this.minLum.Name = "minLum";
            this.minLum.Size = new System.Drawing.Size(41, 20);
            this.minLum.TabIndex = 25;
            this.minLum.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Min Luminosity";
            // 
            // maxTemp
            // 
            this.maxTemp.Location = new System.Drawing.Point(84, 45);
            this.maxTemp.Name = "maxTemp";
            this.maxTemp.Size = new System.Drawing.Size(41, 20);
            this.maxTemp.TabIndex = 23;
            this.maxTemp.Text = "40";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Max Temp";
            // 
            // minTemp
            // 
            this.minTemp.Location = new System.Drawing.Point(84, 19);
            this.minTemp.Name = "minTemp";
            this.minTemp.Size = new System.Drawing.Size(41, 20);
            this.minTemp.TabIndex = 21;
            this.minTemp.Text = "0";
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Starting,
            this.Destination});
            this.listView.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.listView.FullRowSelect = true;
            this.listView.Location = new System.Drawing.Point(518, 205);
            this.listView.Name = "listView";
            this.listView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listView.Size = new System.Drawing.Size(200, 195);
            this.listView.TabIndex = 21;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // Starting
            // 
            this.Starting.Text = "Starting";
            this.Starting.Width = 102;
            // 
            // Destination
            // 
            this.Destination.Text = "Destination";
            this.Destination.Width = 95;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(518, 455);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(99, 23);
            this.clearButton.TabIndex = 30;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // checkButton
            // 
            this.checkButton.Location = new System.Drawing.Point(621, 455);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(97, 23);
            this.checkButton.TabIndex = 31;
            this.checkButton.Text = "Check";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // infoText
            // 
            this.infoText.Location = new System.Drawing.Point(903, 357);
            this.infoText.Name = "infoText";
            this.infoText.ReadOnly = true;
            this.infoText.Size = new System.Drawing.Size(214, 127);
            this.infoText.TabIndex = 33;
            this.infoText.Text = "Samples information: not yet loaded";
            // 
            // comboBox1
            // 
            this.comboBox1.AllowDrop = true;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Temperature",
            "Luminosity",
            "Pressure",
            "Acceleration",
            "Velocity"});
            this.comboBox1.Location = new System.Drawing.Point(804, 361);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(93, 21);
            this.comboBox1.TabIndex = 34;
            this.comboBox1.Text = "Temperature";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 518);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(500, 10);
            this.progressBar1.TabIndex = 36;
            // 
            // HeatmapButton
            // 
            this.HeatmapButton.Location = new System.Drawing.Point(58, 59);
            this.HeatmapButton.Name = "HeatmapButton";
            this.HeatmapButton.Size = new System.Drawing.Size(146, 31);
            this.HeatmapButton.TabIndex = 37;
            this.HeatmapButton.Text = "Generate Heatmap";
            this.HeatmapButton.UseVisualStyleBackColor = true;
            this.HeatmapButton.Click += new System.EventHandler(this.HeatmapButton_Click);
            // 
            // clearHeatmap
            // 
            this.clearHeatmap.Location = new System.Drawing.Point(58, 93);
            this.clearHeatmap.Name = "clearHeatmap";
            this.clearHeatmap.Size = new System.Drawing.Size(146, 23);
            this.clearHeatmap.TabIndex = 38;
            this.clearHeatmap.Text = "Clear";
            this.clearHeatmap.UseVisualStyleBackColor = true;
            this.clearHeatmap.Click += new System.EventHandler(this.clearHeatmap_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lable1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.comboBox3);
            this.panel1.Controls.Add(this.clearHeatmap);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.Radius);
            this.panel1.Controls.Add(this.HeatmapButton);
            this.panel1.Location = new System.Drawing.Point(903, 490);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(214, 123);
            this.panel1.TabIndex = 39;
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Font = new System.Drawing.Font("Motorwerk", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable1.Location = new System.Drawing.Point(4, 4);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(25, 112);
            this.lable1.TabIndex = 42;
            this.lable1.Text = "H\r\nE\r\nA\r\nT\r\nM\r\nA\r\nP";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(35, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(17, 112);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // comboBox3
            // 
            this.comboBox3.AllowDrop = true;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Temperature",
            "Luminosity",
            "Pressure",
            "Acceleration"});
            this.comboBox3.Location = new System.Drawing.Point(58, 34);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(146, 21);
            this.comboBox3.TabIndex = 40;
            this.comboBox3.Text = "Temperature";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Massive",
            "Large",
            "Medium",
            "Small"});
            this.comboBox2.Location = new System.Drawing.Point(101, 7);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(103, 21);
            this.comboBox2.TabIndex = 40;
            this.comboBox2.Text = "Medium";
            // 
            // Radius
            // 
            this.Radius.AutoSize = true;
            this.Radius.Location = new System.Drawing.Point(55, 10);
            this.Radius.Name = "Radius";
            this.Radius.Size = new System.Drawing.Size(40, 13);
            this.Radius.TabIndex = 39;
            this.Radius.Text = "Radius";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.localSet);
            this.panel2.Controls.Add(this.timerLable);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.loadKey);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.passText);
            this.panel2.Controls.Add(this.Upload);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.userName);
            this.panel2.Controls.Add(this.Download);
            this.panel2.Location = new System.Drawing.Point(518, 482);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 131);
            this.panel2.TabIndex = 40;
            // 
            // localSet
            // 
            this.localSet.Location = new System.Drawing.Point(6, 73);
            this.localSet.Name = "localSet";
            this.localSet.Size = new System.Drawing.Size(77, 23);
            this.localSet.TabIndex = 41;
            this.localSet.Text = "Local Dir";
            this.localSet.UseVisualStyleBackColor = true;
            this.localSet.Click += new System.EventHandler(this.localSet_Click);
            // 
            // timerLable
            // 
            this.timerLable.AutoSize = true;
            this.timerLable.Location = new System.Drawing.Point(0, 113);
            this.timerLable.Name = "timerLable";
            this.timerLable.Size = new System.Drawing.Size(81, 13);
            this.timerLable.TabIndex = 41;
            this.timerLable.Text = "Next sync: 4:59";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(7, 49);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Use PPKey";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // loadKey
            // 
            this.loadKey.Location = new System.Drawing.Point(89, 45);
            this.loadKey.Name = "loadKey";
            this.loadKey.Size = new System.Drawing.Size(104, 23);
            this.loadKey.TabIndex = 6;
            this.loadKey.Text = "Load key";
            this.loadKey.UseVisualStyleBackColor = true;
            this.loadKey.Click += new System.EventHandler(this.loadKey_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password";
            // 
            // passText
            // 
            this.passText.Location = new System.Drawing.Point(89, 19);
            this.passText.Name = "passText";
            this.passText.Size = new System.Drawing.Size(104, 20);
            this.passText.TabIndex = 4;
            // 
            // Upload
            // 
            this.Upload.Location = new System.Drawing.Point(89, 72);
            this.Upload.Name = "Upload";
            this.Upload.Size = new System.Drawing.Size(104, 23);
            this.Upload.TabIndex = 3;
            this.Upload.Text = "Upload";
            this.Upload.UseVisualStyleBackColor = true;
            this.Upload.Click += new System.EventHandler(this.Upload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "User Name";
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(7, 19);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(76, 20);
            this.userName.TabIndex = 1;
            this.userName.Text = "s4312959";
            // 
            // Download
            // 
            this.Download.Location = new System.Drawing.Point(89, 100);
            this.Download.Name = "Download";
            this.Download.Size = new System.Drawing.Size(104, 23);
            this.Download.TabIndex = 0;
            this.Download.Text = "Start Syncing";
            this.Download.UseVisualStyleBackColor = true;
            this.Download.Click += new System.EventHandler(this.Download_Click);
            // 
            // pictureTemp
            // 
            this.pictureTemp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureTemp.Location = new System.Drawing.Point(518, 406);
            this.pictureTemp.Name = "pictureTemp";
            this.pictureTemp.Size = new System.Drawing.Size(45, 45);
            this.pictureTemp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureTemp.TabIndex = 41;
            this.pictureTemp.TabStop = false;
            this.pictureTemp.Click += new System.EventHandler(this.pictureTemp_Click);
            // 
            // picturePre
            // 
            this.picturePre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picturePre.Location = new System.Drawing.Point(570, 406);
            this.picturePre.Name = "picturePre";
            this.picturePre.Size = new System.Drawing.Size(45, 45);
            this.picturePre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturePre.TabIndex = 42;
            this.picturePre.TabStop = false;
            this.picturePre.Click += new System.EventHandler(this.picturePre_Click);
            // 
            // pictureLum
            // 
            this.pictureLum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureLum.Location = new System.Drawing.Point(622, 406);
            this.pictureLum.Name = "pictureLum";
            this.pictureLum.Size = new System.Drawing.Size(45, 45);
            this.pictureLum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureLum.TabIndex = 43;
            this.pictureLum.TabStop = false;
            this.pictureLum.Click += new System.EventHandler(this.pictureLum_Click);
            // 
            // pictureAccel
            // 
            this.pictureAccel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureAccel.Location = new System.Drawing.Point(673, 406);
            this.pictureAccel.Name = "pictureAccel";
            this.pictureAccel.Size = new System.Drawing.Size(45, 45);
            this.pictureAccel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureAccel.TabIndex = 44;
            this.pictureAccel.TabStop = false;
            this.pictureAccel.Click += new System.EventHandler(this.pictureAccel_Click);
            // 
            // parseConverted
            // 
            this.parseConverted.Location = new System.Drawing.Point(131, 19);
            this.parseConverted.Name = "parseConverted";
            this.parseConverted.Size = new System.Drawing.Size(66, 23);
            this.parseConverted.TabIndex = 23;
            this.parseConverted.Text = "Converted";
            this.parseConverted.UseVisualStyleBackColor = true;
            this.parseConverted.Click += new System.EventHandler(this.parseConverted_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 621);
            this.Controls.Add(this.pictureAccel);
            this.Controls.Add(this.pictureLum);
            this.Controls.Add(this.picturePre);
            this.Controls.Add(this.pictureTemp);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.infoText);
            this.Controls.Add(this.showGraphButton);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gMap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Team 28";
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAccel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMap;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label TemperLable1;
        private System.Windows.Forms.TextBox textStart;
        private System.Windows.Forms.TextBox textEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button get_route;
        private GMap.NET.WindowsForms.GMapOverlay markersOverlay;
        private GMap.NET.WindowsForms.GMapOverlay routesOverlay;
        private GMap.NET.WindowsForms.GMapOverlay heatmapOverlay;
        private System.Windows.Forms.Button writeFile;
        private System.Windows.Forms.Button parseFile;
        private System.Windows.Forms.Button setUpRoute;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader Starting;
        private System.Windows.Forms.ColumnHeader Destination;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.Button showGraphButton;
        private System.Windows.Forms.TextBox minTemp;
        private System.Windows.Forms.TextBox maxTemp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox maxAccel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox minLum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.RichTextBox infoText;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox maxPre;
        private System.Windows.Forms.TextBox minPre;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox maxLum;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button HeatmapButton;
        private System.Windows.Forms.Button clearHeatmap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label Radius;
        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Download;
        private System.Windows.Forms.Button Upload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.TextBox passText;
        private System.Windows.Forms.Label timerLable;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button loadKey;
        private System.Windows.Forms.Label label2;
        private Thread SyncThread;
        private System.Windows.Forms.Button writeConfig;
        private System.Windows.Forms.Button localSet;
        private System.Windows.Forms.PictureBox pictureTemp;
        private System.Windows.Forms.PictureBox picturePre;
        private System.Windows.Forms.PictureBox pictureLum;
        private System.Windows.Forms.PictureBox pictureAccel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button parseConverted;
    }
}

