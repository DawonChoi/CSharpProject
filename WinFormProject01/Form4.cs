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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        MySqlConnection conn;
        MySqlDataAdapter dataAdapter;
        DataSet dataSet;

        int age;
        string name, part, agency;

        int g_count;
        string g_name, g_date, g_agency;

        string a_name, a_ceo, a_address;

        private bool isMember = false;
        private bool isGroup = false;
        private bool isAgency = false;

        public Form4(string name, int age, string part, string agency)
        {
            InitializeComponent();
            this.name = name;
            this.age = age;
            this.part = part;
            this.agency = agency;
            this.isMember = true;
        }

        public Form4(string g_name, int g_count, string g_date, string g_agency, bool isGroup)
        {
            InitializeComponent();
            this.g_name = g_name;
            this.g_count = g_count;
            this.g_date = g_date;
            this.g_agency = g_agency;
            this.isGroup = isGroup;
        }

        public Form4(string a_name, string a_ceo, string a_address)
        {
            InitializeComponent();
            this.a_name = a_name;
            this.a_ceo = a_ceo;
            this.a_address = a_address;
            this.isAgency = true;
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            string connStr = "server=localhost;port=3306;database=mydatabase;uid=root;pwd=cd101368@";
            conn = new MySqlConnection(connStr);
            dataAdapter = new MySqlDataAdapter("SELECT * FROM agency", conn);
            dataSet = new DataSet();

            if (isAgency)
                ShowAgency();
            else if (isGroup)
                ShowGroup();
            else if (isMember)
                ShowMember();

            SetLabel();

        }

        private void remover_Click(object sender, EventArgs e)
        {
            if (isAgency)
                RemoveAgency();
            else if (isGroup)
                RemoveGroup();
            else if (isMember)
                RemoveMember();
        }

        private void RemoveMember()
        {
            string sql = $"DELETE FROM g_member WHERE name = '{name}'";
            dataAdapter.DeleteCommand = new MySqlCommand(sql, conn);

            try
            {
                conn.Open();
                dataAdapter.DeleteCommand.ExecuteNonQuery();
                MessageBox.Show("멤버를 삭제하였습니다.");
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

        private void RemoveGroup()
        {
            string sql = $"DELETE FROM kpopgroup WHERE membercount = {g_count} and debutdate = '{g_date}'";
            dataAdapter.DeleteCommand = new MySqlCommand(sql, conn);

            try
            {
                conn.Open();
                dataAdapter.DeleteCommand.ExecuteNonQuery();
                MessageBox.Show("그룹을 삭제하였습니다.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("그룹의 속한 멤버를 먼저 삭제해주세요.");
            }
            finally
            {
                conn.Close();
            }
        }

        private void RemoveAgency()
        {
            string sql = $"DELETE FROM agency WHERE agencyname='{a_name}'";
            dataAdapter.DeleteCommand = new MySqlCommand(sql, conn);

            try
            {
                conn.Open();
                dataAdapter.DeleteCommand.ExecuteNonQuery();
                MessageBox.Show("소속사를 삭제하였습니다.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("해당 소속사의 그룹을 먼저 삭제해주세요");
            }
            finally
            {
                conn.Close();
            }
        }

        private void adjustor_Click(object sender, EventArgs e)
        {
           
            if (isAgency)
                AdjustAgency();
            else if (isGroup)
                AdjustGroup();
            else if (isMember)
                AdjustMember();
        }

        private void AdjustMember()
        {
            string condition;
            condition = CheckCondition();

            string sql = "UPDATE g_member SET " + condition + $" where name='{name}'";
            dataAdapter.UpdateCommand = new MySqlCommand(sql, conn);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@name", tb01.Text);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@age", tb02.Text);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@part", tb03.Text);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@memberof", tb04.Text);
            try
            {
                conn.Open();
                dataAdapter.UpdateCommand.ExecuteNonQuery();

                MessageBox.Show("멤버 정보를 갱신하였습니다.");

            }
            catch (Exception ex)
            {
                if(MessageBox.Show("존재하지 않는 그룹입니다, 새로운 그룹을 만드시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Form3 Dig = new Form3();
                    Dig.Owner = this;               
                    Dig.ShowDialog();              
                    Dig.Dispose();
                }

            }
            finally
            {
                conn.Close();
            }
        }

        private void AdjustGroup()
        {
            string condition;
            condition = CheckCondition();

            string sql = "UPDATE kpopgroup SET " + condition + $" where groupname='{g_name}'";
            dataAdapter.UpdateCommand = new MySqlCommand(sql, conn);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@groupname", tb01.Text);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@membercount", tb02.Text);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@debutdate", tb03.Text);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@agency", tb04.Text);
            try
            {
                conn.Open();
                dataAdapter.UpdateCommand.ExecuteNonQuery();
                MessageBox.Show("그룹 정보를 갱신하였습니다.");

            }
            catch (Exception ex)
            {
                if (MessageBox.Show("존재하지 않는 소속사입니다, 새로운 소속사를 만드시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Form2 Dig = new Form2();
                    Dig.Owner = this;
                    Dig.ShowDialog();
                    Dig.Dispose();
                }
            }
            finally
            {
                conn.Close();
            }
        }

        private void AdjustAgency()
        {
            string condition;
            condition = CheckCondition();

            string sql = "UPDATE agency SET "+ condition + $" where agencyname='{a_name}'";
            dataAdapter.UpdateCommand = new MySqlCommand(sql, conn);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@agencyname",tb01.Text);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@ceo",tb02.Text);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@address", tb03.Text);
            try
            {
                conn.Open();
                dataAdapter.UpdateCommand.ExecuteNonQuery();
                MessageBox.Show("소속사 정보를 갱신하였습니다.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("해당 소속사에 소속된 그룹이 존재하므로 소속사이름을 수정할 수 없습니다.");
            }
            finally
            {
                conn.Close();
            }
        }

        private string CheckCondition()
        {
            string master_condition = "";

            if(isAgency)
            {
                string[] conditions = new string[3];
                conditions[0] = (tb01.Text != "") ? "agencyname=@agencyname" : null;
                conditions[1] = (tb02.Text != "") ? "ceo=@ceo" : null;
                conditions[2] = (tb03.Text != "") ? "address=@address" : null;


                if(conditions[0] != null || conditions[1] != null || conditions[2] != null)
                {
                    bool first = true;
                    for (int i = 0; i < conditions.Length; i++)
                    {
                        if(conditions[i] != null)
                        {
                            if(first)
                            {
                                master_condition += conditions[i];
                                first = false;
                            }
                            else
                            {
                                master_condition += ("," + conditions[i]);
                            }
                        }
                    }
                }
                
                return master_condition;
            }else if (isGroup)
            {
                string[] conditions = new string[4];
                conditions[0] = (tb01.Text != "") ? "groupname=@groupname" : null;
                conditions[1] = (tb02.Text != "") ? "membercount=@membercount" : null;
                conditions[2] = (tb03.Text != "") ? "debutdate=@debutdate" : null;
                conditions[3] = (tb04.Text != "") ? "agency=@agency" : null;

                if (conditions[0] != null || conditions[1] != null || conditions[2] != null || conditions[3] != null)
                {
                    bool first = true;
                    for (int i = 0; i < conditions.Length; i++)
                    {
                        if (conditions[i] != null)
                        {
                            if (first)
                            {
                                master_condition += conditions[i];
                                first = false;
                            }
                            else
                            {
                                master_condition += ("," + conditions[i]);
                            }
                        }
                    }
                }

                return master_condition;
            }else if(isMember)
            {
                string[] conditions = new string[4];
                conditions[0] = (tb01.Text != "") ? "name=@name" : null;
                conditions[1] = (tb02.Text != "") ? "age=@age" : null;
                conditions[2] = (tb03.Text != "") ? "part=@part" : null;
                conditions[3] = (tb04.Text != "") ? "memberof=@memberof" : null;

                if (conditions[0] != null || conditions[1] != null || conditions[2] != null || conditions[3] != null)
                {
                    bool first = true;
                    for (int i = 0; i < conditions.Length; i++)
                    {
                        if (conditions[i] != null)
                        {
                            if (first)
                            {
                                master_condition += conditions[i];
                                first = false;
                            }
                            else
                            {
                                master_condition += ("," + conditions[i]);
                            }
                        }
                    }
                }

                return master_condition;
            }
                

            return null;
        }

        private void SetLabel()
        {
           if(isAgency)
            {
                label01.Text = "소속사 이름";
                label02.Text = "CEO 이름";
                label03.Text = "주소";
                label04.Text = "해당 없음";
                tb04.Enabled = false;
            }else if(isGroup)
            {
                label01.Text = "그룹 이름";
                label02.Text = "멤버 수";
                label03.Text = "데뷔 일자";
                label04.Text = "소속사";
            }
            else if(isMember)
            {
                label01.Text = "이름";
                label02.Text = "나이";
                label03.Text = "역할";
                label04.Text = "소속그룹";
            }
        }

        private void ShowMember()
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter($"select * from g_member where name='{name}'", conn);
            DataSet dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "g_member");
            dataGridView1.DataSource = dataSet.Tables["g_member"];
        }

        private void ShowGroup()
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter($"select * from kpopgroup where groupname='{g_name}'", conn);
            DataSet dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "kpopgroup");
            dataGridView1.DataSource = dataSet.Tables["kpopgroup"];
        }

        private void ShowAgency()
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter($"select * from agency where agencyname='{a_name}'", conn);
            DataSet dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "agency");
            dataGridView1.DataSource = dataSet.Tables["agency"];

        }
    }
}