using System.ComponentModel.DataAnnotations;

namespace ST10281011_PROG7311_POE_PART_2.Models
{

    //List of measuremets for products assisted by ChatGPT (OpenAI, 2025). See README File for Details.
    //OpenAI ChatGpt. 2025.
    //<https://chatgpt.com/share/68232d50-0be4-800d-b0f4-421cc236ce20>


    // Enum storing the different units of measure for products
    public enum UnitOfMeasure
    {
        [Display(Name = "Kilogram(s)")]
        Kilogram,

        [Display(Name = "Gram(s)")]
        Gram,

        [Display(Name = "Liter(s)")]
        Liter,

        [Display(Name = "Milliliter(s)")]
        Milliliter,

        [Display(Name = "Piece(s)")]
        Piece,

        [Display(Name = "Dozen(s)")]
        Dozen,

        [Display(Name = "Pack(s)")]
        Pack,

        [Display(Name = "Bag(s)")]
        Bag,

        [Display(Name = "Box(es)")]
        Box
    }
}