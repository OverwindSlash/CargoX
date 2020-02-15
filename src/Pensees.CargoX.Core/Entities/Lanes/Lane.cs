using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Domain.Entities;

namespace Pensees.CargoX.Entities
{
    public class Lane : Entity<long>
    {
        /// <summary>
        /// 卡口ID GA/T 1400.1《公安视频图像信息应用系统 第1部分：通用技术要求》，采集设备、卡口点位、采集系统、分析系统、视图库、应用平台等设备编码规则
        /// GB/T28181附录D中D.1规定的编码规则
        /// 编码规则A 由中心编码(8位)、行业编码(2位)、类型编码(3位)和序号(7位)四个码段共20位十进制数字字符构成,即系统编码=中心编码+ 行业编码+ 类型编码+ 序号。
        /// </summary>
        [Required]
        [StringLength(20)]
        [DisplayName("卡口ID")]
        public string TollgateId { get; set; }

        /// <summary>
        /// 车道ID 卡口内车道唯一编号，从1开始
        /// </summary>
        [Required]
        [DisplayName("车道ID")]
        public int LaneId { get; set; }

        /// <summary>
        /// 车道编号 车辆行驶方向最左车道为1，由左向右顺序编号。与方向有关
        /// </summary>
        [Required]
        [DisplayName("车道编号")]
        public int LaneNo { get; set; }

        /// <summary>
        /// 车道名称
        /// </summary>
        [Required]
        [StringLength(100)]
        [DisplayName("名称")]
        public string Name { get; set; }

        /// <summary>
        /// 车道方向
        /// 1	西向东（简称东，下同）
        /// 2	东向西（西）         
        /// 3	北向南（南）         
        /// 4	南向北（北）         
        /// 5	西南到东北（东北）   
        /// 6	东北到西南（西南）   
        /// 7	西北到东南（东南）   
        /// 8	东南到西北（西北）   
        /// 9	其他                
        /// </summary>
        [Required]
        [StringLength(1)]
        [DisplayName("车道方向")]
        public string Direction { get; set; }

        /// <summary>
        /// 车道描述 车道补充说明
        /// </summary>
        [StringLength(256)]
        [DisplayName("车道描述")]
        public string Desc { get; set; }

        /// <summary>
        /// 车道限速 限速，单位km/h(公里/小时)
        /// </summary>
        [DisplayName("车道限速")]
        public int MaxSpeed { get; set; }

        /// <summary>
        /// 车道出入城
        /// 1 进城、2出城、3非进出城、4 进出城混合
        /// </summary>
        [DisplayName("车道出入城")]
        public int CityPass { get; set; }

        /// <summary>
        /// 设备ID 车道上对应的采集处理设备ID
        /// GB/T28181附录D中D.1规定的编码规则
        /// </summary>
        [Required]
        [StringLength(20)]
        [DisplayName("设备ID")]
        public string ApeId { get; set; }
    }
}
