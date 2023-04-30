using MySql.Data.MySqlClient;

namespace OnlineShop.Repositories
{
    public class CategoryRepository : BaseRepository
    {
        public CategoryRepository(MySqlConnection connection) : base(connection)
        {
        }
    }
}
