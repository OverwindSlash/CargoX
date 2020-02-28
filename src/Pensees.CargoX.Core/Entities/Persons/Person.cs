using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pensees.CargoX.Entities
{
    public class Person:Entity<long>
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
        /// 位置标记时间
        /// 人工采集时有效
        /// </summary>
        [DisplayName("位置标记时间")]
        public DateTime LocationMarkTime { get; set; }

        /// <summary>
        /// 人员出现时间
        /// 人工采集时有效
        /// </summary>
        [DisplayName("人员出现时间")]
        public DateTime PersonAppearTime { get; set; }

        /// <summary>
        /// 11 人员消失时间
        /// 人工采集时有效
        /// </summary>
        [DisplayName("人员消失时间")]
        public DateTime PersonDisAppearTime { get; set; }

        /// <summary>
        /// 12 证件种类
        /// IDType::string(3)::GAT 517，常用证件代码
        /// </summary>
        [DisplayName("证件种类")]
        [StringLength(3)]
        public string IDType { get; set; }

        /// <summary>
        /// 13 证件号码
        /// 有效证件号码
        /// IdNumberType::string(0..30)::证件号码
        /// </summary>
        [DisplayName("证件种类")]
        [StringLength(30)]
        public string IDNumber { get; set; }

        /// <summary>
        /// 14 姓名
        /// 人员的中文姓名全称
        /// NameType::string(0..50)::姓名
        /// </summary>
        [DisplayName("姓名")]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 15 曾用名
        /// 曾经在户籍管理部门正式登记注册、人事档案中正式记载的姓氏名称
        /// UsedNameType::string(0..50)::曾用名
        /// </summary>
        [DisplayName("曾用名")]
        [StringLength(50)]
        public string UsedName { get; set; }

        /// <summary>
        /// 16 绰号
        /// 使用姓名及曾用名之外的名称
        /// AliasType::string(0..50)::别名、绰号
        /// </summary>
        [DisplayName("绰号")]
        [StringLength(50)]
        public string Alias { get; set; }

        /// <summary>
        /// 17 性别代码
        /// GenderType::string::性别
        /// </summary>
        [DisplayName("性别代码")]
        public string GenderCode { get; set; }

        /// <summary>
        /// 18 年龄上限
        /// 最大可能年龄
        /// </summary>
        [DisplayName("年龄上限")]
        public int AgeUpLimit { get; set; }

        /// <summary>
        /// 19 年龄下限
        /// 最小可能年龄
        /// </summary>
        [DisplayName("年龄下限")]
        public int AgeLowerLimit { get; set; }

        /// <summary>
        /// 20 民族代码
        /// 中国各名族的罗马字母拼写法和代码
        /// EthicCodeType::string(2)::GB/T 3304，中国各名族的罗马字母拼写法和代码
        /// </summary>
        [DisplayName("民族代码")]
        [StringLength(2)]
        public string EthicCode { get; set; }

        /// <summary>
        /// 21 国籍代码
        /// 世界各国和地区名称代码
        /// NationalityCodeType::string(3)::GB/T 2659，国籍代码、世界各国和地区名称代码
        /// </summary>
        [DisplayName("国籍代码")]
        [StringLength(3)]
        public string NationalityCode { get; set; }

        /// <summary>
        /// 22 籍贯省市县代码
        /// PlaceCodeType::string(6)::GB/T 2260，行政区划、籍贯省市县代码
        /// </summary>
        [DisplayName("籍贯省市县代码")]
        [StringLength(6)]
        public string NativeCityCode { get; set; }

        /// <summary>
        /// 23 居住地行政区划
        /// PlaceCodeType::string(6)::GB/T 2260，行政区划、籍贯省市县代码
        /// </summary>
        [DisplayName("居住地行政区划")]
        [StringLength(6)]
        public string ResidenceAdminDivision { get; set; }

        /// <summary>
        /// 24 汉语口音代码
        /// 汉语口音编码规则
        /// ChineseAccentCode::string(6)::GA 240.57，汉语口音编码规则 
        /// </summary>
        [DisplayName("汉语口音代码")]
        [StringLength(6)]
        public string ChineseAccentCode { get; set; }

        /// <summary>
        /// 25 单位名称
        /// 人员所在的工作单位
        /// OrgType::string(0..100)::单位名称
        /// </summary>
        [DisplayName("单位名称")]
        [StringLength(100)]
        public string PersonOrg { get; set; }

        /// <summary>
        /// 26 职业类别代码
        /// 职业分类与代码，不包含代码中“—”
        /// JobCategoryType::string(3)::GB/T 6565，职业分类与代码，不包含代码中“—” 
        /// </summary>
        [DisplayName("职业类别代码")]
        [StringLength(3)]
        public string JobCategory { get; set; }

        /// <summary>
        /// 27 同行人数
        /// 被标注人的同行人数
        /// </summary>
        [DisplayName("同行人数")]
        public int AccompanyNumber { get; set; }

        /// <summary>
        /// 28 身高上限
        /// 人的身高最大可能值，单位为厘米（cm） 
        /// </summary>
        [DisplayName("身高上限")]
        public int HeightUpLimit { get; set; }

        /// <summary>
        /// 29 身高下限
        /// 人的身高最小可能值，单位为厘米（cm）
        /// </summary>
        [DisplayName("身高下限")]
        public int HeightLowerLimit { get; set; }

        /// <summary>
        /// 30 体型
        /// BodyType::string::GA 240.24，体型 
        /// </summary>
        [DisplayName("体型")]
        public string BodyType { get; set; }

        /// <summary>
        /// 31 肤色
        /// SkinColorType::string::GA 240.24，肤色 
        /// </summary>
        [DisplayName("肤色")]
        public string SkinColor { get; set; }

        /// <summary>
        /// 32 发型
        /// HairStyleType::string(2)::发型
        /// </summary>
        [DisplayName("发型")]
        [StringLength(2)]
        public string HairStyle { get; set; }

        /// <summary>
        /// 33 发色
        /// ColorType::string(2)::颜色
        /// </summary>
        [DisplayName("发色")]
        [StringLength(2)]
        public string HairColor { get; set; }

        /// <summary>
        /// 34 姿态
        /// PostureType::string(2)::姿态
        /// </summary>
        [DisplayName("姿态")]
        [StringLength(2)]
        public string Gesture { get; set; }

        /// <summary>
        /// 35 状态
        /// PersonStatusType::string(2)::人的状态 
        /// </summary>
        [DisplayName("状态")]
        [StringLength(2)]
        public string Status { get; set; }

        /// <summary>
        /// 36 脸型
        /// FaceStyleType::string(4)::GA 240.24，脸型 
        /// </summary>
        [DisplayName("脸型")]
        [StringLength(4)]
        public string FaceStyle { get; set; }

        /// <summary>
        /// 37 脸部特征
        /// FacialFeatureType::string(40)::GA 240.24，脸部特征
        /// </summary>
        [DisplayName("脸部特征")]
        [StringLength(40)]
        public string FacialFeature { get; set; }

        /// <summary>
        /// 38 体貌特征
        /// PhysicalFeatureType::string(200)::GA 240.24，体貌特征
        /// </summary>
        [DisplayName("体貌特征")]
        [StringLength(200)]
        public string PhysicalFeature { get; set; }

        /// <summary>
        /// 39 体表特征
        /// BodyFeatureType::string(70)::GA 240.24，体表特征，有多个时用英文半角逗号分隔
        /// </summary>
        [DisplayName("体表特征")]
        [StringLength(70)]
        public string BodyFeature { get; set; }

        /// <summary>
        /// 40 习惯动作
        /// HabitualActionType::string(2)::习惯动作
        /// </summary>
        [DisplayName("习惯动作")]
        [StringLength(2)]
        public string HabitualMovement { get; set; }

        /// <summary>
        /// 41 行为
        /// BehaviorType::string(2)::行为
        /// </summary>
        [DisplayName("行为")]
        [StringLength(2)]
        public string Behavior { get; set; }

        /// <summary>
        /// 42 行为描述
        /// 对行为项备注中没有的行为进行描述 
        /// </summary>
        [DisplayName("行为描述")]
        [StringLength(256)]
        public string BehaviorDescription { get; set; }

        /// <summary>
        /// 43 附属物
        /// 当有多个时用英文半角分号”;”分隔 
        /// AppendageType::string(2)::附属物
        /// </summary>
        [DisplayName("附属物")]
        [StringLength(128)]
        public string Appendant { get; set; }

        /// <summary>
        /// 44 附属物描述
        /// 对代码表中没有的附属物进行描述
        /// </summary>
        [DisplayName("附属物描述")]
        [StringLength(256)]
        public string AppendantDescription { get; set; }

        /// <summary>
        /// 45 伞颜色
        /// ColorType::string(2)::颜色
        /// </summary>
        [DisplayName("伞颜色")]
        [StringLength(2)]
        public string UmbrellaColor { get; set; }

        /// <summary>
        /// 46 口罩颜色
        /// ColorType::string(2)::颜色
        /// </summary>
        [DisplayName("口罩颜色")]
        [StringLength(2)]
        public string RespiratorColor { get; set; }

        /// <summary>
        /// 47 帽子款式
        /// HatStyleType::string (2)::帽子款式
        /// </summary>
        [DisplayName("帽子款式")]
        [StringLength(2)]
        public string CapStyle { get; set; }

        /// <summary>
        /// 48 帽子颜色
        /// ColorType::string(2)::颜色
        /// </summary>
        [DisplayName("帽子颜色")]
        [StringLength(2)]
        public string CapColor { get; set; }

        /// <summary>
        /// 49 眼镜款式
        /// GlassesStyleType::string(2)::眼镜款式 
        /// </summary>
        [DisplayName("眼镜款式")]
        [StringLength(2)]
        public string GlassStyle { get; set; }

        /// <summary>
        /// 50  眼镜颜色
        /// ColorType::string(2)::颜色
        /// </summary>
        [DisplayName("眼镜颜色")]
        [StringLength(2)]
        public string GlassColor { get; set; }

        /// <summary>
        /// 51 围巾颜色
        /// ColorType::string(2)::颜色
        /// </summary>
        [DisplayName("围巾颜色")]
        [StringLength(2)]
        public string ScarfColor { get; set; }

        /// <summary>
        /// 52 包款式
        /// BagStyleType::string(2)::包款式
        /// </summary>
        [DisplayName("包款式")]
        [StringLength(2)]
        public string BagStyle { get; set; }

        /// <summary>
        /// 53 包颜色
        /// ColorType::string(2)::颜色
        /// </summary>
        [DisplayName("包颜色")]
        [StringLength(2)]
        public string BagColor { get; set; }

        /// <summary>
        /// 54 上衣款式
        /// CoatStyleType::string(2)::上衣款式
        /// </summary>
        [DisplayName("上衣款式")]
        [StringLength(2)]
        public string CoatStyle { get; set; }

        /// <summary>
        /// 55 上衣长度
        /// CoatLengthType::string::上衣长度
        /// </summary>
        [DisplayName("上衣长度")]
        public string CoatLength { get; set; }

        /// <summary>
        /// 56 上衣颜色
        /// ColorType::string(2)::颜色
        /// </summary>
        [DisplayName("上衣颜色")]
        [StringLength(2)]
        public string CoatColor { get; set; }

        /// <summary>
        /// 57 裤子款式
        /// PantsStyleType::string(2)::裤子款式
        /// </summary>
        [DisplayName("裤子款式")]
        [StringLength(2)]
        public string TrousersStyle { get; set; }

        /// <summary>
        /// 58 裤子颜色
        /// ColorType::string(2)::颜色
        /// </summary>
        [DisplayName("裤子颜色")]
        [StringLength(2)]
        public string TrousersColor { get; set; }

        /// <summary>
        /// 59 裤子长度
        /// PantsLengthType::string::裤子长度
        /// </summary>
        [DisplayName("裤子长度")]
        public string TrousersLen { get; set; }

        /// <summary>
        /// 60 鞋子款式
        /// ShoesStyleType::string(2)::鞋子款式
        /// </summary>
        [DisplayName("鞋子款式")]
        [StringLength(2)]
        public string ShoesStyle { get; set; }

        /// <summary>
        /// 61 鞋子颜色
        /// ColorType::string(2)::颜色
        /// </summary>
        [DisplayName("鞋子颜色")]
        [StringLength(2)]
        public string ShoesColor { get; set; }

        /// <summary>
        /// 62 是否驾驶员
        /// 人工采集时必选 0：否；1：是；2：不确定
        /// </summary>
        [DisplayName("是否驾驶员")]
        public int IsDriver { get; set; }

        /// <summary>
        /// 63 是否涉外人员
        /// 0：否；1：是；2：不确定
        /// </summary>
        [DisplayName("是否涉外人员")]
        public int IsForeigner { get; set; }

        /// <summary>
        /// 64 护照证件种类
        /// enPassportType::string(2)::护照证件种类
        /// </summary>
        [DisplayName("护照证件种类")]
        [StringLength(2)]
        public string PassportType { get; set; }

        /// <summary>
        /// 65 出入境人员类别代码
        /// ImmigrantTypeCodeType::string(2)::GA/T 704.13，出入境人员分类代码 
        /// </summary>
        [DisplayName("出入境人员类别代码")]
        [StringLength(2)]
        public string ImmigrantTypeCode { get; set; }

        /// <summary>
        /// 66 是否涉恐人员
        /// 0：否；1：是；2：不确定
        /// </summary>
        [DisplayName("是否涉恐人员")]
        public int IsSuspectedTerrorist { get; set; }

        /// <summary>
        /// 67 涉恐人员编号
        /// SuspectedTerroristNumberType::string(19)::GA/T 726.10，涉恐人员编号
        /// </summary>
        [DisplayName("涉恐人员编号")]
        [StringLength(19)]
        public string SuspectedTerroristNumber { get; set; }

        /// <summary>
        /// 68 是否涉案人员
        /// 0：否；1：是；2：不确定 
        /// </summary>
        [DisplayName("是否涉案人员")]
        public int IsCriminalInvolved { get; set; }

        /// <summary>
        /// 69 涉案人员专长代码
        /// CriminalInvolvedSpecilisationCodeType::string(2)::GA 240.2，涉恐人员专长代码 
        /// </summary>
        [DisplayName("涉案人员专长代码")]
        [StringLength(2)]
        public string CriminalInvolvedSpecilisationCode { get; set; }

        /// <summary>
        /// 70 体表特殊标记
        /// BodySpeciallMarkType::string(7)::GA 240.3，体表特殊标记
        /// </summary>
        [DisplayName("体表特殊标记")]
        [StringLength(7)]
        public string BodySpeciallMark { get; set; }

        /// <summary>
        /// 71 作案手段
        /// CrimeMethodType::string(4)::GA 240.3，作案手段 
        /// </summary>
        [DisplayName("作案手段")]
        [StringLength(4)]
        public string CrimeMethod { get; set; }

        /// <summary>
        /// 72 作案特点代码
        /// CrimeCharacterCodeType::string(3)::GA 240.8，作案特点分类和代码
        /// </summary>
        [DisplayName("体表特殊标记")]
        [StringLength(3)]
        public string CrimeCharacterCode { get; set; }

        /// <summary>
        /// 73 在逃人员编号
        /// EscapedCriminalNumberType::string(23)::GA 240.56，在逃人员信息编号规则 
        /// </summary>
        [DisplayName("在逃人员编号")]
        [StringLength(23)]
        public string EscapedCriminalNumber { get; set; }

        /// <summary>
        /// 74 是否在押人员
        /// 0：否；1：是；2：不确定，人工采集必填
        /// </summary>
        [DisplayName("是否在押人员")]
        public int IsDetainees { get; set; }

        /// <summary>
        /// 75 看守所编码
        /// DetentionHouseCodeType::string(9)::GB/T 2260，GA 300.22，GA 300.23 
        /// 看守所编码，编码从左至右的含义是： 
        /// a)第 1～6 位表示看守所所在行政区划，代码采用 GB/T 2260 
        /// b)第 7 位表示监管单位归口类别，代码采用 GA 300.22 
        /// c)第 8 位表示监管单位类型，代码类型采用 GA 300.23 
        /// d)第 9 位表示看守所序号，代码由各监管单位自定
        /// </summary>
        [DisplayName("体表特殊标记")]
        [StringLength(9)]
        public string DetentionHouseCode { get; set; }

        /// <summary>
        /// 76 在押人员身份
        /// DetaineesIdentityType::string(2)::在押人员身份
        /// </summary>
        [DisplayName("在押人员身份")]
        [StringLength(2)]
        public string DetaineesIdentity { get; set; }

        /// <summary>
        /// 77 在押人员特殊身份
        /// DetaineesSpecialIdentityType::string(2)::GA 300.6，在押人员特殊身份代码
        /// </summary>
        [DisplayName("在押人员特殊身份")]
        [StringLength(2)]
        public string DetaineesSpecialIdentity { get; set; }

        /// <summary>
        /// 78 成员类型代码
        /// MemberTypeCodeType::string(2)::GA 300.9，成员类型代码 
        /// </summary>
        [DisplayName("体表特殊标记")]
        [StringLength(2)]
        public string MemberTypeCode { get; set; }

        /// <summary>
        /// 79 是否被害人
        /// 人工采集时必选 0：否；1：是；2：不确定
        /// </summary>
        [DisplayName("是否被害人")]
        public int IsVictim { get; set; }

        /// <summary>
        /// 80 被害人种类
        /// VictimType::string(3)::GA 240.6，被害人类型 
        /// </summary>
        [DisplayName("被害人种类")]
        [StringLength(3)]
        public string VictimType { get; set; }

        /// <summary>
        /// 81 受伤害程度
        /// InjuredDegreeType::string::受伤害程度
        /// </summary>
        [DisplayName("受伤害程度")]
        public string InjuredDegree { get; set; }

        /// <summary>
        /// 82 尸体状况代码
        /// CorpseConditionCodeType::string(2)::GA/T 693.12，尸体状况分类与代码
        /// </summary>
        [DisplayName("尸体状况代码")]
        [StringLength(2)]
        public string CorpseConditionCode { get; set; }

        /// <summary>
        /// 83 是否可疑人
        /// 人工采集时必选 0：否；1：是；2：不确定
        /// </summary>
        [DisplayName("是否可疑人")]
        public int IsSuspiciousPerson { get; set; }

        /// <summary>
        /// 84 图像列表 
        /// 可以包含0个或者多个子图像对象
        /// </summary>
        [DisplayName("图像列表")]
        public List<SubImageInfo> SubImageInfos { get; set; }

        /// <summary>
        /// 人体朝向
        /// 澎思私有扩展
        /// </summary>
        [DisplayName("朝向")]
        public string Orientation { get; set; }

        /// <summary>
        /// 上衣花纹
        /// 澎思私有扩展
        /// </summary>
        [DisplayName("上衣花纹")]
        public string CoatPattern { get; set; }
    }
}
