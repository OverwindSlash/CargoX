using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Domain.Entities;

namespace Pensees.CargoX.Entities
{
    public class VideoSliceInfo : Entity<long>
    {
        /// <summary>
        /// 视频标识
        /// GA/T 1400.1《公安视频图像信息应用系统 第1部分：通用技术要求》，图像信息基本要素ID，视频、图像、文件
        /// </summary>
        [StringLength(41)]
        [DisplayName("视频标识")]
        public string VideoID { get; set; }

        /// <summary>
        /// 信息分类 人工采集还是自动采集
        /// </summary>
        [Required]
        [DisplayName("信息分类")]
        public int InfoKind { get; set; }

        /// <summary>
        /// 视频来源，视频图像数据来源
        /// </summary>
        [Required]
        [StringLength(2)]
        [DisplayName("视频来源")]
        public string VideoSource { get; set; }

        /// <summary>
        /// 摘要视频标志
        /// True=摘要视频，false=原始视频，缺少该字段或缺省为false
        /// </summary>
        [DefaultValue(false)]
        [DisplayName("摘要视频标志")]
        public bool IsAbstractVideo { get; set; }

        /// <summary>
        /// 原始视频ID
        /// GA/T 1400.1《公安视频图像信息应用系统 第1部分：通用技术要求》，图像信息基本要素ID，视频、图像、文件
        /// </summary>
        [StringLength(41)]
        [DisplayName("原始视频ID")]
        public string OriginVideoID { get; set; }

        /// <summary>
        /// 原始视频URL
        /// </summary>
        [MaxLength(256)]
        [DisplayName("原始视频URL")]
        public string OriginVideoURL { get; set; }

        /// <summary>
        /// 视频图像分析处理事件类型
        /// GA/T 1400.3 B.3.51　视频图像分析处理事件类型（EventType）
        /// </summary>
        [DisplayName("视频图像分析处理事件类型")]
        public int EventSort { get; set; }

        /// <summary>
        /// 设备编码，自动采集必选
        /// GA/T 1400.1《公安视频图像信息应用系统 第1部分：通用技术要求》，采集设备、卡口点位、采集系统、分析系统、视图库、应用平台等设备编码规则
        /// </summary>
        [StringLength(20)]
        [DisplayName("设备编码")]
        public string DeviceId { get; set; }

        /// <summary>
        /// 存储路径  视频文件的存储路径，采用URI命名规则
        /// </summary>
        [MaxLength(256)]
        [DisplayName("存储路径")]
        public string StoragePath { get; set; }

        /// <summary>
        /// 缩略图存储路径  视频缩略图文件的存储路径，采用URI命名规则
        /// </summary>
        [MaxLength(256)]
        [DisplayName("缩略图存储路径")]
        public string ThumbnailStoragePath { get; set; }

        /// <summary>
        /// 视频文件哈希值  使用 MD5算法
        /// </summary>
        [MaxLength(128)]
        [DisplayName("视频文件哈希值")]
        public string FileHash { get; set; }

        /// <summary>
        /// 视频文件格式
        /// Mpg	    MPG
        /// Mov	    MOV
        /// Avi	    AVI
        /// Rm	    RM
        /// Rmvb	RMVB
        /// Flv	    FLV
        /// Vob	    VOB
        /// M2ts	M2TS
        /// Mp4	    MP4
        /// Es	    ES
        /// Ps	    PS
        /// Ts	    TS文件
        /// Other	其他 
        /// </summary>
        [Required]
        [MaxLength(6)]
        [DisplayName("视频文件格式")]
        public string FileFormat { get; set; }

        /// <summary>
        /// 视频编码格式
        /// 1	SVAC
        /// 2	H.264
        /// 3	MPEG-4
        /// 4	MPEG-2
        /// 5	MJPEG
        /// 6	H.263
        /// 7	H.265
        /// 99	其他
        /// </summary>
        [Required]
        [MaxLength(2)]
        [DisplayName("视频编码格式")]
        public string CodedFormat { get; set; }

        /// <summary>
        /// 音频标志
        /// 0:无音频，1:含音频
        /// </summary>
        [Required]
        [DisplayName("音频标志")]
        public int AudioFlag { get; set; }

        /// <summary>
        /// 题名  视频资料名称的汉语描述
        /// </summary>
        [Required]
        [MaxLength(128)]
        [DisplayName("题名")]
        public string Title { get; set; }

        /// <summary>
        /// 题名补充  题名的补充和备注信息
        /// </summary>
        [MaxLength(128)]
        [DisplayName("题名补充")]
        public string TitleNote { get; set; }

        /// <summary>
        /// 专项名  视频资料所属的专项名称
        /// </summary>
        [MaxLength(128)]
        [DisplayName("专项名")]
        public string SpecialName { get; set; }

        /// <summary>
        /// 关键词  能够表述视频资料主要内容的、具有检索意义的词或词组
        /// </summary>
        [MaxLength(200)]
        [DisplayName("关键词")]
        public string Keyword { get; set; }

        /// <summary>
        /// 内容描述  对视频内容的简要描述
        /// </summary>
        [Required]
        [MaxLength(1024)]
        [DisplayName("内容描述")]
        public string ContentDescription { get; set; }

