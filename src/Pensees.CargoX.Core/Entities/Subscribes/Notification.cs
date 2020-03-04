using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace Pensees.CargoX.Entities
{
    public class Notification : Entity<long>
    {
        /// <summary>
        /// 通知标识符 订阅的通知标识符
        /// </summary>
        [Required]
        [StringLength(33)]
        public string NotificationID { get; set; }

        /// <summary>
        /// 订阅标识符
        /// 该订阅标识符，数据共享接口调用时由VIID生成，级联接口调用时不可为空，取消订阅时必选
        /// </summary>
        [Required]
        [StringLength(33)]
        public string SubscribeID { get; set; }

        /// <summary>
        /// 订阅标题
        /// 描述订阅的主题和目标，订阅时必选
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string Title { get; set; }

        /// <summary>
        /// 触发时间  
        /// </summary>
        [Required]
        public DateTime TriggerTime { get; set; }

        /// <summary>
        /// 信息标识
        /// 订阅通知的详细信息(人、车、物、场景)标识集合
        /// </summary>
        [MaxLength(1024)]
        public string InfoIDs { get; set; }

        /// <summary>
        /// 视频案事件  视频案事件信息数据集
        /// </summary>
        [NotMapped]
        public List<Case> Cases { get; set; }

        /// <summary>
        /// 视频卡口	视频卡口信息数据集
        /// </summary>
        [NotMapped]
        public List<Tollgate> TollgateList { get; set; }

        /// <summary>
        /// 车道  车道信息数据集
        /// </summary>
        [NotMapped]
        public List<Lane> LaneList { get; set; }

        /// <summary>
        /// 设备  设备信息数据集
        /// </summary>
        [NotMapped]
        public List<Ape> DeviceList { get; set; }

        /// <summary>
        /// 设备状态  该通知针对批量订阅方式
        /// </summary>
        [NotMapped]
        public List<ApeStatus> DeviceStatusList { get; set; }

        /// <summary>
        /// 采集系统  设备网管信息数据集
        /// </summary>
        [NotMapped]
        public List<Aps> APSObjectList { get; set; }

        /// <summary>
        /// 采集系统状态  该通知针对批量订阅方式
        /// </summary>
        [NotMapped]
        public List<ApeStatus> APSStatusObjectList { get; set; }

        /// <summary>
        /// 人员信息  人员信息数据集
        /// </summary>
        [NotMapped]
        public List<Person> PersonObjectList { get; set; }

        /// <summary>
        /// 人脸信息  人脸信息数据集
        /// </summary>
        [NotMapped]
        public List<Face> FaceObjectList { get; set; }

        /// <summary>
        /// 机动车信息  机动车(过车)信息数据集
        /// </summary>
        [NotMapped]
        public List<Motor> MotorVehicleObjectList { get; set; }

        /// <summary>
        /// 非机动车信息  非机动车数据集
        /// </summary>
        [NotMapped]
        public List<NonMotor> NonMotorVehicleObjectList { get; set; }

        /// <summary>
        /// 物品信息
        /// </summary>
        [NotMapped]
        public List<Thing> ThingObjectList { get; set; }

        /// <summary>
        /// 场景信息
        /// </summary>
        [NotMapped]
        public List<Thing> SceneObjectList { get; set; }
    }
}
