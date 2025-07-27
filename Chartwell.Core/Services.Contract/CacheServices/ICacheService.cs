using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Services.Contract.CacheServices
{
    public interface ICacheService
    {
        Task<string> GetCacheAsync(string key);
        Task SetCacheAsync(string key, object response, TimeSpan expireDate);
    }
}
