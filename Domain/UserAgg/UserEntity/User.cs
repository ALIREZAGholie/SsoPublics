using Domain._DomainValueObjects;
using Domain.UserAgg.UserRoleEntity;
using Microsoft.AspNetCore.Identity;

namespace Domain.UserAgg.UserEntity
{
    public class User : IdentityUser<string>
    {
        public User()
        {

        }

        public User(string firstName, string lastName, PhoneNumber userName)
        {
            Id = Guid.NewGuid().ToString();
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            PhoneNumber = userName;
            FullName = $"{firstName} {lastName}";
            LockoutEnd = null;
            LockoutEnabled = false;
            AccessFailedCount = 0;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName { get; private set; }


        public ICollection<UserRole>? UserRoles { get; set; } = [];

        public void LoginFailed()
        {
            AccessFailedCount++;
        }

        public void LoginLock(DateTimeOffset? lockoutEnd)
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
