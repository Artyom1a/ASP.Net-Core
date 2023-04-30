using MySql.Data.MySqlClient;

namespace OnlineShop.Repositories
{
    public class OrderProductRepository : BaseRepository
    {
        public OrderProductRepository(MySqlConnection connection) : base(connection)
        {
        }
    }
}
