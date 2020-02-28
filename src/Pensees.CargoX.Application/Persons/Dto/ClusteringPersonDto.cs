using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Pensees.CargoX.Common.Dto;
using Pensees.CargoX.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pensees.CargoX.Persons.Dto
{
    [AutoMap(typeof(Person))]
    public class ClusteringPersonDto: EntityDto<long>
    {
        /// <summary>
        /// 人员标识
        /// ImageCntObjectIdType::string(48)::GA/T 1400.1 图像信息内容要素 ID，人、人脸、机动车、非机动车、物品、场景等
        /// </summary>
        [Required]
        [StringLength(48)]
        [DisplayName("人员标识")]
        public string PersonID { get; set; }

        /// <summary>
        /// 信息分类
        /// 人工采集还是自动采集
        /// InfoType::int::视频图像信息类型
        /// </summary>
        [Required]
        [DisplayName("信息分类")]
        public int InfoType { get; set; }

        /// <summary>
        /// 来源图像信息标识
        /// BasicObjectIdType::string(41)::GA/T 1400.1，图像信息基本要素 ID，视频、图像、文件
        /// </summary>
        [Required]
        [DisplayName("来源标识")]
        [StringLength(41)]
        public string SourceID { get; set; }

        /// <summary>
        /// 设备编码
        /// 设备编码，自动采集必选
        /// DeviceIDType::string(20)::GA/T 1400.1，采集设备、卡口点位、采集系统、分析系统、视图库、应用平台等设备编码规则
        /// </summary>
        [DisplayName("设备编码")]
        [StringLength(20)]
        public string DeviceID { get; set; }

        /// <summary>
        /// 左上角 X 坐标
        /// 人的轮廓外接矩形在画面中的位置，记录矩形框的左上角坐标及右下角坐标，自动采集记录时为必选
        /// </summary>
        [DisplayName("左上角 X 坐标")]
        public int LeftTopX { get; set; }

        /// <summary>
        /// 左上角 Y 坐标
        /// 人的轮廓外接矩形在画面中的位置，记录矩形框的左上角坐标及右下角坐标，自动采集记录时为必选
        /// </summary>
        [DisplayName("左上角 Y 坐标")]
        public int LeftTopY { get; set; }

        /// <summary>
        /// 右下角 X 坐标
        /// 人的轮廓外接矩形在画面中的位置，记录矩形框的左上角坐标及右下角坐标，自动采集记录时为必选
        /// </summary>
        [DisplayName("右下角 X 坐标")]
        public int RightBtmX { get; set; }

        /// <summary>
        /// 右下角 Y 坐标
        /// 人的轮廓外接矩形在画面中的位置，记录矩形框的左上角坐标及右下角坐标，自动采集记录时为必选
        /// </summary>
        [DisplayName("右下角 Y 坐标")]
        public int RightBtmY { get; set; }

        /// <summary>
        /// 图像列表 可以包含0个或者多个子图像对象
        /// </summary>
        [DisplayName("图像列表")]
        public SubImageInfoDtoList SubImageList { get; set; }
    }
}
