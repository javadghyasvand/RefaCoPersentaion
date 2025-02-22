using GeneralManagement.Domain.AboutAgg;
using GeneralManagement.Domain.CertificateAgg;
using GeneralManagement.Domain.FaqAgg;
using GeneralManagement.Domain.GalleryAgg;
using GeneralManagement.Domain.GeneralAgg;
using GeneralManagement.Domain.LogoAgg;
using GeneralManagement.Domain.SocialMediaAgg;
using GeneralManagement.Domain.WarrantyAgg;
using GeneralManagement.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GeneralManagement.Infrastructure.EFCore
{
    public class GeneralContext: DbContext
    {
        public DbSet<SiteLogo> SiteLogos { get; set; }
        public DbSet<GeneralSetting> GeneralSettings { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Warranty> Warranty { get; set; }
        public GeneralContext(DbContextOptions<GeneralContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(SiteLogoMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}