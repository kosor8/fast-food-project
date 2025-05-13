namespace FastFoodMenuAPI.Models
{
    public class CategoryNode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductNode> Children { get; set; }
    }
}
