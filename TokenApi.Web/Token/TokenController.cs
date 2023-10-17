using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using TokenApi.Base;
using TokenApi.Dto;
using TokenApi.Service;

namespace TokenApi.Web;

[Route("token/api/v1.0/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly ITokenManagementService tokenManagementService;
    public TokenController(ITokenManagementService tokenManagementService)
    {
        this.tokenManagementService = tokenManagementService;
    }


    [HttpPost]
    public BaseResponse<TokenResponse> Login([FromBody] TokenRequest request)
    {
        var response = tokenManagementService.GenerateToken(request);
        return response;
    }

   

}