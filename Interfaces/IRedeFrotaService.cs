using WebApi.Dtos;

namespace WebApi.Interfaces
{
    public interface IRedeFrotaService
    {
        Task<ResponseGenerico<RedeFrotaResponse>> BuscarRedefrota(string cliente, string dta_inicio, string dta_final);
    }
}
