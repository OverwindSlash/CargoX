using System;
using System.Collections.Generic;
using System.Text;

namespace Pensees.CargoX.System
{
    public class SystemTimeDto
    {
        public string VIIDServerID { get; set; }
        /// <summary>
        /// 校时模式
        /// 1 网络
        /// 2 手动
        /// </summary>
        public string TimeMode { get; set; }
        public DateTime LocalTime { get; set; }
        public string TimeZone { get; set; }
    }
}
