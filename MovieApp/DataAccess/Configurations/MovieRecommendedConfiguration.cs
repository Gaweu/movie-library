using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.Infrastucture.Models;

namespace MovieApp.DataAccess.Configurations
{
    public class MovieRecommendedConfiguration : IEntityTypeConfiguration<MovieRecommended>
    {
        public void Configure(EntityTypeBuilder<MovieRecommended> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
