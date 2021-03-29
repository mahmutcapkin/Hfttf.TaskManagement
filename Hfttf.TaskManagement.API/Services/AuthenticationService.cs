using Hfttf.TaskManagement.API.Domain.Responses;
using Hfttf.TaskManagement.API.Domain.Services;
using Hfttf.TaskManagement.API.Security.Token;
using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.ResourceViewModel;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.API.Services
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        private readonly ITokenHandler tokenHandler;
        private readonly CustomTokenOptions tokenOptions;
        private readonly IUserService userService;



        public AuthenticationService(IUserService userService, ITokenHandler tokenHandler, IOptions<CustomTokenOptions> tokenOptions, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager) : base(userManager, signInManager, roleManager)
        {
            this.tokenHandler = tokenHandler;
            this.userService = userService;
            this.tokenOptions = tokenOptions.Value;

        }

        public async Task<BaseResponse<AccessToken>> CreateAccessTokenByRefreshToken(RefreshTokenViewModelResource refreshTokenViewModel)
        {

            var userClaim = await userService.GetUserByRefreshToken(refreshTokenViewModel.RefreshToken);

            if (userClaim.Item1 != null)
            {
                AccessToken accessToken = await tokenHandler.CreateAccessToken(userClaim.Item1);

                Claim refreshTokenClaim = new Claim("refreshToken", accessToken.RefreshToken);
                Claim refreshTokenEndDateClaim = new Claim("refreshTokenEndDate", DateTime.Now.AddMinutes(tokenOptions.RefreshTokenExpiration).ToString());

                await userManager.ReplaceClaimAsync(userClaim.Item1, userClaim.Item2[0], refreshTokenClaim);
                await userManager.ReplaceClaimAsync(userClaim.Item1, userClaim.Item2[1], refreshTokenEndDateClaim);

                return new BaseResponse<AccessToken>(accessToken);

            }
            else
            {
                return new BaseResponse<AccessToken>("Böyle bir refreshtoken sahip kullanıcı yok");
            }

        }

        public async Task<BaseResponse<AccessToken>> RevokeRefreshToken(RefreshTokenViewModelResource refreshTokenViewModel)
        {
            bool result = await userService.RevokeRefrefreshToken(refreshTokenViewModel.RefreshToken);

            if (result)
            {

                return new BaseResponse<AccessToken>(new AccessToken());
            }
            else
            {
                return new BaseResponse<AccessToken>("refreshtoken veritabanında bulunamadı");
            }

        }

        public async Task<BaseResponse<AccessToken>> SignIn(SignInViewModelResource signInViewModel)
        {

            ApplicationUser user = await userManager.FindByEmailAsync(signInViewModel.Email);

            if (user != null)
            {
                bool isUser = await userManager.CheckPasswordAsync(user, signInViewModel.Password);


                if (isUser)
                {
                    AccessToken accessToken =await tokenHandler.CreateAccessToken(user);


                    Claim refreshTokenClaim = new Claim("refreshToken", accessToken.RefreshToken);
                    Claim refreshTokenEndDateClaim = new Claim("refreshTokenEndDate", DateTime.Now.AddMinutes(tokenOptions.RefreshTokenExpiration).ToString());


                    List<Claim> refreshClaimList = userManager.GetClaimsAsync(user).Result.Where(c => c.Type.Contains("refreshToken")).ToList();


                    if (refreshClaimList.Any())
                    {
                        await userManager.ReplaceClaimAsync(user, refreshClaimList[0], refreshTokenClaim);
                        await userManager.ReplaceClaimAsync(user, refreshClaimList[1], refreshTokenEndDateClaim);

                    }
                    else
                    {
                        await userManager.AddClaimsAsync(user, new[] { refreshTokenClaim, refreshTokenEndDateClaim });
                    }

                    return new BaseResponse<AccessToken>(accessToken);

                }

                return new BaseResponse<AccessToken>("şifre yanlış");
            }
            return new BaseResponse<AccessToken>("email yanlış");

        }

        public async Task<BaseResponse<SignUpViewModelResource>> SignUp(SignUpViewModelResource userViewModel)
        {
            var userExist = await userManager.FindByNameAsync(userViewModel.UserName);
            if(userExist!=null)
            {
                return new BaseResponse<SignUpViewModelResource>("Böyle bir kullanıcı mevcuttur");
            }
            ApplicationUser user = new ApplicationUser 
            { 
                UserName = userViewModel.UserName, 
                Email = userViewModel.Email,
            };

            IdentityResult result = await this.userManager.CreateAsync(user,userViewModel.Password);         

            if (result.Succeeded)
            {
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new ApplicationRole { Name = UserRoles.Admin });

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new ApplicationRole { Name = UserRoles.User });

                if (await roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await userManager.AddToRolesAsync(user, new List<string>() { UserRoles.User });
                }

                return new BaseResponse<SignUpViewModelResource>(user.Adapt<SignUpViewModelResource>());
            }
            else
            {
                return new BaseResponse<SignUpViewModelResource>(result.Errors.First().Description);
            }

        }
    }
}
