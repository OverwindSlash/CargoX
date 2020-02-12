using Abp.AutoMapper;
using Pensees.CargoX.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace Pensees.CargoX.Tollgates.Dto
{
    [AutoMap(typeof(Tollgate))]
    public class TollgateDto : EntityDto<long>
    {
        /// <summary>
        /// 卡口ID GA/T 1400.1《公安视频图像信息应用系统 第1部分：通用技术要求》，采集设备、卡口点位、采集系统、分析系统、视图库、应用平台等设备编码规则
        /// </summary>
        [Required]
        [StringLength(20)]
        [DisplayName("卡口ID")]
        public string TollgateId { get; set; }

        /// <summary>
        /// 卡口名称
        /// </summary>
        [Required]
        [StringLength(100)]
        [DisplayName("名称")]
        public string Name { get; set; }

        /// <summary>
        /// 卡口经度 地球经度n10，6;精确到小数点后6位
        /// </summary>
        [Required]
        [DisplayName("经度")]
        public double Longitude { get; set; }

        /// <summary>
        /// 卡口纬度 地球纬度n10，6;精确到小数点后6位
        /// </summary>
        [Required]
        [DisplayName("纬度")]
        public double Latitude { get; set; }

        /// <summary>
        /// 安装地点行政区划代码 GB/T 2260，行政区划、籍贯省市县代码
        /// </summary>
        [Required]
        [StringLength(6)]
        [DisplayName("安装地点行政区划代码")]
        public string PlaceCode { get; set; }

        /// <summary>
        /// 位置名 具体到位置或街道门牌号，由(乡镇街道)+ (街路巷)+ (门楼牌号)+ (门楼详细地址) 构成
        /// </summary>
        [StringLength(256)]
        [DisplayName("位置名")]
        public string Place { get; set; }

        /// <summary>
        /// 卡口状态 视频设备工作状态:1在线、2离线、9其他
        /// </summary>
        [Required]
        [StringLength(1)]
        [DisplayName("卡口状态")]
        public string Status { get; set; }

        /// <summary>
        /// 卡口类型 10，国际; 20，省际; 30，市际; 31，市区; 40，县际; 41，县区;  99，其他;
        /// </summary>
        [Required]
        [StringLength(2)]
        [DisplayName("卡口类型")]
        public string TollgateCat { get; set; }

        /// <summary>
        /// 卡口用途 80治安卡口，81交通卡口，82其他
        /// </summary>
        [Required]
        [DisplayName("卡口用途")]
        public int TollgateCat2 { get; set; }

        /// <summary>
        /// 卡口车道数
        /// </summary>
        [DisplayName("卡口车道数")]
        public int LaneNum { get; set; }

        /// <summary>
        /// 管辖单位代码 机构代码(由GA/T 380规定)
        /// </summary>
        [StringLength(12)]
        [DisplayName("管辖单位代码")]
        public string OrgCode { get; set; }

        /// <summary>
        /// 卡口启用时间 启用时间之后的数据有效
        /// </summary>
        [DisplayName("卡口启用时间")]
        public DateTime ActiveTime { get; set; }
    }
}
