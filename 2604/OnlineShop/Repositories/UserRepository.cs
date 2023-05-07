using MySql.Data.MySqlClient;
using OnlineShop.Models.Repository;
using System.Text;
using System.Text.Json;

namespace OnlineShop.Repositories
{
    public class UserRepository : BaseRepository
    {
        private readonly string SQL_GET_ALL = "select Id,Name,Surname,Email,Password from Users;";
        private readonly string SQL_GET_ALL_By_Email = "select Id,Name,Surname,Email,Password from Users where email=@email;";
        //private readonly string SQL_insertItem = "insert into Users(NAME, SURNAME,Email,Password) values {0} ;";
        private const string SQL_insertItem = "insert into Users(NAME, SURNAME,Email,Password) values(?, ?, ?, ?);";
        private const string SQL_UPDATE = "update users set Name = ?, Surname = ?, Email = ?, Pwd = ? where email = ?;";
        private const string SQL_DELETE = "delete from Users where id = {0};";
        public UserRepository(MySqlConnection connection) : base(connection)
        {

        }

        public List<User> GetAll()
        {
            try
            {
                m_Connection.Open();
                MySqlCommand command = new MySqlCommand(SQL_GET_ALL, m_Connection);
                MySqlDataReader reader = command.ExecuteReader();
                List<User> users = new List<User>();

                while (reader.Read())
                {
                    users.Add(new User()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Surname = reader.GetString(2),
                        Email = reader.GetString(3),
                        Password = reader.GetString(4)
                    });
                }
                return users;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
            finally
            {
                m_Connection.Close();
            }
        }

        public User GetById(int id)
        {

            try
            {
                var User = GetAll();
                return User.FirstOrDefault(x => x.Id == id);

            }

            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
            finally
            {
                m_Connection.Close();
            }

        }

        //public void Test(MySqlConnection conn, string sqript, params object[] item)
        //{
        //    // ? -> @pr{i}
        //    MySqlCommand command = new MySqlCommand(sqript, conn);
        //    for (int i = 0; i < item.Length; i++)
        //    {
        //        command.Parameters.AddWithValue($"pr{i}", item[i]);
        //    }
        //    command.ExecuteNonQuery();
        //}

        private void DynamicQuery(MySqlConnection conn, string script, params object[] item)
        {
            int startIndex = 0;
            int i = 0;
            var sb = new StringBuilder();
            while (startIndex < script.Length)
            {
                var endIndex = script.IndexOf('?', startIndex);
                if (endIndex == -1)
                {
                    sb.Append(script[startIndex..]);
                    break;
                }
                sb.Append(script[startIndex..endIndex]); //sb.Append(script.Substring(startIndex, endIndex - startIndex));
                sb.Append($"@pr{i++}");
                startIndex = endIndex + 1;
            }
            MySqlCommand command = new MySqlCommand(sb.ToString(), conn);
            for (i = 0; i < item.Length; i++)
            {
                command.Parameters.AddWithValue($"@pr{i}", item[i]);
            }
            command.ExecuteNonQuery();
        }

        public void WriteNew(User user)
        {
            try
            {
                if (user == null) throw new ArgumentNullException(nameof(user));
                m_Connection.Open();
                if (m_Connection == null) throw new Exception("connection is null");

                DynamicQuery(m_Connection, SQL_insertItem, user.Name, user.Surname, user.Email, user.Password);

                //MySqlCommand command = new MySqlCommand(string.Format(SQL_insertItem, "(@name0, @surname0,@email0,@password0)"), m_Connection);
                //command.Parameters.AddWithValue("@name0", user.Name);
                //command.Parameters.AddWithValue("@surname0", user.Surname);
                //command.Parameters.AddWithValue("@email0", user.Email);
                //command.Parameters.AddWithValue("@password0", user.Password);
                //command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }

            finally
            {
                m_Connection.Close();
            }
        }


        public User GetByEmai(string email)
        {
            try
            {
                m_Connection.Open();
                MySqlCommand command = new MySqlCommand(SQL_GET_ALL_By_Email, m_Connection);
                command.Parameters.AddWithValue("@email", email);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    User user = new User()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Surname = reader.GetString(2),
                        Email = reader.GetString(3),
                        Password = reader.GetString(4)
                    };
                    return user;
                }
                return null;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
            finally
            {
                m_Connection.Close();
            }
        }

        public User Update(User user)
        {
            try
            {
                m_Connection.Open();
                DynamicQuery(m_Connection, SQL_UPDATE, user.Name, user.Surname, user.Email, user.Password);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                m_Connection.Close();
            }
        }


        public bool Delete(int Id)
        {
            try
            {
                m_Connection.Open();
                MySqlCommand command = new MySqlCommand(string.Format(SQL_DELETE, Id), m_Connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                m_Connection.Close();
            }
        }

    }
}
