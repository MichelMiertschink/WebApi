using WebApi.Dtos;

namespace WebApi.Interfaces
{
    public interface IRedeFrotaService
    {
        Task<ResponseGenerico<RedeFrotaResponse>> BuscarRedefrota(string dta_inicio, string dta_final);
    }
}
