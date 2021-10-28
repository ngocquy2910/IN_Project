using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Object_detect
{
    public partial class AI_Medicine : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        public AI_Medicine()
        {

            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void AI_Medicine_Load(object sender, EventArgs e)
        {
            richText_Note.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, richText_Note.Width, richText_Note.Height, 30, 30));
        }
    }
}
