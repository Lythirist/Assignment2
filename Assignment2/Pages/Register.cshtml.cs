using Assignment2.ViewModels;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment2.Pages
{
	//Initialize the build-in ASP.NET Identity
	public class RegisterModel : PageModel
	{
		private UserManager<IdentityUser> UserManager { get; }
		private SignInManager<IdentityUser> SignInManager { get; }
		[BindProperty]
		public Register RModel { get; set; }
		public RegisterModel(UserManager<IdentityUser> userManager,
		SignInManager<IdentityUser> signInManager)
		{
			this.UserManager = userManager;
			this.SignInManager = signInManager;
		}
		public void OnGet()
		{
		}
		//Save data into the database
		public async Task<IActionResult> OnPostAsync()
		{
			if (ModelState.IsValid)
			{
				var dataProtectionProvider = DataProtectionProvider.Create("EncryptData");
				var protector = dataProtectionProvider.CreateProtector("MySecretKey");
				var user = new IdentityUser()
				{
					UserName = RModel.Email,
					Email = RModel.Email,
				};
				var result = await UserManager.CreateAsync(user, RModel.Password);
				if (result.Succeeded)
				{
					await SignInManager.SignInAsync(user, false);
					return RedirectToPage("Index");
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}
			return Page();
		}
	}
}