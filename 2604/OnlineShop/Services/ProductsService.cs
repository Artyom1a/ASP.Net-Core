using OnlineShop.Models.Repository;
using OnlineShop.Repositories;
using OnlineShop.Models.View;


namespace OnlineShop.Services
{
    public class ProductsService
    {
        private readonly ProductRepository p_Product;
        private readonly BrandRepository p_Brand;
        private readonly CategoryRepository p_Category;

        public ProductsService(ProductRepository product, BrandRepository brand, CategoryRepository category)
        {
            p_Product = product;
            p_Brand = brand;
            p_Category = category;
        }
        //---------------

        //public List<User> GetAll()
        //{
        //    return m_userrep.GetAll();
        //}

    }
}
