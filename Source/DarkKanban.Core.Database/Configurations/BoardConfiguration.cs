using DarkKanban.Core.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DarkKanban.Core.Database.Configurations
{
    public class BoardConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.ToTable(nameof(Board));

            builder.HasKey(b => b.Id);
            
            builder.Property(r => r.Description)
                .HasMaxLength(300);

            builder.Property(r => r.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(b => b.Columns)
                .WithOne(c => c.Board);
        }
    }
}