using Api_Development.Models.Domain;
using Api_Development.Models.DTOs;
using AutoMapper;

namespace Api_Development.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Regiao, RegiaoDto>().ReverseMap();
            CreateMap<AddRegiaoRequestDto, Regiao>().ReverseMap();
            CreateMap<UpdateRegiaoRequestDto, Regiao>().ReverseMap();
            CreateMap<AddCaminhadaRequestDto, Caminhada>().ReverseMap();
            CreateMap<Caminhada, CaminhadaDto>().ReverseMap();
            CreateMap<UpdateCaminhadaRequestDto, Caminhada>().ReverseMap();
            CreateMap<Dificuldade, DificuldadeDto>().ReverseMap();
            CreateMap<UpdateDificuldadeRequestDto, Dificuldade>().ReverseMap();
            CreateMap<AddDificuldadeRequestDto, Dificuldade>().ReverseMap();
        }
    }
}
