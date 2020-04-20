﻿using MassTransit;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pensees.CargoX.Entities;
using Shared.Cache;
using Shared.Common;
using Shared.Events.Common;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Notifier
{
    public class TimeService: IHostedService
    {
        private readonly ILogger _logger;
        private readonly ICacheService _cacheService;
        private readonly IDistributedCache _cache;
        private readonly IBusControl _bus;
        NotificationController controller = NotificationController.GetInstance();
        Timer _timer;
        TimeNode[] timeCircle;
        int count;
        int location;

        public TimeService(ILoggerFactory loggerFactory, 
            ICacheService cacheService,
            IDistributedCache cache,
            IBusControl bus)
        {
            _logger = loggerFactory.CreateLogger<TimeService>();
            _cacheService = cacheService;
            _bus = bus;
            _cache = cache;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting bus");
            await _bus.StartAsync(cancellationToken).ConfigureAwait(false);
            InitTimeCircle();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping bus");
            return _bus.StopAsync(cancellationToken);
        }


        private void InitTimeCircle()
        {
            //get all subscribes, 以确定数组长度：单位时间为最小公约数，长度为最小公倍数/单位时间
            var subscribes = _cacheService.GetAllSubscribesAsync().Result;
            var intervalList = subscribes.Where(p => p.ReportInterval != 0).Select(p => p.ReportInterval).ToList();
            // 3/10
            var gcd = Gcd(intervalList);
            var lcm = Lcm(intervalList);

            count = lcm/gcd;
            timeCircle = new TimeNode[count];
            for (int j = 0; j < count; j++)
            {
                timeCircle[j] = new TimeNode();
                for (int i = 0; i < subscribes.Count; i++)
                {
                    if (subscribes[i].ReportInterval == 0)
                    {
                        subscribes[i].ReportInterval = lcm;
                    }
                    //初始位置不挂载
                    if ((j + 1) * gcd % subscribes[i].ReportInterval == 0)
                    {
                        timeCircle[j].Subscribes.Add(subscribes[i].SubscribeID);
                    }
                }
            }
            

            _timer = new Timer(Tick, null, TimeSpan.FromSeconds(gcd), TimeSpan.FromSeconds(gcd));
        }

        //拨动时间轮
        private void Tick(object source)
        {
            _logger.LogInformation($"location is {location}");
            location += 1;
            location = location % count;
            HandleNode(timeCircle[location]);
        }

        //当时间拨动到某个TimeNode上时，依次处理该时间点需要发送的订阅
        private void HandleNode(TimeNode node)
        {
            foreach (var subscribe in node.Subscribes)
            {
                var notification = PrepareNotificationBySubscribeId(subscribe);
                DoPost(notification);
            }
        }
        // 准备每个订阅：从字典中去取
        private Notification PrepareNotificationBySubscribeId(string subscribeId)
        {
            ConcurrentQueue<NotificationEvent> notificationEventQueue;
            if (!controller.NotificationDictionary.TryGetValue(subscribeId, out notificationEventQueue))
            {
                return null;
            }
            var count = notificationEventQueue.Count;
            if (count == 0)
            {
                return null;
            }
            var notification = new Notification { NotificationID = Guid.NewGuid().ToString(), SubscribeID = subscribeId };
            //依据类型存入对应字段
            for (int i = 0; i < count; i++)
            {
                NotificationEvent message;
                if (notificationEventQueue.TryDequeue(out message))
                {
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
            return notification;
        }


        private void DoPost(Notification notification)
        {
            if (notification != null)
            {
                _logger.LogError($"do {notification.FaceObjectList.Count} post task");
            }
        }

        //gcd
        int Gcd(List<int> intList)
        {
            intList.Sort();
            int a = intList[0];
            int b = 1;
            for (int i = 1; i < intList.Count; i++)
            {
                b = intList[i];
                a = gcd(b, a);
                if (a==1)
                {
                    break;
                }
            }
            return a;
        }
        int gcd(int a, int b)           //自定义函数求最大公约数
        {
            int temp;                   //整形零时变量
            if (a < b)                     //a<b 则交换 
            {
                temp = a; a = b; b = temp;
            }
            while (b != 0)
            {
                temp = a % b;              //a中大数除以b中小数循环取余，直到b及余数为0
                a = b;
                b = temp;
            }
            return a;                  //返回最大公约数到调用函数处
        }

        int Lcm(List<int> intList)
        {
            intList.Sort();
            int a = intList[0];
            int b;
            for (int i = 1; i < intList.Count; i++)
            {
                b = intList[i];
                a = lcm(b,a);
            }
            return a;
        }
        int lcm(int a, int b)
        {
            int temp;
            temp = gcd(a, b);
            return a * b / temp;
        }
    }

    public class TimeNode
    {
        public List<string> Subscribes { get; set; } = new List<string>();
    }
}
