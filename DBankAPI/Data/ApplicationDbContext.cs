using System;
using System.Collections.Generic;
using System.Text;
using DBankAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DBankAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<ContaCorrente> ContasCorrentes { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("DataSource=app.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ContaCorrente>().HasKey(p => new { p.Id });
            modelBuilder.Entity<Lancamento>().HasKey(p => new { p.Id });

            //pega as configuracoes das classes que estao com o DbSet   
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            
            modelBuilder.Entity<ContaCorrente>().HasData(
                new ContaCorrente { Id = 1, Email = "origem@gmail.com", Numero = 20232, Digito = '8' },
                new ContaCorrente { Id = 2, Email = "destino@gmail.com",  Numero = 12345, Digito = 'x' }
            );


            //Seed Usuário Origem
            string UserOrigem_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            
            var appUser = new IdentityUser
            {
                Id = UserOrigem_ID,
                Email = "origem@gmail.com",
                EmailConfirmed = true,
                UserName = "origem@gmail.com"
            };

            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "DbSP2021*");

            modelBuilder.Entity<IdentityUser>().HasData(appUser);            
            
            //Seed Usuário Destino
            string UserDestino_ID = "89cc6d4a-dc38-4e01-a2f5-3b64211ef3dd";
            
            var appUserDestino = new IdentityUser
            {
                Id = UserDestino_ID,
                Email = "destino@gmail.com",
                EmailConfirmed = true,
                UserName = "destino@gmail.com"
            };

            PasswordHasher<IdentityUser> phDestino = new PasswordHasher<IdentityUser>();
            appUserDestino.PasswordHash = ph.HashPassword(appUserDestino, "DbSP2021*");

            modelBuilder.Entity<IdentityUser>().HasData(appUserDestino);            

        }
    }
}
