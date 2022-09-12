using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Template.Infrastructure.Repositories;
using Microsoft.Extensions.Options;

namespace Template.Infrastructure.Data
{
    public class TemplateContext : DbContext
    {
        // public  DbSet<Currency> Currencies { get; set; }
      
        public TemplateContext(){}

        public TemplateContext(DbContextOptions<TemplateContext> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Permiso> Permiso { get; set; }
        public DbSet<Usuario_Empresa> Usuario_Empresas { get; set; }
        public DbSet<Rol_Permiso> Rol_Permisos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
            var dbUser = Environment.GetEnvironmentVariable("DATABASE_USER");
            var dbPassword = Environment.GetEnvironmentVariable("DATABASE_PASSWORD");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
             
            var connectionString = $"Server={dbHost};port={dbPort};user id={dbUser};password={dbPassword};database={dbName};pooling=true";

            options.UseNpgsql(connectionString);


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Usuario_Empresa>().HasKey(x => new{ x.UsuarioId, x.EmpresaId, x.RolId });
            modelBuilder.Entity<Rol_Permiso>().HasKey(x => new { x.RolId, x.PermisoId });


            // modelBuilder.Entity<Industry>()
            //     .HasMany(c => c.Companies)
            //     .WithOne(c => c.Industry)
            //     .HasForeignKey(c => c.IndustryId)
            //     .IsRequired(false);

            // modelBuilder.Entity<Member>()
            //     .HasMany(m => m.Groups)
            //     .WithMany(g => g.Members)
            //     .UsingEntity<MemberGroup>(
            //         mg => mg.HasOne(g => g.Group).WithMany().HasForeignKey(g => g.GroupId),
            //         mg => mg.HasOne(m => m.Member).WithMany().HasForeignKey(m => m.MemberId),
            //         mg =>
            //         {
            //             mg.HasKey(m => new { m.GroupId, m.MemberId });
            //         }
            //     );

            // modelBuilder.Entity<GroupTaxonomy>()
            //     .HasKey(m => new { m.GroupId, m.TaxonomyId });


            // modelBuilder.Entity<MemberTaxonomy>()
            //     .HasKey(m => new { m.MemberId, m.TaxonomyId });


            // modelBuilder.Entity<Project>()
            //     .HasMany(p => p.Groups)
            //     .WithOne(g => g.Project)
            //     .HasForeignKey(g => g.ProjectId);

            // base.OnModelCreating(modelBuilder);

        }
    }
}
