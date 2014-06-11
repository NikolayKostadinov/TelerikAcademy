using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Countries.Data.Models.Mapping
{
    public class CountryMap : EntityTypeConfiguration<Country>
    {
        public CountryMap()
        {
            // Primary Key
            this.HasKey(t => t.Code);

            // Properties
            this.Property(t => t.Code)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(52);

            this.Property(t => t.Region)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.LocalName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.GovernmentForm)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.HeadOfState)
                .HasMaxLength(60);

            this.Property(t => t.Code2)
                .IsRequired()
                .HasMaxLength(3);

            // Table & Column Mappings
            this.ToTable("Country");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Flag).HasColumnName("Flag");
            this.Property(t => t.ContinentId).HasColumnName("ContinentId");
            this.Property(t => t.Region).HasColumnName("Region");
            this.Property(t => t.SurfaceArea).HasColumnName("SurfaceArea");
            this.Property(t => t.IndepYear).HasColumnName("IndepYear");
            this.Property(t => t.Population).HasColumnName("Population");
            this.Property(t => t.LifeExpectancy).HasColumnName("LifeExpectancy");
            this.Property(t => t.GNP).HasColumnName("GNP");
            this.Property(t => t.GNPOld).HasColumnName("GNPOld");
            this.Property(t => t.LocalName).HasColumnName("LocalName");
            this.Property(t => t.GovernmentForm).HasColumnName("GovernmentForm");
            this.Property(t => t.HeadOfState).HasColumnName("HeadOfState");
            this.Property(t => t.Capital).HasColumnName("Capital");
            this.Property(t => t.Code2).HasColumnName("Code2");

            // Relationships
            this.HasOptional(t => t.City)
                .WithMany(t => t.Countries)
                .HasForeignKey(d => d.Capital);
            this.HasRequired(t => t.Continent)
                .WithMany(t => t.Countries)
                .HasForeignKey(d => d.ContinentId);

        }
    }
}
