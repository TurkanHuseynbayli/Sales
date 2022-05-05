namespace ProductManagement.Models
{
    public class Sales
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
