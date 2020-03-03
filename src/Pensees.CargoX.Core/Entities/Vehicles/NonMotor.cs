using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Domain.Entities;

namespace Pensees.CargoX.Entities
{
    public class NonMotor : Entity<long>
    {
        /// <summary>
        /// 车辆标识
        /// ImageCntObjectIdType::string(48)
        /// GA/T 1400.1 图像信息内容要素 ID，人、人脸、机动车、非机动车、物品、场景等
        /// </summary>
        [Required]
        [StringLength(48)]
        [DisplayName("车辆标识")]
        public string NonMotorVehicleID { get; set; }

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
        /// 车的轮廓外接矩形在画面中的位置，记录左上角坐标及右下角坐标，自动采集记录时为必选
        /// </summary>
        [DisplayName("左上角X坐标")]
        public int LeftTopX { get; set; }

        /// <summary>
        /// 左上角Y坐标
        /// 车的轮廓外接矩形在画面中的位置，记录左上角坐标及右下角坐标，自动采集记录时为必选
        /// </summary>
        [DisplayName("左上角Y坐标")]
        public int LeftTopY { get; set; }

        /// <summary>
        /// 右下角X坐标
        /// 车的轮廓外接矩形在画面中的位置，记录左上角坐标及右下角坐标，自动采集记录时为必选
        /// </summary>
        [DisplayName("右下角X坐标")]
        public int RightBtmX { get; set; }

        /// <summary>
        /// 右下角Y坐标
        /// 车的轮廓外接矩形在画面中的位置，记录左上角坐标及右下角坐标，自动采集记录时为必选
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
        /// 有无车牌
        /// </summary>
        [DisplayName("有无车牌")]
        public bool HasPlate { get; set; }

        /// <summary>
        /// 号牌种类
        /// 01	大型汽车号牌
        /// 02	小型汽车号牌
        /// 03	使馆汽车号牌
        /// 04	领馆汽车号牌
        /// 05	境外汽车号牌
        /// 06	外籍汽车号牌
        /// 07	普通摩托车号牌
        /// </summary>
        [DisplayName("号牌种类")]
        [StringLength(2)]
        public string PlateClass { get; set; }

        /// <summary>
        /// 号牌颜色 指号牌底色，取ColorType中部分值： 黑色，白色，黄色，蓝色，绿色
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
        [DisplayName("号牌颜色")]
        [StringLength(2)]
        public string PlateColor { get; set; }

        /// <summary>
        /// 车牌号
        /// 各类机动车号牌编号车牌全部无法识别的以“无车牌”标识，部分未识别的每个字符以半角‘-’代替
        /// </summary>
        [DisplayName("车牌号")]
        [MaxLength(16)]
        public string PlateNo { get; set; }

        /// <summary>
        /// 挂车牌号
        /// 各类机动车挂车号牌编号
        /// </summary>
        [DisplayName("挂车牌号")]
        [MaxLength(16)]
        public string PlateNoAttach { get; set; }

        /// <summary>
        /// 车牌描述
        /// 车牌框广告信息，包括车行名称，联系电话等
        /// </summary>
        [DisplayName("车牌描述")]
        [MaxLength(64)]
        public string PlateDescribe { get; set; }

        /// <summary>
        /// 是否套牌
        /// </summary>
        [DisplayName("是否套牌")]
        public bool IsDecked { get; set; }

        /// <summary>
        /// 是否涂改
        /// </summary>
        [DisplayName("是否涂改")]
        public bool IsAltered { get; set; }

        /// <summary>
        /// 是否遮挡
        /// </summary>
        [DisplayName("是否遮挡")]
        public bool IsCovered { get; set; }

        /// <summary>
        /// 行驶速度
        /// </summary>
        [DisplayName("行驶速度")]
        public double Speed { get; set; }

        /// <summary>
        /// 行驶状态代码
        /// GA/T 16.55，机动车行驶状态代码                
        /// </summary>
        [StringLength(4)]
        [DisplayName("行驶状态代码")]
        public string DrivingStatusCode { get; set; }

