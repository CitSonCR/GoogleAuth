using System;
using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ThirdPartyAuthTest.Models
{
	public class LoginViewModel
	{
		public LoginViewModel()
		{
		}

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }   //ReturnUrl is the URL the user was trying to access before authentication.
                                                //We preserve and pass it between requests using the ReturnUrl property,
                                                //so the user can be redirected to that URL upon successful authentication.

        public IList<AuthenticationScheme> ExternalLogins { get; set; } //ExternalLogins property stores the list of external logins like
                                                                        //(Facebook, Google, etc) that are store in our application.
    }
}

