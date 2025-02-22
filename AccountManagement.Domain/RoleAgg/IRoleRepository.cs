using System.Collections.Generic;
using AccountManagement.Application.Contracts.Role;
using My_Shop_Framework.Domain;

namespace AccountManagement.Domain.RoleAgg
{
    public interface IRoleRepository:IRepository<long,Role>
    {
        List<RoleViewModel> GetRoles();
        long FirstRoles();
        EditRole GetDetails (long id);
    }
}