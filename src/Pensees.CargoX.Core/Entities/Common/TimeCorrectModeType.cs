using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pensees.CargoX.Entities
{
    public class TimeCorrectModeType
    {
        /// <summary>
        /// 校时模式
        /// 1 网络
        /// 2 手动
        /// </summary>
        [Required]
        [StringLength(20)]
        public string TypeValue { get; set; }
    }
}
