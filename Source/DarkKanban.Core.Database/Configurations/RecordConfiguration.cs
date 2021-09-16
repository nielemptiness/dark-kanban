using DarkKanban.Core.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DarkKanban.Core.Database.Configurations
{
    public class RecordConfiguration : IEntityTypeConfiguration<Record>
    {
        public void Configure(EntityTypeBuilder<Record> builder)
        {
            builder.ToTable(nameof(Record));

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Description)
                .HasMaxLength(500);

            builder.Property(r => r.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(x => x.Column)
                .WithMany(c => c.Records)
                .HasForeignKey(r => r.ColumnId);
        }
    }
}