using Domain.FormAgg.FormEntity;

namespace Domain.FormAgg.FormTypeEntity
{
    public class FormType : AggregateRoot
    {
        public FormType()
        {

        }

        public string Name { get; set; }

        public virtual ICollection<Form> Type { get; set; }
    }
}
