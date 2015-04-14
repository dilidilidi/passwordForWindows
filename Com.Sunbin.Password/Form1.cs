using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Com.Sunbin.Password.Properties;

namespace Com.Sunbin.Password
{
    public partial class Form1 : Form
    {
        protected DataTable Dt;

        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            var p = new Dao.PasswordDaoHelper();
            var cbc = new DataGridViewCheckBoxColumn();
            dataGridView_password.Columns.Add(cbc);
            Dt = p.Read();
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

            byte[] key = Encoding.UTF8.GetBytes(secretKey);

            // Encrypt the string to an array of bytes.

//            byte[] encrypted = Aes256.Aes256.EncryptStringToBytes_Aes(plainText, key, key);
//            MessageBox.Show(Encoding.UTF8.GetString(encrypted));

            //RNGCryptoServiceProvider

            // Decrypt the bytes to a string.
//            string roundtrip = Aes256.Aes256.DecryptStringFromBytes_Aes(encrypted, key, key);
//            MessageBox.Show(roundtrip);
        }

        private void button_localSave_Click(object sender, EventArgs e)
        {
            var ep = new Entity.Password(0, "ddd", "xxx", "0000","111");
            var dp = new Dao.PasswordDaoHelper();

            bool result = dp.Insert(ep);
            if (result)
            {
                Dt = dp.Read();
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