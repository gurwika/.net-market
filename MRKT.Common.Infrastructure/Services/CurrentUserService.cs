﻿using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using MRKT.Common.Application.Common.Abstraction;

namespace MRKT.Common.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            Ip = httpContextAccessor.HttpContext?.Connection.RemoteIpAddress;
            UserId = httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            IsAuthenticated = UserId != null;
        }

        public IPAddress Ip { get; }
        public string UserId { get; }
        public bool IsAuthenticated { get; }
    }
}
