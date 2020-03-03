using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace Pensees.CargoX.Entities
{
    public class Vehicle : Entity<long>
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
        public int InfoType { get; set; }
    }
}
