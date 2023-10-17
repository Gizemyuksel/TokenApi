using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenApi.Base;
using TokenApi.Data;
using TokenApi.Dto;
using TokenApi.Service.Base;

namespace TokenApi.Service;

public interface IAccountService : IBaseService<AccountDto, Account>
{
    BaseResponse<AccountDto> GetByUsername(string username);
}
