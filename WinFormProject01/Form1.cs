using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormProject01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MySqlConnection conn;
        MySqlDataAdapter dataAdapter;
        DataSet dataSet;
        Form3 form3 = new Form3();
        int selectedRowIndex;

        string[] master_members = { "제니", "지수", "리사", "로제", "최다원"};

        private void Form1_Load(object sender, EventArgs e)
        {

            DrawPicture(@"C:\C#-workspace\WinFormPJ01\WinFormProject\WinFormProject01\resources\" + "default.jpg");
            string connStr = "server=localhost;port=3306;database=mydatabase;uid=root;pwd=cd101368@";
            conn = new MySqlConnection(connStr);
            dataAdapter = new MySqlDataAdapter("SELECT * FROM agency", conn);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "agency");
            dataGridView1.DataSource = dataSet.Tables["agency"];

            SetSearchComboBox();
        }

        public DataGridView GetGridView()
        {
            return this.dataGridView1;
        }

        public ComboBox GetComboBoxAgency()
        {
            return this.cbAgency;
        }

        public ComboBox GetComboBoxGroup()
        {
            return this.cbGroup;
        }

        private void SetSearchComboBox()
        {
            string sql = "SELECT agencyname FROM agency";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                // CountryCode 목록 표시
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())  // 다음 레코드가 있으면 true
                {
                    cbAgency.Items.Add(reader.GetString("agencyname"));
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

        private void cbAgency_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cleaner();
            string sql = "select groupname from kpopgroup where agency = @agency";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@agency", cbAgency.Text);

            cbGroup.Items.Clear();

            try
            {
                // District 목록 표시
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())  // 다음 레코드가 있으면 true
                {
                    cbGroup.Items.Add(reader.GetString("groupname"));
                }
                reader.Close();

                dataAdapter = new MySqlDataAdapter($"SELECT * FROM kpopgroup where agency = '{cbAgency.Text}'", conn);
                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "kpopgroup");
                dataGridView1.DataSource = dataSet.Tables["kpopgroup"];
                Form3.master_agency = cbAgency.Text;
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

        private void Cleaner()
        {
            cbMember.Items.Clear();
            cbGroup.Items.Clear();
            cbMember.Text = "";
            cbGroup.Text = "";
            lbName.Text = "";
            DrawPicture(@"C:\C#-workspace\WinFormPJ01\WinFormProject\WinFormProject01\resources\" + "default.jpg");
        }

        private void cbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMember.Items.Clear();
            cbMember.Text = "";
            DrawPicture(@"C:\C#-workspace\WinFormPJ01\WinFormProject\WinFormProject01\resources\" + "default.jpg");

            string sql = "select name from g_member where memberof = @memberof";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@memberof", cbGroup.Text);

            try
            {
                // District 목록 표시
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())  // 다음 레코드가 있으면 true
                {
                    cbMember.Items.Add(reader.GetString("name"));
                }
                reader.Close();

                dataAdapter = new MySqlDataAdapter($"SELECT * FROM g_member where memberof = '{cbGroup.Text}'", conn);
                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "g_member");
                dataGridView1.DataSource = dataSet.Tables["g_member"];
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

        private void cbMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            string picture = cbMember.Text;
            string p_dic = @"C:\C#-workspace\WinFormPJ01\WinFormProject\WinFormProject01\resources\" + ConfirmPicture(picture) + ".jpg";

            dataAdapter = new MySqlDataAdapter($"SELECT * FROM g_member where memberof = '{cbGroup.Text}' and name = '{cbMember.Text}'", conn);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "g_member");
            dataGridView1.DataSource = dataSet.Tables["g_member"];

            DrawPicture(p_dic);
            lbName.Text = cbMember.Text;
            

        }

        private void DrawPicture(string dic)
        {
            // // 소스이미지 가져오기
            var src = (Bitmap)Bitmap.FromFile(dic);

            // 소스이미지 크기와 동일한 타겟이미지 생성
            Bitmap tgt = new Bitmap(src.Width, src.Height);

            // 타겟이미지의 Graphics 객체 얻기        
            using (Graphics g = Graphics.FromImage(tgt))
            {
                // 배경색을 설정
                var rect = new Rectangle(0, 0, tgt.Width, tgt.Height);
                using (Brush br = new SolidBrush(SystemColors.Control))
                {
                    g.FillRectangle(br, 0, 0, tgt.Width, tgt.Height);
                }

                // 원모양으로 Clip
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, tgt.Width, tgt.Height);
                g.SetClip(path);

                // 소스이미지를 원모양으로 잘라 타겟이미지에 출력
                g.DrawImage(src, 0, 0);
            }

            // PictureBox에 이미지 출력
            pictureBox1.Image = tgt;
        }

        private string ConfirmPicture(string picture)
        {

            for (int p_index = 0; p_index < master_members.Length; p_index++)
            {
                if (picture == master_members[p_index])
                   return master_members[p_index];
            }

            return "default";
        }

        private void btn_addMember_Click(object sender, EventArgs e)
        {
            if (tbName.Text != "" && tbAge.Text != "" && tbPart.Text != "") {
                if (cbGroup.Text != "")
                {
                    string[] rowDatas = { // 그룹박스가 비었다면 rowDatas에 결점이 생김
                    tbName.Text, tbAge.Text, tbPart.Text, cbGroup.Text
                };
                    InsertMember(rowDatas);
                }
                else if (cbGroup.Text == "" && cbAgency.Text == "")
                {
                    Form2 AgencyMaker = new Form2();
                    AgencyMaker.Owner = this;               // 새로운 폼의 부모가 Form1 인스턴스임을 지정
                    AgencyMaker.ShowDialog();               // 폼 띄우기(Modal)
                    AgencyMaker.Dispose();
                }
                else
                {
                    Form3 GroupMaker = new Form3();
                    GroupMaker.Owner = this;
                    GroupMaker.ShowDialog();
                    GroupMaker.Dispose();
                }
                tbName.Clear();
                tbAge.Clear();
                tbPart.Clear();
            }
            else
            {
                MessageBox.Show("모든 정보를 입력하세요.");
            }
        }


        private void InsertMember(string[] rowDatas)
        {
            string sql = "INSERT INTO g_member(name, age, part, memberof) " +
                "VALUES(@name, @age, @part, @memberof)";
            dataAdapter.InsertCommand = new MySqlCommand(sql, conn);
            #region 변수 처리
            dataAdapter.InsertCommand.Parameters.Add("@name", MySqlDbType.VarChar);
            dataAdapter.InsertCommand.Parameters.Add("@age", MySqlDbType.Int32);
            dataAdapter.InsertCommand.Parameters.Add("@part", MySqlDbType.VarChar);
            dataAdapter.InsertCommand.Parameters.Add("@memberof", MySqlDbType.VarChar);

            dataAdapter.InsertCommand.Parameters["@name"].Value = rowDatas[0];
            dataAdapter.InsertCommand.Parameters["@age"].Value = int.Parse(rowDatas[1]);
            dataAdapter.InsertCommand.Parameters["@part"].Value = rowDatas[2];
            dataAdapter.InsertCommand.Parameters["@memberof"].Value = rowDatas[3];
            #endregion
            try
            {
                conn.Open();
                dataAdapter.InsertCommand.ExecuteNonQuery();

                dataSet.Clear();                                        // 이전 데이터 지우기
                dataAdapter.Fill(dataSet, "g_member");                      // DB -> DataSet
                dataGridView1.DataSource = dataSet.Tables["g_member"];      // dataGridView에 테이블 표시                                     // 텍스트 박스 내용 지우기
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRowIndex = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[selectedRowIndex];
                if ((cbMember.Text != "") || (cbAgency.Text != "" && cbGroup.Text != ""))
                {
                    Form4 memberForm = new Form4(row.Cells[0].Value.ToString(),
                        int.Parse(row.Cells[1].Value.ToString()), row.Cells[2].Value.ToString(),
                        row.Cells[3].Value.ToString());

                    memberForm.Owner = this;
                    memberForm.ShowDialog();
                    memberForm.Dispose();
                }
                else if (cbAgency.Text != "" && cbGroup.Text == "")
                {
                    Form4 groupForm = new Form4(row.Cells[0].Value.ToString(),
                        int.Parse(row.Cells[1].Value.ToString()), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), true);

                    groupForm.Owner = this;
                    groupForm.ShowDialog();
                    groupForm.Dispose();
                }
                else if (cbAgency.Text == "" && cbGroup.Text == "" && cbMember.Text == "")
                {
                    Form4 AgencyForm = new Form4(row.Cells[0].Value.ToString(),
                        row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString());

                    AgencyForm.Owner = this;
                    AgencyForm.ShowDialog();
                    AgencyForm.Dispose();
                }
            }catch(Exception)
            {

            }

        }

        private void oversee_Click(object sender, EventArgs e)
        {
            lbName.Text = "";
            cbAgency.Text = "";
            cbGroup.Text = "";
            cbMember.Text = "";

            dataAdapter = new MySqlDataAdapter("SELECT * FROM agency", conn);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "agency");
            dataGridView1.DataSource = dataSet.Tables["agency"];
            DrawPicture(@"C:\C#-workspace\WinFormPJ01\WinFormProject\WinFormProject01\resources\" + "default.jpg");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
