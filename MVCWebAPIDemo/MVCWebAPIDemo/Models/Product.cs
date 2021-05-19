using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCWebAPIDemo.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="Product name cannot exceed 50 characters")]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Quantiy { get; set; }

    }
}