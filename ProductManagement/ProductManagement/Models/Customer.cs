namespace ProductManagement.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<Sales>? Sales { get; set; }
    }
}
