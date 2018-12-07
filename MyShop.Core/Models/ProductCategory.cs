﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyShop.Core.Models
{
    public class ProductCategory
    {
        public string Id { get; set; }
        [StringLength(20)]
        [DisplayName("Product Category")]
        public string Category { get; set; }

        public ProductCategory()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
