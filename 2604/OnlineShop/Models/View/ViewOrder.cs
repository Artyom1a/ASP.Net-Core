namespace OnlineShop.Models.View
{
    public class ViewOrder
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int Product_Id { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public int Discount { get; set; }
    }
}
