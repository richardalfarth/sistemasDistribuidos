using AutoMapper;
using Project.Domain;

namespace Project.WebAPI.Helpers
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