﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ThriftshopWeb.Models;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

}