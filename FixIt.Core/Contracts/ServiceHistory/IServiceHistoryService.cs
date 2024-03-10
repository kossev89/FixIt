using FixIt.Core.Models.ServiceHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixIt.Core.Contracts.ServiceHistory
{
    public interface IServiceHistoryService
    {
        Task<IEnumerable<ServiceHistoryViewModel>> GetAllAsync();
        string GetUserId();
    }
}
