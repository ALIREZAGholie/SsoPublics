using Domain.UserAgg.UserRoleEntity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.UserAgg.RoleEntity
{
    public class Role : IdentityRole<string>
    {
        public Role()
        {

        }

        public Role(string name, string? parentId, DateTime roleExpireDate)
        {
            Name = name;
            Parent = "";
            ParentId = parentId;
            RoleExpireDate = roleExpireDate;
            Guid = Guid.NewGuid();
        }

        public string? ParentId { get; private set; }
        public string Parent { get; private set; }
        public Guid Guid { get; private set; }
        public DateTime RoleExpireDate { get; private set; }
        public long GKey { get; private set; }


        [ForeignKey(nameof(ParentId))]
        public Role? ParentRole { get; set; }
        public ICollection<Role> SubRoles { get; set; } = [];
        public ICollection<UserRole>? UserRoles { get; set; } = [];


        public Role Edit(string name, string? parentId, DateTime roleExpireDate)
        {
            Name = name;
            Parent = "";
            ParentId = parentId;
            RoleExpireDate = roleExpireDate;
            return this;
        }

        public Role SetParents(string parents)
        {
            Parent = parents;
            return this;
        }
    }
}
