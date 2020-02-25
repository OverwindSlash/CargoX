using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AutoMapper.Configuration.Annotations;
using Pensees.CargoX.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pensees.CargoX.Faces.Dto
{
    [AutoMap(typeof(Face))]
    [AutoMapTo(typeof(ClusteringFaceDto))]
    public class FaceDto : EntityDto<long>
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
        /// 设备编码，自动采集必选
        /// GA/T 1400.1《公安视频图像信息应用系统 第1部分：通用技术要求》，采集设备、卡口点位、采集系统、分析系统、视图库、应用平台等设备编码规则
        /// </summary>
        [StringLength(20)]
        [DisplayName("设备编码")]
        public string DeviceId { get; set; }

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
        /// 位置标记时间 人工采集时有效
        /// </summary>
        [DisplayName("位置标记时间")]
        public DateTime LocationMarkTime { get; set; }

        /// <summary>
        /// 人脸出现时间 人工采集时有效
        /// </summary>
        [DisplayName("人脸出现时间")]
        public DateTime FaceAppearTime { get; set; }

        /// <summary>
        /// 人脸消失时间 人工采集时有效
        /// </summary>
        [DisplayName("人脸消失时间")]
        public DateTime FaceDisAppearTime { get; set; }

        /// <summary>
        /// 证件种类 GAT 517，常用证件代码
        /// </summary>
        [StringLength(3)]
        [DisplayName("证件种类")]
        public string IdType { get; set; }

        /// <summary>
        /// 证件号码，有效证件号码
        /// </summary>
        [MaxLength(30)]
        [DisplayName("证件号码")]
        public string IdNumber { get; set; }

        /// <summary>
        /// 姓名 人员的中文姓名全称
        /// </summary>
        [MaxLength(50)]
        [DisplayName("姓名")]
        public string Name { get; set; }

        /// <summary>
        /// 曾用名 曾经在户籍管理部门正式登记注册、人事档案中正式记载的姓氏名称
        /// </summary>
        [MaxLength(50)]
        [DisplayName("曾用名")]
        public string UsedName { get; set; }

        /// <summary>
        /// 绰号 使用姓名及曾用名之外的名称
        /// </summary>
        [MaxLength(50)]
        [DisplayName("绰号")]
        public string Alias { get; set; }

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
        /// 民族代码
        /// 中国各名族的罗马字母拼写法和代码
        /// GB/T 3304，中国各名族的罗马字母拼写法和代码
        /// </summary>
        [StringLength(2)]
        [DisplayName("民族代码")]
        public string EthicCode { get; set; }

        /// <summary>
        /// 国籍代码 世界各国和地区名称代码
        /// GB/T 2659，国籍代码、世界各国和地区名称代码
        /// </summary>
        [StringLength(3)]
        [DisplayName("国籍代码")]
        public string NationalityCode { get; set; }

        /// <summary>
        /// 籍贯省市县代码 GB/T 2260，行政区划、籍贯省市县代码
        /// </summary>
        [StringLength(6)]
        [DisplayName("籍贯省市县代码")]
        public string NativeCityCode { get; set; }

        /// <summary>
        /// 居住地行政区划 GB/T 2260，行政区划、籍贯省市县代码
        /// </summary>
        [StringLength(6)]
        [DisplayName("居住地行政区划")]
        public string ResidenceAdminDivision { get; set; }

        /// <summary>
        /// 汉语口音代码 汉语口音编码规则
        /// GA 240.57，汉语口音编码规则
        /// </summary>
        [StringLength(6)]
        [DisplayName("汉语口音代码")]
        public string ChineseAccentCode { get; set; }

        /// <summary>
        /// 职业类别代码 职业分类与代码，不包含代码中“—”
        /// GB/T 6565，职业分类与代码，不包含代码中“—”
        /// </summary>
        [StringLength(3)]
        [DisplayName("职业类别代码")]
        public string JobCategory { get; set; }

        /// <summary>
        /// 同行人脸数 被标注人脸的同行人脸数
        /// </summary>
        [DisplayName("同行人脸数")]
        public int AccompanyNumber { get; set; }

        /// <summary>
        /// 肤色 GA 240.24，肤色
        /// </summary>
        [DisplayName("肤色")]
        public string SkinColor { get; set; }

        /// <summary>
        /// 发型
        /// </summary>
        [StringLength(2)]
        [DisplayName("发型")]
        public string HairStyle { get; set; }

        /// <summary>
        /// 发色
        /// </summary>
        [StringLength(2)]
        [DisplayName("发色")]
        public string HairColor { get; set; }

        /// <summary>
        /// 脸型 GA 240.24，脸型
        /// </summary>
        [StringLength(4)]
        [DisplayName("脸型")]
        public string FaceStyle { get; set; }

        /// <summary>
        /// 脸部特征 GA 240.24，脸部特征
        /// </summary>
        [StringLength(40)]
        [DisplayName("脸部特征")]
        public string FacialFeatureType { get; set; }

        /// <summary>
        /// 体貌特征 GA 240.24，体貌特征
        /// </summary>
        [StringLength(200)]
        [DisplayName("体貌特征")]
        public string PhysicalFeature { get; set; }

        /// <summary>
        /// 口罩颜色
        /// </summary>
        [StringLength(2)]
        [DisplayName("口罩颜色")]
        public string RespiratorColor { get; set; }

        /// <summary>
        /// 帽子款式
        /// </summary>
        [StringLength(2)]
        [DisplayName("帽子款式")]
        public string CapStyle { get; set; }

        /// <summary>
        /// 帽子颜色
        /// </summary>
        [StringLength(2)]
        [DisplayName("帽子颜色")]
        public string CapColor { get; set; }

        /// <summary>
        /// 眼镜款式
        /// </summary>
        [StringLength(2)]
        [DisplayName("眼镜款式")]
        public string GlassStyle { get; set; }

        /// <summary>
        /// 眼镜颜色
        /// </summary>
        [StringLength(2)]
        [DisplayName("眼镜颜色")]
        public string GlassColor { get; set; }

        /// <summary>
        /// 是否驾驶员 0：否；1：是；2：不确定
        /// </summary>
        [DisplayName("是否驾驶员")]
        public int IsDriver { get; set; }

        /// <summary>
        /// 是否涉外人员 0：否；1：是；2：不确定
        /// </summary>
        [DisplayName("是否涉外人员")]
        public int IsForeigner { get; set; }

        /// <summary>
        /// 护照证件种类
        /// </summary>
        [StringLength(2)]
        [DisplayName("护照证件种类")]
        public string PassportType { get; set; }

        /// <summary>
        /// 出入境人员类别代码
        /// GA/T 704.13，出入境人员分类代码
        /// </summary>
        [StringLength(2)]
        [DisplayName("出入境人员类别代码")]
        public string ImmigrantTypeCode { get; set; }

        /// <summary>
        /// 是否涉恐人员 0：否；1：是；2：不确定
        /// </summary>
        [DisplayName("是否涉恐人员")]
        public int IsSuspectedTerrorist { get; set; }

        /// <summary>
        /// 涉恐人员编号
        /// GA/T 726.10，涉恐人员编号
        /// </summary>
        [StringLength(19)]
        [DisplayName("涉恐人员编号")]
        public string SuspectedTerroristNumber { get; set; }

        /// <summary>
        /// 是否涉案人员 0：否；1：是；2：不确定
        /// </summary>
        [DisplayName("是否涉案人员")]
        public int IsCriminalInvolved { get; set; }

        /// <summary>
        /// 涉案人员专长代码
        /// GA 240.2，涉案人员专长代码
        /// </summary>
        [StringLength(2)]
        [DisplayName("涉案人员专长代码")]
        public string CriminalInvolvedSpecilisationCode { get; set; }

        /// <summary>
        /// 体表特殊标记
        /// GA 240.3，体表特殊标记
        /// </summary>
        [StringLength(7)]
        [DisplayName("体表特殊标记")]
        public string BodySpeciallMark { get; set; }

        /// <summary>
        /// 作案手段
        /// GA 240.3，作案手段
        /// </summary>
        [StringLength(4)]
        [DisplayName("作案手段")]
        public string CrimeMethod { get; set; }

        /// <summary>
        /// 作案特点代码
        /// GA 240.8，作案特点分类和代码
        /// </summary>
        [StringLength(4)]
        [DisplayName("作案特点代码")]
        public string CrimeCharacterCode { get; set; }

        /// <summary>
        /// 在逃人员编号
        /// GA 240.56，在逃人员信息编号规则
        /// </summary>
        [StringLength(23)]
        [DisplayName("在逃人员编号")]
        public string EscapedCriminalNumber { get; set; }

        /// <summary>
        /// 是否在押人员 0：否；1：是；2：不确定
        /// </summary>
        [Required]
        [DisplayName("是否在押人员")]
        public int IsDetainees { get; set; }

        /// <summary>
        /// 看守所编码
        /// GB/T 2260，GA 300.22，GA 300.23
        /// 看守所编码，编码从左至右的含义是：
        /// a)第1～6位表示看守所所在行政区划，代码采用GB/T 2260
        /// b)第7位表示监管单位归口类别，代码采用GA 300.22
        /// c)第8位表示监管单位类型，代码类型采用GA 300.23
        /// d)第9位表示看守所序号，代码由各监管单位自定 
        /// </summary>
        [StringLength(9)]
        [DisplayName("看守所编码")]
        public string DetentionHouseCode { get; set; }

        /// <summary>
        /// 在押人员身份
        /// </summary>
        [StringLength(2)]
        [DisplayName("在押人员身份")]
        public string DetaineesIdentity { get; set; }

        /// <summary>
        /// 在押人员特殊身份
        /// GA 300.6，在押人员特殊身份代码
        /// </summary>
        [StringLength(2)]
        [DisplayName("在押人员特殊身份")]
        public string DetaineesSpecialIdentity { get; set; }

        /// <summary>
        /// 成员类型代码
        /// GA 300.9，成员类型代码
        /// </summary>
        [StringLength(2)]
        [DisplayName("成员类型代码")]
        public string MemberTypeCode { get; set; }

        /// <summary>
        /// 是否被害人 0：否；1：是；2：不确定
        /// </summary>
        [Required]
        [DisplayName("是否被害人")]
        public int IsVictim { get; set; }

        /// <summary>
        /// 被害人种类
        /// GA 240.6，被害人类型
        /// </summary>
        [StringLength(2)]
        [DisplayName("被害人种类")]
        public string VictimType { get; set; }

        /// <summary>
        /// 受伤害程度
        /// </summary>
        [DisplayName("受伤害程度")]
        public string InjuredDegree { get; set; }

        /// <summary>
        /// 尸体状况代码
        /// GA/T 693.12，尸体状况分类与代码
        /// </summary>
        [StringLength(2)]
        [DisplayName("尸体状况代码")]
        public string CorpseConditionCode { get; set; }

        /// <summary>
        /// 是否可疑人 0：否；1：是；2：不确定
        /// </summary>
        [Required]
        [DisplayName("是否可疑人")]
        public int IsSuspiciousPerson { get; set; }

        /// <summary>
        /// 姿态分布
        /// 1：平视；2：微仰；3：微俯；4：左微侧脸；5：左斜侧脸；6：左全侧脸；7：右微侧脸；8：右斜侧脸；9：右全侧脸
        /// </summary>
        [DisplayName("姿态分布")]
        public int Attitude { get; set; }

        /// <summary>
        /// 相似度
        /// 人脸相似度，[0，1]
        /// </summary>
        [DisplayName("相似度")]
        public double Similaritydegree { get; set; }

        /// <summary>
        /// 眉型
        /// 1：上扬眉；2：一字眉；3：八字眉；4：淡眉毛5：浓眉毛；6：弯眉；7：细眉；8：短眉毛；9：特殊眉；　有多个特征时用英文半角分号”;”分隔
        /// </summary>
        [StringLength(32)]
        [DisplayName("眉型")]
        public string EyebrowStyle { get; set; }

        /// <summary>
        /// 鼻型
        /// 1：上扬眉；2：一字眉；3：八字眉；4：淡眉毛5：浓眉毛；6：弯眉；7：细眉；8：短眉毛；9：特殊眉；　有多个特征时用英文半角分号”;”分隔
        /// </summary>
        [StringLength(32)]
        [DisplayName("鼻型")]
        public string NoseStyle { get; set; }

        /// <summary>
        /// 胡型
        /// 1：一字胡；2：八字胡；3：淡胡子；4：络腮胡；5：山羊胡；6：花白胡；7：一点胡
        /// </summary>
        [StringLength(32)]
        [DisplayName("胡型")]
        public string MustacheStyle { get; set; }

        /// <summary>
        /// 嘴唇
        /// 1：常见嘴；2：厚嘴唇；3：薄嘴唇；4：厚嘴巴；5：上翘嘴；6：下撇嘴；7：凸嘴；8：凹嘴；9：露齿嘴；10：小嘴；　有多个特征时用英文半角分号”;”分隔
        /// </summary>
        [StringLength(32)]
        [DisplayName("嘴唇")]
        public string LipStyle { get; set; }

        /// <summary>
        /// 皱纹眼袋
        /// 1：抬头纹；2：左眼角纹；3：右眼角纹；4：眉间纹；5：左眼纹；6：右眼纹；7：眼袋；8：左笑纹；9：右笑纹；10：鼻间纹；11：左瘦纹；12：右瘦纹；　有多个特征时用英文半角分号”;”分隔
        /// </summary>
        [StringLength(32)]
        [DisplayName("皱纹眼袋")]
        public string WrinklePouch { get; set; }

        /// <summary>
        /// 痤疮色斑
        /// 1：痤疮（单）；2：痤疮（少）；3：痤疮（多）；4：雀斑（稀）；5：雀斑（少）；6：雀斑（多）；7：色斑；　有多个特征时用英文半角分号”;”分隔
        /// </summary>
        [StringLength(32)]
        [DisplayName("痤疮色斑")]
        public string AcneStain { get; set; }

        /// <summary>
        /// 黑痣胎记
        /// 1：痣（小）；2：痣（中）；3：痣（大）；4：黑痣（小）；5：黑痣（中）；6：黑痣（大）；7：胎记；　有多个特征时用英文半角分号”;”分隔
        /// </summary>
        [StringLength(32)]
        [DisplayName("黑痣胎记")]
        public string FreckleBirthmark { get; set; }

        /// <summary>
        /// 疤痕酒窝
        /// 1：疤痕；2：酒窝左；3：酒窝右；　有多个特征时用英文半角分号”;”分隔
        /// </summary>
        [StringLength(32)]
        [DisplayName("疤痕酒窝")]
        public string ScarDimple { get; set; }

        /// <summary>
        /// 其他特征
        /// 1：酒渣鼻（小）；2：酒渣鼻（大）；3：酒渣鼻（重）；
        /// 4：招风耳左；5：招风耳右；6：大耳朵左；7：大耳朵右；
        /// 8：粗糙皮肤；9：白癜风小；10：白癜风中；11：白癜风大；
        /// 有多个特征时用英文半角分号”;”分隔
        /// </summary>
        [StringLength(32)]
        [DisplayName("其他特征")]
        public string OtherFeature { get; set; }

        /// <summary>
        /// 图像列表 可以包含0个或者多个子图像对象
        /// </summary>
        [DisplayName("图像列表")]
        public SubImageInfoDtoList SubImageList { get; set; }

        /// <summary>
        /// 只为 AutoMapper 使用
        /// </summary>
        //[DisplayName("图像列表")]
        //public List<SubImageInfoDto> SubImageInfos { get; set; }

        /// <summary>
        /// 人脸特征值
        /// 非 1400 属性
        /// </summary>
        [DisplayName("特征值")]
        [NotMapped]
        public List<byte> Feature { get; set; }
    }
}
