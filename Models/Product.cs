using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST10281011_PROG7311_POE_PART_2.Models
{

    //Improvements for data anotations and validation assisted by ChatGPT (OpenAI, 2025). See README File for Details.
    //OpenAI ChatGpt. 2025.
    //<https://chatgpt.com/share/68232d50-0be4-800d-b0f4-421cc236ce20>
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Product Description must be more no more than 30 characters long")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Product Type")]
        public ProductCategories ProductType { get; set; }

        [Required]
        [Display(Name = "Production Date")]
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(1.50, 10000, ErrorMessage = "Price must be greater than or equal to 1.00 and less than 10000")]
        public double Price { get; set; }


        [Required]
        [Range(1, 1000, ErrorMessage ="Quantity must be greater than or equal to 1 & less than 1000")]
        public double Quantity { get; set; }

        [Required]
        [Display(Name = "Unit Of Measure")]
        public UnitOfMeasure UnitOfMeasure { get; set; } 


    }
}
