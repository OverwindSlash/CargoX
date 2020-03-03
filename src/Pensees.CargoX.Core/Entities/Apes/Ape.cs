using Abp.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pensees.CargoX.Entities
{
    public class Ape : Entity<long>
    {
        /// <summary>
        /// 设备ID
        /// DeviceIDType::string(20)
        /// GA/T 1400.1，采集设备、卡口点位、采集系统、分析系统、视图库、应用平台等设备编码规则
        /// </summary>
        [Required]
        [DisplayName("设备ID")]
        [StringLength(20)]
        public string ApeID { get; set; }

        /// <summary>
        /// 名称
        /// DeviceNameType::string(0..100)
        /// </summary>
        [Required]
        [DisplayName("名称")]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// 型号
        /// ModelType::string(0..100)
        /// </summary>
        [Required]
        [DisplayName("型号")]
        [MaxLength(100)]
        public string Model { get; set; }

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
        /// 经度
        /// LongitudeType::double
        /// </summary>
        [Required]
        [DisplayName("经度")]
        public double Longitude { get; set; }

        /// <summary>
        /// 纬度
        /// LatitudeType::double
        /// </summary>
        [Required]
        [DisplayName("纬度")]
        public double Latitude { get; set; }

        /// <summary>
        /// 安装地点行政区划代码
        /// PlaceCodeType::string(6)::GB/T 2260，行政区划、籍贯省市县代码
        /// </summary>
        [Required]
        [DisplayName("安装地点行政区划代码")]
        [StringLength(6)]
        public string PlaceCode { get; set; }

        /// <summary>
        /// 位置名
        /// 具体到摄像机位置或街道门牌号，由(乡镇街道)+ (街路巷)+ (门楼牌号)+ (门楼详细地址) 构成
        /// </summary>
        [DisplayName("位置名")]
        [StringLength(256)]
        public string Place { get; set; }

        /// <summary>
        /// 管辖单位代码
        /// OrgCodeType::string(12)
        /// </summary>
        [DisplayName("管辖单位代码")]
        [StringLength(12)]
        public string OrgCode { get; set; }

        /// <summary>
        /// 车辆抓拍方向
        /// 0：拍车头；1：拍车尾，兼容无视频卡口信息设备
        /// </summary>
        [DisplayName("车辆抓拍方向")]
        public int CapDirection { get; set; }

        /// <summary>
        /// 监视方向
        /// HDirectionType::string
        /// B.3.52　水平方向（HDirectionType、HorizontalShotType）
        /// </summary>
        [DisplayName("监视方向")]
        public string MonitorDirection { get; set; }

        /// <summary>
        /// 监视区域说明
        /// </summary>
        [DisplayName("监视区域说明")]
        [MaxLength(256)]
        public string MonitorAreaDesc { get; set; }

        /// <summary>
        /// 是否在线
        /// 视频设备工作状态:1在线、2离线、9其他
        /// </summary>
        [Required]
        [DisplayName("是否在线")]
        [MaxLength(1)]
        public string IsOnline { get; set; }

        /// <summary>
        /// 所属采集系统
        /// DeviceIDType::string(20)
        /// 采集设备所接的采集系统设备
        /// </summary>
        [DisplayName("所属采集系统")]
        [StringLength(20)]
        public string OwnerApsID { get; set; }

        /// <summary>
        /// 用户账号  用于支持修改设备登陆帐号 
        /// </summary>
        [DisplayName("用户账号")]
        [StringLength(64)]
        public string UserId { get; set; }

        /// <summary>
        /// 口令 用于支持修改设备登陆帐号
        /// PasswordType::string(0..32)
        /// </summary>
        [DisplayName("口令")]
        [MaxLength(32)]
        public string Password { get; set; }
    }
}
