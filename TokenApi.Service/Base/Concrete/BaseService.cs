using AutoMapper;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenApi.Base;
using TokenApi.Data.Repository;
using TokenApi.Data.UnitOfWork;

namespace TokenApi.Service.Base;

public abstract class BaseService<Dto, TEntity> : IBaseService<Dto, TEntity> where TEntity : class
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IGenericRepository<TEntity> genericRepository;

    public BaseService(IUnitOfWork unitOfWork, IMapper mapper, IGenericRepository<TEntity> genericRepository)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
        this.genericRepository = genericRepository;
    }

    public virtual BaseResponse<Dto> GetById(int id)
    {
        var entity = genericRepository.GetById(id);
        var mapped = mapper.Map<TEntity, Dto>(entity);
        return new BaseResponse<Dto>(mapped);
    }

    public virtual BaseResponse<List<Dto>> GetAll()
    {
        var entityList = genericRepository.GetAll();
        var mapped = mapper.Map<List<TEntity>, List<Dto>>(entityList);
        return new BaseResponse<List<Dto>>(mapped);
    }


    public virtual BaseResponse<bool> Post(Dto insertResource)
    {
        try
        {
            var entity = mapper.Map<Dto, TEntity>(insertResource);

            genericRepository.Post(entity);
            unitOfWork.Complete();

            return new BaseResponse<bool>(true);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "BaseService_Insert");
            return new BaseResponse<bool>(ex.StackTrace);
        }
    }

    public virtual BaseResponse<bool> Put(int id, Dto updateResource)
    {
        try
        {
            var entity = genericRepository.GetById(id);
            if (entity is null)
            {
                return new BaseResponse<bool>("No_Data");
            }

            var mappedEntity = mapper.Map<Dto, TEntity>(updateResource);
            mappedEntity.GetType().GetProperty("Id").SetValue(mappedEntity, id);

            genericRepository.Put(mappedEntity);
            unitOfWork.Complete();

            return new BaseResponse<bool>(true);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "BaseService_Update");
            return new BaseResponse<bool>(ex.StackTrace);
        }
    }

    public virtual BaseResponse<bool> Delete(int id)
    {
        try
        {
            var entity = genericRepository.GetById(id);
            if (entity is null)
            {
                return new BaseResponse<bool>("No_Data");
            }

            genericRepository.Delete(entity);
            unitOfWork.Complete();

            return new BaseResponse<bool>(true);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "BaseService_Delete");
            return new BaseResponse<bool>(ex.StackTrace);
        }
    }

    
}
