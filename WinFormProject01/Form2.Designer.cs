namespace WinFormProject01
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAgencyName = new System.Windows.Forms.TextBox();
            this.tbCeo = new System.Windows.Forms.TextBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_addAgency = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔스퀘어 Bold", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(16, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "소속사명";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔스퀘어 Bold", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(48, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 42);
            this.label2.TabIndex = 1;
            this.label2.Text = "사장명";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔스퀘어 Bold", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(74, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 42);
            this.label3.TabIndex = 2;
            this.label3.Text = "주소";
            // 
            // tbAgencyName
            // 
            this.tbAgencyName.Font = new System.Drawing.Font("나눔스퀘어", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbAgencyName.Location = new System.Drawing.Point(177, 66);
            this.tbAgencyName.Name = "tbAgencyName";
            this.tbAgencyName.Size = new System.Drawing.Size(394, 49);
            this.tbAgencyName.TabIndex = 3;
            // 
            // tbCeo
            // 
            this.tbCeo.Font = new System.Drawing.Font("나눔스퀘어", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbCeo.Location = new System.Drawing.Point(177, 128);
            this.tbCeo.Name = "tbCeo";
            this.tbCeo.Size = new System.Drawing.Size(394, 49);
            this.tbCeo.TabIndex = 4;
            // 
            // tbAddress
            // 
            this.tbAddress.Font = new System.Drawing.Font("나눔스퀘어", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbAddress.Location = new System.Drawing.Point(177, 191);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(394, 49);
            this.tbAddress.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btn_addAgency);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbAddress);
            this.groupBox1.Controls.Add(this.tbAgencyName);
            this.groupBox1.Controls.Add(this.tbCeo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("문체부 제목 돋음체", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(39, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(683, 448);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info_";
            // 
            // btn_addAgency
            // 
            this.btn_addAgency.BackColor = System.Drawing.SystemColors.Info;
            this.btn_addAgency.Font = new System.Drawing.Font("나눔바른고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_addAgency.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_addAgency.Location = new System.Drawing.Point(177, 309);
            this.btn_addAgency.Name = "btn_addAgency";
            this.btn_addAgency.Size = new System.Drawing.Size(332, 72);
            this.btn_addAgency.TabIndex = 9;
            this.btn_addAgency.Text = "소속사 추가하기";
            this.btn_addAgency.UseVisualStyleBackColor = false;
            this.btn_addAgency.Click += new System.EventHandler(this.btn_addAgency_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔스퀘어라운드 Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(185, -36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(292, 33);
            this.label4.TabIndex = 7;
            this.label4.Text = "소속사를 생성해주세요";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("나눔스퀘어라운드 Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(171, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(387, 33);
            this.label5.TabIndex = 7;
            this.label5.Text = " 새로운 소속사를 추가해주세요";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 527);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form2";
            this.Text = "소속사 생성";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbAgencyName;
        private System.Windows.Forms.TextBox tbCeo;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_addAgency;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}