using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Thriftshop.Models;

public class ItemCondition
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Item Condition")]
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

}