using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenApi.Base;

namespace TokenApi.Service.Base;

public interface IBaseService<Dto, TEntity>
{
    BaseResponse<Dto> GetById(int id);
    BaseResponse<List<Dto>> GetAll();
    BaseResponse<bool> Post(Dto insertResource);
    BaseResponse<bool> Put(int id, Dto updateResource);
    BaseResponse<bool> Delete(int id);
}

