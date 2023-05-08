
using System.Text.Json;
using System.Text;
using OnlineShop.Repositories;
using MySql.Data.MySqlClient;
using System.Data.Common;
using OnlineShop.Models.Repository;

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
            m_userrep = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public List<User> GetAll()
        {
            return m_userrep.GetAll();
        }

        public User GetById(int id)
        {
            return  m_userrep.GetById(id);
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

        public  User Update(User user)
        {
            return m_userrep.Update(user);
        }




        public bool Delete(int id)
        {
            return m_userrep.Delete(id);
        }


        internal User GetUserByEmail(string email)
        {
            
            if (email == null)
            {
                throw new ArgumentNullException(nameof (email));
            }

            return m_userrep.GetByEmai(email);
        }




    }
}