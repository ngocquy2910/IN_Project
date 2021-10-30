using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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
        public string get(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
                

        }

        private void AI_Medicine_Load(object sender, EventArgs e)
        {
            richText_Note.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, richText_Note.Width, richText_Note.Height, 30, 30));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string svr = "http://192.168.1.2:8000/ai_medicine?data=" + label11.Text;
            string reStr = get(svr);
            richText_AISuggestions.Text = reStr;
        }
    }
}
