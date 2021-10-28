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
using MySql.Data.MySqlClient;
using System.Globalization;

namespace Object_detect
{
    public partial class Patient_follow_up : Form
    {
        public Patient_follow_up()
        {
            InitializeComponent();
        }

        private void Patient_follow_up_Load(object sender, EventArgs e)
        {
            ConnectionToDB();
            checkIndex();
            timer1.Enabled = true;
        }

        private string query = "select * from healthindex order by InsertAt desc LIMIT 10";
        private string MySQLConnectionString = "Server=127.0.0.1; Port=3307; Database=yersintalent; Uid=root; Pwd=root; SslMode=none;";
        MySqlConnection databaseConnection;
        MySqlCommand commandDatabase;
        string[,] healthIndex = new string[4, 10];
        int test = 0;

        private void ConnectionToDB()
        {
            databaseConnection = new MySqlConnection(MySQLConnectionString);
            commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                if (myReader.HasRows)
                {
                    int temp = 0;
                    while (myReader.Read())
                    {
                        Console.WriteLine(myReader.GetString(0) + "-" + myReader.GetString(1) + "-" + myReader.GetString(2) + "-" + myReader.GetString(3));
                        for (int i = 0; i < 4; i++)
                        {
                            healthIndex[i, temp] = myReader.GetString(i);
                        }
                        temp++;
                    }
                }
                databaseConnection.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }

        private void openWarningForm(string a, string b)
        {
            WarningForm wf = new WarningForm(a, b);
            wf.Show();
        }

        private void checkIndex()
        {
            double avgTemp = (Convert.ToDouble(healthIndex[1, 7]) + Convert.ToDouble(healthIndex[1, 8]) + Convert.ToDouble(healthIndex[1, 9])) / 3;
            int avgHr = (Convert.ToInt32(healthIndex[2, 7]) + Convert.ToInt32(healthIndex[2, 8]) + Convert.ToInt32(healthIndex[2, 9])) / 3;
            int avgSpo2 = (Convert.ToInt32(healthIndex[3, 7]) + Convert.ToInt32(healthIndex[3, 8]) + Convert.ToInt32(healthIndex[3, 9])) / 3;

            if (Convert.ToDouble(healthIndex[1, 0]) > 39 && Convert.ToDouble(healthIndex[1, 0]) < 40)
            {
                openWarningForm("Lowlevel", "Temp");
                timer1.Enabled = false;
            }
            if (Convert.ToDouble(healthIndex[1, 0]) >= 40)
            {
                openWarningForm("Highlevel", "Temp");
                timer1.Enabled = false;
            }

            //HeartRate
        }

        private void DrawChart_Tick(object sender, EventArgs e)
        {
            ConnectionToDB();
            this.chartHeart.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
            chartHeart.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            chartHeart.Series[1].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            chartTemp.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            chartHeart.ChartAreas[0].AxisX.Minimum = DateTime.ParseExact(healthIndex[0, 9].Split(' ')[1], "HH:mm:ss", CultureInfo.InvariantCulture).ToOADate();
            chartHeart.ChartAreas[0].AxisX.Maximum = DateTime.ParseExact(healthIndex[0, 0].Split(' ')[1], "HH:mm:ss", CultureInfo.InvariantCulture).ToOADate();
            chartTemp.ChartAreas[0].AxisX.Minimum = DateTime.ParseExact(healthIndex[0, 9].Split(' ')[1], "HH:mm:ss", CultureInfo.InvariantCulture).ToOADate();
            chartTemp.ChartAreas[0].AxisX.Maximum = DateTime.ParseExact(healthIndex[0, 0].Split(' ')[1], "HH:mm:ss", CultureInfo.InvariantCulture).ToOADate();

            if (test > 9)
            {
                test = 0;
                chartHeart.Series[0].Points.RemoveAt(0);
                chartHeart.Series[1].Points.RemoveAt(0);
                chartHeart.Series[0].Points.RemoveAt(0);
            }
            test++;

            chartHeart.Series[0].Points.AddXY(DateTime.Parse(healthIndex[0, 0].Split(' ')[1]).ToOADate(), Convert.ToInt32(healthIndex[2, 0]));
            chartHeart.Series[1].Points.AddXY(DateTime.Parse(healthIndex[0, 0].Split(' ')[1]).ToOADate(), Convert.ToInt32(healthIndex[3, 0]));
            chartTemp.Series[0].Points.AddXY(DateTime.Parse(healthIndex[0, 0].Split(' ')[1]).ToOADate(), Convert.ToDouble(healthIndex[1, 0]));
            chartHeart.ResetAutoValues();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            checkIndex();
        }
    }
}
