namespace Com.Sunbin.Password.Entity
{
    class Password
    {
        /// <summary>
        /// Password实体类
        /// </summary>
        /// <param name="id">ID</param>
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

        //ID
        public int Id
        {
            get { return Id; }
            set { Id = value; }
        }

        //密文
        public string CipherText
        {
            get { return CipherText; }
            set { CipherText = value; }
        }

        //盐值
        public string Salt
        {
            get { return Salt; }
            set { Salt = value; }
        }

        //加密因子
        public string Iv
        {
            get { return Iv; }
            set { Iv = value; }
        }

        //备注
        public string Remark
        {
            get { return Remark; }
            set { Remark = value; }
        }
    }
}