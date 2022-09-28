namespace Application.Model
{
    public class Order
    {
        public string TableCode { get; set; }
        public IList<OrderItem> Pasteis { get; set; } = new List<OrderItem>();

        public Order(string tableCode)
        {
            TableCode = tableCode;
        }
    }
}
