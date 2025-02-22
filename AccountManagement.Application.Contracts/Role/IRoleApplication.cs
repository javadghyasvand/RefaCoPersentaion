using System.Collections.Generic;
using My_Shop_Framework.Application;

namespace AccountManagement.Application.Contracts.Role
{
    public interface IRoleApplication
    {
        OperationResult Create(CreateRole command);
        /*OperationResult Edit(EditRole command);*/
        List<RoleViewModel> GetRoles();
        EditRole GetDetails(long id);
    }
}