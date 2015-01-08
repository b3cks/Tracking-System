using GMap.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gMapForNet
{
    public partial class Form2 : Form
    {
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        
        public Form2(List<PointLatLng> settingUp, Form1 mainForm)
        {
            this.settingUp = settingUp;
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int accelActThres = Int32.Parse(textBox1.Text);
                int accelInactTime = Int32.Parse(textBox2.Text);
                int accelTapThres = Int32.Parse(textBox3.Text);
                int accelTapDuration = Int32.Parse(textBox4.Text);
                int confTracking = Int32.Parse(textBox5.Text);
                int confDebug = Int32.Parse(textBox6.Text);
                int confHighTemporalRes = Int32.Parse(textBox7.Text);
                int confWakeOnMovement = Int32.Parse(textBox18.Text);
                double interpolate = Double.Parse(textBox17.Text);
                string outFile = IOModule.WriteConfig(
                    accelActThres,
                    accelInactTime,
                    accelTapThres,
                    accelTapDuration,
                    confTracking,
                    confDebug,
                    confHighTemporalRes,
                    confWakeOnMovement,
                    interpolate,
                    this.settingUp);
                DialogResult result = saveFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(saveFileDialog1.FileName, outFile);
                }
                this.Hide();
                mainForm.Enabled = true;
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainForm.Enabled = true;
        }
    }
}
