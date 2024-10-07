using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSELE4_Activity.Model
{
    // A model is usually more closely related to how your data is stored (database, services, etc.)
    // and the model will closely resemble those.
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public byte[] Content { get; set; }


    }
    public class ProductViewModel
    {
        // The ViewModel on the other hand is closely related to
        // how your data is presented to the user. 
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }

        [Display(Name = "Product Image")]
        public IFormFile FormFile { get; set; }
    }
}


