using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsWebApplication.Entities;

using System.Text.Json.Serialization;

[Table("products")]
public class Product
{
    [Display(Name ="Product ID")]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }
    [Required,MinLength(6),MaxLength(25)]
    public string? Designation { get; set; }
    [Required,Range(100,1000000)]
    public double Price { get; set; }
    public Category? Category { get; set; }
}