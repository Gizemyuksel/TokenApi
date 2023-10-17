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

public interface IPersonService : IBaseService<PersonDto, Person>
{
    BaseResponse<List<PersonDto>> ApplyAccountFilter(int id);
    BaseResponse<PersonDto> GetPersonById(int accountId, int id);


}