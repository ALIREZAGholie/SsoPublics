using Domain.CompanyAgg.CompanyEntity;
using Domain.UserAgg.UserEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.RoleAgg.MemberShipTypeEntity
{
    public class MemberShipType : AggregateRoot
    {
        public MemberShipType(string name)
        {
            Name = name;
        }

        public long CompanyId { get; private set; }
        public string Name { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public Company? Company { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
