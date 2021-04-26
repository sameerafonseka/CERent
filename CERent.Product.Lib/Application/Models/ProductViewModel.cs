using System;
using System.Collections.Generic;
using System.Text;

namespace CERent.Product.Lib.Application.Models
{
    public class ProductViewModel
    {
        public List<Product> Product { get; set; }
    }

    public class Product
    {
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductType { get; set; }

        public string ProductTranslationKey { get; set; }

        public string ProductUrl { get; set; }
    }

}
