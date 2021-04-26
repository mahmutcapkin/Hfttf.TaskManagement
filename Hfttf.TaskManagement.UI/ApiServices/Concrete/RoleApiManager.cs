using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Models;
using Hfttf.TaskManagement.UI.Models.Role;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Concrete
{
    public class RoleApiManager : IRoleService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RoleApiManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddAsync(RoleAdd model)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var jsonData = JsonConvert.SerializeObject(model);

                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var responseMessage = await httpClient.PostAsync("http://localhost:5000/api/TaskManagementApi/Roles/", stringContent);
            }
        }

        public async Task DeleteAsync(string id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                await httpClient.DeleteAsync($"http://localhost:5000/api/TaskManagementApi/Roles/{id}");

            }
        }

        public async Task UpdateAsync(RoleUpdate model)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var jsonData = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                await httpClient.PutAsync("http://localhost:5000/api/TaskManagementApi/Roles", stringContent);
            }
        }



        public async Task<List<RoleResponse>> GetAllAsync()
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await httpClient.GetAsync("http://localhost:5000/api/TaskManagementApi/Roles/GetList");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var veri = await responseMessage.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<BaseResponse<List<RoleResponse>>>(veri);
                    List<RoleResponse> roleResponses = data.Data;
                    return roleResponses;

                }
            }
            return null;
        }

        public async Task<RoleResponse> GetByIdAsync(string id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await httpClient.GetAsync($"http://localhost:5000/api/TaskManagementApi/Roles/GetById?Id={id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var roleResponses = JsonConvert.DeserializeObject<BaseResponse<RoleResponse>>(await responseMessage.Content.ReadAsStringAsync());
                    RoleResponse role = roleResponses.Data;
                    return role;
                }

            }
            return null;
        }

        public async Task AssignRoleToUser(string userId, List<string> roleId)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteRoleToUser(string userId, List<string> roleId)
        {
            throw new NotImplementedException();
        }


    }
}
