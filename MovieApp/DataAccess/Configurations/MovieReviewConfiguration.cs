using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.Models;

namespace MovieApp.DataAccess.Configurations
{
    public class MovieReviewConfiguration : IEntityTypeConfiguration<MovieReview>
    {
        public void Configure(EntityTypeBuilder<MovieReview> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Username).HasMaxLength(50);
            builder.Property(p => p.Review).HasMaxLength(500);
        }
    }
}
