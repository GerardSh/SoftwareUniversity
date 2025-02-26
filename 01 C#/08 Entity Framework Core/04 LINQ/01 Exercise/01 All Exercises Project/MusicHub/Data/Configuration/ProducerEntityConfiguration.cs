using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicHub.Data.Models;

namespace MusicHub.Data.Configuration
{
    using static EntityValidationConstants.Producer;
    public class ProducerEntityConfiguration : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> entity)
        {
            entity
                .HasKey(p => p.Id);

            entity
                .Property(p => p.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(ProducerNameMaxLength);

            entity
                .Property(p => p.Pseudonym)
                .IsRequired(false)
                .IsUnicode();            
            
            entity
                .Property(p => p.PhoneNumber)
                .IsRequired(false)
                .IsUnicode();
        }
    }
}
