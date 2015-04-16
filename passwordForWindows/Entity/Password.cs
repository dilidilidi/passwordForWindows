namespace Com.Sunbin.Password.Entity
{
    internal class Password
    {
        /// <summary>
        ///     Password实体类
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="cipherText">密文</param>
        /// <param name="salt">盐值</param>
        /// <param name="iv">加密因子</param>
        /// <param name="remark">备注</param>
        public Password(int id, string cipherText, string salt, string iv, string remark)
        {
            Id = id;
            CipherText = cipherText;
            Salt = salt;
            Iv = iv;
            Remark = remark;
        }


        public int Id { get; set; }

        public string CipherText { get; set; }

        public string Salt { get; set; }

        public string Iv { get; set; }

        public string Remark { get; set; }
    }
}