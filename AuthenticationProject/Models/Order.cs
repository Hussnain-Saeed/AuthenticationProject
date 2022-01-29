using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationProject.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime AddedOn { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public virtual User Buyer { get; set; }
        public int BuyerId { get; set; }
    }
}