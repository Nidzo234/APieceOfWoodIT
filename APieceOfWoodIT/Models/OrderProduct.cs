using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APieceOfWoodIT.Models
{
    public class OrderProduct
    {
        public OrderProduct() { }
        public OrderProduct(int OrderId, int ProductId) {
            this.OrderId= OrderId;
            this.ProductId= ProductId;
        }
        [Key] public int OrderProductId { get; set; }
        public int OrderId { get; set; }

        [Required]
        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public Product Products { get; set; }
    }
}