using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Domain.Account.Agg
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public override bool LockoutEnabled { get; set; }
        public string ProfilePhotoPath { get; set; }
        public string? NationalCode { get; set; }
        public string? Position { get; set; }
        public string? OrganizationName { get; set; }
        public bool IsApproved { get; set; } = false;
    }
}
