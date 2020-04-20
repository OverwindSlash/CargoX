using Microsoft.Extensions.Logging;
using Pensees.CargoX.Entities;
using Shared.Cache;
using Shared.Common;
using Shared.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grabber.Grabber
{
    public class PersonGrabber : GrabberBase<PersonEvent, Person>
    {
        public PersonGrabber(ICacheService cacheService, ILoggerFactory loggerFactory) : base(cacheService, loggerFactory)
        {
        }

        public override bool IsSubscribed(PersonEvent personEvent, Subscribe subscribe)
        {
            log.LogInformation("i am from person grabber");
            //var device = _cacheService.GetDeviceById(createEvent.DeviceId);
            if (subscribe.ResourceURI.Equals(personEvent.DeviceId))
                //|| subscribe.ResourceURI.Contains(device.TollgateId)
                //|| subscribe.ResourceURI.Contains(device.LaneId))
            {
                return true;
            }
            return false;
        }
    }
}
