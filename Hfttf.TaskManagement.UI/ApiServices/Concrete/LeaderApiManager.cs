using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Models;
using Hfttf.TaskManagement.UI.Models.Leader;
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
    public class LeaderApiManager:ILeaderService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public LeaderApiManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddAsync(LeaderAdd model)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var jsonData = JsonConvert.SerializeObject(model);

                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var responseMessage = await httpClient.PostAsync("http://localhost:5000/api/TaskManagementApi/Leaders/", stringContent);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                await httpClient.DeleteAsync($"http://localhost:5000/api/TaskManagementApi/Leaders/{id}");

            }
        }

        public async Task UpdateAsync(LeaderUpdate model)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var jsonData = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                await httpClient.PutAsync("http://localhost:5000/api/TaskManagementApi/Leaders", stringContent);
            }
        }

        public async Task<List<LeaderResponse>> GetAllAsync()
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await httpClient.GetAsync("http://localhost:5000/api/TaskManagementApi/Leaders/GetList");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var veri = await responseMessage.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<BaseResponse<List<LeaderResponse>>>(veri);
                    List<LeaderResponse> leaderResponses = data.Data;
                    return leaderResponses;

                }
            }
            return null;
        }

        public async Task<LeaderResponse> GetByIdAsync(int id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await httpClient.GetAsync($"http://localhost:5000/api/TaskManagementApi/Leaders/GetById?Id={id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var leaderResponses = JsonConvert.DeserializeObject<BaseResponse<LeaderResponse>>(await responseMessage.Content.ReadAsStringAsync());
                    LeaderResponse leader = leaderResponses.Data;
                    return leader;
                }

            }
            return null;
        }

        public async Task<LeaderResponse> GetByIdWithProjectAndUser(int id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await httpClient.GetAsync($"http://localhost:5000/api/TaskManagementApi/Leaders/GetById?Id={id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var leaderResponses = JsonConvert.DeserializeObject<BaseResponse<LeaderResponse>>(await responseMessage.Content.ReadAsStringAsync());
                    LeaderResponse leader = leaderResponses.Data;
                    return leader;
                }

            }
            return null;
        }

        public async Task<LeaderResponse> GetByProjectIdandUserId(int projectId, string userId)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await httpClient.GetAsync($"http://localhost:5000/api/TaskManagementApi/Leaders/GetByProjectIdandUserId?Id={id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var leaderResponses = JsonConvert.DeserializeObject<BaseResponse<LeaderResponse>>(await responseMessage.Content.ReadAsStringAsync());
                    LeaderResponse leader = leaderResponses.Data;
                    return leader;
                }

            }
            return null;
        }

        public async Task<List<LeaderResponse>> GetListByProjectId(int id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await httpClient.GetAsync($"http://localhost:5000/api/TaskManagementApi/Leaders/GetListByUserId?Id={id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var veri = await responseMessage.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<BaseResponse<List<LeaderResponse>>>(veri);
                    List<LeaderResponse> leaderResponses = data.Data;
                    return leaderResponses;
                }
            }
            return null;
        }

        public async Task<List<LeaderResponse>> GetListByProjectIdandUserId(int projectId, string userId)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await httpClient.GetAsync($"http://localhost:5000/api/TaskManagementApi/Leaders/GetListByUserId?Id={id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var veri = await responseMessage.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<BaseResponse<List<LeaderResponse>>>(veri);
                    List<LeaderResponse> leaderResponses = data.Data;
                    return leaderResponses;
                }
            }
            return null;
        }

        public async Task<List<LeaderResponse>> GetListByUserId(string id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await httpClient.GetAsync($"http://localhost:5000/api/TaskManagementApi/Leaders/GetListByUserId?Id={id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var veri = await responseMessage.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<BaseResponse<List<LeaderResponse>>>(veri);
                    List<LeaderResponse> leaderResponses = data.Data;
                    return leaderResponses;
                }
            }
            return null;
        }


    }
}
