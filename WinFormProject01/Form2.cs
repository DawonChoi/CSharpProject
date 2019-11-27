using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormProject01
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        MySqlConnection conn;
        MySqlDataAdapter dataAdapter;
        DataSet dataSet;
        Form1 mainForm = new Form1();

        private void Form2_Load(object sender, EventArgs e)
        {
            string connStr = "server=localhost;port=3306;database=mydatabase;uid=root;pwd=cd101368@";
            conn = new MySqlConnection(connStr);
            dataSet = new DataSet();
            dataAdapter = new MySqlDataAdapter("SELECT * FROM agency", conn);
        }

        private void btn_addAgency_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO agency(agencyname, ceo, address) " +
                "VALUES(@agencyname, @ceo, @address)";



            if(tbAgencyName.Text != "" && tbCeo.Text != "" && tbAddress.Text != "")
            {
                dataAdapter.InsertCommand = new MySqlCommand(sql, conn);
                #region 변수 처리
                dataAdapter.InsertCommand.Parameters.Add("@agencyname", MySqlDbType.VarChar);
                dataAdapter.InsertCommand.Parameters.Add("@ceo", MySqlDbType.VarChar);
                dataAdapter.InsertCommand.Parameters.Add("@address", MySqlDbType.VarChar);

                dataAdapter.InsertCommand.Parameters["@agencyname"].Value = tbAgencyName.Text;
                dataAdapter.InsertCommand.Parameters["@ceo"].Value = tbCeo.Text;
                dataAdapter.InsertCommand.Parameters["@address"].Value = tbAddress.Text;
                #endregion
                try
                {
                    DataGridView dv = mainForm.GetGridView();
                    ComboBox cb = mainForm.GetComboBoxAgency();

                    conn.Open();
                    dataAdapter.InsertCommand.ExecuteNonQuery();

                    dataSet.Clear();                                        
                    dataAdapter.Fill(dataSet, "agency");                      
                    dv.DataSource = dataSet.Tables["agency"];

                    string add_sql = $"select agencyname from agency where agencyname = '{tbAgencyName}'";
                    MySqlCommand cmd = new MySqlCommand(add_sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    reader = cmd.ExecuteReader();
                    while (reader.Read())  // 다음 레코드가 있으면 true
                    {
                        cb.Items.Add(reader.GetString("agencyname"));
                    }
                    reader.Close();

                    MessageBox.Show("새로운 소속사가 생성되었습니다.");
                    ClearAgencyInfo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("새로운 소속사가 생성되었습니다.");
                    //MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }

            }
        }

        private void ClearAgencyInfo()
        {
            tbAddress.Clear();
            tbCeo.Clear();
            tbAgencyName.Clear();
        }
    }
}
