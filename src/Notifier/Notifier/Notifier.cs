using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Events.Common;
using Shared.Redis;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notifier
{
    public class Notifier : IConsumer<NotificationEvent>
    {
        readonly ILogger _logger;
        private readonly IRedisManager _redisManager;
        private readonly ITimerParam timerParam;

        public Notifier(ILoggerFactory loggerFactory, IRedisManager redisManager, ITimerParam timerParam)
        {
            _logger = loggerFactory.CreateLogger<Notifier>();
            _redisManager = redisManager;
            this.timerParam = timerParam;
        }
        public async Task Consume(ConsumeContext<NotificationEvent> context)
        {
            _logger.LogInformation("i am from consume");
            //_redisManager.Set<string>("notifier", "test", TimeSpan.FromSeconds(30));
            if (context.Message.SubscribeID != null)
            {
                
                //controller.NotificationDictionary.GetOrAdd(context.Message.SubscribeID, (p) => new ConcurrentQueue<NotificationEvent>()).Enqueue(context.Message);
               await SubscribeController.SubcribeTimerDic.GetOrAdd(context.Message.SubscribeID,
                    (p) => {
                        timerParam.SubscribeId = context.Message.SubscribeID;
                        timerParam.Timespan = context.Message.ReportInterval;
                        return new SubscribeTimer(timerParam);
                    })
                    .HandleNotificationEvent(context.Message);
            }
            //return Task.CompletedTask;
        }
    }
}
