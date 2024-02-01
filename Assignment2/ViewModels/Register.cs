using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace Assignment2.ViewModels
{
	public class Register
	{
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Credit card number must be 16 digits")]
        public string CreditCard { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Mobile number must be 10 digits")]
        public string MobileNo { get; set; }

        [Required]
		public string BillingAddress { get; set; }

		[Required]
		[RegularExpression(@"^[a-zA-Z0-9\s\.,#-]+$", ErrorMessage = "Allow all Special Characters")]
		public string ShippingAddress { get; set; }

		[Required]
		[DataType(DataType.EmailAddress)]
		[EmailAddress(ErrorMessage = "Invalid email address")]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{12,}$", ErrorMessage = "Password must be at least 12 characters long and include lowercase, uppercase, numbers, and special characters.")]
        public string Password { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Compare(nameof(Password), ErrorMessage = "Password and confirmation password do not match")]
		public string ConfirmPassword { get; set; }
	}
}
