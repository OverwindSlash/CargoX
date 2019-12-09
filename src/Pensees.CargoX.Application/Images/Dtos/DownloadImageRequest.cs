namespace Pensees.CargoX.Images.Dtos
{
    public class DownloadImageRequest
    {
        public string BucketName { get; set; }
        public string ImageName { get; set; }
        public string ImageType { get; set; }
    }
}