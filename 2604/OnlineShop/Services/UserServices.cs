
using System.Text.Json;
using System.Text;
using OnlineShop.Models;
using OnlineShop.Repositories;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace OnlineShop.Services
{
    public class UserServices
    {
      //  private readonly UserRepository m_service
        private readonly UserRepository m_userrep;
        //public UserServices(UserRepository rep)
        //{
        //    m_Service = rep ?? throw new ArgumentNullException(nameof(rep));
        //}
        public UserServices(UserRepository repository)
        {
            m_userrep = repository;
        }

        public void Create(User user)
        {
            var list = m_userrep.GetAll();
            var item = list.FirstOrDefault(x => x.Email == user.Email);
            if (item != null)
            {
                throw new Exception();
            }
            //list.Add(user);
            m_userrep.WriteNew(user);
        }
    }
}