using System.Dynamic;
using System.Text.Json;
using WebApi.Dtos;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Rest
{
    public class BrasilApiRest : IBrasilApi
    {
        public Task<ResponseGenerico<Banco>> BuscarBanco(string codigoBanco)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseGenerico<Endereco>> BuscarEnderecoPorCep(string cep)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/cep/v1/{cep}");

            var response = new ResponseGenerico<Endereco>();
            using (var client = new HttpClient())
            {
                var responseBrasilApi = await client.SendAsync(request);
                var contentResp = await responseBrasilApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<Endereco>(contentResp);

                if (responseBrasilApi.IsSuccessStatusCode)
                {
                    response.CodigoHttp = responseBrasilApi.StatusCode;
                    response.DadosRetorno = objResponse;
                } else
                {
                    response.CodigoHttp = responseBrasilApi.StatusCode;
                    response.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }
            }
            return response;
        }

        public Task<ResponseGenerico<List<Banco>>> BuscarTodosBancos()
        {
            throw new NotImplementedException();
        }
    }
}
