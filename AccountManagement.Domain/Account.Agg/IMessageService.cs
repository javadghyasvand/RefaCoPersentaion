using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.Account.Agg
{
    public interface IMessageService
    {
        public Task<bool> SendSms(SmsTemplate template, string phoneNumber, string number);
        public Task<bool> SendStringSms(SmsTemplate template, string phoneNumber, string name);
    }
}
