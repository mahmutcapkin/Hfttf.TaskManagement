using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Models;
using Hfttf.TaskManagement.UI.Models.UserAssignment;
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
    public class UserAssignmentApiManager:IUserAssignmentService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAssignmentApiManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddAsync(UserAssignmentAdd model)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var jsonData = JsonConvert.SerializeObject(model);

                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var responseMessage = await httpClient.PostAsync("http://localhost:5000/api/TaskManagementApi/UserAssignments/", stringContent);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                await httpClient.DeleteAsync($"http://localhost:5000/api/TaskManagementApi/UserAssignments/{id}");

            }
        }

        public async Task UpdateAsync(UserAssignmentUpdate model)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var jsonData = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                await httpClient.PutAsync("http://localhost:5000/api/TaskManagementApi/UserAssignments", stringContent);
            }
        }

        public async Task<List<UserAssignmentResponse>> GetAllAsync()
        {
            throw new NotImplementedException(); var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await httpClient.GetAsync("http://localhost:5000/api/TaskManagementApi/UserAssignments/GetList");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var veri = await responseMessage.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<BaseResponse<List<UserAssignmentResponse>>>(veri);
                    List<UserAssignmentResponse> userAssignmentResponses = data.Data;
                    return userAssignmentResponses;

                }
            }
            return null;
        }

        public async Task<UserAssignmentResponse> GetByIdAsync(int id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await httpClient.GetAsync($"http://localhost:5000/api/TaskManagementApi/UserAssignments/GetById?Id={id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var userAssignmentResponses = JsonConvert.DeserializeObject<BaseResponse<UserAssignmentResponse>>(await responseMessage.Content.ReadAsStringAsync());
                    UserAssignmentResponse assignmentResponse = userAssignmentResponses.Data;
                    return assignmentResponse;
                }

            }
            return null;
        }

        public async Task<List<UserAssignmentResponse>> GetListByUserId(string id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await httpClient.GetAsync($"http://localhost:5000/api/TaskManagementApi/UserAssignments/GetListByUserId?UserId={id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var veri = await responseMessage.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<BaseResponse<List<UserAssignmentResponse>>>(veri);
                    List<UserAssignmentResponse> userAssignmentResponses = data.Data;
                    return userAssignmentResponses;
                }
            }
            return null;
        }


    }
}
