using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixIt.Core.Contracts.User
{
    public interface IUserService
    {
        Task<IEnumerable<IdentityUser>> GetAllCustomersAsync();
    }
}
