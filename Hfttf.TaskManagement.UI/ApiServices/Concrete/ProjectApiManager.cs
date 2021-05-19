using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Models;
using Hfttf.TaskManagement.UI.Models.Project;
using Hfttf.TaskManagement.UI.Models.User;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Concrete
{
    public class ProjectApiManager : IProjectService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProjectApiManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> AddAsync(ProjectAdd model)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var jsonData = JsonConvert.SerializeObject(model);

                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var responseMessage = await httpClient.PostAsync("http://localhost:5000/api/TaskManagementApi/Projects/Insert", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage =await httpClient.DeleteAsync($"http://localhost:5000/api/TaskManagementApi/Projects/Delete/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<bool> UpdateAsync(ProjectUpdate model)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var jsonData = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage=  await httpClient.PutAsync("http://localhost:5000/api/TaskManagementApi/Projects/Update", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<List<ProjectResponse>> GetAllAsync()
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await httpClient.GetAsync("http://localhost:5000/api/TaskManagementApi/Projects/GetList");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var veri = await responseMessage.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<BaseResponse<List<ProjectResponse>>>(veri);
                    List<ProjectResponse> projectResponses = data.Data;
                    return projectResponses;

                }
            }
            return null;
        }

        public async Task<ProjectResponse> GetByIdAsync(int id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await httpClient.GetAsync($"http://localhost:5000/api/TaskManagementApi/Projects/GetById?Id={id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var projectResponse = JsonConvert.DeserializeObject<BaseResponse<ProjectResponse>>(await responseMessage.Content.ReadAsStringAsync());
                    ProjectResponse project = projectResponse.Data;
                    return project;
                }

            }
            return null;
        }

        public async Task<List<ProjectResponse>> GetListByUserId(string id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await httpClient.GetAsync($"http://localhost:5000/api/TaskManagementApi/Projects/GetListByUserId?UserId={id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var veri = await responseMessage.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<BaseResponse<List<ProjectResponse>>>(veri);
                    List<ProjectResponse> projectResponses = data.Data;
                    return projectResponses;
                }
            }
            return null;
        }

        public async Task<List<ProjectResponse>> GetListWithTasksandUsers()
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await httpClient.GetAsync("http://localhost:5000/api/TaskManagementApi/Projects/GetListWithTasksandUsers");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var veri = await responseMessage.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<BaseResponse<List<ProjectResponse>>>(veri);
                    List<ProjectResponse> projectResponse = data.Data;
                    return projectResponse;

                }
            }
            return null;
        }

        public async Task<ProjectResponse> GetProjectWithUserandTaskById(int id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await httpClient.GetAsync($"http://localhost:5000/api/TaskManagementApi/Projects/GetProjectWithUserandTaskById?Id={id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var projectResponse = JsonConvert.DeserializeObject<BaseResponse<ProjectResponse>>(await responseMessage.Content.ReadAsStringAsync());
                    ProjectResponse project = projectResponse.Data;
                    return project;
                }

            }
            return null;
        }

        public async Task<bool> ProjectAddUser(ProjectAssignUser model)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var jsonData = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PutAsync("http://localhost:5000/api/TaskManagementApi/Projects/ProjectAddUser", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<bool> ProjectDeleteUser(ProjectAssignUser model)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var jsonData = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PutAsync("http://localhost:5000/api/TaskManagementApi/Projects/ProjectDeleteUser", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<List<UserDropdownList>> GetListForDropdown(int projectId)
        {
            List<UserDropdownList> list = new List<UserDropdownList>();
            var project = await GetProjectWithUserandTaskById(projectId);
            foreach (var user in project.ApplicationUsers)
            {
                UserDropdownList userDropdownList = new UserDropdownList();
                userDropdownList.UserId = user.Id;
                userDropdownList.FullName = user.FirstName + " " + user.LastName;
                list.Add(userDropdownList);
            }
            return list;
        }
    }
}
