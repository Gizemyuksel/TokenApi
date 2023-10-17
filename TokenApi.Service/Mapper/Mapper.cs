using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenApi.Data;
using TokenApi.Dto;

namespace TokenApi.Service;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Person, PersonDto>();
        CreateMap<PersonDto, Person>();

        CreateMap<Account, AccountDto>();
        CreateMap<AccountDto, Account>();


    }
}