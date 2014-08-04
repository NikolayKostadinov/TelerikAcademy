using System.ComponentModel.DataAnnotations;

namespace FileUpload.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "e-mail")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string Action { get; set; }
        public string ReturnUrl { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Текуща парола")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Полето {0} трябва да има дължина поне {2} символа.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Нова парола")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Повторение на парола")]
        [Compare("NewPassword", ErrorMessage = "Паролата и повторната парола трябва да си съвпадат!")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        //[EmailAddress]
        [Display(Name = "Потребител")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [Display(Name = "Запомни ме?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        //[EmailAddress]
        [Display(Name = "Потребител")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "e-mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Полето {0} трябва да има дължина поне {2} символа.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Повторение на парола")]
        [Compare("Password", ErrorMessage = "Паролата и повторната парола трябва да си съвпадат!")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        //[EmailAddress]
        [Display(Name = "Потребител")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Полето {0} трябва да има дължина поне {2} символа.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Повторение на парола")]
        [Compare("Password", ErrorMessage = "Паролата и повторната парола трябва да си съвпадат!")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "e-mail")]
        public string Email { get; set; }
    }

     public class ChangePasswordViewModel
        {
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Текуща парола")]
            public string OldPassword { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "Полето {0} трябва да има дължина поне {2} символа.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Нова парола")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Повторение на парола")]
            [Compare("NewPassword", ErrorMessage = "Паролата и повторната парола трябва да си съвпадат!")]
            public string ConfirmPassword { get; set; }
        }
}
