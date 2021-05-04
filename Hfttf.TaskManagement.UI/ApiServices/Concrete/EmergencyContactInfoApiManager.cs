using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Models;
using Hfttf.TaskManagement.UI.Models.EmergencyContactInfo;
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
    public class EmergencyContactInfoApiManager:IEmergencyContactInfoService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmergencyContactInfoApiManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddAsync(EmergencyContactInfoAdd model)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var jsonData = JsonConvert.SerializeObject(model);

                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var responseMessage = await httpClient.PostAsync("http://localhost:5000/api/TaskManagementApi/EmergencyContactInfos/Insert", stringContent);
            }
        }
        public async Task UpdateAsync(EmergencyContactInfoUpdate model)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var jsonData = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PutAsync("http://localhost:5000/api/TaskManagementApi/EmergencyContactInfos/Update", stringContent);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

               var responseMessage= await httpClient.DeleteAsync($"http://localhost:5000/api/TaskManagementApi/EmergencyContactInfos/Delete/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            return false;
        }



        public async Task<List<EmergencyContactInfoResponse>> GetAllAsync()
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await httpClient.GetAsync("http://localhost:5000/api/TaskManagementApi/EmergencyContactInfos/GetList");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var veri = await responseMessage.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<BaseResponse<List<EmergencyContactInfoResponse>>>(veri);
                    List<EmergencyContactInfoResponse> emergencyContactInfoResponse = data.Data;
                    return emergencyContactInfoResponse;

                }
            }
            return null;
        }

        public async Task<EmergencyContactInfoResponse> GetByIdAsync(int id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await httpClient.GetAsync($"http://localhost:5000/api/TaskManagementApi/EmergencyContactInfos/GetById?Id={id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var emergencyContactInfoResponse = JsonConvert.DeserializeObject<BaseResponse<EmergencyContactInfoResponse>>(await responseMessage.Content.ReadAsStringAsync());
                    EmergencyContactInfoResponse emergencyContactInfos = emergencyContactInfoResponse.Data;
                    return emergencyContactInfos;
                }

            }
            return null;
        }

        public async Task<List<EmergencyContactInfoResponse>> GetListByUserId(string id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await httpClient.GetAsync($"http://localhost:5000/api/TaskManagementApi/EmergencyContactInfos/GetListByUserId?UserId={id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var veri = await responseMessage.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<BaseResponse<List<EmergencyContactInfoResponse>>>(veri);
                    List<EmergencyContactInfoResponse> emergencyContactInfos = data.Data;
                    return emergencyContactInfos;
                }
            }
            return null;
        }


    }
}
