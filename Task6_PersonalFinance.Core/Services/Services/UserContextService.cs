﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Task6_PersonalFinance.Core.Services.Interfaces;

namespace Task6_PersonalFinance.Core.Services.Services
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;

        public int? GetUserId => User != null ? int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value) : null;
    }
}
