using System.ComponentModel.DataAnnotations;

namespace FormsApp.Models
{
    /* [Bind("Name","Price")] Bu proplar bind edilir. */ 
    public class Product {

        [Display(Name="Urun Id")]
        /* [BindNever] Hiçbir zaman bind edilmez */
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Gerekli Alan")]
        [Display(Name="Ürün Adı")]
        [StringLength(10)]
        public string Name { get; set; } = null!;


        [Display(Name="Ürün Fiyatı")]
        [Required]
        [Range(0,100000)]
        public decimal? Price { get; set; }


        [Display(Name="Ürünün Görseli")]
        public string? Image { get; set; } = string.Empty;


        public bool IsActive { get; set; }  

        [Required]
        [Display(Name="Kategori")]
        public int? CategoryId { get; set; }
    }
}
