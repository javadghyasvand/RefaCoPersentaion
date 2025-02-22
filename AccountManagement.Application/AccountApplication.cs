using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.Account.Agg;
using AccountManagement.Domain.RoleAgg;
using My_Shop_Framework.Application;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IFileUploader _fileUploader;
        /* private readonly IAuthHelper _authHelper;*/

        public AccountApplication(IAccountRepository accountRepository, IPasswordHasher passwordHasher,
            IFileUploader fileUploader, /*IAuthHelper authHelper,*/ IRoleRepository roleRepository)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _fileUploader = fileUploader;
            /* _authHelper = authHelper;*/
            _roleRepository = roleRepository;
        }


        public OperationResult Register(RegisterAccount command)

        {
            var operation = new OperationResult();

            if (_accountRepository.Exists(x => x.UserName == command.UserName || x.Mobile == command.Mobile))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var filepath = "ProfilePhotos\\";

            var fileName = command.ProfilePhoto != null ? _fileUploader.FileUpload(command.ProfilePhoto, filepath) : "NoPhoto.png";

            command.Password = _passwordHasher.Hash(command.Password);
            var account = new Account(command.FullName, command.UserName, command.Password, command.Mobile, fileName,
                command.RoleId);
            _accountRepository.Create(account);
            _accountRepository.SaveChanges();
            return operation.Success();
        }

       /* public OperationResult Edit(EditAccount command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                operation.Failed(ApplicationMessages.RecordNotFund);

            if (_accountRepository.Exists(x =>
                    (x.UserName == command.UserName || x.Mobile == command.Mobile) && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var filepath = "ProfilePhotos\\";

            var fileName = command.ProfilePhoto != null ? _fileUploader.FileUpload(command.ProfilePhoto, filepath) : "NoPhoto.png";

            account.Edit(command.FullName, command.UserName, command.Mobile, fileName, command.RoleId);
            _accountRepository.SaveChanges();
            return operation.Success();
        }*/

        public OperationResult ChangePassword(ChangePassword command)
        {
            var operation = new OperationResult();
            /* var account = _accountRepository.Get(command.Id);
             if (account == null)
                 operation.Failed(ApplicationMessages.RecordNotFund);
             if (command.Password != command.RePassword)
                 return operation.Failed(ApplicationMessages.PasswordNotMatch);
             command.Password = _passwordHasher.Hash(command.Password);
             if (account != null)
                 account.ChangePassword(command.Password);
             else
                 operation.Failed(ApplicationMessages.RecordNotFund);
             _accountRepository.SaveChanges();*/
            return operation.Success();
        }

        public OperationResult Login(Login command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.GetBy(command.Email);
            if (account == null)
                return operation.Failed(ApplicationMessages.WrongUserPass);
            (bool Verified, bool NeedsUpgrade) result = _passwordHasher.Check(account.Password, command.Password);
            if (!result.Verified)
                return operation.Failed(ApplicationMessages.WrongUserPass);

            var permission = _roleRepository.Get(account.RoleId).Permissions.Select(x => x.Code).ToList();

            var authViewModel = new AuthViewModel
            {
                Id = account.Id,
                RoleId = account.RoleId,
                Name = account.FullName,
                UserName = account.UserName,
                Mobile = account.Mobile,
                Role = _roleRepository.GetDetails(account.RoleId).Name,
                ProfilePicture = account.ProfilePhoto,
                Permissions = permission
            };
            /* _authHelper.SignIn(authViewModel);*/
            return operation.Success();
        }

        public EditAccount GetDetails(long id)
        {
            return _accountRepository.GetDetails(id);
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            return _accountRepository.Search(searchModel);
        }

        public List<AccountViewModel> ListAccounts()
        {
            return _accountRepository.ListAccounts();
        }

        public AccountViewModel GetAccountById(long id)
        {
            var account = _accountRepository.Get(id);
            return new AccountViewModel
            {
                FullName = account.FullName,
                Mobile = account.Mobile
            };
        }


        public void Logout()
        {
            /* _authHelper.SignOut();*/
        }

        public OperationResult Edit(EditAccount command)
        {
            throw new System.NotImplementedException();
        }
    }
}