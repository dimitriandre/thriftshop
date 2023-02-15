using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Thriftshop.Models;

public class CoverType
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Cover Type")]
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

}