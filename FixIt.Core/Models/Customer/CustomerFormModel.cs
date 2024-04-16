using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FixIt.Infrastructure.Data.Constants.ValidationConstants;

namespace FixIt.Core.Models.Customer
{
    public class CustomerFormModel
    {
        public string Id { get; set; }
        [Required (ErrorMessage = RequiredErrorMessage)]
        [StringLength(UsernameMax, MinimumLength = UsernameMin, ErrorMessage = NameValidationError)]
        public string UserName => Email;
        public string NormalizedUserName => UserName.Normalize();
        [Required(ErrorMessage = RequiredErrorMessage)]
        [RegularExpression(EmailPattern, ErrorMessage = EmailValidationError)]
        public string Email { get; set; } = string.Empty;
        public string NormalizedEmail => Email.Normalize();
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(UsernameMax, MinimumLength = UsernameMin, ErrorMessage = RequiredErrorMessage)]
        public string Password { get; set; } = string.Empty;

        [RegularExpression(PhonePattern, ErrorMessage = PhoneValidationError)]
        public string? PhoneNumber { get; set; }
    }
}
