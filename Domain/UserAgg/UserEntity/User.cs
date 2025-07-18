using Domain._DomainException;
using Domain._DomainValueObjects;
using Domain.RoleAgg.RoleEntity;
using Domain.UserAgg.UserEntity.Services;
using Webgostar.Framework.Base.SecurityTools;

namespace Domain.UserAgg.UserEntity
{
    public class User : AggregateRoot
    {
        public User()
        {

        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public int AccessFailedCount { get; private set; }
        public bool LockoutEnabled { get; private set; }
        public long? LockoutEnd { get; private set; }
        public Guid Guid { get; private set; }

        public virtual ICollection<Role>? Roles { get; set; }


        public User(string firstName, string lastName, PhoneNumber userName,
            Password password, IUserDomainService domainService)
        {
            Guard(userName, domainService);
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = Hasher.HashPassword(UserName, password);
            FullName = $"{firstName} {lastName}";
            LockoutEnd = null;
            LockoutEnabled = false;
            AccessFailedCount = 0;
            Guid = Guid.NewGuid();
        }

        void Guard(string userName, IUserDomainService domainService)
        {
            if (domainService.IsExist(userName).Result)
                throw new InvalidDomainDataException("نام کاربری تکراری است");
        }

        public void LoginFailed()
        {
            AccessFailedCount++;
        }

        public void LoginLock(long? lockoutEnd)
        {
            LockoutEnabled = true;
            LockoutEnd = lockoutEnd;
        }

        public void LoginSuccess()
        {
            AccessFailedCount = 0;
            LockoutEnd = null;
            LockoutEnabled = false;
        }
    }
}
