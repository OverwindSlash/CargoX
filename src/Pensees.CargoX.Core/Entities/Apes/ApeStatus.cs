using Abp.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pensees.CargoX.Entities
{
    public class ApeStatus : Entity<long>
    {
        /// <summary>
        /// 设备ID
        /// DeviceIDType::string(20)
        /// GA/T 1400.1，采集设备、卡口点位、采集系统、分析系统、视图库、应用平台等设备编码规则
        /// </summary>
        [Required]
        [DisplayName("设备ID")]
        [StringLength(20)]
        public string ApsID { get; set; }

        /// <summary>
        /// 是否在线
        /// 视频系统工作状态:1在线、2离线、9其他
        /// </summary>
        [Required]
        [DisplayName("是否在线")]
        [MaxLength(1)]
        public string IsOnline { get; set; }

        /// <summary>
        /// 当前时间
        /// </summary>
        public DateTime CurrentTime { get; set; }
    }
}
