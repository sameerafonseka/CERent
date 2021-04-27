using CERent.Product.Lib.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using CERent.Product.Lib.Application.Models;
using System.Linq;

namespace CERent.Product.Lib.Application.Mappers
{
    public static class EquipmentProductMapper
    {
        public static Models.Product Map(this Equipment equipment)
        {
            if (equipment == null)
                return null;

            var p = new Models.Product();
            p.ProductId = equipment.Id;
            p.ProductName = equipment.Name;
            p.ProductTranslationKey = equipment.TranslationKey;
            p.ProductType = equipment.Type.ToString("f");
            p.ProductUrl = equipment.PictureUrl;

            return p;
        }

        public static IList<Models.Product> Map(this IList<Equipment> equipment)
        {
            return equipment.Select(x => x?.Map()).ToList();
        }
    }
}
