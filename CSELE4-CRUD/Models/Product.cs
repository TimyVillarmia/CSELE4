using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSELE4_CRUD.Models
{
    public class Product
    {


        public int Id { get; set; }

        [Display(Name="Product Name")]
        public string Name { get; set; }

        public string Description { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public ProductCategory? ProductCategory { get; set; }
        public double Price { get; set; }

        [Display(Name = "Image")]
        public byte[]? Content { get; set; }

    }
}
