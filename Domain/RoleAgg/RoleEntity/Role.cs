using Domain.CompanyAgg.CompanyEntity;
using Domain.RoleAgg.MemberShipTypeEntity;
using Domain.UserAgg.UserRoleEntity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.RoleAgg.RoleEntity
{
    public class Role : IdentityRole<string>
    {
        public Role()
        {
            
        }

        public Role(string name, string? parentId, long companyId, bool accessAll,
            bool accessAllEmploye, DateTime roleExpireDate, long memberShipTypeId)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Parent = "";
            ParentId = parentId;
            AccessAll = accessAll;
            AccessAllEmploye = accessAllEmploye;
            RoleExpireDate = roleExpireDate;
            MemberShipTypeId = memberShipTypeId;
            CompanyId = companyId;
        }

        public long CompanyId { get; private set; }
        public string? ParentId { get; private set; }
        public long MemberShipTypeId { get; private set; }
        public string Parent { get; private set; }
        public DateTime RoleExpireDate { get; private set; }
        public long GKey { get; private set; }
        public bool AccessAll { get; private set; }
        public bool AccessAllEmploye { get; private set; }


        [ForeignKey(nameof(ParentId))]
        public Role? ParentRole { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public Company? Company { get; set; }
        [ForeignKey(nameof(MemberShipTypeId))]
        public virtual MemberShipType MemberShipType { get; set; }
        public ICollection<Role> SubRoles { get; set; } = [];
        public ICollection<UserRole>? UserRoles { get; set; } = [];


        public Role Edit(string name, string? parentId, long companyId, bool accessAll,
            bool accessAllEmploye, long memberShipTypeId, DateTime roleExpireDate)
        {
            Name = name;
            Parent = "";
            ParentId = parentId;
            AccessAll = accessAll;
            AccessAllEmploye = accessAllEmploye;
            RoleExpireDate = roleExpireDate;
            CompanyId = companyId;
            MemberShipTypeId = memberShipTypeId;

            return this;
        }

        public Role SetParents(string parents)
        {
            Parent = parents;
            return this;
        }
    }
}
