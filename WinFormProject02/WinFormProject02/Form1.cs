using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace WinFormProject02
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        MySqlDataAdapter dataAdapter, dataAdapter2, dataAdapter3;
        DataSet dataSet, dataSet2, dataSet3;
        int selectedRowIndex;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
            string connStr = "server=localhost;port=3306;database=trafficissue;uid=root;pwd=cd101368@";
            conn = new MySqlConnection(connStr);
            dataAdapter = new MySqlDataAdapter("SELECT * FROM person", conn);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "person");
            dataGridView1.DataSource = dataSet.Tables["person"];

            dataAdapter = new MySqlDataAdapter("SELECT * FROM accident", conn);
            dataAdapter.Fill(dataSet, "accident");
            dataGridView2.DataSource = dataSet.Tables["accident"];

            dataAdapter = new MySqlDataAdapter("SELECT * FROM city", conn);
            dataAdapter.Fill(dataSet, "city");
            dataGridView3.DataSource = dataSet.Tables["city"];



            SetSearchComboBox();
        }

        #region ComboBox 세팅
        // **** 검색 조건 ComboBox에 CountryCode 목록 세팅 ****
        private void SetSearchComboBox()
        {
            string sql = "SELECT distinct cityname FROM city";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                // CountryCode 목록 표시
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())  // 다음 레코드가 있으면 true
                {
                    cbCity.Items.Add(reader.GetString("cityname"));
                }
                reader.Close();

                cbInsurance.Items.Add(0);
                cbInsurance.Items.Add(1);
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
        #endregion

        // **** SELECT 버튼 클릭 ****
        private void btnSelect_Click(object sender, EventArgs e)
        {
            string queryStr = "SELECT * FROM person WHERE ";

            string[] conditions = new string[5];
            conditions[0] = (tbTel.Text != "") ? "tel=@tel" : null;
            conditions[1] = (tbName.Text != "") ? "name=@name" : null;
            conditions[2] = (tbAge.Text != "") ? "age=@age" : null;
            conditions[3] = (cbCity.Text != "") ? "city=@city" : null;
            conditions[4] = (cbInsurance.Text != "") ? "insurance=@insurance" : null;

            if(tbTel.Text != "" || tbName.Text != "" || tbAge.Text != "" || cbCity.Text != "" || cbInsurance.Text != "")
            {
                bool isFirst = true;

                for (int i = 0; i < conditions.Length; i++)
                {
                    if(conditions[i] != null)
                    {
                        if(isFirst)
                        {
                            queryStr += conditions[i];
                            isFirst = false;
                        }
                        else
                        {
                            queryStr += ", " + conditions[i];
                        }
                    }
                    
                }
            }
            else
            {
                queryStr = "SELECT * FROM person";
            }

            #region SelectCommand 객체 생성 및 Parameters 설정
            dataAdapter.SelectCommand = new MySqlCommand(queryStr, conn);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@tel", tbTel.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@name", tbName.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@age", tbAge.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@city", cbCity.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@insurance", cbInsurance.Text);
            #endregion

            try
            {
                conn.Open();
                dataSet.Clear();
                if (dataAdapter.Fill(dataSet, "person") > 0)
                    dataGridView1.DataSource = dataSet.Tables["person"];
                else
                    MessageBox.Show("찾는 데이터가 없습니다.");
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

        // **** DataGridView에서 행을 선택하면 새창을 띄움 ****
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRowIndex];

            // 새로운 폼에 선택된 row의 정보를 담아서 생성
            Form2 Dig = new Form2(
                selectedRowIndex,
                row.Cells[0].Value.ToString(),
                row.Cells[1].Value.ToString(),
                row.Cells[2].Value.ToString(),
                row.Cells[3].Value.ToString(),
                row.Cells[4].Value.ToString()
                );

            Dig.Owner = this;               // 새로운 폼의 부모가 Form1 인스턴스임을 지정
            Dig.ShowDialog();               // 폼 띄우기(Modal)
            Dig.Dispose();
        }

        // **** Insert SQL 실행 ****
        public void InsertRow(string[] rowDatas)
        {
            string queryStr = "INSERT INTO person (tel, name, age, city, insurance) " +
                "VALUES(@tel, @name, @age, @city, @insurance)";
            dataAdapter.InsertCommand = new MySqlCommand(queryStr, conn);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@tel", rowDatas[0]);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@name", rowDatas[1]);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@age", rowDatas[2]);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@city", rowDatas[3]);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@insurance", rowDatas[4]);

            try
            {
                conn.Open();
                dataAdapter.InsertCommand.ExecuteNonQuery();

                dataSet.Clear();                                        // 이전 데이터 지우기
                dataAdapter.Fill(dataSet, "person");                      // DB -> DataSet
                dataGridView1.DataSource = dataSet.Tables["person"];      // dataGridView에 테이블 표시                                     // 텍스트 박스 내용 지우기
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

        // **** Delete SQL 실행 ****
        internal void DeleteRow(string id)
        {
            string sql = "DELETE FROM person WHERE tel=@tel";
            dataAdapter.DeleteCommand = new MySqlCommand(sql, conn);
            dataAdapter.DeleteCommand.Parameters.AddWithValue("@tel", id);

            try
            {
                conn.Open();
                dataAdapter.DeleteCommand.ExecuteNonQuery();

                dataSet.Clear();
                dataAdapter.Fill(dataSet, "person");
                dataGridView1.DataSource = dataSet.Tables["person"];
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

        // **** Update SQL 실행 ****
        internal void UpdateRow(string[] rowDatas)
        {
            string sql = "UPDATE person SET tel=@tel, name=@name, age=@age, city=@city, insurance=@insurance WHERE tel=@tel";
            dataAdapter.UpdateCommand = new MySqlCommand(sql, conn);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@tel", rowDatas[0]);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@name", rowDatas[1]);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@age", rowDatas[2]);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@city", rowDatas[3]);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@insurance", rowDatas[4]);

            try
            {
                conn.Open();
                dataAdapter.UpdateCommand.ExecuteNonQuery();

                dataSet.Clear();  // 이전 데이터 지우기
                dataAdapter.Fill(dataSet, "person");
                dataGridView1.DataSource = dataSet.Tables["person"];
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

        // **** Insert 버튼 클릭(새창 띄우기) ****
        private void btnInsert_Click(object sender, EventArgs e)
        {
            Form2 Dig = new Form2();
            Dig.Owner = this;               // 새로운 폼의 부모가 Form1 인스턴스임을 지정
            Dig.ShowDialog();               // 폼 띄우기(Modal)
            Dig.Dispose();
        }

        // 검색 조건 초기화 함수
        private void btnClear_Click(object sender, EventArgs e)
        {
            tbName.Clear();
            tbTel.Clear();
            tbAge.Clear();
            cbCity.Text = "";
            cbInsurance.Text = "";
        }

        private void saver_Click(object sender, EventArgs e)
        {
            //dataGridView에 데이터가 있는지 체크
            if (dataGridView1.RowCount < 2) // 1이면 데이터가 없음
            {
                MessageBox.Show("저장할 데이터가 없습니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //라디오 버튼 선택에 따라 다른 처리
            if (rbTxt.Checked)
            {
                saveFileDialog1.Filter = "텍스트 파일(*.txt)|*.txt";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    SaveAsTxt(saveFileDialog1.FileName);
                }
            }
            else if (rbExcel.Checked)
            {
                saveFileDialog1.Filter = "엑셀 파일(*.xlsx)|*.xlsx";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    SaveAsExcel(saveFileDialog1.FileName);
                }
            }
            else
            {
                MessageBox.Show("저장 형태가 선택되지 않았습니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void SaveAsExcel(string filePath)
        {
            // 1. 엑셀 사용에 필요한 객체 준비
            Excel.Application eApp; // 엑셀 프로그램
            Excel.Workbook eWorkbook; // 엑셀 워크북(시트 여러개 포함)
            Excel.Worksheet eWorksheet; // 엑셀 워크시트

            eApp = new Excel.Application();
            eWorkbook = eApp.Workbooks.Add();
            eWorksheet = eWorkbook.Sheets[1]; // 엑셀 워크시트는 Index가 1부터 시작된다.

            // 2. 엑셀에 저장할 데이터를 2차원 스트링 배열로 준비
            int colCount = dataSet.Tables["person"].Columns.Count;
            int rowCount = dataSet.Tables["person"].Rows.Count + 1;
            string[,] dataArr = new string[rowCount, colCount];

            // 2-1 Column 이름 저장
            for (int i = 0; i < dataSet.Tables["person"].Columns.Count; i++)
            {
                dataArr[0, i] = dataSet.Tables["person"].Columns[i].ColumnName; // 첫 행에 컬럼이름을 저장
            }
            // 2-2 Row 데이터 저장
            for (int i = 0; i < dataSet.Tables["person"].Rows.Count; i++)
            {
                for (int j = 0; j < dataSet.Tables["person"].Columns.Count; j++)
                {
                    dataArr[i + 1, j] = dataSet.Tables["person"].Rows[i].ItemArray[j].ToString();
                }
            }

            // 3. 준비된 스트링 배열을 엑셀파일로 저장
            string endCell = Convert.ToChar(65 + colCount - 1).ToString() + rowCount.ToString();
            eWorksheet.get_Range($"A1:{endCell}").Value = dataArr; // 배열의 데이터를 엑셀시트에 기록

            eWorkbook.SaveAs(filePath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                false, false, Excel.XlSaveAsAccessMode.xlShared, false, false, Type.Missing, Type.Missing,
                Type.Missing);
            eWorkbook.Close(false, Type.Missing, Type.Missing);
            eApp.Quit();
        }

        void SaveAsTxt(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                // Column 이름들을 저장(한줄)
                foreach (DataColumn col in dataSet.Tables["person"].Columns)
                {
                    sw.Write($"{col.ColumnName}\t");
                }
                sw.WriteLine();

                // Rows 데이터들을 저장
                foreach (DataRow row in dataSet.Tables["person"].Rows)
                {
                    string rowString = "";
                    foreach (var data in row.ItemArray)
                    {
                        rowString += $"{data}\t";
                    }
                    sw.WriteLine(rowString);
                }
            }
        }

    }
}
