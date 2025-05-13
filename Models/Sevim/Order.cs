namespace FastFoodMenuAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<SimpleCartItem> Items { get; set; }
        public string Status { get; set; } 
    }
}



