using Hfttf.TaskManagement.Core.MinIOInterface;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.BaseBucketName;
using Hfttf.TaskManagement.Service.Services.Projects.Commands;
using Hfttf.TaskManagement.Service.Services.Projects.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Projects.Responses;
using MediatR;
using Minio;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Projects.Handlers
{
    public class ProjectFileUploadHandler : BaseProjectHandler, IRequestHandler<ProjectFileUploadCommand, Response>
    {

        private readonly ICreateMinioClient _createMinioClient;
        public ProjectFileUploadHandler(IProjectRepository projectRepository, ICreateMinioClient createMinioClient) : base(projectRepository)
        {
            _createMinioClient = createMinioClient;
        }
        MinioClient MinioClient => _createMinioClient.CreateMinioClient();
        public async Task<Response> Handle(ProjectFileUploadCommand request, CancellationToken cancellationToken)
        {
            var project = _projectRepository.GetByIdAsync(request.ProjectId);
            if (project == null)
            {
                var unSuccesResult = Response.UnSuccess("Project Not Found", 404, true);
                return unSuccesResult;
            }

            string imageName = request.ProjectId + BucketNames.Profile + Path.GetExtension(request.FormFile.FileName);
            string contentType = request.FormFile.ContentType;
            string objectName = request.ProjectId + "/" + BucketNames.ProjectProfile + imageName;
            string deleteObject = request.ProjectId + "/" + BucketNames.ProjectProfile;

            MemoryStream stream = new MemoryStream();
            await request.FormFile.CopyToAsync(stream);
            stream.Position = 0;

            var listObjects = await MinioClient.ListObjectsAsync(BucketNames.ProjectBucket, deleteObject).ToList();
            foreach (var obj in listObjects)
            {
                await MinioClient.RemoveObjectAsync(BucketNames.ProjectBucket, obj.Key);
            }
            bool isFound = await MinioClient.BucketExistsAsync(BucketNames.ProjectBucket);
            if (!isFound)
            {
                await MinioClient.MakeBucketAsync(BucketNames.ProjectBucket);
            }
            await MinioClient.PutObjectAsync(BucketNames.ProjectBucket, objectName, stream, stream.Length, contentType);

            var response = new FileUploadResponse()
            {
                StatusCode = 200,
                Message = "File Has Successfully Added!"
            };
            return Response.Success(response, 200);

        }
    }
}
