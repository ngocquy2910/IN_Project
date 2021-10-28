using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Object_detect
{
    public partial class Statistics_of_hospital_beds : Form
    {
        public Statistics_of_hospital_beds()
        {
            InitializeComponent();
        }
        //---------------------------------- AUTO CREATE BUTTON -----------------------------------------------------------//
        public void CreateButton(Panel Show)
        {
            
            int TOP = 0, LEFT = 0;

            for (int i = 1; i <= 15; i++)
            {
                string name = "Giường";

                Button button = new Button();
                // THEM THUOC TINH
                button.Name = string.Format("Bed{0}", i);
                button.Tag = string.Format("[{0}]", i);
                button.Text = string.Format(name + i.ToString());
                button.Font = new Font("Arial Narrow", 12);
                button.Size = new Size(125, 101);
                button.Top = TOP;
                button.Left = LEFT;

                LEFT += 150;
                if (ina > 2)
                {
                    if( i % 2 == 0)
                    {
                        button.BackColor = Color.Red;
                    }
                }
                else
                {
                    button.BackColor = Color.FromArgb(0, 255, 0);
                }
                button.ForeColor = Color.Black;
                button.BackgroundImage = Image.FromFile("D:\\CER\\beda.png");
                button.Click += new EventHandler(bt_Click);
                // them vao panel
                Show.Controls.Add(button);
                if(i % 5 == 0)
                {
                    TOP += 120;
                    LEFT = 0;

                }
               
                    
                
                
                
            }
        }
        public void bt_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            string search = bt.Text.ToString();
        }
        // -------------------------------------------------------- END CREATE BUTTON -----------------------------------------------//
        private void Statistics_of_hospital_beds_Load(object sender, EventArgs e)
        {
            
        }
        int ina = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            ++ina;
            if(ina > 0)
            {
                CreateButton(panel6); 
            }
            
        }
    }
}
