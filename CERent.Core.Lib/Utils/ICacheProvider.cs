using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Threading.Tasks;

namespace CERent.Core.Lib.Utils
{
    public interface ICacheProvider
    {
        Task<T> GetFromCache<T>(string key) where T : class;

        Task SetCache<T>(string key, T value, DistributedCacheEntryOptions options = null) where T : class;

        Task ClearCache(string key);
        
    }
}