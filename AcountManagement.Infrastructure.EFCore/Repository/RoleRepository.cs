using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Domain.Account.Agg;
using AccountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using My_Shop_Framework.Application;
using My_Shop_Framework.Infrastructure;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class RoleRepository : RepositoryBase<long, Role>, IRoleRepository
    {
        private readonly AccountContext _accountContext;

        public RoleRepository(AccountContext accountContext) : base(accountContext)
        {
            _accountContext = accountContext;
        }

        public List<RoleViewModel> GetRoles()
        {
            var query = _accountContext.Roles.Select(x => new RoleViewModel()
            {
                Id = x.Id.ToString(),
                Name = x.Name,
                CreationDate = x.CreationDateTime.ToFarsi()
            }).OrderByDescending(x => x.Id);


            return query.ToList();
        }

        public long FirstRoles()
        {
            var roleId = _accountContext.Roles.Select(x => new
            {
                x.Id,
            }).First();


            return roleId.Id;
        }

        public EditRole GetDetails(long id)
        {
            /* var role = _accountContext.Roles.Select(x => new EditRole
             {
                 Id = x.Id,
                 Name = x.Name,
                 MappedPermissions = MapPermissions(x.Permissions)
             }).AsNoTracking().FirstOrDefault(x => x.Id == id);
             role.Permissions = role.MappedPermissions.Select(x => x.Code).ToList();
             return role;*/
            return null;
        }

        private static List<PermissionsDto> MapPermissions(IEnumerable<Permission> xPermissions)
        {
            return xPermissions.Select(x => new PermissionsDto(x.Code, x.Name)).ToList();
        }
    }
}