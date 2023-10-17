using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenApi.Base;
using TokenApi.Data.Repository;
using TokenApi.Data.UnitOfWork;
using TokenApi.Data;
using TokenApi.Dto;
using TokenApi.Service.Base;

namespace TokenApi.Service;

public class AccountService : BaseService<AccountDto, Account>, IAccountService
{
    private readonly IGenericRepository<Account> genericRepository;
    private readonly IMapper mapper;
    public AccountService(IUnitOfWork unitOfWork, IMapper mapper, IGenericRepository<Account> genericRepository) : base(unitOfWork, mapper, genericRepository)
    {
        this.genericRepository = genericRepository;
        this.mapper = mapper;
    }

    public BaseResponse<AccountDto> GetByUsername(string username)
    {
        var account = genericRepository.Where(x => x.UserName == username).FirstOrDefault();
        var mapped = mapper.Map<Account, AccountDto>(account);
        return new BaseResponse<AccountDto>(mapped);
    }
}
