using AutoMapper;
using EFRepository.DTO;
using EFRepository.Models;

namespace ATWebAPI
{
    public static class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<UserDTO, User>().ReverseMap();

            });
            return mappingConfig;
        }
    }
}
