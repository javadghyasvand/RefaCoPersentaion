using System.Collections.Generic;
using AccountManagement.Application.Contracts.Account;
using My_Shop_Framework.Domain;

namespace AccountManagement.Domain.Account.Agg
{
    public interface IAccountRepository:IRepository<long,Account>
    {
        Account  GetBy(string userName);
        EditAccount GetDetails(long id);
        List<AccountViewModel> Search(AccountSearchModel searchModel);
        List<AccountViewModel> ListAccounts();
    }
}