using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Models;
using Hfttf.TaskManagement.UI.Models.BankInformation;
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
    public class BankInformationApiManager:IBankInformationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BankInformationApiManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddAsync(BankInformationAdd model)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var jsonData = JsonConvert.SerializeObject(model);

                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var responseMessage = await httpClient.PostAsync("http://localhost:5000/api/TaskManagementApi/BankInformations/", stringContent);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                await httpClient.DeleteAsync($"http://localhost:5000/api/TaskManagementApi/BankInformations/{id}");

            }
        }

        public async Task UpdateAsync(BankInformationUpdate model)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var jsonData = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                await httpClient.PutAsync("http://localhost:5000/api/TaskManagementApi/BankInformations", stringContent);
            }
        }

        public async Task<List<BankInformationResponse>> GetAllAsync()
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await httpClient.GetAsync("http://localhost:5000/api/TaskManagementApi/BankInformations/GetList");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var veri = await responseMessage.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<BaseResponse<List<BankInformationResponse>>>(veri);
                    List<BankInformationResponse>  bankInformations = data.Data;
                    return bankInformations;

                }
            }
            return null;
        }

        public async Task<BankInformationResponse> GetByIdAsync(int id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await httpClient.GetAsync($"http://localhost:5000/api/TaskManagementApi/BankInformations/GetById?Id={id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var addressResponse = JsonConvert.DeserializeObject<BaseResponse<BankInformationResponse>>(await responseMessage.Content.ReadAsStringAsync());
                    BankInformationResponse address = addressResponse.Data;
                    return address;
                }

            }
            return null;
        }

        public async Task<List<BankInformationResponse>> GetListByUserId(string id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var responseMessage = await httpClient.GetAsync($"http://localhost:5000/api/TaskManagementApi/BankInformations/GetListByUserId?UserId={id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var veri = await responseMessage.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<BaseResponse<List<BankInformationResponse>>>(veri);
                    List<BankInformationResponse> bankInformations = data.Data;
                    return bankInformations;
                }
            }
            return null;
        }


    }
}
