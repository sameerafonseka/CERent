using CERent.Product.Lib.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CERent.Product.Lib.Domain.EntityConfigs
{
    class EquipmentEntityConfig : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Equipments");

            entityTypeBuilder.HasKey(x => x.Id);

        }
    }
}
