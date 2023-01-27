using System.ComponentModel.DataAnnotations;

namespace RSSManagmentService.Api.Dto.Request
{
    public class UserRegistrDto : IValidatableObject
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Login))
            {
                yield return new ValidationResult("Login is required");
            }

            if (string.IsNullOrEmpty(Password))
            {
                yield return new ValidationResult("Password is required");
            }

            if (Password.Length > 0 && Password.Length < 8)
            {
                yield return new ValidationResult("Min password length - 8 symbols");
            }

            if (!Email.Contains("@"))
            {
                yield return new ValidationResult("Incorrect email");
            }
        }
    }
}