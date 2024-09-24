using System.ComponentModel.DataAnnotations.Schema;

namespace CSELE4_Activity.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public string ProductImageFile { get; set; }

        [NotMapped]
        public IFormFile ProductImage { get; set; }
    }
}


