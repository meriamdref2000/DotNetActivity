using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsWebApplication.Entities;

[Table("categories")]
public class Category
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CategoryId { get; set; }
    [Required]
    [MaxLength(50)]
    public string? Name { get; set; }
}