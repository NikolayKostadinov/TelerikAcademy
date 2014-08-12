using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CountryInfoSystemDAL.Model;

namespace CountryInfoSystem.Data.Mapping
{
    public class CityMap : EntityTypeConfiguration<City>
    {
        public CityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(35);

            this.Property(t => t.CountryCode)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.District)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("City");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.CountryCode).HasColumnName("CountryCode");
            this.Property(t => t.District).HasColumnName("District");
            this.Property(t => t.Population).HasColumnName("Population");

            // Relationships
            this.HasRequired(t => t.Country)
                .WithMany(t => t.Cities)
                .HasForeignKey(d => d.CountryCode);

        }
    }
}
