using Domain.RoleAgg.RoleFormEntity;

namespace Domain.FormAgg.FormEntity
{
    public class Form : AggregateRoot
    {
        public Form(string formNamePersian, string parent, long formTypeId, string formUrl, string icon, int order)
        {
            FormNamePersian = formNamePersian;
            Parent = parent;
            FormTypeId = formTypeId;
            FormUrl = formUrl;
            Icon = icon;
            Order = order;
        }

        public long? ParentId { get; private set; }
        public long FormTypeId { get; set; }
        public string FormNamePersian { get; private set; }
        public string FormUrl { get; set; }
        public string Parent { get; private set; }
        public string Icon { get; private set; }
        public int Order { get; private set; }

        public virtual ICollection<Form> ParentForms { get; set; }
        public virtual ICollection<RoleForm> RoleForms { get; set; }
    }
}
