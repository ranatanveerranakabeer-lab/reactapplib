namespace FirstProject.domain.cs.Interface
{
    public class OrderDTO
    {
        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalAmount { get; set; }
    }
}