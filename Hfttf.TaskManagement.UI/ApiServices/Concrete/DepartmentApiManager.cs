using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Models;
using Hfttf.TaskManagement.UI.Models.Department;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Concrete
{
    public class DepartmentApiManager:IDepartmentService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DepartmentApiManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddAsync(DepartmentAdd model)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var jsonData = JsonConvert.SerializeObject(model);

                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var responseMessage = await httpClient.PostAsync("http://localhost:5000/api/TaskManagementApi/Departments/", stringContent);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                await httpClient.DeleteAsync($"http://localhost:5000/api/TaskManagementApi/Departments/{id}");

            }
        }

        public async Task UpdateAsync(DepartmentUpdate model)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var jsonData = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                await httpClient.PutAsync("http://localhost:5000/api/TaskManagementApi/Departments", stringContent);
            }
        }

        public async Task<List<DepartmentResponse>> GetAllAsync()
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await httpClient.GetAsync("http://localhost:5000/api/TaskManagementApi/Departments/GetList");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var veri = await responseMessage.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<BaseResponse<List<DepartmentResponse>>>(veri);
                    List<DepartmentResponse> departmentResponses = data.Data;
                    return departmentResponses;

                }
            }
            return null;
        }

        public async Task<DepartmentResponse> GetByIdAsync(int id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await httpClient.GetAsync($"http://localhost:5000/api/TaskManagementApi/Departments/GetById?Id={id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var departmentResponse = JsonConvert.DeserializeObject<BaseResponse<DepartmentResponse>>(await responseMessage.Content.ReadAsStringAsync());
                    DepartmentResponse address = departmentResponse.Data;
                    return address;
                }

            }
            return null;
        }

        public async Task<DepartmentResponse> GetDepartmentWithUsersById(int id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await httpClient.GetAsync($"http://localhost:5000/api/TaskManagementApi/Departments/GetById?Id={id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var departmentResponse = JsonConvert.DeserializeObject<BaseResponse<DepartmentResponse>>(await responseMessage.Content.ReadAsStringAsync());
                    DepartmentResponse address = departmentResponse.Data;
                    return address;
                }

            }
            return null;
        }

        public async Task<List<DepartmentResponse>> GetListWithUsers()
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await httpClient.GetAsync("http://localhost:5000/api/TaskManagementApi/Departments/GetListWithUsers");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var veri = await responseMessage.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<BaseResponse<List<DepartmentResponse>>>(veri);
                    List<DepartmentResponse> departmentResponses = data.Data;
                    return departmentResponses;

                }
            }
            return null;
        }


    }
}
