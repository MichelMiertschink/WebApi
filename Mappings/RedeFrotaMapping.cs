using AutoMapper;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Mappings
{
    public class RedeFrotaMapping : Profile
    {
        public RedeFrotaMapping()
        {
            CreateMap(typeof(ResponseGenerico<>), typeof(ResponseGenerico<>));
            CreateMap<RedeFrotaResponse, RedeFrota>();
            CreateMap<RedeFrota, RedeFrotaResponse>();
        }
    }
}
