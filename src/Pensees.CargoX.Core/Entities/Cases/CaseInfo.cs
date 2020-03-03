using System;
using Abp.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pensees.CargoX.Entities
{
    [DisplayName("视频案件事件对象")]
    public class CaseInfo : Entity<long>
    {
        /// <summary>
        /// 案事件标识
        /// CaseObjectIdType::string(30)
        /// GA/T 1400.1《公安视频图像信息应用系统 第1部分：通用技术要求》，案(事)件管理对象ID 
        /// </summary>
        [Required]
        [StringLength(30)]
        [DisplayName("案事件标识")]
        public string CaseID { get; set; }

        /// <summary>
        /// 案件关联标识
        /// CaseLinkMarkType::string(23) 案件编号
        /// </summary>
        [DisplayName("案件关联标识")]
        [StringLength(23)]
        public string CaseLinkMark { get; set; }

        /// <summary>
        /// 案件名称
        /// CaseNameType::string(0...120) 
        /// </summary>
        [Required]
        [MaxLength(120)]
        [DisplayName("案件名称")]
        public string CaseName { get; set; }

        /// <summary>
        /// 简要案情
        /// 案(事)件主要信息描述，表示案件的简要说明
        /// CaseAbstractType::string(0...4000)
        /// </summary>
        [Required]
        [MaxLength(4000)]
        [DisplayName("简要案情")]
        public string CaseAbstract { get; set; }

        /// <summary>
        /// 线索标识
        /// 视频标识或者图像标识列表，有多个时用英文半角分号”;”分隔
        /// </summary>
        [Required]
        [MaxLength(1024)]
        [DisplayName("线索标识")]
        public string ClueID { get; set; }

        /// <summary>
        /// 事发时间上限
        /// </summary>
        [Required]
        [DisplayName("事发时间上限")]
        public DateTime TimeUpLimit { get; set; }

        /// <summary>
        /// 事发时间下限
        /// </summary>
        [DisplayName("事发时间下限")]
        public DateTime TimeLowLimit { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 事发地点行政区划代码
        /// PlaceCodeType::string(6)::GB/T 2260，行政区划、籍贯省市县代码
        /// </summary>
        [Required]
        [DisplayName("事发地点行政区划代码")]
        [StringLength(6)]
        public string PlaceCode { get; set; }

        /// <summary>
        /// 事发地点区划内详细地址
        /// PlaceFullAddressType::string(0...100)
        /// GA/T 543.1，具体到摄像机位置或街道门牌号，由DE00072(乡镇街道)+ DE00074(街路巷)+ DE00080(门楼牌号)+ DE00081(门楼详细地址)构成
        /// </summary>
        [Required]
        [DisplayName("事发地点区划内详细地址")]
        [MaxLength(100)]
        public string PlaceFullAddress { get; set; }

        /// <summary>
        /// 可疑人数量
        /// </summary>
        [DisplayName("可疑人数量")]
        public int SuspectNumber { get; set; }

        /// <summary>
        /// 发现人标识符
        /// 列表形式，多个时以”;”间隔。发现人的人员标识
        /// </summary>
        [DisplayName("发现人标识符")]
        [MaxLength(1024)]
        public string WitnessIDs { get; set; }
        
        /// <summary>
        /// 创建人姓名
        /// NameType::string(0..50)
        /// </summary>
        [DisplayName("创建人姓名")]
        [MaxLength(50)]
        public string CreatorName { get; set; }

        /// <summary>
        /// 创建人证件类型
        /// IDType::string(3)::GAT 517，常用证件代码
        /// 案件入库时创建人的有效证件类型
        /// </summary>
        [DisplayName("创建人证件类型")]
        [StringLength(3)]
        public string CreatorIDType { get; set; }

        /// <summary>
        /// 创建人证件号码
        /// IdNumberType::string(0..30)::证件号码
        /// 案件入库时创建人的有效证件号码
        /// </summary>
        [DisplayName("创建人证件号码")]
        [StringLength(30)]
        public string CreatorID { get; set; }

        /// <summary>
        /// 创建人单位名称
        /// 案件入库时创建人的所在单位名称
        /// OrgType::string(0..100)
        /// </summary>
        [DisplayName("创建人单位名称")]
        [MaxLength(100)]
        public string CreatorOrg { get; set; }

        /// <summary>
        /// 事发地经度
        /// LongitudeType::double
        /// </summary>
        [DisplayName("事发地经度")]
        public double Longitude { get; set; }

        /// <summary>
        /// 事发地纬度
        /// LatitudeType::double
        /// </summary>
        [DisplayName("事发地纬度")]
        public double Latitude { get; set; }

        /// <summary>
        /// 机动车标识符  列表形式，多个时以”;”间隔
        /// </summary>
        [DisplayName("机动车标识符")]
        [MaxLength(1024)]
        public string MotorVehicleIDs { get; set; }

        /// <summary>
        /// 非机动车标识符  列表形式，多个时以”;”间隔
        /// </summary>
        [DisplayName("非机动车标识符")]
        [MaxLength(1024)]
        public string NonMotorVehicleIDs { get; set; }

        /// <summary>
        /// 人员标识符  列表形式，多个时以”;”间隔
        /// </summary>
        [DisplayName("人员标识符")]
        [MaxLength(1024)]
        public string PersonIDs { get; set; }

        /// <summary>
        /// 人脸标识符  列表形式，多个时以”;”间隔
        /// </summary>
        [DisplayName("人脸标识符")]
        [MaxLength(1024)]
        public string FaceIDs { get; set; }

        /// <summary>
        /// 物品标识符  列表形式，多个时以”;”间隔
        /// </summary>
        [DisplayName("物品标识符")]
        [MaxLength(1024)]
        public string ThingIDs { get; set; }

        /// <summary>
        /// 文件标识符  列表形式，多个时以”;”间隔
        /// </summary>
        [DisplayName("文件标识符")]
        [MaxLength(1024)]
        public string FileIDs { get; set; }

        /// <summary>
        /// 场景标识符  列表形式，多个时以”;”间隔
        /// </summary>
        [DisplayName("场景标识符")]
        [MaxLength(1024)]
        public string SceneIDs { get; set; }

        /// <summary>
        /// 相关案件标识  列表形式，多个时以”;”间隔
        /// </summary>
        [DisplayName("相关案件标识")]
        [MaxLength(1024)]
        public string RelateCaseIdList { get; set; }

        /// <summary>
        /// 父案件标识  被归并后指向父案件
        /// CaseObjectIdType::string(30)
        /// GA/T 1400.1《公安视频图像信息应用系统 第1部分：通用技术要求》，案(事)件管理对象ID 
        /// </summary>
        [DisplayName("父案件标识")]
        [StringLength(30)]
        public string ParentCaseId { get; set; }

        /// <summary>
        /// 案件状态
        /// 0:事件，1：已立案，2：已侦破，3：侦破待复核，4：已结案，5：结案待复核，6：并案待复核、7：撤案待复核，8：结案归档，9：并案归档，10：撤案归档
        /// </summary>
        [Required]
        [DisplayName("案件状态")]
        public int State { get; set; }
    }
}
