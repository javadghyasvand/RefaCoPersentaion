using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System;
using AccountManagement.Domain.Account.Agg;
using AccountManagement.Infrastructure.EFCore;

namespace ServiceHost.Utils
{
    public class CustomSignInManager : SignInManager<ApplicationUser>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AccountContext _dbContext;
        private readonly IHttpContextAccessor _contextAccessor;

        public CustomSignInManager(
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<ApplicationUser>> logger,
            AccountContext dbContext,
            IAuthenticationSchemeProvider schemeProvider,
            IUserConfirmation<ApplicationUser> userConfirmation
        )
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemeProvider, userConfirmation)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async override Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            var user = await _userManager.FindByNameAsync(userName);
            /*var user = await _userManager.FindByEmailAsync(userName);*/
            if (user == null)
                return SignInResult.Failed;
            if (user != null && !user.IsApproved)
                return SignInResult.NotAllowed;
            if (!user.LockoutEnabled)
                return SignInResult.NotAllowed;

            return await base.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);

        }
    }
}
