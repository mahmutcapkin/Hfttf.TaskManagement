using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Infrastructure.Data.EntityFrameworkCore;
using Hfttf.TaskManagement.Infrastructure.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Infrastructure.Repositories.EntityFrameworkCoreRepositories
{
    public class ProjectRepositoryEf : Repository<Project>, IProjectRepository
    {
        public ProjectRepositoryEf(TaskManagementContext taskManagementContext) : base(taskManagementContext)
        {
        }

        public async Task<IReadOnlyList<Project>> GetListByUserId(string userId)
        {
            //var projects = await _taskManagementContext.Projects.Include(x => x.Leaders).ThenInclude(x => x.User).Include(x => x.ProjectTeams).ThenInclude(x => x.User).Include(x => x.Tasks).ToListAsync();
            //var newProjects = new List<Project>();
            //foreach (var project in projects)
            //{
            //    if (project.ProjectTeams.Any(x => x.UserId == userId) || project.Leaders.Any(x => x.UserId == userId))
            //    {
            //        newProjects.Add(project);
            //    }
            //}
            //return newProjects;
            return null;
        }

        public async Task<IReadOnlyList<Project>> GetListPaginationByUserId(string userId, int pageNumber, int pageSize)
        {
            //var projects = await _taskManagementContext.Projects.Include(x => x.Leaders.Where(x => x.UserId == userId)).ThenInclude(x => x.User).Include(x => x.ProjectTeams.Where(x => x.UserId == userId)).ThenInclude(x => x.User).Include(x => x.Tasks).ToListAsync();
            //var newProjects = new List<Project>();
            //foreach (var project in projects)
            //{
            //    if (project.ProjectTeams.Any(x => x.UserId == userId) || project.Leaders.Any(x => x.UserId == userId))
            //    {
            //        newProjects.Add(project);
            //    }
            //}
            //var pagedData = newProjects.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            //return pagedData;
            return null;
        }

        public async Task<IReadOnlyList<Project>> GetProjectDetailById(int id)
        {
            //var projects = await _taskManagementContext.Projects.Where(x => x.Id == id).Include(x => x.Leaders).ThenInclude(x => x.User).Include(x => x.ProjectTeams).ThenInclude(x => x.User).Include(x => x.Tasks).ToListAsync();
            //return projects;
            return null;
        }
    }
}
