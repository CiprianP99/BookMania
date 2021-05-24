using BookMania.Interfaces;
using BookMania.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookMania.Services
{

    public class AccountService : PageModel
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public UserManager<User> _userManager { get; set; }
        public SignInManager<User> SignInManager { get; set; }
        public ILogger<AccountService> Logger { get; set; }

        public AccountService(SignInManager<User> signInManager,
            ILogger<AccountService> logger,
            UserManager<User> userManager,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            SignInManager = signInManager;
            Logger = logger;
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public InputModelLogin InputLogin { get; set; }
        [BindProperty]
        public InputModelRegister InputRegister { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModelLogin
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public class InputModelRegister
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "UserName: ")]
            public string LoginName { get; set; }

            [Required]
            [Display(Name = "First Name: ")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name: ")]
            public string LastName { get; set; }

            [Display(Name = "City: ")]
            public string City { get; set; }

            [Display(Name = "Address: ")]
            public string Address { get; set; }

            [Display(Name = "Profile Image ")]
            public string ProfileImage { get; set; }

        }
        public async Task OnGetAsyncLogin(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await SignInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }
    }
}
