using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.Account.Agg
{
    public class SmsSent 
    {
        #region general
        public virtual int Id { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual string? CreatorUserId { get; set; }
        public virtual ApplicationUser CreatorUser { get; set; }
        #endregion

        public string Text { get; set; }
        public string PhoneNumber { get; set; }
        public virtual string? ReciverUserId { get; set; }
        public virtual ApplicationUser ReciverUser { get; set; }
    }
}
