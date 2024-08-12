using ECommerce.Comment.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Comment.Context
{
    public class CommentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1442;Database=ECommerceCommentDb;User=sa;Password=Password12*;TrustServerCertificate=True");
        }

        public DbSet<UserComment> UserComments { get; set; }
    }
}
