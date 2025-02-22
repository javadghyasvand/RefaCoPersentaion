using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.Account.Agg;
using Microsoft.EntityFrameworkCore;
using My_Shop_Framework.Application;
using My_Shop_Framework.Infrastructure;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class AccountRepository : RepositoryBase<long, Account>, IAccountRepository
    {
        private readonly AccountContext _accountContext;

        public AccountRepository(AccountContext accountContext) : base(accountContext)
        {
            _accountContext = accountContext;
        }

        public Account GetBy(string userName)
        {
            return _accountContext.Accounts.FirstOrDefault(a => a.UserName == userName);
        }

        /*public EditAccount GetDetails(long id)
        {
            return _accountContext.Accounts.Select(x => new EditAccount
            {
                Id = x.Id,
                *//*FullName = x.FullName,*//*
                Mobile = x.Mobile,
                RoleId = x.RoleId,
                UserName = x.UserName,
                PictureString = x.ProfilePhoto
            }).FirstOrDefault(x => x.Id == id);
        }*/
        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            var query = _accountContext.Accounts.Include(x => x.Role).Select(x => new AccountViewModel
            {
                Id = x.Id,
                UserName = x.UserName,
                FullName = x.FullName,
                Mobile = x.Mobile,
                ProfilePhoto = x.ProfilePhoto,
                Role = x.Role.Name,
                RoleId = x.RoleId,
                CreationDate = x.CreationDateTime.ToFarsi()
            }).OrderByDescending(x => x.Id);

            if (!string.IsNullOrWhiteSpace(searchModel.FullName))
                query.Where(x => x.FullName.Contains(searchModel.FullName));

            if (!string.IsNullOrWhiteSpace(searchModel.Mobile))
                query.Where(x => x.Mobile.Contains(searchModel.Mobile));

            if (!string.IsNullOrWhiteSpace(searchModel.UserName))
                query.Where(x => x.UserName.Contains(searchModel.UserName));

            if (searchModel.RoleId > 0)
                query.Where(x => x.RoleId == searchModel.RoleId);
            return query.ToList();
        }

        public List<AccountViewModel> ListAccounts()
        {
            var query = _accountContext.Accounts.Include(x => x.Role).Select(x => new AccountViewModel
            {
                Id = x.Id,
                UserName = x.UserName,
                FullName = x.FullName,
                Mobile = x.Mobile,
                ProfilePhoto = x.ProfilePhoto,
                Role = x.Role.Name,
                RoleId = x.RoleId,
                CreationDate = x.CreationDateTime.ToFarsi()
            }).OrderByDescending(x => x.Id);
            return query.ToList();
        }

        public EditAccount GetDetails(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}