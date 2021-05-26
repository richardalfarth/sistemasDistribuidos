using AutoMapper;
using FDP.API.Domain;

namespace FDP.API.WebAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<FolhaSalarial,FolhaSalariaDto>().ReverseMap();
            CreateMap<Funcionario, FuncionarioDto>().ReverseMap();
        }
    }
}