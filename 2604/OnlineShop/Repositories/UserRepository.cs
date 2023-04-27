using MySql.Data.MySqlClient;
using OnlineShop.Models;

namespace OnlineShop.Repositories
{
    public class UserRepository
    {
        private readonly string SQL_GET_ALL = "select Id,Name,Surname,Email,Password from Users;";
        private readonly MySqlConnection m_Connection;
        public UserRepository(MySqlConnection connection)
        {
            m_Connection = connection;
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
    }
}
