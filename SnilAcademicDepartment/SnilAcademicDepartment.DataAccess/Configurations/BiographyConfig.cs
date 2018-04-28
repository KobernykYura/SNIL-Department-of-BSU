﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public class BiographyConfig : EntityTypeConfiguration<Biography>
    {
        public BiographyConfig()
        {
            this.HasKey(p => p.BiographyId);

            this.Property(p => p.Description)
               .IsRequired()
               .HasColumnName("Biography");

            this.HasMany(e => e.People)
                .WithRequired(e => e.Biography1)
                .HasForeignKey(e => e.Biography)
                .WillCascadeOnDelete(false);
        }
    }
}
