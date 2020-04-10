using Microsoft.AspNet.OData.Builder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    public class CustomerOrders
    {
        public int OrderID { get; set; }
        public string ShippingAddress { get; set; }

    }
}