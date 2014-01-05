namespace Atm.Data.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;
    using Atm.Model;

    public class CardAccountMap : EntityTypeConfiguration<CardAccount>
    {
        public CardAccountMap()
        {
            // Primary Key
            this.HasKey(t => t.CardAccountsId);

            // Properties
            this.Property(t => t.CardNumber)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.CardPin)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.CardCash)
                .IsRequired()
                .IsConcurrencyToken();

            // Table & Column Mappings
            this.ToTable("CardAccounts");
            this.Property(t => t.CardAccountsId).HasColumnName("CardAccountsId");
            this.Property(t => t.CardNumber).HasColumnName("CardNumber");
            this.Property(t => t.CardPin).HasColumnName("CardPin");
            this.Property(t => t.CardCash).HasColumnName("CardCash");
        }
    }
}
