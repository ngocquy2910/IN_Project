using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Object_detect
{
    class Connect_SQL_IN
    {
        //-----------------------------BEGIN: TẠO LIÊN KẾT ĐẾN MYSQL--------------------------------------------------------
        public static MySqlConnection Connect_MySql(string host, int port, string database, string username, string password)
        {
            // Connection String.
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }

        public static MySqlConnection GetDBConnection()
        {
            string host = "127.0.0.1";
            int port = 3307;
            string database = "in_data";
            string username = "root";
            string password = "";
            MySqlConnection conn = Connect_MySql(host,port,database,username,password);
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            return conn;
        }
        //-------------------------------------END: LIÊN KẾT TỚI SQL-------------------------------------------------------------------

        public static int TongKhoaINT()
        {
            int s;
            string query = " SELECT TongKhoaINT()";
            MySqlConnection conn = GetDBConnection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            s = (int)cmd.ExecuteScalar();
            conn.Close();
            return s;
            
        }
        public static int TongGiuong(string MP)
        {
            int s;
            string query = " SELECT TongGiuong('"+MP+"')";
            MySqlConnection conn = GetDBConnection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            s = (int)cmd.ExecuteScalar();
            conn.Close();
            return s;
        }
        public static int TongGiuongUse(string MP)
        {
            int s;
            string query = " SELECT TongGiuongUse('"+MP+"')";
            MySqlConnection conn = GetDBConnection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            s = (int)cmd.ExecuteScalar();
            conn.Close();
            return s;
        }
        public static int TongGiuongTrong(string MP)
        {
            int s;
            string query = " SELECT TongGiuongTrong('"+MP+"')";
            MySqlConnection conn = GetDBConnection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            s = (int)cmd.ExecuteScalar();
            conn.Close();
            return s;
        }

        //-------------------------------------BEGIN: Hiển thị thông tin khoa----------------------------------------------------------
        public static void HienThiTenKhoa(Button khoa, int i)
        {
            string query = "SELECT TenKhoa FROM khoa WHERE MaKhoa = 'KH00"+i+"' ";
            MySqlConnection conn = GetDBConnection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader DTRead = cmd.ExecuteReader();
            if(DTRead.HasRows)
            {
                DTRead.Read();
                khoa.Text = DTRead[0].ToString();
                khoa.Name = DTRead[0].ToString();
            }
            conn.Close();

        }
        //-------------------------------------END: Hiển thị thông tin khoa------------------------------------------------------------

        //-------------------------------------BEGIN: Hiển thị thông tin Giương----------------------------------------------------------
      
       
        public static void HienThiTTGiuong(Button G,int i, string MP)
        {
            
            if(i > LayMaGiuongDauCuoi_MP(MP))
            {
                i = LayMaGiuongDauTien_MP(MP);
                HienThiTTGiuong(G, i,MP);
            }
            else
            {
                string SoGiuong = "SG000";
                if (i < 10)
                {
                    SoGiuong = "SG000";
                }
                if (i >= 10 && i < 100)
                {
                    SoGiuong = "SG00";
                }
                string query = "SELECT * FROM giuong WHERE SoGiuong = '" + SoGiuong + "" + i + "' AND MaPhong = '" + MP + "'";
                // MessageBox.Show(query);
                MySqlConnection conn = GetDBConnection();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader DTRead = cmd.ExecuteReader();
                if (DTRead.HasRows)
                {
                    int tt = 0;
                    DTRead.Read();
                    G.Text = DTRead[0].ToString();
                    G.Name = DTRead[0].ToString();
                    tt = int.Parse(DTRead[3].ToString());
                    if (tt == 1)
                    {
                        G.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                    }
                }
                else
                {
                    G.Visible = false;
                }
                conn.Close();
            }

        }

        //-------------------------------------END: Hiển thị thông tin Giương------------------------------------------------------------

        //-------------------------------------Begin: Hiển thị CBB--------------------------------------------
        public static void HienThiCBB(string query, string id, string ten, ComboBox cbb)
        {
            string sql = query;
            MySqlConnection conn = GetDBConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = System.Data.CommandType.Text;
            DataTable dt = new DataTable();
            MySqlDataAdapter DTA = new MySqlDataAdapter(cmd);
            DTA.Fill(dt);
            if (DTA != null)
            {
                cbb.ValueMember = id;
                cbb.DisplayMember = ten;
                cbb.DataSource = dt;
            }
            conn.Close();
        }
        //-------------------------------------END: Hiển thị CBB--------------------------------------------
        //-------------------------------------Begin: Lấy mã giường đầu tiên trong phòng MPx-----------------
        public static int LayMaGiuongDauTien_MP(string MP)
        {
            int SG;
            string s = "";
            string query = "SELECT SoGiuong FROM giuong WHERE giuong.MaPhong = '"+MP+"' ORDER BY SoGiuong LIMIT 1";
            MySqlConnection conn = GetDBConnection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            if(cmd.ExecuteScalar() != null)
            {
                s = cmd.ExecuteScalar().ToString();
                string s2 = s.Substring(2);
                SG = int.Parse(s2.ToString());
                conn.Close();
                return SG;
            }
            else
            {
                MessageBox.Show("Hiện tại phòng này chưa có giường bệnh nào!");
                conn.Close();
                return 0;
            }
           

        }

        public static int LayMaGiuongDauCuoi_MP(string MP)
        {
            int SG;
            string s = "";
            string query = "SELECT SoGiuong FROM giuong WHERE giuong.MaPhong = '" + MP + "' ORDER BY SoGiuong DESC LIMIT 1";
            MySqlConnection conn = GetDBConnection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            if (cmd.ExecuteScalar() != null)
            {
                s = cmd.ExecuteScalar().ToString();
                string s2 = s.Substring(2);
                SG = int.Parse(s2.ToString());
                conn.Close();
                return SG;
            }
            else
            {
                conn.Close();
                return 0;
            }
           
        }
        //-------------------------------------END: Lấy mã giường đầu tiên trong phòng MPx-----------------

        //-------------------------------------BEGIN: Thông tin chi tiết bệnh án-----------------------------
        public static void HienThiCTBA(Label SG, Label BA, Label BN,string S)
        {
            string query = "SELECT g.SoGiuong, ba.ChuanDoanBenh, bn.TenBN FROM giuong g, benhan ba, benhnhan bn WHERE g.MaBA = ba.MaBA AND ba.MaBN = bn.MaBN AND g.SoGiuong = '"+S+"'";
            MySqlConnection conn = GetDBConnection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            
            MySqlDataReader DTRead = cmd.ExecuteReader();
            if (DTRead.HasRows)
            {
                DTRead.Read();
                SG.Text = DTRead[0].ToString();
                BA.Text = DTRead[1].ToString();
                BN.Text = DTRead[2].ToString();
            }
            else 
            {
                SG.Text = "";
                BA.Text = "";
                BN.Text = "";
            }
            conn.Close();
        }

        public static void HienThiCTBN(string S, Label MaBA, Label BN, Label SDT, Label DC, Label GT, Label T, Label CDB, Label BS, Label NN)
        {
            string query = "SELECT ba.MaBA, bn.MaBN, bn.TenBN,bn.DiaChi,bn.SDT,bn.GioiTinh,bn.Tuoi,ba.ChuanDoanBenh,bs.TenBS, ba.NgayNhap FROM giuong g, benhan ba, benhnhan bn , bacsi bs WHERE g.MaBA = ba.MaBA AND ba.MaBN = bn.MaBN AND ba.MaBS = bs.MaBS AND g.SoGiuong = '"+S+"'";
            MySqlConnection conn = GetDBConnection();
            MySqlCommand cmd = new MySqlCommand(query, conn);

            MySqlDataReader DTRead = cmd.ExecuteReader();
            if (DTRead.HasRows)
            {
                int giotinh = 0;
                DTRead.Read();
                MaBA.Text = DTRead[0].ToString();
               // MaBA.Text = DTRead[1].ToString();
                BN.Text = DTRead[2].ToString();
                DC.Text = DTRead[3].ToString();
                SDT.Text = DTRead[4].ToString();
                giotinh = int.Parse(DTRead[5].ToString());
                T.Text = DTRead[6].ToString();
                CDB.Text = DTRead[7].ToString();
                BS.Text = DTRead[8].ToString();
                NN.Text = DTRead[9].ToString();

                if(giotinh == 0)
                {
                    GT.Text = "Nam";
                }
                else
                {
                    GT.Text = "Nữ";
                }
            }
           
            conn.Close();
        }
        //-------------------------------------END: Thông tin chi tiết bệnh án------------------------------
    }
}
