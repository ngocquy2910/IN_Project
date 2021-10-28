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
    public partial class Home2 : Form
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
        public Home2()
        {
            InitializeComponent();
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
           
        }

        private void Home2_Load(object sender, EventArgs e)
        {
            rick_txt_send.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, rick_txt_send.Width, rick_txt_send.Height, 30, 30));
        }
    }
}
