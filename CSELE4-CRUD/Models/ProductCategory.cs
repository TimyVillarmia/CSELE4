using System.ComponentModel.DataAnnotations;

namespace CSELE4_CRUD.Models
{
    public class ProductCategory
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        [Display(Name="Category Name")]
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Product>? Products { get; set; }
    }
}
