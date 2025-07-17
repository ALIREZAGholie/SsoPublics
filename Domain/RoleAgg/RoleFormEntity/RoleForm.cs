using Domain.FormAgg.FormEntity;
using Domain.RoleAgg.RoleEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.RoleAgg.RoleFormEntity
{
    public class RoleForm : AggregateRoot
    {
        public long FormId { get; set; }
        public long RoleId { get; set; }

        [ForeignKey(nameof(FormId))]
        public virtual Role Role { get; set; }
        [ForeignKey(nameof(RoleId))]
        public virtual Form Form { get; set; }
    }
}
