using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AccountManagement.Domain.Account.Agg;
using System.Security.Policy;
namespace AccountManagement.Domain.Account.Agg
{
    public class MessageService : IMessageService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        const string ApiKey = "556942772F684671776338745A524F7951716A6559542F395A69506B6E555978787976666F3477542F57633D";
        public MessageService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<bool> SendSms(SmsTemplate template, string phoneNmuber, string number)
        {

            /*var ReciverUser = await _userManager.FindByNameAsync(UserName);*/

            using (var httpClient = new HttpClient())
            {
                var response1 = await httpClient.GetAsync("https://api.kavenegar.com/v1/" + $"{ApiKey}/verify/lookup.json?receptor={phoneNmuber}&token={number}&template={template}");
            }
            return true;
        }

        public async Task<bool> SendStringSms(SmsTemplate template, string phoneNumber, string name)
        {
            using (var httpClient = new HttpClient())
            {
                var response2 = await httpClient.GetAsync("https://api.kavenegar.com/v1/" + $"{ApiKey}/verify/lookup.json?receptor={phoneNumber}&token={name}&template={template}");
            }
            return true;
        }
        /*public async Task<bool> SendSms(SmsTemplate template, string UserName, string CreatorUserName, string number, bool IsAccept)
{

var AcceptUser = await _userManager.FindByNameAsync(UserName);
var CreatorUser = await _userManager.FindByNameAsync(UserName);

if (!CreatorUser.PhoneNumber.IsNullOrEmpty() && CreatorUser.EnableToSendSms)
{
using (var httpClient = new HttpClient())
{

  string state = IsAccept ? "تایید" : "رد";
  var response1 = await httpClient.GetAsync("https://api.kavenegar.com/v1/" + $"{ApiKey}/verify/lookup.json?receptor={CreatorUser.PhoneNumber}&token=E-{number}&token3={state}&template={template}");
}
}
return true;
}

public async Task<bool> SendSmsVerify(SmsTemplate template, string ProductionNumber, List<string> RoleNames)
{
RoleNames.Add("SuperAdmin");
foreach (var roleName in RoleNames)
{
var users = await _userManager.GetUsersInRoleAsync(roleName);
if (users != null)
{
  foreach (var user in users)
  {
      if (!user.PhoneNumber.IsNullOrEmpty() && user.EnableToSendSms)
      {
          using (var httpClient = new HttpClient())
          {
              var response1 = await httpClient.GetAsync("https://api.kavenegar.com/v1/" + $"{ApiKey}/verify/lookup.json?receptor={user.PhoneNumber}&token={ProductionNumber}&template={template}");

          }
      }
  }
}
}




return true;
}

public async Task<bool> Send2Fa(SmsTemplate template, string phoneNumber, string token)
{
if (!phoneNumber.IsNullOrEmpty())
{
using (var httpClient = new HttpClient())
{
  var response1 = await httpClient.GetAsync("https://api.kavenegar.com/v1/" + $"{ApiKey}/verify/lookup.json?receptor={phoneNumber}&token={token}&template={template}");

}
}

return true;
}
}*/
    }
}
