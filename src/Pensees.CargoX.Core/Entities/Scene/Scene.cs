using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Domain.Entities;

namespace Pensees.CargoX.Entities
{
    public class Scene : Entity<long>
    {
        /// <summary>
        /// 场景标识
        /// ImageCntObjectIdType::string(48)
        /// GA/T 1400.1 图像信息内容要素 ID，人、人脸、机动车、非机动车、物品、场景等
        /// </summary>
        [Required]
        [StringLength(48)]
        [DisplayName("场景标识")]
        public string SceneID { get; set; }

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
        /// 出现时间
        /// </summary>
        [DisplayName("出现时间")]
        public DateTime BeginTime { get; set; }

        /// <summary>
        /// 选择处所代码
        /// PlaceType::string(4)
        /// GA 240.5，选择处所代码
        /// </summary>
        [StringLength(4)]
        [DisplayName("选择处所代码")]
        public string PlaceType { get; set; }

        /// <summary>
        /// 天气情况分类
        /// WeatherType::string(2)
        /// GA 240.5，天气情况分类
        /// </summary>
        [StringLength(2)]
        [DisplayName("天气情况分类")]
        public string WeatherType { get; set; }

        /// <summary>
        /// 场景描述  对场景特征的文字描述
        /// </summary>
        [StringLength(256)]
        [DisplayName("场景描述")]
        public string SceneDescribe { get; set; }

        /// <summary>
        /// 道路类型代码
        /// SceneType::string(2)
        /// GA/T 16.79，道路类型代码
        /// </summary>
        [StringLength(2)]
        [DisplayName("道路类型代码")]
        public string SceneType { get; set; }

        /// <summary>
        /// 道路线形代码
        /// RoadAlignmentType::string(2)
        /// GA/T 16.81，道路线形代码
        /// </summary>
        [StringLength(2)]
        [DisplayName("道路线形代码")]
        public string RoadAlignmentType { get; set; }

        /// <summary>
        /// 道路地形分类 
        /// </summary>
        [DisplayName("道路地形分类")]
        public int RoadTerraintype { get; set; }

        /// <summary>
        /// 道路路面类型代码
        /// RoadSurfaceType::string(1)
        /// GA/T 16.82，道路路面类型代码
        /// </summary>
        [StringLength(1)]
        [DisplayName("道路路面类型代码")]
        public string RoadSurfaceType { get; set; }

        /// <summary>
        /// 道路路面状况代码
        /// RoadCoditionType::string(1)
        /// GA/T 16.77，道路路面状况代码
        /// </summary>
        [StringLength(1)]
        [DisplayName("道路路面状况代码")]
        public string RoadCoditionType { get; set; }

        /// <summary>
        /// 道路路口路段类型代码
        /// RoadJunctionSectionType::string(2)
        /// GA/T 16.83，道路路口路段类型代码
        /// </summary>
        [StringLength(2)]
        [DisplayName("道路路口路段类型代码")]
        public string RoadJunctionSectionType { get; set; }

        /// <summary>
        /// 道路路面状况代码
        /// RoadLightingType::string(1)
        /// GA/T 16.76，道路照明条件代码
        /// </summary>
        [StringLength(1)]
        [DisplayName("道路路面状况代码")]
        public string RoadLightingType { get; set; }

        /// <summary>
        /// 现场图示
        /// IllustrationType::string(2)
        /// </summary>
        [StringLength(2)]
        [DisplayName("现场图示")]
        public string Illustration { get; set; }

        /// <summary>
        /// 现场风向
        /// WindDirectionType::string(2)
        /// GA/T 693.2，现场风向代码
        /// </summary>
        [StringLength(2)]
        [DisplayName("现场风向")]
        public string WindDirection { get; set; }

        /// <summary>
        /// 现场光线
        /// IlluminationType::string
        /// </summary>
        [DisplayName("现场光线")]
        public string Illumination { get; set; }

        /// <summary>
        /// 现场条件
        /// FieldConditionType::string
        /// </summary>
        [DisplayName("现场条件")]
        public string FieldCondition { get; set; }

        /// <summary>
        /// 现场温度
        /// 单位为摄氏度（℃）
        /// </summary>
        [DisplayName("现场温度")]
        public double Temperature { get; set; }

        /// <summary>
        /// 现场湿度
        /// HumidityType::string
        /// </summary>
        [DisplayName("现场湿度")]
        public string Humidity { get; set; }

        /// <summary>
        /// 人群聚集程度
        /// DenseDegreeType::string
        /// </summary>
        [DisplayName("人群聚集程度")]
        public string PopulationDensity { get; set; }

        /// <summary>
        /// 物品密度
        /// DenseDegreeType::string
        /// </summary>
        [DisplayName("物品密度")]
        public string DenseDegree { get; set; }

        /// <summary>
        /// 场景重要程度
        /// 取值为1～5，数值越大表示越重要
        /// </summary>
        [DisplayName("场景重要程度")]
        public int Importance { get; set; }

        /// <summary>
        /// 图像列表 可以包含0个或者多个子图像对象
        /// </summary>
        [DisplayName("图像列表")]
        public List<SubImageInfo> SubImageInfos { get; set; }
    }
}

