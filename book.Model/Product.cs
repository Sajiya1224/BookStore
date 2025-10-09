using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("productName")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        public string? AiSummary { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        [Column("genere")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "List Price")]
        public double ListPrice { get; set; }

        [Required]
        [Display(Name ="Price for 1-50")]
        [Column("price")]
        [Range(1, 1000)]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Price for 50+")]
        [Range(1, 1000)]
        public double Price50 { get; set; }

        [Required]
        [Display(Name = "Price for 100+")]
        [Range(1, 1000)]
        public double Price100 { get; set; }

        [Required]
        [Column("availability")]
        public bool Availability { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        [ValidateNever]
        public string ImgUrl { get; set; }
    }
}
