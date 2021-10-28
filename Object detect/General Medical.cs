using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Object_detect
{
    public partial class General_Medical : Form
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
        Capture capture;
        string[] lines;
        delegate void UpdatePictureboxCallback();

        public General_Medical()
        {
            InitializeComponent();
            lines = File.ReadAllLines("yolov4x.txt");
        }
        private void Capture_ImageGrabbedFile(object sender, EventArgs e)
        {
            try
            {
                Mat m = new Mat();
                capture.Retrieve(m);
                pictureBox1.Image = m.ToImage<Bgr, byte>().Bitmap;
                Thread.Sleep(1000 / (byte)capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps));

                int currentFame = (int)Math.Floor(capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames));

                if (currentFame % 5 == 0)
                {
                    detect(true);
                }

            }
            catch (Exception)
            { }
        }
        private void UpdatePicturebox()
        {
            if (pictureBox1.InvokeRequired)
            {
                UpdatePictureboxCallback d = new UpdatePictureboxCallback(UpdatePicturebox); // khởi tạo 1 delegate mới gọi đến SetText
                this.Invoke(d, new object[] { });
            }
            else pictureBox1.Refresh();
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "D:\\IN\\Dataset\\images\\train";
            openFileDialog.Filter = "Img files (*.JPG)|*.JPG|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                pictureBox1.Image = Image.FromFile(filePath);
                txt_PatientID.Text = "BN0098";


            }
            richText_MoveHopital.Text = "";
        }

        private void General_Medical_Load(object sender, EventArgs e)
        {
            richText_MoveHopital.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, richText_MoveHopital.Width, richText_MoveHopital.Height, 30, 30));
            richText_Send.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, richText_Send.Width, richText_Send.Height, 30, 30));
            txt_PatientID.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txt_PatientID.Width, txt_PatientID.Height, 30, 30));
            richText_chat.Text = "Mr Hoang : Patient BN0032 dangerous pleural effusion needs attention\n \n" +
             "Miss Linh : Patient BN0035 dangerously enlarged heart\n \n" +
             "Mr. Hung : Patient BN0158 dangerous pleural effusion needs attention\n\n" +
             "Mr. Nghia : Partient BN0154 dangerously enlarged heart\n\n";
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            string newchat = label7.Text + " : " + richText_Send.Text;
            richText_chat.Text = "Mr Hoang : Patient BN0032 dangerous pleural effusion needs attention\n \n" +
                "Miss Linh : Patient BN0035 dangerously enlarged heart\n \n" +
                "Mr. Hung : Patient BN0158 dangerous pleural effusion needs attention\n\n" +
                "Mr. Nghia : Partient BN0154 dangerously enlarged heart\n\n" +
                newchat;
            richText_Send.Text = "";
        }
        private String sendPOST(String url, String B64)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 15000;
                var postData = "image=" + EscapeData(B64);

                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return responseString;
            }
            catch (Exception ex)
            {
                return "Exception" + ex.ToString();
            }
        }
        public static string ConvertImageToBase64String(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                return Convert.ToBase64String(ms.ToArray());
            }
        }
        public string sendGet(string uri)
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
        private String EscapeData(String B64)
        {
            int B64_length = B64.Length;
            if (B64_length <= 32000)
                return Uri.EscapeDataString(B64);

            int idx = 0;
            StringBuilder builder = new StringBuilder();
            String substr = B64.Substring(idx, 32000);
            while (idx < B64_length)
            {
                builder.Append(Uri.EscapeDataString(substr));
                idx += 32000;

                if (idx < B64_length)
                    substr = B64.Substring(idx, Math.Min(32000, B64_length - idx));

            }
            return builder.ToString();
        }

        void detect(bool camvideo)
        {
            // Convert image to B64
            Bitmap bmp = new Bitmap(pictureBox1.Image);



            Bitmap rbmp = new Bitmap(bmp);
            int width = bmp.Width;
            int height = bmp.Height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    Color p = bmp.GetPixel(x, y);

                    //extract ARGB value from p
                    int a = p.A;
                    int r = p.G;
                    int g = p.G;
                    int b = p.B;
                    int q = p.G;
                    //set red image pixel
                    rbmp.SetPixel(x, y, Color.FromArgb(a, r, r, r));


                }
            }
            pictureBox1.Image = rbmp;
            String B64 = ConvertImageToBase64String(pictureBox1.Image);

            // Goi len server va tra ve ket qua
            String server_ip = "localhost";
            String server_path = "http://" + server_ip + ":8000/detect";


            String retStr = sendPOST(server_path, B64);


            // Ve cac khung chu nhat va ten class len anh 
            Graphics newGraphics = Graphics.FromImage(pictureBox1.Image);
            String[] items = retStr.Split('|');


            for (int idx = 0; idx < items.Length - 1; idx++)
            {
                String[] val = items[idx].Split(',');
                /*                richTextBox2.Text += a.ToString();
                */
                // Draw it
                Random rnd = new Random();
                Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                Pen blackPen = new Pen(randomColor, 4);

                // Create rectangle.               
                Rectangle rect = new Rectangle(int.Parse(val[1]), int.Parse(val[2]), int.Parse(val[3]), int.Parse(val[4]));

                // Draw rectangle to screen.
                newGraphics.DrawRectangle(blackPen, rect);
                string a = lines[int.Parse(val[0])];
                newGraphics.DrawString(a, new Font("Times New Roman", 20), Brushes.Red, rect);
                richText_MoveHopital.Text += a + "\n";
            }
            if (richText_MoveHopital.Text == "")
            {
                richText_MoveHopital.Text = "Khong Co Benh Ve Phoi";
            }



            if (!camvideo)
                pictureBox1.Refresh();
            else
            {
                //pictureBox1.Refresh(); // Không chạy được vì khác thread
                UpdatePicturebox(); // Nên phải dùng delegate
                Thread.Sleep(150);
            }
        }

        private void btn_Detect_Click(object sender, EventArgs e)
        {
            detect(false);

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
