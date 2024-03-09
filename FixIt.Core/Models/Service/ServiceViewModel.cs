using FixIt.Infrastructure.Data.Enumerators;
using System.ComponentModel.DataAnnotations;
using static FixIt.Infrastructure.Data.Constants.ValidationConstants;

namespace FixIt.Core.Models.Service
{
    public class ServiceViewModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage = RequiredErrorMessage)]
        public ServiceType Type { get; set; }
    }
}
