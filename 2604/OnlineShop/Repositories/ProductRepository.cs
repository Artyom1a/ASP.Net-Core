using MySql.Data.MySqlClient;

namespace OnlineShop.Repositories
{
    public class ProductRepository : BaseRepository
    {
        public ProductRepository(MySqlConnection connection) : base(connection)
        {
        }
    }
}
