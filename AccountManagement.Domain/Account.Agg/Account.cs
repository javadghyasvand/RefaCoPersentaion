using My_Shop_Framework.Domain;
using AccountManagement.Domain.RoleAgg;

namespace AccountManagement.Domain.Account.Agg
{
    public class Account : EntityBase
    {
        public string FullName { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Mobile { get; private set; }
        public string ProfilePhoto { get; private set; }
        public long RoleId { get; private set; }
        public Role Role { get; private set; }

        public Account(string fullName, string userName, string password, string mobile, string profilePhoto,
            long roleId)
        {
            FullName = fullName;
            UserName = userName;
            Password = password;
            Mobile = mobile;
            ProfilePhoto = profilePhoto;
            if (roleId == 0)
            {
                RoleId = 2;
            }
            else
            {
                RoleId = roleId;
            }
               
        }

        public void Edit(string fullName, string userName, string mobile, string profilePhoto, long roleId)
        {
            FullName = fullName;
            UserName = userName;
            Mobile = mobile;
            if (!string.IsNullOrWhiteSpace(profilePhoto))
                ProfilePhoto = profilePhoto;
            RoleId = roleId;
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }
    }
}