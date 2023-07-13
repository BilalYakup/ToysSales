using Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.SeedData
{
    public class CategorySeedData : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData
                (
                new Category { Id = 1, Name = "Cars", Image = "Cars.jpg" },

                new Category { Id = 2, Name = "Minecraft", Image = "Minecraft.jpg" },

                new Category { Id = 3, Name = "Star Wars", Image = "StarWars.png" }
                ) ;
        }
    }
}
