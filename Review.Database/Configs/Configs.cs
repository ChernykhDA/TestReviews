using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Review.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review.Database.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasOne(x => x.Role)
                .WithMany(y => y.Users);
        }
    }

    public class ReviewConfigs : IEntityTypeConfiguration<ReviewModel>
    {
        public void Configure(EntityTypeBuilder<ReviewModel> builder)
        {
            builder
                .Property(b => b.Like)
                .HasMaxLength(1000)
                .IsRequired();

            builder
                .Property(b => b.NotLike)
                .HasMaxLength(1000);

            builder
                .Property(b => b.Comment)
                .HasMaxLength(1000);

            builder
                .HasOne(x => x.User)
                .WithMany(y => y.ReviewModels);
        }

    }

    public class TokenConfigs : IEntityTypeConfiguration<UToken>
    {
        public void Configure(EntityTypeBuilder<UToken> builder)
        {
            builder
                .HasOne(x => x.User)
                .WithMany(y => y.UTokens);
        }

    }
}
