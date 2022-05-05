using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.Models
{
    public class Basket
    {
        public int Id { get; set; } 
        public int Count { get; set; } 
        public int ProductId { get; set; } 
        public Product Product { get; set; }      
        public string UserID { get; set; }
    }
    
}
