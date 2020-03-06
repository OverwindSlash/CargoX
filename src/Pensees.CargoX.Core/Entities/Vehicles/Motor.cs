using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace Pensees.CargoX.Entities
{
    public class Motor : Entity<long>
    {
        /// <summary>
        /// 车辆标识
        /// ImageCntObjectIdType::string(48)
        /// GA/T 1400.1 图像信息内容要素 ID，人、人脸、机动车、非机动车、物品、场景等
        /// </summary>
        [Required]
        [StringLength(48)]
        [DisplayName("车辆标识")]
        public string MotorVehicleID { get; set; }

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
        /// 关联卡口编号 GA/T 1400.1《公安视频图像信息应用系统 第1部分：通用技术要求》，采集设备、卡口点位、采集系统、分析系统、视图库、应用平台等设备编码规则
        /// GB/T28181附录D中D.1规定的编码规则
        /// 编码规则A 由中心编码(8位)、行业编码(2位)、类型编码(3位)和序号(7位)四个码段共20位十进制数字字符构成,即系统编码=中心编码+ 行业编码+ 类型编码+ 序号。
        /// </summary>
        [StringLength(20)]
        [DisplayName("关联卡口编号")]
        public string TollgateId { get; set; }

        /// <summary>
        /// 设备编码，自动采集必选
        /// GA/T 1400.1《公安视频图像信息应用系统 第1部分：通用技术要求》，采集设备、卡口点位、采集系统、分析系统、视图库、应用平台等设备编码规则
        /// </summary>
        [StringLength(20)]
        [DisplayName("设备编码")]
        public string DeviceId { get; set; }

        /// <summary>
        /// 近景照片
        /// 卡口相机所拍照片，自动采集必选，图像访问路径，采用URI命名规则
        /// </summary>
        [Required]
        [StringLength(256)]
        [DisplayName("近景照片")]
        public string StorageUrl1 { get; set; }

        /// <summary>
        /// 车牌照片 
        /// </summary>
        [Required]
        [StringLength(256)]
        [DisplayName("车牌照片")]
        public string StorageUrl2 { get; set; }

        /// <summary>
        /// 远景照片
        /// 全景相机所拍照片
        /// </summary>
        [Required]
        [StringLength(256)]
        [DisplayName("远景照片")]
        public string StorageUrl3 { get; set; }

        /// <summary>
        /// 合成图
        /// </summary>
        [Required]
        [StringLength(256)]
        [DisplayName("合成图")]
        public string StorageUrl4 { get; set; }

        /// <summary>
        /// 缩略图
        /// </summary>
        [Required]
        [StringLength(256)]
        [DisplayName("缩略图")]
        public string StorageUrl5 { get; set; }

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
        /// 车道编号 车辆行驶方向最左车道为1，由左向右顺序编号。与方向有关
        /// </summary>
        [DisplayName("车道编号")]
        public int LaneNo { get; set; }

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
        [MaxLength(15)]
        public string PlateNo { get; set; }

        /// <summary>
        /// 挂车牌号
        /// 各类机动车挂车号牌编号
        /// </summary>
        [DisplayName("挂车牌号")]
        [MaxLength(15)]
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
        /// 行驶方向
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
        [DisplayName("行驶方向")]
        public string Direction { get; set; }

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
        /// 车辆类型
        /// GA/T16.4机动车车辆类型代码
        /// </summary>
        [StringLength(3)]
        [DisplayName("车辆类型")]
        public string VehicleClass { get; set; }

        /// <summary>
        /// 车辆品牌
        /// 车辆品牌代码
        /// </summary>
        [StringLength(3)]
        [DisplayName("车辆品牌")]
        public string VehicleBrand { get; set; }

        /// <summary>
        /// 车辆型号 
        /// </summary>
        [MaxLength(32)]
        [DisplayName("车辆型号")]
        public string VehicleModel { get; set; }

        /// <summary>
        /// 车辆年款 
        /// </summary>
        [MaxLength(16)]
        [DisplayName("车辆年款")]
        public string VehicleStyles { get; set; }

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
        /// 颜色深浅 
        /// </summary>
        [DisplayName("颜色深浅")]
        public string VehicleColorDepth { get; set; }

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
        /// 撞痕信息 
        /// </summary>
        [DisplayName("撞痕信息")]
        public string HitMarkInfo { get; set; }

        /// <summary>
        /// 车身描述 描述车身上的文字信息，或者车上载物信息
        /// </summary>
        [MaxLength(128)]
        [DisplayName("车身描述")]
        public string VehicleBodyDesc { get; set; }

        /// <summary>
        /// 车前部物品  当有多个时可用英文半角逗号分隔
        /// </summary>
        [MaxLength(128)]
        [DisplayName("车前部物品")]
        public string VehicleFrontItem { get; set; }

        /// <summary>
        /// 车前部物品描述  对车前部物品数量、颜色、种类等信息的描述
        /// </summary>
        [MaxLength(256)]
        [DisplayName("车前部物品描述")]
        public string DescOfFrontItem { get; set; }

        /// <summary>
        /// 车后部物品  当有多个时可用英文半角逗号分隔
        /// </summary>
        [MaxLength(128)]
        [DisplayName("车后部物品")]
        public string VehicleRearItem { get; set; }

        /// <summary>
        /// 车后部物品描述  对车后部物品数量、颜色、种类等信息的描述
        /// </summary>
        [MaxLength(256)]
        [DisplayName("车后部物品描述")]
        public string DescOfRearItem { get; set; }

        /// <summary>
        /// 车内人数  车辆内人员数量
        /// </summary>
        [DisplayName("车内人数")]
        public int NumOfPassenger { get; set; }

        /// <summary>
        /// 经过时刻 卡口事件有效，过车时间
        /// </summary>
        [DisplayName("经过时刻")]
        public DateTime PassTime { get; set; }

        /// <summary>
        /// 经过道路名称  车辆被标注时经过的道路名称
        /// </summary>
        [MaxLength(64)]
        [DisplayName("经过道路名称")]
        public string NameOfPassedRoad { get; set; }

        /// <summary>
        /// 是否可疑车
        /// </summary>
        [DisplayName("是否可疑车")]
        public bool IsSuspicious { get; set; }

        /// <summary>
        /// 遮阳板状态
        /// 0：收起；1：放下
        /// </summary>
        [DisplayName("遮阳板状态")]
        public int Sunvisor { get; set; }

        /// <summary>
        /// 安全带状态
        /// 0：未系；1：有系
        /// </summary>
        [DisplayName("安全带状态")]
        public int SafetyBelt { get; set; }

        /// <summary>
        /// 打电话状态
        /// 0：未打电话；1：打电话中
        /// </summary>
        [DisplayName("打电话状态")]
        public int Calling { get; set; }

        /// <summary>
        /// 号牌识别可信度  整个号牌号码的识别可信度，以0～100数值表示百分比，数值越大可信度越高
        /// </summary>
        [MaxLength(3)]
        [DisplayName("号牌识别可信度")]
        public string PlateReliability { get; set; }

        /// <summary>
        /// 每位号牌号码可信度
        /// 号牌号码的识别可信度，以0～100数值表示百分比，数值越大可信度越高。
        /// 按“字符1-可信度1，字符2-可信度2”方式排列，中间为英文半角连接线、逗号；
        /// 例如识别号牌号码为：苏B12345，则取值为：”苏-80，B-90，1-90，2-88，3-90，4-67，5-87” 
        /// </summary>
        [MaxLength(64)]
        [DisplayName("每位号牌号码可信度")]
        public string PlateCharReliability { get; set; }

        /// <summary>
        /// 品牌标志识别可信度  车辆品牌标志可信度；以0～100之间数值表示百分比，数值越大可信度越高
        /// </summary>
        [MaxLength(3)]
        [DisplayName("品牌标志识别可信度")]
        public string BrandReliability { get; set; }

        /// <summary>
        /// 图像列表 可以包含0个或者多个子图像对象
        /// </summary>
        [DisplayName("图像列表")]
        public List<SubImageInfo> SubImageInfos { get; set; }
        /// <summary>
        /// 拍摄时间：冗余SubImageInfo中字段，方便查询
        /// </summary>
        [DisplayName("拍摄时间")]
        public DateTime ShotTime { get; set; }
    }
}
