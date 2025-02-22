using AccountManagement.Domain.Account.Agg;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;
using My_Shop_Framework.Application;

namespace ServiceHost.Pages.Profile
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly EmailSender _emailSender;
        private readonly IAntiforgery _antiforgery;
        private string _errorMessage;

        public IndexModel(UserManager<ApplicationUser> userManager, EmailSender emailSender, IAntiforgery antiforgery)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _antiforgery = antiforgery;
        }
        public string RequestVerificationToken { get; private set; }
        public UserProfileViewModel UserProfile { get; set; }

        public async Task OnGetAsync()
        {
            RequestVerificationToken = _antiforgery.GetAndStoreTokens(HttpContext).RequestToken;
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                UserProfile = new UserProfileViewModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,

                    RegistrationDate = user.CreateDate.ToString(),
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email
                };
            }
        }

        public async Task<IActionResult> OnPostSetEmailAsync([FromBody] string email)
        {
            // Validate the email input
            if (string.IsNullOrEmpty(email))
            {
                _errorMessage = LoginMessage.GetMessage("EmailEmpty", CultureInfo.CurrentCulture.Name);
                return BadRequest(new { success = false, message = _errorMessage });
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                _errorMessage = LoginMessage.GetMessage("EmailFormat", CultureInfo.CurrentCulture.Name);
                return BadRequest(new { success = false, message = _errorMessage });
            }

            // Optionally, fetch the current user from the database
            // Example: If using Identity
            var userId = User?.Identity?.Name; // Adjust based on your authentication setup
            if (userId == null)
            {
                _errorMessage = LoginMessage.GetMessage("UserNotFound", CultureInfo.CurrentCulture.Name);
                return StatusCode(401, new { success = false, message = _errorMessage });
            }

            // Save email to the database
            try
            {
                // Assuming you have a UserManager<ApplicationUser> injected and ApplicationUser includes the Email field
                var user = await _userManager.FindByNameAsync(userId);
                if (user == null)
                {
                    _errorMessage = LoginMessage.GetMessage("UserNotFound", CultureInfo.CurrentCulture.Name);
                    return NotFound(new { success = false, message = _errorMessage });
                }

                user.Email = email;
                user.EmailConfirmed = false; // Optional: For confirmation workflow
                var updateResult = await _userManager.UpdateAsync(user);
                if (!updateResult.Succeeded)
                {
                    _errorMessage = LoginMessage.GetMessage("UpdatingEmail", CultureInfo.CurrentCulture.Name);
                    return StatusCode(500, new { success = false, message = _errorMessage });
                }
            }
            catch (Exception ex)
            {
                _errorMessage = LoginMessage.GetMessage("SaveEmail", CultureInfo.CurrentCulture.Name);
                Console.WriteLine($"Error updating email: {ex.Message}");
                return StatusCode(500, new { success = false, message = _errorMessage });
            }

            // Send a confirmation email
            try
            {
                
                _errorMessage = LoginMessage.GetMessage("EmailVerification", CultureInfo.CurrentCulture.Name);
                var subject = "_errorMessage";
                var body = $"<p>ایمیل شما با موفقیت ثبت شد.</p><p>آدرس ایمیل: {email}</p>";
                await _emailSender.SendEmailAsync(email, subject, body);
            }
            catch (Exception ex)
            {
                // Log the exception
                _errorMessage = LoginMessage.GetMessage("SendEmail", CultureInfo.CurrentCulture.Name);
                Console.WriteLine($"Error sending email: {ex.Message}");
                return StatusCode(500, new { success = false, message = _errorMessage });
            }

            _errorMessage = LoginMessage.GetMessage("SendSuccess", CultureInfo.CurrentCulture.Name);
            return new JsonResult(new { success = true, message = _errorMessage });
        }

        public class UserProfileViewModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string RegistrationDate { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string Role { get; set; }
        }

        public class SetEmailRequest
        {
            public string Email { get; set; }
        }
    }
}
