using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Common;

namespace Ordering.Infrastructure.Persistence.Configurations
{
    public class BaseAuditableEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseAuditableEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(o => o.LastModifiedBy).HasMaxLength(100);
        }
    }
}
