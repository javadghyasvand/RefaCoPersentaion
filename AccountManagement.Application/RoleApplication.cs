using System.Collections.Generic;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Domain.Account.Agg;
using AccountManagement.Domain.RoleAgg;
using My_Shop_Framework.Application;

namespace AccountManagement.Application
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _roleRepository;

        public RoleApplication(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }


        public OperationResult Create(CreateRole command)
        {
            var operation = new OperationResult();
            if (_roleRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var role = new Role(command.Name,new List<Permission>());
            _roleRepository.Create(role);
            _roleRepository.SaveChanges();
            return operation.Success();
        }

       /* public OperationResult Edit(EditRole command)
        {
            var operation = new OperationResult();
            var role = _roleRepository.Get(command.Id);
            if (role == null)
                operation.Failed(ApplicationMessages.RecordNotFund);

            if (_roleRepository.Exists(x =>x.Name == command.Name  && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var permission = new List<Permission>();
            command.Permissions.ForEach(code=>permission.Add(new Permission(code)));
            if (role != null) role.Edit(command.Name, permission);
            _roleRepository.SaveChanges();
            return operation.Success();
        }*/

        public List<RoleViewModel> GetRoles()
        {
            return _roleRepository.GetRoles();
        }

        public EditRole GetDetails(long id)
        {
            return _roleRepository.GetDetails(id);
        }
    }
}