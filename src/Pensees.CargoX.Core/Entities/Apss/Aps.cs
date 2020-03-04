using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace Pensees.CargoX.Entities
{
    public class Aps : Entity<long>
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
        /// 名称
        /// DeviceNameType::string(0..100)
        /// </summary>
        [Required]
        [DisplayName("名称")]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// IP地址
        /// IPAddrType::string(0..100)
        /// </summary>
        [Required]
        [DisplayName("IP地址")]
        [MaxLength(30)]
        public string IPAddr { get; set; }

        /// <summary>
        /// IPv6地址
        /// IPV6AddrType::string(64)
        /// </summary>
        [DisplayName("IPv6地址")]
        [StringLength(64)]
        public string IPV6Addr { get; set; }

        /// <summary>
        /// 端口号
        /// NetPortType::int
        /// </summary>
        [Required]
        [DisplayName("端口号")]
        public int Port { get; set; }

        /// <summary>
        /// 是否在线
        /// 视频系统工作状态:1在线、2离线、9其他
        /// </summary>
        [Required]
        [DisplayName("是否在线")]
        [MaxLength(1)]
        public string IsOnline { get; set; }
    }
}
