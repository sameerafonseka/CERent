using CERent.Product.Lib.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using CERent.Product.Lib.Application.Models;
using System.Linq;

namespace CERent.Product.Lib.Application.Mappers
{
    internal static class EquipmentProductMapper
    {
        public static Models.ProductViewModel Map(this Equipment equipment)
        {
            if (equipment == null)
                return null;

            var p = new Models.ProductViewModel();
            p.Id = equipment.Id;
            p.Name = equipment.Name;
            p.TranslationKey = equipment.TranslationKey;
            p.Type = equipment.Type.ToString("f");
            p.ImageUrl = equipment.PictureUrl;
            p.Description = equipment.Description;

            return p;
        }

        public static IList<Models.ProductViewModel> Map(this IList<Equipment> equipment)
        {
            return equipment.Select(x => x?.Map()).ToList();
        }
    }
}
