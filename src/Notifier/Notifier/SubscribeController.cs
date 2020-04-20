using Microsoft.Extensions.Logging;
using Pensees.CargoX.Entities;
using Shared.Events.Common;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using Shared.Redis;
using System.Collections.Generic;

namespace Notifier
{
    public class SubscribeController
    {
        public static ConcurrentDictionary<string, SubscribeTimer> SubcribeTimerDic { get; set; } = new ConcurrentDictionary<string, SubscribeTimer>();
        
    }

    public interface ITimerParam
    {
        public string SubscribeId { get; set; }
        public int Timespan { get; set; }
    }
    //将需要依赖DI的Service抽取出来依靠DI赋值，其它属性传递前单独赋值。
    public class TimerParam : ITimerParam
    {
        public ILogger logger;
        public IRedisManager redisManager;

        public TimerParam(ILoggerFactory loggerFactory, IRedisManager redisManager)
        {
            this.logger = loggerFactory.CreateLogger<TimerParam>();
            this.redisManager = redisManager;
        }

        public string SubscribeId { get ; set; }
        public int Timespan { get; set; }
    }

    public class SubscribeTimer
    {
        //private static ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        //{
        //    builder
        //        .AddFilter("Microsoft", LogLevel.Warning)
        //        .AddFilter("System", LogLevel.Warning)
        //        .AddFilter("SubscribeController", LogLevel.Debug)
        //        .AddConsole()
        //        .AddEventLog();
        //});
        //private static ILogger logger = loggerFactory.CreateLogger<NotificationController>();
        private readonly TimerParam timerParam;
        private static readonly HttpClient client = new HttpClient();
        public Timer Timer { get; set; }
        private ConcurrentQueue<NotificationEvent> NotificationQueue { get; set; } = new ConcurrentQueue<NotificationEvent>();
        private ConcurrentQueue<Guid> NotificationKeyQueue { get; set; } = new ConcurrentQueue<Guid>();
        public int MaxSending { get; set; } = 10;
        public SubscribeTimer(ITimerParam baseTimer)
        {
            timerParam = baseTimer as TimerParam;
            Timer = new Timer(Tick, baseTimer.SubscribeId, TimeSpan.FromSeconds(baseTimer.Timespan), TimeSpan.FromSeconds(baseTimer.Timespan));
        }
        void Tick(object sourc)
        {
            try
            {
                timerParam.logger.LogInformation($"tick tock");
#if true
                //从redis一次性全部取出NotificationKeyQueue
                if (NotificationKeyQueue.Count <= 0)
                {
                    return;
                }
                List<List<Guid>> guidsList = new List<List<Guid>>();
                List<Guid> notificationKeyList = new List<Guid>();
                for (int i = 0; i < NotificationKeyQueue.Count; i++)
                {
                    if (i>0 && i%MaxSending==0)
                    {
                        guidsList.Add(notificationKeyList);
                        notificationKeyList.Clear();
                    }
                    Guid key;
                    if (NotificationKeyQueue.TryDequeue(out key))
                    {
                        notificationKeyList.Add(key);
                    }
                }
                if (notificationKeyList.Count>0)
                {
                    guidsList.Add(notificationKeyList);
                }
                if (guidsList.Count==0)
                {
                    timerParam.logger.LogWarning("nothing...");
                    return;
                }
                string subscribeId = (string)sourc;
                //如果数量太多，应该分批进行，默认每批10条

                foreach (var guids in guidsList)
                {
                    var notification = new Notification { NotificationID = Guid.NewGuid().ToString(), SubscribeID = subscribeId };
                    string url = "";
                    int index = 0;
                    foreach (var guid in guids)
                    {
                        var message = timerParam.redisManager.StringGet<NotificationEvent>(guid.ToString());
                        if (string.IsNullOrEmpty(url))
                        {
                            url = message.ReceiveAddr;
                        }
                        switch (message.Type.ToLower())
                        {
                            case "face":
                                notification.FaceObjectList.Add(message.Entity as Face);
                                break;
                            case "person":
                                notification.PersonObjectList.Add(message.Entity as Person);
                                break;
                            case "motor":
                                notification.MotorVehicleObjectList.Add(message.Entity as Motor);
                                break;
                            case "nonmotor":
                                notification.NonMotorVehicleObjectList.Add(message.Entity as NonMotor);
                                break;
                            default:
                                break;
                        }
                        index++;
                        timerParam.redisManager.StringDelete(guid.ToString());
                    }
                    //DoPost(notification, url);
                    var postItem = new NotificationItem(notification, url);
                    ThreadPool.QueueUserWorkItem(DoWork, postItem);
                }
#else

                string subscribeId = (string)sourc;
                var notification = new Notification { NotificationID = Guid.NewGuid().ToString(), SubscribeID = subscribeId };
                string url = "";
                //依据类型存入对应字段
                if (NotificationQueue.Count > 0)
                {
                    for (int i = 0; i < NotificationQueue.Count; i++)
                    {
                        
                        NotificationEvent message;
                        if (NotificationQueue.TryDequeue(out message))
                        {
                            if (string.IsNullOrEmpty(url))
                            {
                                url = message.ReceiveAddr;
                            }   
                            //暂时不判空，方便测试
                            switch (message.Type.ToLower())
                            {
                                case "face":
                                    notification.FaceObjectList.Add(message.Entity as Face);
                                    break;
                                case "person":
                                    notification.PersonObjectList.Add(message.Entity as Person);
                                    break;
                                case "motor":
                                    notification.MotorVehicleObjectList.Add(message.Entity as Motor);
                                    break;
                                case "nonmotor":
                                    notification.NonMotorVehicleObjectList.Add(message.Entity as NonMotor);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    //DoPost(notification, url);
                    var postItem = new NotificationItem(notification,url);
                    ThreadPool.QueueUserWorkItem(DoWork, postItem);
                }
#endif
            }
            catch (Exception ex)
            {
                timerParam.logger.LogError("tick failed:"+ ex.Message);
            }

        }
        public Task HandleNotificationEvent(NotificationEvent notificationEvent)
        {
            //NotificationQueue.Enqueue(notificationEvent);
#if true
            //TODO：统一放入redis持久化，同时兼顾发送间隔比较长的订阅（比如一天发一次）
            var key = Guid.NewGuid();
            NotificationKeyQueue.Enqueue(key);
            return timerParam.redisManager.StringSetAsync(key.ToString(), notificationEvent);
#endif
        }
        private void DoWork(object obj)
        {
            DoPost(obj);
        }
        //private async Task DoPost(Notification notification,string url)
        private async Task DoPost(object obj)
        {
            NotificationItem item = (NotificationItem)obj;
            var notification = item.Notification;
            var url = item.Url;
            if (notification != null)
            {
                timerParam.logger.LogError($"do {notification.FaceObjectList.Count} face task");
                timerParam.logger.LogError($"do {notification.PersonObjectList.Count} person task");
                try
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Post, url))
                    using (var httpContent = CreateHttpContent(notification))
                    {
                        request.Content = httpContent;

                        using (var response = await client
                            .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                            .ConfigureAwait(false))
                        {
                            response.EnsureSuccessStatusCode();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
            }
            
        }
        public static async Task PostStreamAsync(object content, CancellationToken cancellationToken)
        {
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, ""))
            using (var httpContent = CreateHttpContent(content))
            {
                request.Content = httpContent;

                using (var response = await client
                    .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                    .ConfigureAwait(false))
                {
                    response.EnsureSuccessStatusCode();
                }
            }
        }
        public static HttpContent CreateHttpContent(object content)
        {
            HttpContent httpContent = null;

            if (content != null)
            {
                var ms = new MemoryStream();
                SerializeJsonIntoStream(content, ms);
                ms.Seek(0, SeekOrigin.Begin);
                httpContent = new StreamContent(ms);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            return httpContent;
        }
        public static void SerializeJsonIntoStream(object value, Stream stream)
        {
            using (var sw = new StreamWriter(stream, new UTF8Encoding(false), 1024, true))
            using (var jtw = new JsonTextWriter(sw) { Formatting = Formatting.None })
            {
                var js = new JsonSerializer();
                js.Serialize(jtw, value);
                jtw.Flush();
            }
        }

        private class NotificationItem
        {
            public Notification Notification { get; set; }
            public string Url { get; set; }
            public NotificationItem(Notification notification, string url)
            {
                this.Notification = notification;
                this.Url = url;
            }
        }
    }
}
