﻿using System.Data.Entity.ModelConfiguration;
using ServiciosProfesionales.Entities;

namespace ServiciosProfesionales.DataContext.Configurations
{
    public class ClienteEntityConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteEntityConfiguration()
        {
            Property(p => p.RazonSocial)
                .HasMaxLength(128)
                .IsUnicode(false);

            Property(p => p.Rfc)
                .HasMaxLength(128)
                .IsUnicode(false);

            Property(p => p.Domicilio)
                .HasMaxLength(128)
                .IsUnicode(false);

            Property(p => p.Email)
                .HasMaxLength(256)
                .IsUnicode(false);

        }
    }
}