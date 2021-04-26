﻿using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Models.Job;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Concrete
{
    public class JobApiManager:IJobService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public JobApiManager( IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddAsync(JobAdd model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<JobForUserResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<JobForUserResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<JobForUserResponse> GetJobWithUsersById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<JobForUserResponse>> GetListWithUsers()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(JobUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
