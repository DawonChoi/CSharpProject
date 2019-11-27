namespace WinFormProject01
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.remover = new System.Windows.Forms.Button();
            this.adjustor = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label01 = new System.Windows.Forms.Label();
            this.label02 = new System.Windows.Forms.Label();
            this.label03 = new System.Windows.Forms.Label();
            this.label04 = new System.Windows.Forms.Label();
            this.tb01 = new System.Windows.Forms.TextBox();
            this.tb02 = new System.Windows.Forms.TextBox();
            this.tb03 = new System.Windows.Forms.TextBox();
            this.tb04 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // remover
            // 
            this.remover.BackColor = System.Drawing.SystemColors.Info;
            this.remover.Font = new System.Drawing.Font("나눔바른고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.remover.ForeColor = System.Drawing.SystemColors.Highlight;
            this.remover.Location = new System.Drawing.Point(418, 298);
            this.remover.Name = "remover";
            this.remover.Size = new System.Drawing.Size(332, 72);
            this.remover.TabIndex = 9;
            this.remover.Text = "삭제하기";
            this.remover.UseVisualStyleBackColor = false;
            this.remover.Click += new System.EventHandler(this.remover_Click);
            // 
            // adjustor
            // 
            this.adjustor.BackColor = System.Drawing.SystemColors.Info;
            this.adjustor.Font = new System.Drawing.Font("나눔바른고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.adjustor.ForeColor = System.Drawing.SystemColors.Highlight;
            this.adjustor.Location = new System.Drawing.Point(37, 297);
            this.adjustor.Name = "adjustor";
            this.adjustor.Size = new System.Drawing.Size(332, 72);
            this.adjustor.TabIndex = 10;
            this.adjustor.Text = "수정하기";
            this.adjustor.UseVisualStyleBackColor = false;
            this.adjustor.Click += new System.EventHandler(this.adjustor_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(34, 137);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(723, 63);
            this.dataGridView1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔스퀘어 Bold", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(157, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(484, 48);
            this.label1.TabIndex = 12;
            this.label1.Text = "사전 정보 조회(수정, 삭제)";
            // 
            // label01
            // 
            this.label01.AutoSize = true;
            this.label01.Location = new System.Drawing.Point(113, 217);
            this.label01.Name = "label01";
            this.label01.Size = new System.Drawing.Size(45, 15);
            this.label01.TabIndex = 13;
            this.label01.Text = "label2";
            // 
            // label02
            // 
            this.label02.AutoSize = true;
            this.label02.Location = new System.Drawing.Point(278, 217);
            this.label02.Name = "label02";
            this.label02.Size = new System.Drawing.Size(45, 15);
            this.label02.TabIndex = 14;
            this.label02.Text = "label2";
            // 
            // label03
            // 
            this.label03.AutoSize = true;
            this.label03.Location = new System.Drawing.Point(441, 217);
            this.label03.Name = "label03";
            this.label03.Size = new System.Drawing.Size(45, 15);
            this.label03.TabIndex = 15;
            this.label03.Text = "label2";
            // 
            // label04
            // 
            this.label04.AutoSize = true;
            this.label04.Location = new System.Drawing.Point(603, 217);
            this.label04.Name = "label04";
            this.label04.Size = new System.Drawing.Size(45, 15);
            this.label04.TabIndex = 16;
            this.label04.Text = "label2";
            // 
            // tb01
            // 
            this.tb01.Location = new System.Drawing.Point(67, 247);
            this.tb01.Name = "tb01";
            this.tb01.Size = new System.Drawing.Size(140, 25);
            this.tb01.TabIndex = 17;
            // 
            // tb02
            // 
            this.tb02.Location = new System.Drawing.Point(230, 247);
            this.tb02.Name = "tb02";
            this.tb02.Size = new System.Drawing.Size(140, 25);
            this.tb02.TabIndex = 18;
            // 
            // tb03
            // 
            this.tb03.Location = new System.Drawing.Point(397, 247);
            this.tb03.Name = "tb03";
            this.tb03.Size = new System.Drawing.Size(140, 25);
            this.tb03.TabIndex = 19;
            // 
            // tb04
            // 
            this.tb04.Location = new System.Drawing.Point(565, 247);
            this.tb04.Name = "tb04";
            this.tb04.Size = new System.Drawing.Size(140, 25);
            this.tb04.TabIndex = 20;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tb04);
            this.Controls.Add(this.tb03);
            this.Controls.Add(this.tb02);
            this.Controls.Add(this.tb01);
            this.Controls.Add(this.label04);
            this.Controls.Add(this.label03);
            this.Controls.Add(this.label02);
            this.Controls.Add(this.label01);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.adjustor);
            this.Controls.Add(this.remover);
            this.Name = "Form4";
            this.Text = "아이돌사전 정보수정";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button remover;
        private System.Windows.Forms.Button adjustor;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label01;
        private System.Windows.Forms.Label label02;
        private System.Windows.Forms.Label label03;
        private System.Windows.Forms.Label label04;
        private System.Windows.Forms.TextBox tb01;
        private System.Windows.Forms.TextBox tb02;
        private System.Windows.Forms.TextBox tb03;
        private System.Windows.Forms.TextBox tb04;
    }
}