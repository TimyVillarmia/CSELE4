using System.ComponentModel.DataAnnotations.Schema;

namespace CSELE4_CRUD.Models
{
    public class Product
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public byte[]? Content { get; set; }
    }
}
