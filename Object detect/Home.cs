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
            panel_Emergency_department.Visible = false;
            panel_Sub_Internal_medicine_department.Visible = false;
            //...
        }

        private void HideSubMenu()
        {
            if (panel_Emergency_department.Visible == true)
                panel_Emergency_department.Visible = false;
            if (panel_Sub_Internal_medicine_department.Visible == true)
                panel_Sub_Internal_medicine_department.Visible = false;
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
            showSubMenu(panel_Emergency_department);
        }

        private void btn_Internal_medicine_department_Click(object sender, EventArgs e)
        {
            showSubMenu(panel_Sub_Internal_medicine_department);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            openChildForm(new Statistics_of_hospital_beds());


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

        private void panel_main_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            rick_txt_send.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, rick_txt_send.Width, rick_txt_send.Height, 30, 30));
        }
    }
}
