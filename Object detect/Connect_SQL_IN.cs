using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
            int port = 3306;
            string database = "in_data";
            string username = "root";
            string password = "";
            MySqlConnection conn = Connect_MySql(host, port, database, username, password);
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
            return s;
        }

        //-------------------------------------BEGIN: Hiển thị thông tin khoa----------------------------------------------------------
        public static void HienThiTenKhoa(Button khoa, int i)
        {
            string query = "SELECT TenKhoa FROM khoa WHERE MaKhoa = 'KH00" + i + "' ";
            MySqlConnection conn = GetDBConnection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader DTRead = cmd.ExecuteReader();
            if (DTRead.HasRows)
            {
                DTRead.Read();
                khoa.Text = DTRead[0].ToString();
                khoa.Name = DTRead[0].ToString();
            }

        }
        //-------------------------------------END: Hiển thị thông tin khoa------------------------------------------------------------

    }
}
