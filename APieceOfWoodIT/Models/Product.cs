using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APieceOfWoodIT.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public String Name { get; set; }
        public string Description { get; set; }
        public String Type { get; set; }
        public int Price { get; set; }
        public String ImageUrl { get; set; }
    }
}