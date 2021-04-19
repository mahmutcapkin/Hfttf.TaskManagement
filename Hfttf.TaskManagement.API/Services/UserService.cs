using Hfttf.TaskManagement.API.Domain.Responses;
using Hfttf.TaskManagement.API.Domain.Services;
using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.ResourceViewModel;
using Mapster;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.API.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager) : base(userManager, signInManager, roleManager)
        {
        }

        public async Task<Tuple<ApplicationUser, IList<Claim>>> GetUserByRefreshToken(string refreshToken)
        {
            Claim claimRefreshToken = new Claim("refreshToken", refreshToken);


            var users = await userManager.GetUsersForClaimAsync(claimRefreshToken);


            if (users.Any())
            {
                var user = users.First();

                IList<Claim> userClaims = await userManager.GetClaimsAsync(user);

                string refreshTokenEndDate = userClaims.First(c => c.Type == "refreshTokenEndDate").Value;

                if (DateTime.Parse(refreshTokenEndDate) > DateTime.Now)
                {

                    return new Tuple<ApplicationUser, IList<Claim>>(user, userClaims);
                }
                else
                {
                    return new Tuple<ApplicationUser, IList<Claim>>(null, null);
                }

            }

            return new Tuple<ApplicationUser, IList<Claim>>(null, null);

        }

        public async Task<ApplicationUser> GetUserByUserName(string userName)
        {

            return await userManager.FindByNameAsync(userName);

        }

        public async Task<UserWithRolesResponse> ActiveUserInfo(string userName)
        {
            ApplicationUser user = await GetUserByUserName(userName);
            var roles = await userManager.GetRolesAsync(user);
            UserWithRolesResponse userWithRolesResponse = new UserWithRolesResponse();
            userWithRolesResponse.Id = user.Id;
            userWithRolesResponse.Email = user.Email;
            userWithRolesResponse.FirstName = user.FirstName;
            userWithRolesResponse.LastName = user.LastName;
            userWithRolesResponse.PhoneNumber = user.PhoneNumber;
            userWithRolesResponse.UserName = user.UserName;
            userWithRolesResponse.Gender = user.Gender;
            userWithRolesResponse.BirthDate = user.BirthDate;
            userWithRolesResponse.Roles = roles.ToList();

            return userWithRolesResponse;

        }

        public async Task<bool> RevokeRefrefreshToken(string refreshToken)
        {

            var result = await GetUserByRefreshToken(refreshToken);

            if (result.Item1 == null) return false;

            IdentityResult response = await userManager.RemoveClaimsAsync(result.Item1, result.Item2);

            if (response.Succeeded)
            {
                return true;
            }

            return false;

        }

        public async Task<BaseResponse<UserViewResponse>> UpdateUser(UserViewResponse userViewModel, string userName)
        {

            ApplicationUser user = await userManager.FindByNameAsync(userName);

            if ((userManager.Users.Count(u => u.PhoneNumber == userViewModel.PhoneNumber) > 1))
            {
                return new BaseResponse<UserViewResponse>("Bu telefon numarası başka bir üyeye ait");

            }

            user.FirstName = userViewModel.FirstName;
            user.LastName = userViewModel.LastName;
            user.BirthDate = userViewModel.BirthDate;
            user.DepartmentId = userViewModel.DepartmentId;
            user.JobId = userViewModel.JobId;
            user.Gender = userViewModel.Gender;
            user.Email = userViewModel.Email;
            user.UserName = userViewModel.UserName;
            user.PhoneNumber = userViewModel.PhoneNumber;
            

            IdentityResult result = await userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return new BaseResponse<UserViewResponse>(user.Adapt<UserViewResponse>());
            }
            else
            {
                return new BaseResponse<UserViewResponse>(result.Errors.First().Description);

            }
        }

        //public async Task<BaseResponse<ApplicationUser>> UploadUserPicture(string picturePath, string userName)
        //{

        //    ApplicationUser user = await userManager.FindByNameAsync(userName);

        //    user.Picture = picturePath;
        //    IdentityResult result = await userManager.UpdateAsync(user);


        //    if (result.Succeeded)
        //    {
        //        return new BaseResponse<ApplicationUser>(user);
        //    }
        //    else
        //    {
        //        return new BaseResponse<ApplicationUser>(result.Errors.First().Description);
        //    }

        //}
    }
}
