using System;
using System.Collections.Generic;
using System.Text;

namespace CERent.Product.Lib.Application.Models
{
    public class ProductsViewModel
    {
        public IList<ProductViewModel> Product { get; set; }
    }

    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string TranslationKey { get; set; }

        public string ImageUrl { get; set; }
    }

}
