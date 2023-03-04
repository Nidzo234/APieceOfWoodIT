using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APieceOfWoodIT.Models
{
    public class Order
    {
        public Order() { }
        public Order(string UserId) {
            this.UserId = UserId;
            this.CreatedDate= DateTime.Now;
        }
        [Key]
        public int OrderId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserId { get; set; }
    }
}