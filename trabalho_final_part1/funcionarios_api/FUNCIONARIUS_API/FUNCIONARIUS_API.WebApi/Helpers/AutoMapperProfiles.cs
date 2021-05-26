using AutoMapper;
using FUNCIONARIUS_API.Domain;
using FUNCIONARIUS_API.WebAPI.Dtos;

namespace FUNCIONARIUS_API.WebAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Funcionario,FuncionarioDto>().ReverseMap();
        }
    }
}