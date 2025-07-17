using Domain.LocationAgg.LocationEntity;
using Domain.OrganizationAgg.ConfigOrganizationEntity;
using Domain.RoleAgg.RoleEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.CompanyAgg.CompanyEntity
{

    public class Company : AggregateRoot
    {
        public Company()
        {

        }

        public long? ParentId { get; private set; }
        public long LocationId { get; private set; }
        public string Parents { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }



        [ForeignKey(nameof(LocationId))]
        public Location Location { get; set; }
        [ForeignKey(nameof(ParentId))]
        public Company ParentCompany { get; set; }
        public ICollection<Company> SubCompanies { get; set; } = [];
        public ICollection<Role> Roles { get; set; } = [];
        public ICollection<ConfigOrganization> ConfigOrganizations { get; set; } = [];


        public Company(long parentId, string name, string address, string phone, long locationId)
        {
            LocationId = locationId;
            ParentId = parentId;
            Parents = "";
            Name = name;
            Address = address;
            Phone = phone;
        }

        public Company Edit(long parentId, string name, string address, string phone, long locationId)
        {
            LocationId = locationId;
            ParentId = parentId;
            Parents = "";
            Name = name;
            Address = address;
            Phone = phone;
            return this;
        }

        public Company SetParents(string parents)
        {
            Parents = parents;
            return this;
        }
    }
}
