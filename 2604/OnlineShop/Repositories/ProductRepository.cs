using MySql.Data.MySqlClient;
using OnlineShop.Models.Repository;
using System.Data.Common;

namespace OnlineShop.Repositories
{
    public class ProductRepository : BaseRepository
    {
        private readonly string SQL_GET_ALL = "select ID, NAME, Description, Price, category_id, brand_id from Product;";
        public ProductRepository(MySqlConnection connection) : base(connection)
        {

        }
        




        public List<Product> GetAll()
        {
            try
            {
                m_Connection.Open();




                MySqlCommand command = new MySqlCommand(SQL_GET_ALL, m_Connection);

                MySqlDataReader reader = command.ExecuteReader();

                List<Product> products = new List<Product>();

               
                while (reader.Read())
                {
                    products.Add(new Product()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        Price = reader.GetDecimal(3),
                        category_id = reader.GetInt32(4),
                        brand_id = reader.GetInt32(5)
                    });
                }
                return products;

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


    
