using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Users.Commands;
using Hfttf.TaskManagement.Service.Services.Users.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Users.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Users.Handlers
{
    public class UserUpdateHandler : BaseUserHandler, IRequestHandler<UserUpdateCommand, Response>
    {
        public UserUpdateHandler(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IUserRepository userRepository) : base(userManager, roleManager, userRepository)
        {
        }

        public async Task<Response> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {

            //var response = await _userManager.UpdateAsync(user);
            //var userResponse = TaskManagementMapper.Mapper.Map<UserResponse>(response);
            //var result = Response.Success(userResponse, 200);
            //return result;

            //ApplicationUser user = await _userManager.FindByIdAsync(request.Id);
                
            //var userModel = TaskManagementMapper.Mapper.Map<ApplicationUser>(request);

            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
            {
                return Response.UnSuccess("Böyle bir kullanıcı mevcut değildir", 400, true);
            }
            var userFake = await _userManager.Users.Where(x => x.PhoneNumber == request.PhoneNumber).FirstOrDefaultAsync();
            if (userFake != null)
            {
                if (user.Id == userFake.Id)
                {
                    user.PhoneNumber = request.PhoneNumber;
                }
                else
                {
                    return Response.UnSuccess("Bu telefon numarası başka bir üyeye aittir", 400, true);
                }
            }
            else
            {
                    user.PhoneNumber = request.PhoneNumber;
            }
          
            var userFake2 = await _userManager.Users.Where(x => x.UserName == request.UserName).FirstOrDefaultAsync();
            if (userFake2 != null)
            {
                if (user.Id == userFake2.Id)
                {
                    user.UserName = request.UserName;
                }
                else
                {
                    return Response.UnSuccess("Bu kullanıcı adı başka bir üyeye aittir", 400, true);
                }
            }
            else
            {
                    user.UserName = request.UserName;
            }
                     
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.BirthDate = request.BirthDate;
            user.Gender = request.Gender;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;
            if (request.JobId != 0)
            {
                user.JobId = request.JobId;
            }

            if (request.DepartmentId != 0)
            {
                user.DepartmentId = request.DepartmentId;
            }

            if(request.DepartmentId!=0 && request.JobId != 0)
            {
                user.JobId = request.JobId;
                user.DepartmentId = request.DepartmentId;
            }else
            {
              
            }
            IdentityResult result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                var userResponse = TaskManagementMapper.Mapper.Map<UserResponse>(user);
                var response = Response.Success(userResponse, 200);
                return response;
            }
            else
            {
                return Response.UnSuccess("Kullanıcı güncellenemedi", 400, true);
            }

            //var user = await _userManager.FindByIdAsync(request.Id);
            //if (user == null)
            //{
            //    var unSuccesResponse = Response.UnSuccess("User Not Found", 400, false);
            //    return unSuccesResponse;
            //}

            //user.PhoneNumber = request.PhoneNumber;
            //user.FirstName = request.FirstName;
            //user.LastName = request.LastName;
            //user.BirthDate = request.BirthDate;
            //user.Gender = request.Gender;
            //user.DepartmentId = request.DepartmentId;
            //user.JobId = request.JobId;
            //try
            //{
            //    var response = await _userManager.UpdateAsync(user);
            //    var result = Response.Success(response, 200);
            //    return result;
            //}
            //catch (Exception e)
            //{
            //    var enErrorResponse = Response.UnSuccess(e.Message, 400, false);
            //    return enErrorResponse;
            //}

        }
    }
}
