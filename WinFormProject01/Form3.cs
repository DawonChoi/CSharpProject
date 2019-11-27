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
    public partial class Form3 : Form
    {
        public static string master_agency;
        private int exCount = 1;

        public Form3()
        {
            InitializeComponent();
        }

        MySqlConnection conn;
        MySqlDataAdapter dataAdapter;
        DataSet dataSet;
        Form1 form1;

        private void Form3_Load(object sender, EventArgs e)
        {
            string connStr = "server=localhost;port=3306;database=mydatabase;uid=root;pwd=cd101368@";
            conn = new MySqlConnection(connStr);
            dataSet = new DataSet();
            dataAdapter = new MySqlDataAdapter("SELECT * FROM kpopgroup", conn);

            label1.Text = master_agency;

            string sql = "SELECT distinct agencyname FROM agency";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            form1 = new Form1();

            try
            {
                // CountryCode 목록 표시
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())  // 다음 레코드가 있으면 true
                {
                    comboBox1.Items.Add(reader.GetString("agencyname"));
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void tbDate_Click(object sender, EventArgs e)
        {
            if(exCount == 1)
            {
                tbDate.Clear();
                exCount++;
            }
        }

        private void btn_addGroup_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO kpopgroup(groupname, membercount, debutdate, agency) " +
    "VALUES(@groupname, @membercount, @debutdate, @agency)";

            if (tbGroupName.Text != "" && tbMember.Text != "" && tbDate.Text != "")
            {
                dataAdapter.InsertCommand = new MySqlCommand(sql, conn);
                #region 변수 처리
                dataAdapter.InsertCommand.Parameters.Add("@groupname", MySqlDbType.VarChar);
                dataAdapter.InsertCommand.Parameters.Add("@membercount", MySqlDbType.Int32);
                dataAdapter.InsertCommand.Parameters.Add("@debutdate", MySqlDbType.Date);
                dataAdapter.InsertCommand.Parameters.Add("@agency", MySqlDbType.VarChar);

                dataAdapter.InsertCommand.Parameters["@groupname"].Value = tbGroupName.Text;
                dataAdapter.InsertCommand.Parameters["@membercount"].Value = tbMember.Text;
                dataAdapter.InsertCommand.Parameters["@debutdate"].Value = tbDate.Text;
                dataAdapter.InsertCommand.Parameters["@agency"].Value = comboBox1.Text;
                #endregion
                try
                {
                    DataGridView dv = form1.GetGridView();

                    conn.Open();
                    dataAdapter.InsertCommand.ExecuteNonQuery();

                    dataSet.Clear();
                    dataAdapter.Fill(dataSet, "group");
                    dv.DataSource = dataSet.Tables["group"];

                    MessageBox.Show("새로운 그룹이 생성되었습니다.");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }

            }
        }
    }
}
