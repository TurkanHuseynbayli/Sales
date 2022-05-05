using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    public class ProductForm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public bool Status { get; set; }
        public decimal TaxRate { get; set; }
        public int Code { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
