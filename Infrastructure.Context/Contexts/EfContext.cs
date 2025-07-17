using Domain.ApiEndpointAgg.ApiEndpointEntity;
using Domain.ClientAgg.ClientEntity;
using Domain.RoleAgg.RoleEntity;
using Domain.UserAgg.UserEntity;
using Domain.UserAgg.UserRoleEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Webgostar.Framework.Infrastructure.Contexts;
using Webgostar.Framework.Infrastructure.MediatR;

namespace Infrastructure.Context.Contexts
{

    public class EfContext(DbContextOptions<EfContext> options, ICustomPublisher customPublisher)
        : EfBaseContext(options, customPublisher, typeof(User).Assembly)
    {
        #region Auth
        public DbSet<User> User { get; set; }
        public DbSet<UserClaim> UserClaim { get; set; }
        public DbSet<UserLogin> UserLogin { get; set; }
        public DbSet<UserToken> UserToken { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RoleClaim> RoleClaim { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        #endregion
        public DbSet<Client> Client { get; set; }
        public DbSet<ApiEndpoint> ApiEndpoint { get; set; }
        public DbSet<ApiEndpointType> ApiEndpointType { get; set; }
        public DbSet<RoleApiPermission> RoleApiPermission { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.HasSequence<int>("LocationType_GKey");
            builder.HasSequence<int>("Role_GKey");
            //builder.HasSequence<int>("Section_GKey");
            //builder.HasSequence<int>("Position_GKey");
            //builder.HasSequence<int>("Rank_GKey");
            //builder.HasSequence<int>("ConfigOrganizationType_GKey");

            var version = GetStoreOptions()?.SchemaVersion ?? IdentitySchemaVersions.Version1;
            OnModelCreatingVersion(builder, version);
        }

        protected virtual Version SchemaVersion => GetStoreOptions()?.SchemaVersion ?? IdentitySchemaVersions.Version1;

        private StoreOptions? GetStoreOptions() => this.GetService<IDbContextOptions>()
                            .Extensions.OfType<CoreOptionsExtension>()
                            .FirstOrDefault()?.ApplicationServiceProvider
                            ?.GetService<IOptions<IdentityOptions>>()
                            ?.Value?.Stores;

        private sealed class PersonalDataConverter(IPersonalDataProtector protector)
            : ValueConverter<string, string>(s => protector.Protect(s), s => protector.Unprotect(s), null);

        internal virtual void OnModelCreatingVersion(ModelBuilder builder, Version schemaVersion)
        {
            if (schemaVersion >= IdentitySchemaVersions.Version2)
            {
                OnModelCreatingVersion2(builder);
            }
            else
            {
                OnModelCreatingVersion1(builder);
            }
        }

        internal virtual void OnModelCreatingVersion2(ModelBuilder builder)
        {
            var storeOptions = GetStoreOptions();
            var maxKeyLength = storeOptions?.MaxLengthForKeys ?? 0;
            if (maxKeyLength == 0)
            {
                maxKeyLength = 128;
            }
            var encryptPersonalData = storeOptions?.ProtectPersonalData ?? false;
            PersonalDataConverter? converter = null;

            builder.Entity<User>(b =>
            {
                b.HasKey(u => u.Id);
                b.HasIndex(u => u.NormalizedUserName).HasDatabaseName("UserNameIndex").IsUnique();
                b.HasIndex(u => u.NormalizedEmail).HasDatabaseName("EmailIndex");

                b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();
                b.Property(u => u.UserName).HasMaxLength(256);
                b.Property(u => u.NormalizedUserName).HasMaxLength(256);
                b.Property(u => u.Email).HasMaxLength(256);
                b.Property(u => u.NormalizedEmail).HasMaxLength(256);
                b.Property(u => u.PhoneNumber).HasMaxLength(256);

                if (encryptPersonalData)
                {
                    converter = new PersonalDataConverter(this.GetService<IPersonalDataProtector>());
                    var personalDataProps = typeof(User).GetProperties().Where(
                                    prop => Attribute.IsDefined(prop, typeof(ProtectedPersonalDataAttribute)));
                    foreach (var p in personalDataProps)
                    {
                        if (p.PropertyType != typeof(string))
                        {
                            throw new InvalidOperationException();
                        }
                        b.Property(typeof(string), p.Name).HasConversion(converter);
                    }
                }

                b.HasMany<UserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();
                b.HasMany<UserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();
                b.HasMany<UserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();
            });

            builder.Entity<UserClaim>(b =>
            {
                b.HasKey(uc => uc.Id);
            });

            builder.Entity<UserLogin>(b =>
            {
                b.HasKey(l => new { l.LoginProvider, l.ProviderKey });

                if (maxKeyLength > 0)
                {
                    b.Property(l => l.LoginProvider).HasMaxLength(maxKeyLength);
                    b.Property(l => l.ProviderKey).HasMaxLength(maxKeyLength);
                }
            });

            builder.Entity<UserToken>(b =>
            {
                b.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

                if (maxKeyLength > 0)
                {
                    b.Property(t => t.LoginProvider).HasMaxLength(maxKeyLength);
                    b.Property(t => t.Name).HasMaxLength(maxKeyLength);
                }

                if (encryptPersonalData)
                {
                    var tokenProps = typeof(UserToken).GetProperties().Where(
                                    prop => Attribute.IsDefined(prop, typeof(ProtectedPersonalDataAttribute)));
                    foreach (var p in tokenProps)
                    {
                        if (p.PropertyType != typeof(string))
                        {
                            throw new InvalidOperationException();
                        }
                        b.Property(typeof(string), p.Name).HasConversion(converter);
                    }
                }
            });

            builder.Entity<User>(b =>
            {
                b.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
            });

            builder.Entity<Role>(b =>
            {
                b.HasKey(r => r.Id);
                b.HasIndex(r => r.NormalizedName).HasDatabaseName("RoleNameIndex").IsUnique();
                b.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

                b.Property(u => u.Name).HasMaxLength(256);
                b.Property(u => u.NormalizedName).HasMaxLength(256);

                b.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();
                b.HasMany<RoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
            });

            builder.Entity<RoleClaim>(b =>
            {
                b.HasKey(rc => rc.Id);
            });

            builder.Entity<UserRole>(b =>
            {
                b.HasKey(r => new { r.UserId, r.RoleId });
            });

            builder.Entity<User>().ToTable("User");
            builder.Entity<Role>().ToTable("Role");
            builder.Entity<UserClaim>().ToTable("UserClaim");
            builder.Entity<UserLogin>().ToTable("UserLogin");
            builder.Entity<UserToken>().ToTable("UserToken");
            builder.Entity<UserRole>().ToTable("UserRole");
            builder.Entity<RoleClaim>().ToTable("RoleClaim");
        }

        internal virtual void OnModelCreatingVersion1(ModelBuilder builder)
        {
            var storeOptions = GetStoreOptions();
            var maxKeyLength = storeOptions?.MaxLengthForKeys ?? 0;
            var encryptPersonalData = storeOptions?.ProtectPersonalData ?? false;
            PersonalDataConverter? converter = null;

            builder.Entity<User>(b =>
            {
                b.HasKey(u => u.Id);
                b.HasIndex(u => u.NormalizedUserName).HasDatabaseName("UserNameIndex").IsUnique();
                b.HasIndex(u => u.NormalizedEmail).HasDatabaseName("EmailIndex");

                b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();
                b.Property(u => u.UserName).HasMaxLength(256);
                b.Property(u => u.NormalizedUserName).HasMaxLength(256);
                b.Property(u => u.Email).HasMaxLength(256);
                b.Property(u => u.NormalizedEmail).HasMaxLength(256);

                if (encryptPersonalData)
                {
                    converter = new PersonalDataConverter(this.GetService<IPersonalDataProtector>());
                    var personalDataProps = typeof(User).GetProperties().Where(
                                    prop => Attribute.IsDefined(prop, typeof(ProtectedPersonalDataAttribute)));
                    foreach (var p in personalDataProps)
                    {
                        if (p.PropertyType != typeof(string))
                        {
                            throw new InvalidOperationException();
                        }
                        b.Property(typeof(string), p.Name).HasConversion(converter);
                    }
                }

                b.HasMany<UserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();
                b.HasMany<UserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();
                b.HasMany<UserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();
            });

            builder.Entity<UserClaim>(b =>
            {
                b.HasKey(uc => uc.Id);
            });

            builder.Entity<UserLogin>(b =>
            {
                b.HasKey(l => new { l.LoginProvider, l.ProviderKey });

                if (maxKeyLength > 0)
                {
                    b.Property(l => l.LoginProvider).HasMaxLength(maxKeyLength);
                    b.Property(l => l.ProviderKey).HasMaxLength(maxKeyLength);
                }
            });

            builder.Entity<UserToken>(b =>
            {
                b.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

                if (maxKeyLength > 0)
                {
                    b.Property(t => t.LoginProvider).HasMaxLength(maxKeyLength);
                    b.Property(t => t.Name).HasMaxLength(maxKeyLength);
                }

                if (encryptPersonalData)
                {
                    var tokenProps = typeof(UserToken).GetProperties().Where(
                                    prop => Attribute.IsDefined(prop, typeof(ProtectedPersonalDataAttribute)));
                    foreach (var p in tokenProps)
                    {
                        if (p.PropertyType != typeof(string))
                        {
                            throw new InvalidOperationException();
                        }
                        b.Property(typeof(string), p.Name).HasConversion(converter);
                    }
                }
            });

            builder.Entity<User>(b =>
            {
                b.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
            });

            builder.Entity<Role>(b =>
            {
                b.HasKey(r => r.Id);
                b.HasIndex(r => r.NormalizedName).HasDatabaseName("RoleNameIndex").IsUnique();
                b.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

                b.Property(u => u.Name).HasMaxLength(256);
                b.Property(u => u.NormalizedName).HasMaxLength(256);

                b.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();
                b.HasMany<RoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
            });

            builder.Entity<RoleClaim>(b =>
            {
                b.HasKey(rc => rc.Id);
            });

            builder.Entity<UserRole>(b =>
            {
                b.HasKey(r => new { r.UserId, r.RoleId });
            });

            builder.Entity<User>().ToTable("User");
            builder.Entity<Role>().ToTable("Role");
            builder.Entity<UserClaim>().ToTable("UserClaim");
            builder.Entity<UserLogin>().ToTable("UserLogin");
            builder.Entity<UserToken>().ToTable("UserToken");
            builder.Entity<UserRole>().ToTable("UserRole");
            builder.Entity<RoleClaim>().ToTable("RoleClaim");
        }
    }
}