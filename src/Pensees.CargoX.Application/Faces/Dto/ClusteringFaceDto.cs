using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Pensees.CargoX.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pensees.CargoX.Faces.Dto
{
    [AutoMap(typeof(Face))]
    public class ClusteringFaceDto : EntityDto<long>
    {
        /// <summary>
        /// 人脸标识
        /// GA/T 1400.1《公安视频图像信息应用系统 第1部分：通用技术要求》图像信息内容要素ID，人、人脸、机动车、非机动车、物品、场景等
        /// </summary>
        [Required]
        [StringLength(48)]
        [DisplayName("人脸标识")]

        public string FaceId { get; set; }

        /// <summary>
        /// 信息分类 人工采集还是自动采集
        /// </summary>
        [Required]
        [DisplayName("信息分类")]
        public int InfoKind { get; set; }

        /// <summary>
        /// 来源标识
        /// GA/T 1400.1《公安视频图像信息应用系统 第1部分：通用技术要求》，图像信息基本要素ID，视频、图像、文件
        /// </summary>
        [Required]
        [StringLength(41)]
        [DisplayName("来源标识")]
        public string SourceId { get; set; }

        /// <summary>
        /// 左上角X坐标 人脸区域，自动采集记录时为必选
        /// </summary>
        [DisplayName("左上角X坐标")]
        public int LeftTopX { get; set; }

        /// <summary>
        /// 左上角Y坐标 人脸区域，自动采集记录时为必选
        /// </summary>
        [DisplayName("左上角Y坐标")]
        public int LeftTopY { get; set; }

        /// <summary>
        /// 右下角X坐标 人脸区域，自动采集记录时为必选
        /// </summary>
        [DisplayName("右下角X坐标")]
        public int RightBtmX { get; set; }

        /// <summary>
        /// 右下角Y坐标 人脸区域，自动采集记录时为必选
        /// </summary>
        [DisplayName("右下角Y坐标")]
        public int RightBtmY { get; set; }

        /// <summary>
        /// 性别代码
        /// </summary>
        [DisplayName("性别代码")]
        public string GenderCode { get; set; }

        /// <summary>
        /// 年龄上限 最大可能年龄
        /// </summary>
        [DisplayName("年龄上限")]
        public int AgeUpLimit { get; set; }

        /// <summary>
        /// 年龄下限 最小可能年龄
        /// </summary>
        [DisplayName("年龄下限")]
        public int AgeLowerLimit { get; set; }

        /// <summary>
        /// 图像列表 可以包含0个或者多个子图像对象
        /// </summary>
        [DisplayName("图像列表")]
        public SubImageInfoDtoList SubImageList { get; set; }

        /// <summary>
        /// 人脸特征值
        /// 非 1400 属性
        /// </summary>
        [Required]
        [DisplayName("特征值")]
        public List<byte> Feature { get; set; }
    }
}
