using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Domain.Models;

namespace Domain.Entities
{
    public class CartItem : BaseEntity<int>
    {
        //[ForeignKey("Cart")]
        public int CartId { get; set; }
        public Cart Cart { get; set; }

        //[ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        //[ForeignKey("ProductPrice")]
        //public decimal Prod_price { get; set; }
        //[ForeignKey("ProductImage")]
        //public string Prod_image { get; set; } = string.Empty;
        //public DateTime Added_At { get; set; } = DateTime.Now;
    }
}
