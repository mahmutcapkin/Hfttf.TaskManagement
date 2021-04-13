﻿using Hfttf.TaskManagement.API.Domain.Responses;
using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.ResourceViewModel;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.API.Domain.Services
{
    public interface IUserService
    {

        Task<BaseResponse<UserViewResponse>> UpdateUser(UserViewResponse userViewResponse, string userName);


        Task<ApplicationUser> GetUserByUserName(string userName);

        Task<UserWithRolesResponse> ActiveUserInfo();

        //Task<BaseResponse<ApplicationUser>> UploadUserPicture(string picturePath, string userName);

        Task<Tuple<ApplicationUser, IList<Claim>>> GetUserByRefreshToken(string refreshToken);

        Task<bool> RevokeRefrefreshToken(string refreshToken);




    }
}