using MySql.Data.MySqlClient;
using OnlineShop.Models;
using System.Text.Json;

namespace OnlineShop.Repositories
{
    public class UserRepository : BaseRepository
    {
        private readonly string SQL_GET_ALL = "select Id,Name,Surname,Email,Password from Users;";

        private readonly string SQL_insertItem = "insert into Users(NAME, SURNAME,Email,Password) values {0} ;";

        public UserRepository(MySqlConnection connection) : base(connection)
        {

        }

        public List<User> GetAll()
        {
            try
            {
                m_Connection.Open();
                MySqlCommand command = new MySqlCommand(SQL_GET_ALL, m_Connection);
                List<User> users = new List<User>();
                MySqlDataReader reader = command.ExecuteReader();

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

        public void WriteNew(User user)
        {
            try
            {
                if (user == null) throw new ArgumentNullException(nameof(user));
                m_Connection.Open();
                if (m_Connection == null) throw new Exception("connection is null");

                MySqlCommand command = new MySqlCommand(string.Format(SQL_insertItem, "(@name0, @surname0,email0)"), m_Connection);
                command.Parameters.AddWithValue("@name0", user.Name);
                command.Parameters.AddWithValue("@surname0", user.Surname);
                command.Parameters.AddWithValue("@email0", user.Email);
                command.Parameters.AddWithValue("@password0", user.Password);
                command.ExecuteNonQuery();
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
      
    }
}
