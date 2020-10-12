﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Permission
{
    public class ViewRequirement : IAuthorizationRequirement
    {
    }

    public class ViewRequirementHandler : AuthorizationHandler<ViewRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _context;

        public ViewRequirementHandler(IHttpContextAccessor httpContextAccessor, DataContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ViewRequirement requirement)
        {
            var currentController = _httpContextAccessor.HttpContext.User?.Claims?.SingleOrDefault(x => x.Type == ClaimTypes.Webpage)?.Value;

            var hasPermission = true;

            if (hasPermission)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}