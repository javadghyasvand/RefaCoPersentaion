using System.Collections.Generic;
using My_Shop_Framework.Domain;

namespace AccountManagement.Domain.RoleAgg
{
    public class Role:EntityBase
    {
        public string Name { get; private set; }
        public List<Account.Agg.Account> Accounts { get;private set; }
        public List<Permission> Permissions { get; private set; }

        public Role()
        {

        }

        public Role(string name)
        {
            Name = name;
        }

        public Role(string name, List<Permission> permissions)
        {
            Name = name;
            Permissions = permissions;
        }

        public void Edit(string name,List<Permission> permissions)
        {
            Name = name;
            Permissions = permissions;
        }
    }
}