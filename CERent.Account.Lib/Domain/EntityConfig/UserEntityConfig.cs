using CERent.Account.Lib.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CERent.Account.Lib.Domain.EntityConfig
{
    class UserEntityConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Users");

            entityTypeBuilder.HasKey(x => x.Id);
       
        }
    }
}