        /// <summary>
        /// 主题人物  描述视频资料内出现的主要人物的中文姓名全称， 当有多个时用英文半角分号”;”分隔
        /// </summary>
        [MaxLength(256)]
        [DisplayName("主题人物")]
        public string MainCharacter { get; set; }

        /// <summary>
        /// 拍摄地点行政区划代码 GB/T 2260，行政区划、籍贯省市县代码
        /// </summary>
        [Required]
        [StringLength(6)]
        [DisplayName("拍摄地点行政区划代码")]
        public string ShotPlaceCode { get; set; }

        /// <summary>
        /// 拍摄地点区划内详细地址
        /// </summary>
        [Required]
        [MaxLength(100)]
        [DisplayName("拍摄地点区划内详细地址")]
        public string ShotPlaceFullAdress { get; set; }

        /// <summary>
        /// 拍摄地点经度
        /// LongitudeType::double
        /// </summary>
        [DisplayName("拍摄地点经度")]
        public double ShotPlaceLongitude { get; set; }

        /// <summary>
        /// 拍摄地点纬度
        /// LatitudeType::double
        /// </summary>
        [DisplayName("拍摄地点纬度")]
        public double ShotPlacetLatitude { get; set; }

        /// <summary>
        /// 水平拍摄方向
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
        [StringLength(1)]
        [DisplayName("水平拍摄方向")]
        public string HorizontalShotDirection { get; set; }

        /// <summary>
        /// 垂直拍摄方向
        /// 1	上
        /// 2	水平
        /// 3	下
        /// </summary>
        [StringLength(1)]
        [DisplayName("垂直拍摄方向")]
        public string VerticalShotDirection { get; set; }

        /// <summary>
        /// 密级代码
        /// 1	绝密
        /// 2	机密
        /// 3	秘密
        /// 4	内部
        /// 5	公开
        /// 9	其他
        /// </summary>
        [StringLength(1)]
        [DisplayName("密级代码")]
        public string SecurityLevel { get; set; }

        /// <summary>
        /// 视频长度  单位为秒（s）
        /// </summary>
        [Required]
        [DisplayName("视频长度")]
        public double VidelLen { get; set; }

        /// <summary>
        /// 视频开始时间  视频标识开始时间
        /// </summary>
        [Required]
        [DisplayName("视频开始时间")]
        public DateTime BeginTime { get; set; }

        /// <summary>
        /// 视频结束时间  视频标识结束时间
        /// </summary>
        [Required]
        [DisplayName("视频结束时间")]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 时间误差  视频标识时间减去实际北京时间的值，单位为秒（s）
        /// </summary>
        [Required]
        [DisplayName("时间误差")]
        public int TimeErr { get; set; }

        /// <summary>
        /// 宽度
        /// </summary>
        [Required]
        [DisplayName("宽度")]
        public int Width { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        [Required]
        [DisplayName("高度")]
        public int Height { get; set; }

        /// <summary>
        /// 图像质量等级
        /// GA/T 1400.3  B.3.6　质量等级（QualityGradeType）
        /// </summary>
        [DisplayName("质量等级")]
        [DefaultValue("3")]
        public string QualityGrade { get; set; }

        /// <summary>
        /// 采集人  视频资料的采集人姓名或采集系统名称，人工采集必选
        /// </summary>
        [MaxLength(50)]
        [DisplayName("采集人")]
        public string CollectorName { get; set; }

        /// <summary>
        /// 采集单位名称  视频资料的采集单位名称，人工采集必选
        /// </summary>
        [DisplayName("采集单位名称")]
        [StringLength(100)]
        public string CollectorOrg { get; set; }

        /// <summary>
        /// 采集人证件类型
        /// </summary>
        [DisplayName("采集人证件类型")]
        [StringLength(3)]
        public string CollectorIDType { get; set; }

        /// <summary>
        /// 采集人证件号码
        /// </summary>
        [DisplayName("采集人证件号码")]
        [StringLength(30)]
        public string CollectorID { get; set; }


        /// <summary>
        /// 入库人  视频资料的入库人姓名或入库系统名称，人工采集必选
        /// </summary>
        [MaxLength(50)]
        [DisplayName("入库人")]
        public string EntryClerk { get; set; }

        /// <summary>
        /// 入库单位名称  视频资料的入库单位名称，人工采集必选
        /// </summary>
        [DisplayName("入库单位名称")]
        [StringLength(100)]
        public string EntryClerkOrg { get; set; }

        /// <summary>
        /// 入库人证件类型
        /// </summary>
        [DisplayName("入库人证件类型")]
        [StringLength(3)]
        public string EntryClerkIDType { get; set; }

        /// <summary>
        /// 入库人证件号码
        /// </summary>
        [DisplayName("入库人证件号码")]
        [StringLength(30)]
        public string EntryClerkID { get; set; }

        /// <summary>
        /// 入库时间  视图库自动生成，创建报文中不需要该字段
        /// </summary>
        [DisplayName("入库时间")]
        public DateTime EntryTime { get; set; }

        /// <summary>
        /// 视频处理标志  0：未处理，1：视频经过处理
        /// </summary>
        [DisplayName("视频处理标志")]
        public int VideoProcFlag { get; set; }

        /// <summary>
        /// 文件大小  视频文件大小，单位byte
        /// </summary>
        [DisplayName("文件大小")]
        public long FileSize { get; set; }
    }
}
