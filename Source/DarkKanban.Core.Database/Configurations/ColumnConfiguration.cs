using DarkKanban.Core.Database.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DarkKanban.Core.Database.Configurations
{
    public class ColumnConfiguration : IEntityTypeConfiguration<Column>
    {
        public void Configure(EntityTypeBuilder<Column> builder)
        {
            builder.ToTable(nameof(Column));

            builder.HasKey(c => c.Id);
            
            builder.Property(r => r.Description)
                .HasMaxLength(100);

            builder.Property(r => r.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasMany(c => c.Records)
                .WithOne(r => r.Column);

            builder.HasOne(c => c.Board)
                .WithMany(c => c.Columns)
                .HasForeignKey(c => c.BoardId);
        }
    }
}