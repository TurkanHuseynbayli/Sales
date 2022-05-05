using ProductManagement.Models;

namespace ProductManagement.ToDoItems
{
    public class ProductVM
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Sales { get; set; }
    }
}
