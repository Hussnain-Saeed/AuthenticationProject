using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public virtual User Seller { get; set; }
        public int SellerId { get; set; }
        public virtual Status Status { get; set; }
        public int StatusId { get; set; }
    }
}