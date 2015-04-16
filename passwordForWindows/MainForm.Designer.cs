namespace Com.Sunbin.Password
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_secretKey = new System.Windows.Forms.TextBox();
            this.textBox_plainText = new System.Windows.Forms.TextBox();
            this.label_secretKey = new System.Windows.Forms.Label();
            this.label_plainText = new System.Windows.Forms.Label();
            this.button_generateCipherText = new System.Windows.Forms.Button();
            this.dataGridView_password = new System.Windows.Forms.DataGridView();
            this.label_remark = new System.Windows.Forms.Label();
            this.textBox_remark = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_password)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_secretKey
            // 
            this.textBox_secretKey.Location = new System.Drawing.Point(50, 17);
            this.textBox_secretKey.Name = "textBox_secretKey";
            this.textBox_secretKey.Size = new System.Drawing.Size(100, 21);
            this.textBox_secretKey.TabIndex = 0;
            // 
            // textBox_plainText
            // 
            this.textBox_plainText.Location = new System.Drawing.Point(50, 57);
            this.textBox_plainText.Name = "textBox_plainText";
            this.textBox_plainText.Size = new System.Drawing.Size(100, 21);
            this.textBox_plainText.TabIndex = 1;
            // 
            // label_secretKey
            // 
            this.label_secretKey.AutoSize = true;
            this.label_secretKey.Location = new System.Drawing.Point(3, 20);
            this.label_secretKey.Name = "label_secretKey";
            this.label_secretKey.Size = new System.Drawing.Size(41, 12);
            this.label_secretKey.TabIndex = 2;
            this.label_secretKey.Text = "密钥：";
            // 
            // label_plainText
            // 
            this.label_plainText.AutoSize = true;
            this.label_plainText.Location = new System.Drawing.Point(3, 60);
            this.label_plainText.Name = "label_plainText";
            this.label_plainText.Size = new System.Drawing.Size(41, 12);
            this.label_plainText.TabIndex = 3;
            this.label_plainText.Text = "明文：";
            // 
            // button_generateCipherText
            // 
            this.button_generateCipherText.Location = new System.Drawing.Point(50, 140);
            this.button_generateCipherText.Name = "button_generateCipherText";
            this.button_generateCipherText.Size = new System.Drawing.Size(75, 23);
            this.button_generateCipherText.TabIndex = 4;
            this.button_generateCipherText.Text = "生成密文";
            this.button_generateCipherText.UseVisualStyleBackColor = true;
            this.button_generateCipherText.Click += new System.EventHandler(this.button_generateCipherText_Click);
            // 
            // dataGridView_password
            // 
            this.dataGridView_password.AllowUserToAddRows = false;
            this.dataGridView_password.AllowUserToResizeColumns = false;
            this.dataGridView_password.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_password.Location = new System.Drawing.Point(180, 17);
            this.dataGridView_password.Name = "dataGridView_password";
            this.dataGridView_password.ReadOnly = true;
            this.dataGridView_password.RowTemplate.Height = 23;
            this.dataGridView_password.Size = new System.Drawing.Size(757, 387);
            this.dataGridView_password.TabIndex = 5;
            // 
            // label_remark
            // 
            this.label_remark.AutoSize = true;
            this.label_remark.Location = new System.Drawing.Point(3, 100);
            this.label_remark.Name = "label_remark";
            this.label_remark.Size = new System.Drawing.Size(41, 12);
            this.label_remark.TabIndex = 7;
            this.label_remark.Text = "备注：";
            // 
            // textBox_remark
            // 
            this.textBox_remark.Location = new System.Drawing.Point(50, 97);
            this.textBox_remark.Name = "textBox_remark";
            this.textBox_remark.Size = new System.Drawing.Size(100, 21);
            this.textBox_remark.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 416);
            this.Controls.Add(this.textBox_remark);
            this.Controls.Add(this.label_remark);
            this.Controls.Add(this.dataGridView_password);
            this.Controls.Add(this.button_generateCipherText);
            this.Controls.Add(this.label_plainText);
            this.Controls.Add(this.label_secretKey);
            this.Controls.Add(this.textBox_plainText);
            this.Controls.Add(this.textBox_secretKey);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_password)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_secretKey;
        private System.Windows.Forms.TextBox textBox_plainText;
        private System.Windows.Forms.Label label_secretKey;
        private System.Windows.Forms.Label label_plainText;
        private System.Windows.Forms.Button button_generateCipherText;
        private System.Windows.Forms.DataGridView dataGridView_password;
        private System.Windows.Forms.Label label_remark;
        private System.Windows.Forms.TextBox textBox_remark;
    }
}

