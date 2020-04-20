using Abp.Application.Services.Dto;
using Abp.Runtime.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Pensees.CargoX.Common.Dto;
using Pensees.CargoX.Entities;
using Pensees.CargoX.Repository.Subscribes;
using Pensees.CargoX.Subscribes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensees.CargoX.Subscribes
{
    public class SubscribesAppService: CargoXAsyncCrudAppService<Subscribe, SubscribeDto, long, PagedAndSortedRequestDto, SubscribeDto, SubscribeDto>,ISubscribesAppService
    {
        private const string SUBSCRIBE_LIST_KEY = "Subscribes";
        const string SUBSCRIBE_FORMAT = "Subscribe:{0}";
        private readonly ISubscribeRepository _subscribeRepository;
        private readonly ICacheManager _cacheManager;
        private readonly IDistributedCache _distributedCache;

        public SubscribesAppService(ISubscribeRepository subscribeRepository,
            ICacheManager cacheManager,
            IDistributedCache distributedCache) :base(subscribeRepository)
        {
            _subscribeRepository = subscribeRepository;
            _cacheManager = cacheManager;
            _distributedCache = distributedCache;
        }

        
        public override async Task<SubscribeDto> CreateAsync(SubscribeDto input)
        {
            var result= await base.CreateAsync(input);
            try
            {
                //List<KeyValuePair<string, object>> keyValuePairs = new List<KeyValuePair<string, object>>();
                //keyValuePairs.Add(new KeyValuePair<string, object>(result.Id.ToString(), result));
                //await _cacheManager.GetCache("CargoX").SetAsync(keyValuePairs.ToArray());
                await CreateSubscribeSession(result);
            }
            catch (Exception)
            {
                throw;
            }
            
            return result;
        }

        public override Task<SubscribeDto> UpdateAsync(SubscribeDto input)
        {
            var result = base.UpdateAsync(input);
            UpdateSubscribeSession(input);
            return result;
        }

        public override Task DeleteAsync(EntityDto<long> input)
        {
            base.DeleteAsync(input);
            return DeleteSubscribeSession(input);
        }
        public override async Task<PagedResultDto<SubscribeDto>> GetAllAsync(PagedAndSortedRequestDto input)
        {
            var result =await base.GetAllAsync(input);
            await GetAllSubscribeSession(result.Items.ToList());
            return result;
        }
        private async Task CreateSubscribeSession(SubscribeDto input)
        {
            //await _cacheManager.GetCache("CargoX").SetAsync(input.Id.ToString(), input);
            await _distributedCache.SetStringAsync(string.Format(SUBSCRIBE_FORMAT, input.Id.ToString()), JsonConvert.SerializeObject(input));
            //存一个全部Subscribes的Id 数组，新增时在尾部添加
            var ids = _subscribeRepository.GetAll().Where(p=>p.EndTime<DateTime.Now && p.CancelTime>DateTime.MinValue).Select(p => p.Id).ToArray();
            var options = new DistributedCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(600));
            await _distributedCache.SetStringAsync(SUBSCRIBE_LIST_KEY, JsonConvert.SerializeObject(ids),options);
            //await _cacheManager.GetCache("CargoX").SetAsync(SUBSCRIBE_LIST_KEY, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(ids)));
        }
        private async Task UpdateSubscribeSession(SubscribeDto input)
        {
            //await _cacheManager.GetCache("CargoX").SetAsync(input.Id.ToString(), input);
            await _distributedCache.SetStringAsync(string.Format(SUBSCRIBE_FORMAT,input.Id.ToString()), JsonConvert.SerializeObject(input));
        }
        private async Task DeleteSubscribeSession(EntityDto<long> input)
        {
            await _cacheManager.GetCache("CargoX").RemoveAsync(string.Format(SUBSCRIBE_FORMAT,input.Id.ToString()));
            //var subscribes = _cacheManager.GetCache("CargoX").Get(SUBSCRIBE_LIST_KEY, () => null);
            var ids = _subscribeRepository.GetAll().Where(p => p.EndTime < DateTime.Now && p.CancelTime > DateTime.MinValue).Select(p => p.Id).ToArray();
            //await _cacheManager.GetCache("CargoX").SetAsync(SUBSCRIBE_LIST_KEY, ids);
            var options = new DistributedCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(600));
            await _distributedCache.SetStringAsync(SUBSCRIBE_LIST_KEY, JsonConvert.SerializeObject(ids),options);
        }
        private async Task GetAllSubscribeSession(List<SubscribeDto> subscribeDtos)
        {
            List<long> ids = new List<long>();
            foreach (var item in subscribeDtos)
            {
                await _distributedCache.SetStringAsync(string.Format(SUBSCRIBE_FORMAT, item.Id.ToString()), JsonConvert.SerializeObject(item));
                ids.Add(item.Id);
            }
            var options = new DistributedCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(600));
            await _distributedCache.SetStringAsync(SUBSCRIBE_LIST_KEY, JsonConvert.SerializeObject(ids),options);
        }
    }
}
