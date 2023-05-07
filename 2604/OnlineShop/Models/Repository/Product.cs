namespace OnlineShop.Models.Repository
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
        public int category_id { get; set; }

        public int brand_id { get; set; }
    }
}

