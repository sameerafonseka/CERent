using CERent.Core.Lib.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CERent.Product.Lib.Domain.Entities
{
    public class Equipment : BaseDomainModel
    {
        public string Name { get; set; }

        public EquipmentType Type { get; set; }

        public string TranslationKey { get; set; }

        public string PictureUrl { get; set; }
    }
}
