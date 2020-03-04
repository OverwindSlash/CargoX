using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Domain.Entities;

namespace Pensees.CargoX.Entities
{
    public class Thing : Entity<long>
    {
        /// <summary>
        /// 物品标识
        /// ImageCntObjectIdType::string(48)
        /// GA/T 1400.1 图像信息内容要素 ID，人、人脸、机动车、非机动车、物品、场景等
        /// </summary>
        [Required]
        [StringLength(48)]
        [DisplayName("物品标识")]
        public string ThingID { get; set; }

        /// <summary>
        /// 信息分类
        /// 人工采集还是自动采集
        /// InfoType::int::视频图像信息类型
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
        /// 设备编码，自动采集必选
        /// GA/T 1400.1《公安视频图像信息应用系统 第1部分：通用技术要求》，采集设备、卡口点位、采集系统、分析系统、视图库、应用平台等设备编码规则
        /// </summary>
        [StringLength(20)]
        [DisplayName("设备编码")]
        public string DeviceId { get; set; }

        /// <summary>
        /// 左上角X坐标
        /// 物品的轮廓外接矩形在画面中的位置，记录矩形框的左上角坐标和右下角坐标，自动采集记录时为必选
        /// </summary>
        [DisplayName("左上角X坐标")]
        public int LeftTopX { get; set; }

        /// <summary>
        /// 左上角Y坐标
        /// 物品的轮廓外接矩形在画面中的位置，记录矩形框的左上角坐标和右下角坐标，自动采集记录时为必选
        /// </summary>
        [DisplayName("左上角Y坐标")]
        public int LeftTopY { get; set; }

        /// <summary>
        /// 右下角X坐标
        /// 物品的轮廓外接矩形在画面中的位置，记录矩形框的左上角坐标和右下角坐标，自动采集记录时为必选
        /// </summary>
        [DisplayName("右下角X坐标")]
        public int RightBtmX { get; set; }

        /// <summary>
        /// 右下角Y坐标
        /// 物品的轮廓外接矩形在画面中的位置，记录矩形框的左上角坐标和右下角坐标，自动采集记录时为必选
        /// </summary>
        [DisplayName("右下角Y坐标")]
        public int RightBtmY { get; set; }

        /// <summary>
        /// 位置标记时间 人工采集时有效
        /// </summary>
        [DisplayName("位置标记时间")]
        public DateTime MarkTime { get; set; }

        /// <summary>
        /// 车辆出现时间 人工采集时有效
        /// </summary>
        [DisplayName("车辆出现时间")]
        public DateTime AppearTime { get; set; }

        /// <summary>
        /// 车辆消失时间 人工采集时有效
        /// </summary>
        [DisplayName("车辆消失时间")]
        public DateTime DisappearTime { get; set; }

        /// <summary>
        /// 物品名称  被标注物品名称
        /// </summary>
        [StringLength(256)]
        [DisplayName("物品名称")]
        public string Name { get; set; }

        /// <summary>
        /// 物品形状  被标注物品形状描述
        /// </summary>
        [StringLength(64)]
        [DisplayName("物品形状")]
        public string Shape { get; set; }

        /// <summary>
        /// 物品颜色
        /// 1	黑
        /// 2	白
        /// 3	灰
        /// 4	红
        /// 5	蓝
        /// 6	黄
        /// 7	橙
        /// 8	棕
        /// 9	绿
        /// 10	紫
        /// 11	青
        /// 12	粉
        /// 13	透明
        /// 99	其他 
        /// </summary>
        [Required]
        [DisplayName("物品颜色")]
        [StringLength(2)]
        public string Color { get; set; }

        /// <summary>
        /// 物品大小  被标注物品大小描述
        /// </summary>
        [StringLength(64)]
        [DisplayName("物品大小")]
        public string Size { get; set; }

        /// <summary>
        /// 物品材质  被标注物品材质描述
        /// </summary>
        [StringLength(256)]
        [DisplayName("物品材质")]
        public string Material { get; set; }

        /// <summary>
        /// 物品特征  被标注物品特征描述
        /// </summary>
        [StringLength(256)]
        [DisplayName("物品特征")]
        public string Characteristic { get; set; }

        /// <summary>
        /// 物品性质
        /// 1	作案工具
        /// 2	被盗抢
        /// 3	损失
        /// 4	缴获
        /// 99	其他
        /// GA/T 1400.3 B.3.27　物品性质（ThingPropertyType）
        /// </summary>
        [StringLength(2)]
        [DisplayName("物品性质")]
        public string Propertiy { get; set; }

        /// <summary>
        /// 涉案物品类型
        /// InvolvedObjType::string(5)
        /// GA 240.10，涉案物品分类和代码
        /// </summary>
        [StringLength(5)]
        [DisplayName("涉案物品类型")]
        public string InvolvedObjType { get; set; }

        /// <summary>
        /// 枪支弹药类别
        /// FirearmsAmmunitionType::string(2)
        /// GA 240.27，枪支弹药类别
        /// </summary>
        [StringLength(2)]
        [DisplayName("枪支弹药类别")]
        public string FirearmsAmmunitionType { get; set; }

        /// <summary>
        /// 工具痕迹代码
        /// ToolTraceType::string(2)
        /// GA 240.42，工具痕迹分类和代码
        /// </summary>
        [StringLength(2)]
        [DisplayName("工具痕迹代码")]
        public string ToolTraceType { get; set; }

        /// <summary>
        /// 物证类别
        /// EvidenceType::string(5)
        /// GA/T 693.5，物证类别
        /// </summary>
        [StringLength(5)]
        [DisplayName("物证类别")]
        public string EvidenceType { get; set; }

        /// <summary>
        /// 案(事)件物证形态代码
        /// CaseEvidenceType::string(2)
        /// GA/T 693.6，案(事)件物证形态代码
        /// </summary>
        [StringLength(2)]
        [DisplayName("案(事)件物证形态代码")]
        public string CaseEvidenceType { get; set; }

        /// <summary>
        /// 图像列表 可以包含0个或者多个子图像对象
        /// </summary>
        [DisplayName("图像列表")]
        public List<SubImageInfo> SubImageInfos { get; set; }
    }
}
