using CMSChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace CMSChallenge.Infrastructure.Context
{
    public class ArticlesContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<ArticleKeyword> ArticleKeywords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ArticlesDB.sqlite");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleKeyword>()
                .HasKey(ak => new { ak.ArticleId, ak.KeywordId });

            modelBuilder.Entity<ArticleKeyword>()
                .HasOne(ak => ak.Article)
                .WithMany(a => a.ArticleKeywords)
                .HasForeignKey(ak => ak.ArticleId);

            modelBuilder.Entity<ArticleKeyword>()
                .HasOne(ak => ak.Keyword)
                .WithMany(k => k.ArticleKeywords)
                .HasForeignKey(ak => ak.KeywordId);
        }
    }
}
