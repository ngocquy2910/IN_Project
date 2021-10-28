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
    public partial class Home : Form
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
        public Home()
        {
            InitializeComponent();
            An_panel();

        }

        private void An_panel()
        {
           // panel_Emergency_department.Visible = false;
           // panel_Sub_Internal_medicine_department.Visible = false;
            //...
        }

        private void HideSubMenu()
        {
          //  if (panel_Emergency_department.Visible == true)
             //   panel_Emergency_department.Visible = false;
              //if (panel_Sub_Internal_medicine_department.Visible == true)
                //panel_Sub_Internal_medicine_department.Visible = false;
        }

        private void showSubMenu(Panel A)
        {
            if (A.Visible == false)
            {
                HideSubMenu();
                A.Visible = true;
            }
            else
                A.Visible = false;
        }

        private void btn_Emergency_department_Click(object sender, EventArgs e)
        {
            //showSubMenu(panel_Emergency_department);
        }

        private void btn_Internal_medicine_department_Click(object sender, EventArgs e)
        {
            //showSubMenu(panel_Sub_Internal_medicine_department);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            HideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HideSubMenu();
        }

        private Form activeForm = null;
        private void openChildForm(Form ChildForm)
        {
            if (activeForm != null) //Form dang mở
                activeForm.Close();
            activeForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            panel_main.Controls.Add(ChildForm);
            panel_main.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            openChildForm(new Home2());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new General_Medical());
            HideSubMenu();
        }

        private void btn_AI_Medicine_Click(object sender, EventArgs e)
        {
            openChildForm(new AI_Medicine());
            HideSubMenu();
        }

        private void btn_StatisticsOfHospitalBeds_Click(object sender, EventArgs e)
        {
            openChildForm(new Statistics_of_hospital_beds());
            HideSubMenu();
        }

        private void btn_surgery_Click(object sender, EventArgs e)
        {
            HideSubMenu();
        }

        private void btn_Follow_Click(object sender, EventArgs e)
        {
            openChildForm(new Patient_follow_up());
            HideSubMenu();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            rick_txt_send.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, rick_txt_send.Width, rick_txt_send.Height, 30, 30));
            Connect_SQL_IN.GetDBConnection(); // conncet Mysql;
            HienThiKhoa();
        }

        //-----------------------------------------BEGIN: Hiển Thị Khoa------------------------------------------------------
        Panel A = null;
        int x = 70;
        public void HienThiKhoa()
        {
            A = new Panel();
            Button Home = new Button();
            Home.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(56)))), ((int)(((byte)(143)))));
            Home.FlatAppearance.BorderSize = 0;
            Home.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            Home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Home.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Home.ForeColor = System.Drawing.Color.White;
            Home.Image = global::Object_detect.Properties.Resources.home__1_;
            Home.Location = new System.Drawing.Point(0, 0);
            Home.Name = "btn_home";
            Home.Size = new System.Drawing.Size(222, 69);
            Home.TabIndex = 0;
            Home.Text = "HOME";
            Home.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            Home.UseVisualStyleBackColor = false;
            Home.Click += new System.EventHandler(this.btn_home_Click);
            this.panel_Directional.Controls.Add(Home);
            int TongKhoa = Connect_SQL_IN.TongKhoaINT();
            for(int i=1; i<=TongKhoa;i++)
            {
                Button Khoa = new Button();
                Khoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(56)))), ((int)(((byte)(143)))));
                Khoa.FlatAppearance.BorderColor = System.Drawing.Color.White;
                Khoa.FlatAppearance.BorderSize = 0;
                Khoa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                Khoa.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
                Khoa.ForeColor = System.Drawing.Color.White;
                Khoa.Location = new System.Drawing.Point(0, x);
                Khoa.Name = "btn_Emergency_department";
                Khoa.Size = new System.Drawing.Size(222, 45);
                Khoa.TabIndex = 2;
              //  Khoa.Text = "NÚT TEST "+ i;
                Khoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                Khoa.UseVisualStyleBackColor = false;
               // Khoa.Click += new System.EventHandler(this.Btn_General_Medical);
         
                Connect_SQL_IN.HienThiTenKhoa(Khoa, i);
                this.panel_Directional.Controls.Add(Khoa);
                x += 45;

                if(Khoa.Name == "Emergency department")
                {
                      Khoa.Click += new System.EventHandler(this.Btn_General_Medical);
                }
                if(Khoa.Name == "Patient follow-up")
                {
                  // Khoa.Click += new System.EventHandler(this.Btn_Patient_follow_up); // Lỗi hiển thị vô hạn.
                }
                if (Khoa.Name == "Statistics of hospital beds" || Khoa.Name == "Genenal Medical"|| Khoa.Name == "Patient follow-up")
                {
                    Khoa.Click += new System.EventHandler(this.Btn_Statistics_of_hospital_beds);
                }
            }
        }

        //-----------------------------------------END: Hiển Thị Khoa--------------------------------------------------------
        //-----------------------------------------BEGIN: Tạo Sự kiện button----------------------------------------------
        private void buttonClick(object sender, EventArgs e)
        {
            Button current = (Button)sender;
            MessageBox.Show(current.Name);
        }
        
        private void Btn_General_Medical(Object sender, EventArgs e)
        {
            Button current = (Button)sender;
            openChildForm(new General_Medical());
        }

        private void Btn_Patient_follow_up(Object sender, EventArgs e)
        {
            Button current = (Button)sender;
            openChildForm(new Patient_follow_up());
        }

        private void Btn_Statistics_of_hospital_beds(Object sender, EventArgs e)
        {
            Button current = (Button)sender;
            openChildForm(new Statistics_of_hospital_beds());
        }

        //-----------------------------------------END: Tạo Sự kiện button------------------------------------------------
    }


}
