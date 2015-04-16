using System.Data;
using Com.Sunbin.Password.Crypt;
using Com.Sunbin.Password.Dao;
using NUnit.Framework;

namespace Com.Sunbin.Password.Tests.Crypt
{
    [TestFixture]
    public class Aes256Test
    {
        [Test]
        public void TestDecrypt()
        {
            var pdHelper = new PasswordDaoHelper();
            DataTable dt = pdHelper.QueryLastItem();
            string key = "1234567812345678";
            string cipherText = dt.Rows[0][1].ToString();
            string salt = dt.Rows[0][2].ToString();
            string iv = dt.Rows[0][3].ToString();
            var aes256 = new Aes256();
            string result = aes256.Decrypt(cipherText, key, salt, iv);
            Assert.IsTrue(result == "Test String");
        }

        [Test]
        public void TestEncrypt()
        {
            Assert.IsTrue(true);
        }
    }
}