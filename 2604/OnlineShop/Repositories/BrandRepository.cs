using MySql.Data.MySqlClient;

namespace OnlineShop.Repositories
{
    public class BrandRepository : BaseRepository
    {
        public BrandRepository(MySqlConnection connection) : base(connection)
        {

        }
    }
}
