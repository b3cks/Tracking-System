using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gMapForNet
{
    public partial class Form3 : Form
    {
        Bitmap General = null;
        Bitmap Import = null;
        Bitmap Graph = null;
        Bitmap Cloud = null;
        Bitmap Heatmap = null;
        Bitmap Config = null;
        
        public Form3()
        {
            InitializeComponent();
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("gMapForNet.General.PNG");
            General = new Bitmap(myStream);
            myStream = myAssembly.GetManifestResourceStream("gMapForNet.ImportAndCheck.PNG");
            Import = new Bitmap(myStream);
            myStream = myAssembly.GetManifestResourceStream("gMapForNet.Graph.PNG");
            Graph = new Bitmap(myStream);
            myStream = myAssembly.GetManifestResourceStream("gMapForNet.Cloud.PNG");
            Cloud = new Bitmap(myStream);
            myStream = myAssembly.GetManifestResourceStream("gMapForNet.Heatmap.PNG");
            Heatmap = new Bitmap(myStream);
            myStream = myAssembly.GetManifestResourceStream("gMapForNet.Config.PNG");
            Config = new Bitmap(myStream);
            pictureBox1.Image = General;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = General;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Import;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Graph;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Heatmap;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Cloud;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Config;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


    }
}
