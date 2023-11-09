using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using mySite.Data.Models;
using mySite.Utility;

namespace mySite.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "이메일")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "비밀번호")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "비밀번호 확인")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "이름")]
            public string Name { get; set; }

            [Required]
            [Display(Name = "닉네임")]
            public string NickName { get; set; }

            [Display(Name = "주소")]
            public string StreetAddress_1 { get; set; }

            [Display(Name = "주소2")]
            public string StreetAddress_2 { get; set; }

            [Display(Name = "주소 3")]
            public string StreetAddress_3 { get; set; }

            [Display(Name = "우편번호")]
            public string PostalCode { get; set; }

            [Display(Name = "핸드폰 번호")]
            public string PhoneNumber { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            string role = Request.Form["rdUserRole"].ToString();

            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = Input.Name,
                    Email = Input.Email,
                    NickName = Input.NickName,
                    StreetAddress_1 = Input.StreetAddress_1,
                    StreetAddress_2 = Input.StreetAddress_2,
                    StreetAddress_3 = Input.StreetAddress_3,
                    PostalCode = Input.PostalCode,
                    RegisteredDate = DateTime.Now
                };

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    // Admin 계정 생성
                    if (!await _roleManager.RoleExistsAsync(roleName: SD.Admin))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.Admin));
                    }

                    await _userManager.AddToRoleAsync(user, SD.Admin);

                    // 일반 유저 생성
                    //if(!await _roleManager.RoleExistsAsync(user, SD.User))
                    //{
                    //    await _roleManager.CreateAsync(new IdentityRole(SD.User));
                    //}

                    //await _userManager.AddToRoleAsync(user, SD.User);

                    //if (role == SD.User)
                    //{
                    //    await _userManager.AddToRoleAsync(user, SD.User);
                    //    await _signInManager.SignInAsync(user, isPersistent: false);
                    //}

                    TempData[SD.Success] = "계정 생성 성공.";

                    //        _logger.LogInformation("User created a new account with password.");

                    //        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    //        var callbackUrl = Url.Page(
                    //            "/Account/ConfirmEmail",
                    //            pageHandler: null,
                    //            values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                    //            protocol: Request.Scheme);

                    //        await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //            $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    //        if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    //        {
                    //            return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    //        }
                    //        else
                    //        {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                    //        }

                }


                //}
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                // If we got this far, something failed, redisplay form

            }
            return Page();
        }

    }
}
