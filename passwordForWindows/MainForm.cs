#region

using System;
using System.Data;
using System.Windows.Forms;
using Com.Sunbin.Password.Crypt;
using Com.Sunbin.Password.Dao;
using Com.Sunbin.Password.Properties;

#endregion

namespace Com.Sunbin.Password
{
    public partial class MainForm : Form
    {
        public DataTable Dt;

        public MainForm()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            PasswordDaoHelper pdHelper = new PasswordDaoHelper();
            DataGridViewCheckBoxColumn cbc = new DataGridViewCheckBoxColumn();
            dataGridView_password.Columns.Add(cbc);
            Dt = pdHelper.Read();
            dataGridView_password.DataSource = Dt;
            dataGridView_password.Columns[0].Width = 50;
            if (dataGridView_password.Columns.Count <= 1) return;
            dataGridView_password.Columns[1].Width = 50;
            dataGridView_password.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView_password.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView_password.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView_password.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void button_generateCipherText_Click(object sender, EventArgs e)
        {
            string secretKey = textBox_secretKey.Text;
            string plainText = textBox_plainText.Text;
            string remarkText = textBox_remark.Text;

            Aes256 aes256 = new Aes256();
            string[] result = aes256.Encrypt(plainText, secretKey);
            Entity.Password p = new Entity.Password(Convert.ToInt32(0), result[2], result[0], result[1], remarkText);
            PasswordDaoHelper pdHelper = new PasswordDaoHelper();

            if (pdHelper.Insert(p))
            {
                Dt = pdHelper.Read();
                dataGridView_password.DataSource = Dt;
                if (dataGridView_password.Columns.Count > 1)
                {
                    dataGridView_password.Columns[1].Width = 50;
                    dataGridView_password.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView_password.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView_password.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                MessageBox.Show(Resources.success);
            }
            else
            {
                MessageBox.Show(Resources.fail);
            }
        }
    }
}