namespace FastFoodAPI.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string? CustomerName { get; set; } = string.Empty;
        public string? Content { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
    }
}
