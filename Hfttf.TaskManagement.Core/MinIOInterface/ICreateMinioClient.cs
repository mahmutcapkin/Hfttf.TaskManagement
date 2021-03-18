using Minio;

namespace Hfttf.TaskManagement.Core.MinIOInterface
{
    public interface ICreateMinioClient
    {
        public MinioClient CreateMinioClient();
    }
}
