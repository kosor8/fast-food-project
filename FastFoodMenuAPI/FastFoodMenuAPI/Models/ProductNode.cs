namespace FastFoodMenuAPI.Models
{
    public class ProductNode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string FormattedPrice => Price.ToString("F2", CultureInfo.InvariantCulture);
    }
}
