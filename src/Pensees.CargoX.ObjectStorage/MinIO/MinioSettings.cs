using Pensees.CargoX.Configuration;
using Pensees.CargoX.Web;

namespace Pensees.CargoX.ObjectStorage.MinIO
{
    public class MinioSettings
    {
        private const string EndPointKey = "App:Endpoint";
        private const string AccessKeyKey = "App:AccessKey";
        private const string SecretKeyKey = "App:SecretKey";

        public static string EndPoint { get; set; }
        public static string AccessKey { get; set; }
        public static string SecretKey { get; set; }

        static MinioSettings()
        {
            // default playground
            EndPoint = "play.min.io";
            AccessKey = "Q3AM3UQ867SPQQA43P2F";
            SecretKey = "zuf+tfteSlswRu7BJ86wekitnifILbZam1KYY3TG";

            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            var endpoint = configuration.GetSection(EndPointKey);
            if (endpoint.Value != null)
            {
                EndPoint = endpoint.Value;
            }

            var accesskey = configuration.GetSection(AccessKeyKey);
            if (accesskey.Value != null)
            {
                AccessKey = accesskey.Value;
            }

            var secretkey = configuration.GetSection(SecretKeyKey);
            if (secretkey.Value != null)
            {
                SecretKey = secretkey.Value;
            }
        }
    }
}
