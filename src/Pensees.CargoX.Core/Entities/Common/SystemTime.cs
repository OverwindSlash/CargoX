using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pensees.CargoX.Entities
{
    public class SystemTime
    {
        public DeviceIDType VIIDServerID { get; set; }
        /// <summary>
        /// 校时模式
        /// 1 网络
        /// 2 手动
        /// </summary>
        public TimeCorrectModeType TimeMode { get; set; }
        public DateTime LocalTime { get; set; }
        public string TimeZone { get; set; }

        public static Task<SystemTime> GetSystemTime()
        {
            return Task.Run(() =>
                {
                    SystemTime systemTime = new SystemTime();
                    systemTime.LocalTime = DateTime.Now;
                    systemTime.TimeZone = DateTime.Now.ToString("%z");

                    return systemTime;
                });
        }

    }
}
