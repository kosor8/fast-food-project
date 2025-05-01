using System;

namespace Web.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string OrderDetails { get; set; }
        public DateTime OrderTime { get; set; }

        public Order(int id, string customerName, string orderDetails)
        {
            Id = id;
            CustomerName = customerName;
            OrderDetails = orderDetails;
            OrderTime = DateTime.Now;
        }
    }
}
