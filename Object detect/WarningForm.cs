using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Object_detect
{
    public partial class WarningForm : Form
    {
        private string warningType;
        private string warningIndex;
        public WarningForm(string a, string b)
        {
            InitializeComponent();
            warningType = a;
            warningIndex = b;
        }

        private void WarningForm_Load(object sender, EventArgs e)
        {
            if (warningType == "LowLevel")
            {
                Image image = Image.FromFile(@"..\..\..\WarningImages\warning1.png");
                pictureBox1.Image = image;
                SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\PC\OneDrive\Desktop\Yersin Talent\Intelligent Nurse\WarningImages\warningSoud2.wav");
                simpleSound.Play();
                label1.Text = "LOW LEVEL WARNING";
                label1.Location = new Point(this.Location.X / 2 + 75, 0);
                if (warningIndex == "Temp")
                {
                    label2.Text = "Patient at bed D2345 has a bad change in temperature index";
                }
                else if (warningIndex == "Hr")
                {
                    label2.Text = "Patient at bed D2345 has a bad change in heart rate index";
                }
                else
                {
                    label2.Text = "Patient at bed D2345 has a bad change in spo2 index";
                    
                }
            }
            else
            {
                Image image = Image.FromFile(@"..\..\..\WarningImages\warning2.png");
                pictureBox1.Image = image;
                SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\PC\OneDrive\Desktop\Yersin Talent\Intelligent Nurse\WarningImages\warningSoud1.wav");
                simpleSound.Play();
                label1.Text = "HIGH LEVEL WARNING";
                label1.Location = new Point(this.Location.X / 2 + 75, 0);
                if (warningIndex == "Temp")
                {
                    label2.Text = "Patient in bed D2345 has dangerous changes in temperature index";
                }
                else if (warningIndex == "Hr")
                {
                    label2.Text = "Patient at bed D2345 has dangerous changes in heart rate index";
                }
                else
                {
                    label2.Text = "Patient in bed D2345 has dangerous changes in spo2 index";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
