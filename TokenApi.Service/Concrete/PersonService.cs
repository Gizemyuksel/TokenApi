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

public class PersonService : BaseService<PersonDto, Person>, IPersonService
{
    private readonly IGenericRepository<Person> genericRepository;
    private readonly IMapper mapper;
    public PersonService(IUnitOfWork unitOfWork, IMapper mapper, IGenericRepository<Person> genericRepository) : base(unitOfWork, mapper, genericRepository)
    {
        this.genericRepository = genericRepository;
        this.mapper = mapper;
    }

    public BaseResponse<List<PersonDto>> ApplyAccountFilter(int id)
    {
        var persons = genericRepository.GetAll().Where(x => x.AccountId == id).ToList();
        var mapped = mapper.Map<List<Person>, List<PersonDto>>(persons);
        return new BaseResponse<List<PersonDto>>(mapped);
    }

    public BaseResponse<PersonDto> GetPersonById(int accountId, int id)
    {

        var persons = genericRepository.GetAll().Where(x => x.AccountId == accountId).ToList();
        var person = persons.Where(x => x.Id == id).ToList();


        var mapped = mapper.Map<List<Person>, List<PersonDto>>(person).FirstOrDefault();

        return new BaseResponse<PersonDto>(mapped);

    }
}
