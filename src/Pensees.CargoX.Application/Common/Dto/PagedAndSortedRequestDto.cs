using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace Pensees.CargoX.Common.Dto
{
    public class PagedAndSortedRequestDto : PagedAndSortedResultRequestDto
    {
        public Dictionary<string, Dictionary<string, string>> Parameters { get; set; }
        /// <summary>
        /// 是否需要图片
        /// </summary>
        public int ImageRequred { get; set; }
        public int FeatureRequred { get; set; }
        //11 人脸
        //14 场景
        public string ImageType { get; set; }

    }
}
