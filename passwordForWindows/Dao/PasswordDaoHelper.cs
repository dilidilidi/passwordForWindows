using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using Com.Sunbin.Password.Properties;

namespace Com.Sunbin.Password.Dao
{
    internal class PasswordDaoHelper
    {
        private const string SqlConnectString = "Data Source=Database/sqlite.db3;";

        /// <summary>
        ///     插入一条密码
        /// </summary>
        /// <returns>
        ///     布尔值，true代表插入成功，false代表插入失败
        /// </returns>
        public bool Insert(Entity.Password p)
        {
            try
            {
                var conn = new SQLiteConnection(SqlConnectString);
                conn.Open();
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO p(cipherText,salt,iv,remark) VALUES(@cipherText,@salt,@iv,@remark)";
                cmd.Parameters.Add(new SQLiteParameter("cipherText", p.CipherText));
                cmd.Parameters.Add(new SQLiteParameter("salt", p.Salt));
                cmd.Parameters.Add(new SQLiteParameter("iv", p.Iv));
                cmd.Parameters.Add(new SQLiteParameter("remark", p.Remark));
                int i = cmd.ExecuteNonQuery();
                return i == 1;
            }
            catch (SQLiteException se)
            {
                MessageBox.Show(se.Message + Resources.newLineString + se.Source + Resources.newLineString +
                                se.StackTrace + Resources.newLineString + se.Data);
                return false;
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message + Resources.newLineString + ae.Source + Resources.newLineString +
                                ae.StackTrace + Resources.newLineString + ae.Data);
                return false;
            }
            catch (Exception ex)
            {
                //Do　any　logging　operation　here　if　necessary  
                MessageBox.Show(ex.Message + Resources.newLineString + ex.Source + Resources.newLineString +
                                ex.StackTrace + Resources.newLineString + ex.Data);
                return false;
            }
        }

        /// <summary>
        ///     更新一条密码
        /// </summary>
        /// <returns>
        ///     布尔值，true代表更新成功，false代表更新失败
        /// </returns>
        public bool Update(Entity.Password p)
        {
            try
            {
                using (var conn = new SQLiteConnection(SqlConnectString))
                {
                    conn.Open();
                    SQLiteCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "update p set cipherText=@cipherText,salt=@salt,iv=@iv,remark=@remark where id=@id;";
                    cmd.Parameters.Add(new SQLiteParameter("id", p.Id));
                    cmd.Parameters.Add(new SQLiteParameter("cipherText", p.CipherText));
                    cmd.Parameters.Add(new SQLiteParameter("salt", p.Salt));
                    cmd.Parameters.Add(new SQLiteParameter("iv", p.Iv));
                    cmd.Parameters.Add(new SQLiteParameter("remark", p.Remark));
                    int i = cmd.ExecuteNonQuery();
                    return i == 1;
                }
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message + Resources.newLineString + ae.Source + Resources.newLineString +
                                ae.StackTrace);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        ///     删除一条密码
        /// </summary>
        /// <returns>
        ///     布尔值，true代表删除成功，false代表删除失败
        /// </returns>
        public bool Delete(int id)
        {
            try
            {
                using (var conn = new SQLiteConnection(SqlConnectString))
                {
                    conn.Open();
                    SQLiteCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "delete from p where id=@id;";
                    cmd.Parameters.Add(new SQLiteParameter("id", id));
                    int i = cmd.ExecuteNonQuery();
                    return i == 1;
                }
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message + Resources.newLineString + ae.Source + Resources.newLineString +
                                ae.StackTrace);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        ///     读取所有密码
        /// </summary>
        /// <returns>
        ///     数据表，如果失败，返回一个空数据表
        /// </returns>
        public DataTable QueryLastItem()
        {
            var dt = new DataTable();
            try
            {
                var conn = new SQLiteConnection(SqlConnectString);
                conn.Open();
                var cmd = new SQLiteCommand(conn)
                {
                    CommandText = "select * from p order by id desc limit 0 , 1;",
                    CommandType = CommandType.Text
                };
                SQLiteDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                }
                dr.Close();
                conn.Close();
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message + Resources.newLineString + ae.Source + Resources.newLineString +
                                ae.StackTrace + Resources.newLineString + ae.Data);
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);  
                MessageBox.Show(ex.Message + Resources.newLineString + ex.Source + Resources.newLineString +
                                ex.StackTrace + Resources.newLineString + ex.Data);
            }
            return dt;
        }

        /// <summary>
        ///     读取所有密码
        /// </summary>
        /// <returns>
        ///     数据表，如果失败，返回一个空数据表
        /// </returns>
        public DataTable Read()
        {
            var dt = new DataTable();
            try
            {
                var conn = new SQLiteConnection(SqlConnectString);
                conn.Open();
                var cmd = new SQLiteCommand(conn)
                {
                    CommandText = "SELECT * FROM p ORDER BY id DESC",
                    CommandType = CommandType.Text
                };
                SQLiteDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                }
                dr.Close();
                conn.Close();
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message + Resources.newLineString + ae.Source + Resources.newLineString +
                                ae.StackTrace + Resources.newLineString + ae.Data);
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);  
                MessageBox.Show(ex.Message + Resources.newLineString + ex.Source + Resources.newLineString +
                                ex.StackTrace + Resources.newLineString + ex.Data);
            }

            return dt;
        }
    }
}