using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace Pensees.CargoX.Entities
{
    public class Case : Entity<long>
    {
        /// <summary>
        /// 案件信息
        /// </summary>
        [Required]
        [DisplayName("案件信息")]
        public CaseInfo CaseInfo { get; set; }


    }
}
