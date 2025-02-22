using System.Collections.Generic;
using My_Shop_Framework.Infrastructure;

namespace AccountManagement.Application.Contracts.Role
{
    public class EditRole:CreateRole
    {
        public string Id { get; set; }
        public List<PermissionsDto> MappedPermissions { get; set; }
    }
}