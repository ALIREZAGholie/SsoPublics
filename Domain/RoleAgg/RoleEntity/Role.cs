using Domain.CompanyAgg.CompanyEntity;
using Domain.RoleAgg.RoleFormEntity;
using Domain.UserAgg.UserEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.RoleAgg.RoleEntity
{
    public class Role : AggregateRoot
    {
        public Role()
        {

        }

        public string Name { get; set; }
        public long CompanyId { get; private set; }
        public long? ParentId { get; private set; }
        public string Parent { get; private set; }
        public DateTime? RoleExpireDate { get; private set; }
        public long GKey { get; private set; }
        public bool AccessAll { get; private set; }
        public bool AccessAllEmploye { get; private set; }
        public Guid Guid { get; private set; }


        [ForeignKey(nameof(ParentId))]
        public Role? ParentRole { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public Company? Company { get; set; }
        public ICollection<Role> SubRoles { get; set; } = [];
        public ICollection<User>? Users { get; set; } = [];
        public ICollection<RoleForm>? RoleForms { get; set; } = [];


        public Role(string name, long? parentId, long companyId, bool accessAll,
            bool accessAllEmploye, DateTime? roleExpireDate = null)
        {
            Name = name;
            Parent = "";
            ParentId = parentId;
            AccessAll = accessAll;
            AccessAllEmploye = accessAllEmploye;
            RoleExpireDate = roleExpireDate;
            CompanyId = companyId;
            Guid = Guid.NewGuid();
        }

        public Role Edit(string name, long? parentId, long companyId, bool accessAll,
            bool accessAllEmploye, DateTime? roleExpireDate = null)
        {
            Name = name;
            Parent = "";
            ParentId = parentId;
            AccessAll = accessAll;
            AccessAllEmploye = accessAllEmploye;
            RoleExpireDate = roleExpireDate;
            CompanyId = companyId;

            return this;
        }

        public Role SetParents(string parents)
        {
            Parent = parents;
            return this;
        }
    }
}
