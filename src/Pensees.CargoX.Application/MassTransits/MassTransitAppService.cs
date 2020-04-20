using Abp.Application.Services;
using MassTransit;
using Pensees.CargoX.Entities;
using Shared.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pensees.CargoX.MassTransits
{
    public class MassTransitAppService : ApplicationService, IMassTransitAppService
    {
        private readonly IPublishEndpoint publishEndpoint;

        public MassTransitAppService(IPublishEndpoint publishEndpoint)
        {
            this.publishEndpoint = publishEndpoint;
        }

        public async Task NotifyEntityCreated()
        {
            await publishEndpoint.Publish(new FaceEvent
            {
                Entity = new Face { Id = 1 },
                DeviceId = "deviceid"
            }).ConfigureAwait(false);
        }
    }
}
