using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixIt.Infrastructure.Data.Models
{
    public class User: IdentityUser
    {
        [Comment("Cars, owned by the user")]
        [Required]
        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
