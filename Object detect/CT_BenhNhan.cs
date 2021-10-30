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
    public partial class CT_BenhNhan : Form
    {
        string SG = "";
        public CT_BenhNhan(string sg)
        {
            InitializeComponent();
            SG = sg;
        }

        private void bt_Thoat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void CT_BenhNhan_Load(object sender, EventArgs e)
        {
            Connect_SQL_IN.HienThiCTBN(SG, lb_MaBA, lb_TenBN, lb_SDT, lb_DC, lb_GT, lb_Tuoi, lb_ChuanDoan, lb_BS,lb_NgayNhap) ;
            
        }
    }
}
