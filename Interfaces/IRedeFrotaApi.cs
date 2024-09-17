using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IRedeFrotaApi
    {
        Task<ResponseGenerico<RedeFrotaResponse>> BuscarPorData(string cliente, string dta_inicio, string dta_final);
    }
}