        /// <summary>
        /// 车辆使用性质代码
        /// GA/T 16.3，机动车使用性质代码
        /// </summary>
        [DisplayName("车辆使用性质代码")]
        public int UsingPropertiesCode { get; set; }

        /// <summary>
        /// 车辆品牌 
        /// </summary>
        [StringLength(32)]
        [DisplayName("车辆品牌")]
        public string VehicleBrand { get; set; }

        /// <summary>
        /// 车辆款型 
        /// </summary>
        [StringLength(64)]
        [DisplayName("车辆款型")]
        public string VehicleType { get; set; }

        /// <summary>
        /// 车辆长度
        /// 5位整数，单位为毫米（mm）
        /// </summary>
        [DisplayName("车辆长度")]
        public int VehicleLength { get; set; }

        /// <summary>
        /// 车辆宽度
        /// 4位整数，单位为毫米（mm）
        /// </summary>
        [DisplayName("车辆宽度")]
        public int VehicleWidth { get; set; }

        /// <summary>
        /// 车辆高度
        /// 4位整数，单位为毫米（mm）
        /// </summary>
        [DisplayName("车辆高度")]
        public int VehicleHeight { get; set; }

        /// <summary>
        /// 车身颜色 
        /// </summary>
        [Required]
        [MaxLength(2)]
        [DisplayName("车身颜色")]
        public string VehicleColor { get; set; }

        /// <summary>
        /// 车前盖 
        /// </summary>
        [MaxLength(64)]
        [DisplayName("车前盖")]
        public string VehicleHood { get; set; }

        /// <summary>
        /// 车后盖 
        /// </summary>
        [MaxLength(64)]
        [DisplayName("车后盖")]
        public string VehicleTrunk { get; set; }

        /// <summary>
        /// 车轮 
        /// </summary>
        [MaxLength(64)]
        [DisplayName("车轮")]
        public string VehicleWheel { get; set; }

        /// <summary>
        /// 车轮印花纹 
        /// </summary>
        [MaxLength(2)]
        [DisplayName("车轮印花纹")]
        public string WheelPrintedPattern { get; set; }

        /// <summary>
        /// 车窗 
        /// </summary>
        [MaxLength(64)]
        [DisplayName("车窗")]
        public string VehicleWindow { get; set; }

        /// <summary>
        /// 车顶 
        /// </summary>
        [MaxLength(64)]
        [DisplayName("车顶")]
        public string VehicleRoof { get; set; }

        /// <summary>
        /// 车门 
        /// </summary>
        [MaxLength(64)]
        [DisplayName("车门")]
        public string VehicleDoor { get; set; }

        /// <summary>
        /// 车侧 
        /// </summary>
        [MaxLength(64)]
        [DisplayName("车侧")]
        public string SideOfVehicle { get; set; }

        /// <summary>
        /// 车厢 
        /// </summary>
        [MaxLength(64)]
        [DisplayName("车厢")]
        public string CarOfVehicle { get; set; }

        /// <summary>
        /// 后视镜 
        /// </summary>
        [MaxLength(64)]
        [DisplayName("后视镜")]
        public string RearviewMirror { get; set; }

        /// <summary>
        /// 底盘 
        /// </summary>
        [MaxLength(64)]
        [DisplayName("底盘")]
        public string VehicleChassis { get; set; }

        /// <summary>
        /// 遮挡 
        /// </summary>
        [MaxLength(64)]
        [DisplayName("遮挡")]
        public string VehicleShielding { get; set; }

        /// <summary>
        /// 贴膜颜色 
        /// </summary>
        [DisplayName("贴膜颜色")]
        public string FilmColor { get; set; }

        /// <summary>
        /// 改装标志
        /// </summary>
        [DisplayName("改装标志")]
        public bool IsModified { get; set; }

        /// <summary>
        /// 图像列表 可以包含0个或者多个子图像对象
        /// </summary>
        [DisplayName("图像列表")]
        public List<SubImageInfo> SubImageInfos { get; set; }
    }
}
