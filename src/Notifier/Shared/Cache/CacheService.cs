using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Pensees.CargoX.Entities;
using Shared.Common;
using Shared.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared.Cache
{
    public class CacheService : ICacheService
    {
        const string SUBSCRIBE_LIST_KEY = "CargoX:Subscribes";
        const string SUBSCRIBE_FORMAT = "CargoX:Subscribe:{0}";
        private static List<Subscribe> SUBSCRIBES = new List<Subscribe>();
        /// <summary>
        /// 这个接口只能存取string及hash。存取时需要序列化或反序列化并进行string与byte[]的转换
        /// </summary>
        private readonly IDistributedCache _cache;
        private readonly ISubscribeQueries _subscribeQueries;

        public CacheService(IDistributedCache cache, ISubscribeQueries subscribeQueries)
        {
            _cache = cache;
            _subscribeQueries = subscribeQueries;
        }

        public List<Device> GetAllDevices()
        {
            return new List<Device>();
        }

        public async System.Threading.Tasks.Task<List<Subscribe>> GetAllSubscribesAsync()
        {
            #region mock data
            //var subscribe= new Subscribe
            //{
            //    SubscribeID = "subscribeid",
            //    ResourceURI = "deviceid",
            //    ReportInterval=2
            //};
            //var subscribe2 = new Subscribe
            //{
            //    SubscribeID = "subscribeid2",
            //    ResourceURI = "deviceid2",
            //    ReportInterval=5
            //};
            //var subscribe3 = new Subscribe
            //{
            //    SubscribeID = "subscribeid3",
            //    ResourceURI = "deviceid3",
            //    ReportInterval = 8
            //};
            #endregion
            var list = new List<Subscribe> ();

            if (SUBSCRIBES.Count>0)
            {
                list = SUBSCRIBES;
                return list;
            }

            var data = _cache.GetString(SUBSCRIBE_LIST_KEY);
            if (data!=null)
            {
                var ids = JsonConvert.DeserializeObject<List<long>>(data);
                foreach (var id in ids)
                {
                    var s = _cache.GetString(string.Format(SUBSCRIBE_FORMAT, id.ToString()));
                    if ( s!=null)
                    {
                        list.Add(JsonConvert.DeserializeObject<Subscribe>(s));
                    }
                }
                SUBSCRIBES = list;
            }
            else
            {
                var result = await _subscribeQueries.GetAllSubscribes();
                list = result.ToList();
                SUBSCRIBES = list;
                //create new SUBSCRIBE_LIST_KEY
                var options = new DistributedCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(600));
                _cache.SetString(SUBSCRIBE_LIST_KEY, JsonConvert.SerializeObject(list.Select(p=>p.Id).ToArray()), options);
            }
            return list;
        }

        public Device GetDeviceById(string id)
        {
            return new Device
            {
                DeviceId = "deviceid",
                TollgateId = "tollgateid",
                LaneId = "laneid"
            };
        }

        private byte[] ConvertToByteArray(string s)
        {
            return Encoding.UTF8.GetBytes(s);
        }
        private string ConvertFromByteArray(byte[] ba)
        {
            return Encoding.UTF8.GetString(ba);
        }
    }
}
