using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Security.Claims;
using TokenApi.Base;
using TokenApi.Data.Repository;
using TokenApi.Data;
using TokenApi.Data.UnitOfWork;
using TokenApi.Dto;
using TokenApi.Service;

namespace TokenApi.Web;

[Route("token/api/v1.0/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService service;
    public AccountController(IAccountService service)
    {
        this.service = service;
    }


    [HttpGet]
    [Authorize]
    public BaseResponse<List<AccountDto>> GetAll()
    {
        Log.Debug("AccountController.GetAll");
        var response = service.GetAll();
        return response;
    }
   
    [HttpGet("{id}")]
    [Authorize]
    public BaseResponse<AccountDto> GetById([FromRoute] int id)
    {
        Log.Debug("AccountController.GetById");
        var response = service.GetById(id);
        return response;
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public BaseResponse<bool> Post([FromBody] AccountDto request)
    {
        Log.Debug("AccountController.Post");
        var response = service.Post(request);
        return response;
    }

    [HttpPut("{id}")]
    [Authorize]
    public BaseResponse<bool> Put(int id, [FromBody] AccountDto request)
    {
        Log.Debug("AccountController.Put");
        var response = service.Put(id, request);
        return response;
    }

    [HttpDelete("{id}")]
    [Authorize]
    public BaseResponse<bool> Delete(int id)
    {
        Log.Debug("AccountController.Delete");
        var response = service.Delete(id);
        return response;
    }

}