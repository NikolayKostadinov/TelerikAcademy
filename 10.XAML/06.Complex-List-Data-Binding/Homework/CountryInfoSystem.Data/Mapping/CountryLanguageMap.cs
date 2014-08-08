using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CountryInfoSystem.Model.Models;

namespace CountryInfoSystem.Data.Mapping
{
    public class CountryLanguageMap : EntityTypeConfiguration<CountryLanguage>
    {
        public CountryLanguageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.CountryCode)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.Language)
                .IsRequired()
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("CountryLanguage");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CountryCode).HasColumnName("CountryCode");
            this.Property(t => t.Language).HasColumnName("Language");
            this.Property(t => t.IsOfficial).HasColumnName("IsOfficial");
            this.Property(t => t.Percentage).HasColumnName("Percentage");

            // Relationships
            this.HasRequired(t => t.Country)
                .WithMany(t => t.CountryLanguages)
                .HasForeignKey(d => d.CountryCode);

        }
    }
}
