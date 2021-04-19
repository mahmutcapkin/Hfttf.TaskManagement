﻿using Hfttf.TaskManagement.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Users.Queries
{
   public class UserDetailQuery:IRequest<Response>
    {
        public string Id { get; set; }

    }
}
