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
        [Required]
        [StringLength(UsernameMax, MinimumLength = UsernameMin, ErrorMessage = NameValidationError)]
        public string UserName { get; set; } = string.Empty;
        public string NormalizedUserName => UserName.Normalize();
        [Required]
        [RegularExpression(EmailPattern, ErrorMessage = EmailValidationError)]
        public string Email { get; set; } = string.Empty;
        public string NormalizedEmail => Email.Normalize();
        [Required]
        [StringLength(UsernameMax, MinimumLength = UsernameMin, ErrorMessage = RequiredErrorMessage)]
        public string Password { get; set; } = string.Empty;
    }
}
