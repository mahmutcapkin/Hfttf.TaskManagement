using Hfttf.TaskManagement.Core.MinIOInterface;
using Microsoft.Extensions.Configuration;
using Minio;

namespace Hfttf.TaskManagement.Infrastructure.MinIO
{
    public class CreateMinioClient : ICreateMinioClient
    {
        public IConfiguration Configuration { get; }

        public CreateMinioClient(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        MinioClient ICreateMinioClient.CreateMinioClient()
        {
            // Minio Connection 
            var endPoint = Configuration["Minio:Endpoint"];
            var accessKey = Configuration["Minio:AccessKey"];
            var secretKey = Configuration["Minio:SecretKey"];
            MinioClient minioClient = new MinioClient(endPoint, accessKey, secretKey);
            return minioClient;
        }
    }
}
