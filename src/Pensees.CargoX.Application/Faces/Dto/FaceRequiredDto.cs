using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using Pensees.CargoX.Entities.Common;
using Pensees.CargoX.Entities.Faces;

namespace Pensees.CargoX.Faces.Dto
{
    [AutoMap(typeof(Face))]
    public class FaceRequiredDto : EntityDto<long>
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
        /// 是否在押人员 0：否；1：是；2：不确定
        /// </summary>
        [Required]
        [DisplayName("是否在押人员")]
        public int IsDetainees { get; set; }

        /// <summary>
        /// 是否被害人 0：否；1：是；2：不确定
        /// </summary>
        [Required]
        [DisplayName("是否被害人")]
        public int IsVictim { get; set; }

        /// <summary>
        /// 是否可疑人 0：否；1：是；2：不确定
        /// </summary>
        [Required]
        [DisplayName("是否可疑人")]
        public int IsSuspiciousPerson { get; set; }

        /// <summary>
        /// 图像列表 可以包含0个或者多个子图像对象
        /// </summary>
        [DisplayName("图像列表")]
        public List<SubImageInfoDto> SubImageList { get; set; }

        /// <summary>
        /// 人脸特征值
        /// 非 1400 属性
        /// </summary>
        [Required]
        [DisplayName("特征值")]
        public List<byte> Feature { get; set; }
    }
}
