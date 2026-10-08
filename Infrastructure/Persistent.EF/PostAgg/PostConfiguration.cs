using Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.PostAgg;
using Domain.UserAgg;

namespace Infrastructure.Persistent.EF.PostAgg; 
public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts", "post");

        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(60);

        builder.Property(b => b.Text)
            .IsRequired()
            .HasMaxLength(500);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.WrittenBy)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

    }
}
