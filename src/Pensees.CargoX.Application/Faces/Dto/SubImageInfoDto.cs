using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Pensees.CargoX.Entities;

namespace Pensees.CargoX.Faces.Dto
{
    [AutoMap(typeof(SubImageInfo))]
    public class SubImageInfoDto : EntityDto<long>
    {
        /// <summary>
        /// 图像ID
        /// GA/T 1400.1《公安视频图像信息应用系统 第1部分：通用技术要求》，图像信息基本要素ID，视频、图像、文件
        /// </summary>
        [Required]
        [StringLength(41)]
        [DisplayName("图像ID")]
        public string ImageID { get; set; }

        /// <summary>
        /// 视频图像分析处理事件类型
        /// GA/T 1400.3 B.3.51　视频图像分析处理事件类型（EventType）
        /// </summary>
        [DisplayName("视频图像分析处理事件类型")]
        public int EventSort { get; set; }

        /// <summary>
        /// 设备ID
        /// GB/T28181附录D中D.1规定的编码规则
        /// </summary>
        [Required]
        [StringLength(20)]
        [DisplayName("设备ID")]
        public string DeviceId { get; set; }

        /// <summary>
        /// 图像存储路径
        /// </summary>
        [DisplayName("图像存储路径")]
        public string StoragePath { get; set; }

        /// <summary>
        /// 图像类型
        /// GA/T 1400.3  B.3.54　图像类型（ImageType）
        /// </summary>
        [Required]
        [MaxLength(3)]
        [DisplayName("图像类型")]
        public string Type { get; set; }

        /// <summary>
        /// 图片格式
        /// GA/T 1400.3  B.3.42　图片格式（ImageFormatType）
        /// </summary>
        [Required]
        [DisplayName("图片格式")]
        public string FileFormat { get; set; }

        /// <summary>
        /// 拍摄时间
        /// </summary>
        [Required]
        [DisplayName("拍摄时间")]
        public DateTime ShotTime { get; set; }

        /// <summary>
        /// 图像宽度
        /// </summary>
        [Required]
        [DisplayName("图像宽度")]
        public int Width { get; set; }

        /// <summary>
        /// 图像高度
        /// </summary>
        [Required]
        [DisplayName("图像高度")]
        public int Height { get; set; }

        /// <summary>
        /// 图像Base64数据
        /// </summary>
        [Required]
        [DisplayName("图像Base64数据")]
        public string Data { get; set; }

        /// <summary>
        /// 存储节点
        /// </summary>
        [DisplayName("存储节点")]
        public string NodeId { get; set; }

        /// <summary>
        /// 存储Key
        /// </summary>
        [DisplayName("存储Key")]
        public string ImageKey { get; set; }
    }
}
