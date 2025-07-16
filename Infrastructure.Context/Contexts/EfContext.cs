using Domain.RoleAgg.RoleEntity;
using Domain.UserAgg.UserEntity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Webgostar.Framework.Infrastructure.Contexts;
using Webgostar.Framework.Infrastructure.MediatR;

namespace Infrastructure.Context.Contexts
{
    public class EfContext(DbContextOptions<EfContext> options, ICustomPublisher customPublisher)
        : EfBaseContext(options, customPublisher, typeof(User).Assembly)
    {
        public DbSet<User> User{ get; set; }
        public DbSet<Role> Role{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }

    //public class EfContext : IdentityDbContext<User>
    //{
    //    public EfContext(DbContextOptions<EfContext> options)
    //        : base(options) { }
    //}
}