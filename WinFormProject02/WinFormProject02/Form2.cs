using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormProject02
{
    public partial class Form2 : Form
    {
        private string tel;
        private string name;
        private string age;
        private string city;
        private string insurance;
        private int selectedRowIndex;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(int selectedRowIndex, string v1, string v2, string v3, string v4, string v5)
        {
            InitializeComponent();
            this.selectedRowIndex = selectedRowIndex;
            tel = v1;
            name = v2;
            age = v3;
            city = v4;
            insurance = v5;
        }

        Form1 mainForm;
        private void Form2_Load(object sender, EventArgs e)
        {
            txtTel.Text = tel;
            txtName.Text = name;
            txtAge.Text = age;
            txtCity.Text = city;
            txtInsurance.Text = insurance;

            if (Owner != null)
            {
                mainForm = Owner as Form1;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string[] rowDatas = {
                txtTel.Text,
                txtName.Text,
                txtAge.Text,
                txtCity.Text,
                txtInsurance.Text };
            mainForm.InsertRow(rowDatas);
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string[] rowDatas = {
                txtTel.Text,
                txtName.Text,
                txtAge.Text,
                txtCity.Text,
                txtInsurance.Text };
            mainForm.UpdateRow(rowDatas);
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            mainForm.DeleteRow(tel);
            this.Close();
        }

        private void btnTextBoxClear_Click(object sender, EventArgs e)
        {
            txtTel.Clear();
            txtName.Clear();
            txtAge.Clear();
            txtCity.Clear();
            txtInsurance.Clear();
        }
    }
}
