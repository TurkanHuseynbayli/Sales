namespace ProductManagement.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Code { get; set; }
        public int Count { get; set; }
        public bool Status { get; set; }
        public decimal TaxRate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public ICollection<Sales>? Sales { get; set; }
        //public ICollection<Basket>? Basket { get; set; }
      
        

    }
}
