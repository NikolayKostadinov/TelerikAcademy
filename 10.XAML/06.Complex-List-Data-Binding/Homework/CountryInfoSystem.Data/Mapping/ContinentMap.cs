using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CountryInfoSystem.Model.Models;

namespace CountryInfoSystem.Data.Mapping
{
    public class ContinentMap : EntityTypeConfiguration<Continent>
    {
        public ContinentMap()
        {
            // Primary Key
            this.HasKey(t => t.ContinentId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("Continents");
            this.Property(t => t.ContinentId).HasColumnName("ContinentId");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
