﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Models
{
    public class ShoppingCart
    {
        public Product Product { get; set; }

        [Range(1, 1000, ErrorMessage = "Enter the value between 1 to 1000")]
        public int Count { get; set; }
    } 
}
