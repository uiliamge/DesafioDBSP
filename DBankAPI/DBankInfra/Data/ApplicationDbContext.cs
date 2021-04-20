using DBankAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DBankAPI.DBankInfra.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<ContaCorrente> ContasCorrentes { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("DataSource=app.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ContaCorrente>().HasKey(p => new { p.Id });
            modelBuilder.Entity<Lancamento>().HasKey(p => new { p.Id });
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            SeedUsersEContasCorrentes(modelBuilder);
            SeedRoles(modelBuilder);
            SeedUserRoles(modelBuilder);
        }

        #region Seeds

        private void SeedUsersEContasCorrentes(ModelBuilder builder)
        {            
            //Seed usuário Admin
            IdentityUser user = new IdentityUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                Email =    "admin@dbsp.pro",
                UserName = "admin@dbsp.pro",
                EmailConfirmed = true,
                LockoutEnabled = false,
            };
            user.NormalizedEmail = user.Email.ToUpper();
            user.NormalizedUserName = user.UserName.ToUpper();
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            user.PasswordHash = ph.HashPassword(user, "DbSP2021*");
            builder.Entity<IdentityUser>().HasData(user);

            //Seed Usuário Origem            
            user = new IdentityUser
            {
                Id = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                Email = "origem@dbsp.pro",
                UserName = "origem@dbsp.pro",
                EmailConfirmed = true,
                LockoutEnabled = false
            };
            user.NormalizedEmail = user.Email.ToUpper();
            user.NormalizedUserName = user.UserName.ToUpper();
            PasswordHasher<IdentityUser> phOrigem = new PasswordHasher<IdentityUser>();
            user.PasswordHash = phOrigem.HashPassword(user, "DbSP2021*");
            builder.Entity<IdentityUser>().HasData(user);

            //Conta corrente do usuário Origem
            builder.Entity<ContaCorrente>().HasData(new ContaCorrente { Id = 1, UserId = user.Id, Numero = 123123 });


            //Seed Usuário Destino

            user = new IdentityUser
            {
                Id = "89cc6d4a-dc38-4e01-a2f5-3b64211ef3dd",
                Email = "destino@dbsp.pro",
                UserName = "destino@dbsp.pro",
                EmailConfirmed = true,
                LockoutEnabled = false
            };
            user.NormalizedEmail = user.Email.ToUpper();
            user.NormalizedUserName = user.UserName.ToUpper();
            PasswordHasher<IdentityUser> phDestino = new PasswordHasher<IdentityUser>();
            user.PasswordHash = phDestino.HashPassword(user, "DbSP2021*");
            builder.Entity<IdentityUser>().HasData(user);

            //Conta corrente do usuário destino
            builder.Entity<ContaCorrente>().HasData(new ContaCorrente { Id = 2, UserId = user.Id, Numero = 12345 });
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "Clientes", ConcurrencyStamp = "2", NormalizedName = "Clientes" }
                );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" },
                new IdentityUserRole<string>() { RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330", UserId = "02174cf0–9412–4cfe-afbf-59f706d72cf6" },
                new IdentityUserRole<string>() { RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330", UserId = "89cc6d4a-dc38-4e01-a2f5-3b64211ef3dd" }
                );
        }

        #endregion
    }
}

