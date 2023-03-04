using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APieceOfWoodIT.Models
{
    public class Tmp
    {
        public Tmp(String Id, int ProductId) {
            this.Id = Id;
            this.ProductId = ProductId;
        }
        public Tmp() { }
        [Key]
        public int TmpId { get; set; }

        [Required]
        [ForeignKey("AspNetUsers")]
        public String Id { get; set; }
        public ApplicationUser AspNetUsers { get; set; }

        [Required]
        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public Product Products { get; set; }
    }
}