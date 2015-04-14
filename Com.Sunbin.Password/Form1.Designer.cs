namespace Com.Sunbin.Password
{
    partial class Form1
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
            this.button_localSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_password)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_secretKey
            // 
            this.textBox_secretKey.Location = new System.Drawing.Point(49, 68);
            this.textBox_secretKey.Name = "textBox_secretKey";
            this.textBox_secretKey.Size = new System.Drawing.Size(100, 21);
            this.textBox_secretKey.TabIndex = 0;
            // 
            // textBox_plainText
            // 
            this.textBox_plainText.Location = new System.Drawing.Point(223, 68);
            this.textBox_plainText.Name = "textBox_plainText";
            this.textBox_plainText.Size = new System.Drawing.Size(100, 21);
            this.textBox_plainText.TabIndex = 1;
            // 
            // label_secretKey
            // 
            this.label_secretKey.AutoSize = true;
            this.label_secretKey.Location = new System.Drawing.Point(49, 34);
            this.label_secretKey.Name = "label_secretKey";
            this.label_secretKey.Size = new System.Drawing.Size(41, 12);
            this.label_secretKey.TabIndex = 2;
            this.label_secretKey.Text = "密钥：";
            // 
            // label_plainText
            // 
            this.label_plainText.AutoSize = true;
            this.label_plainText.Location = new System.Drawing.Point(223, 34);
            this.label_plainText.Name = "label_plainText";
            this.label_plainText.Size = new System.Drawing.Size(41, 12);
            this.label_plainText.TabIndex = 3;
            this.label_plainText.Text = "明文：";
            // 
            // button_generateCipherText
            // 
            this.button_generateCipherText.Location = new System.Drawing.Point(373, 68);
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
            this.dataGridView_password.Location = new System.Drawing.Point(49, 139);
            this.dataGridView_password.Name = "dataGridView_password";
            this.dataGridView_password.ReadOnly = true;
            this.dataGridView_password.RowTemplate.Height = 23;
            this.dataGridView_password.Size = new System.Drawing.Size(818, 277);
            this.dataGridView_password.TabIndex = 5;
            // 
            // button_localSave
            // 
            this.button_localSave.Location = new System.Drawing.Point(477, 65);
            this.button_localSave.Name = "button_localSave";
            this.button_localSave.Size = new System.Drawing.Size(75, 23);
            this.button_localSave.TabIndex = 6;
            this.button_localSave.Text = "保存至本地";
            this.button_localSave.UseVisualStyleBackColor = true;
            this.button_localSave.Click += new System.EventHandler(this.button_localSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 441);
            this.Controls.Add(this.button_localSave);
            this.Controls.Add(this.dataGridView_password);
            this.Controls.Add(this.button_generateCipherText);
            this.Controls.Add(this.label_plainText);
            this.Controls.Add(this.label_secretKey);
            this.Controls.Add(this.textBox_plainText);
            this.Controls.Add(this.textBox_secretKey);
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.Button button_localSave;
    }
}

