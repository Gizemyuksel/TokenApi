using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Xml.Linq;
using TokenApi.Base;
using TokenApi.Data;
using TokenApi.Data.Repository;
using TokenApi.Dto;
using TokenApi.Service;

namespace TokenApi.Web;

[Route("token/api/v1.0/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IPersonService service;
    public PersonController(IPersonService service, IMapper mapper)
    {
        
        this.service = service;
    }

    //AccountId field of the Person model should not be taken from the request, but should be automatically filled from the session information of the user who made the request.
    //All actions in the Person controller should be filtered based on the account ID value stored in the session.
    

    [Route("/api/[controller]/AccountFilter")]
    [HttpGet]
    [Authorize]
    public BaseResponse<List<PersonDto>> GetAllByAccount()
    {
        var identity = User.Claims;
        var account = identity.Where(x => x.Type == "AccountId").FirstOrDefault();
        var accountId = Int32.Parse(account.Value);
        var response = service.ApplyAccountFilter(accountId);
        return response;
    }

    [HttpGet("{id}")]
    [Authorize]
    public BaseResponse<PersonDto> GetById(int id)
    {

        var identity = User.Claims;
        var account = identity.Where(x => x.Type == "AccountId").FirstOrDefault();
        var accountId = Int32.Parse(account.Value);
        var person = service.GetPersonById(accountId, id);
        return person;
    }

    [HttpPost]
    [Authorize]
    public BaseResponse<bool> Post([FromBody] PersonDto request)
    {
        var identity = User.Claims;
        var account = identity.Where(x => x.Type == "AccountId").FirstOrDefault();
        request.AccountId = Int32.Parse(account.Value);
        var response = service.Post(request);
        return response;
    } 


    [HttpPut("{id}")]
    [Authorize]
    public BaseResponse<bool> Put(int id, [FromBody] PersonDto request)
    {
        Log.Debug("PersonController.Put");
        var identity = User.Claims;
        var account = identity.Where(x => x.Type == "AccountId").FirstOrDefault();
        request.AccountId = Int32.Parse(account.Value);

        var response = service.Put(id, request);
        return response;
    }

    [HttpDelete]
    [Authorize]
    public BaseResponse<bool> Delete(int id)
    {
        var identity = User.Claims;
        var account = identity.Where(x => x.Type == "AccountId").FirstOrDefault();
        var accountId = Int32.Parse(account.Value);
        var person = service.GetPersonById(accountId, id);

        var response = service.Delete(person.Response.Id);
        return response;
    }

}
