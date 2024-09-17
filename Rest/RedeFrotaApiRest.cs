using System.Dynamic;
using System.Text.Json;
using WebApi.Dtos;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Rest
{
    public class RedeFrotaApiRest : IRedeFrotaApi
    {
        public async Task<ResponseGenerico<RedeFrotaResponse>> BuscarPorData(string cliente, string dta_inicio, string dta_final)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://prd-redefrota-apim.azure-api.net/inteligencia/FormatoGestranTransacao?{cliente}{dta_inicio}{dta_final}");

            var response = new ResponseGenerico<RedeFrotaResponse>();
            using (var client = new HttpClient())
            {
                var ResponseApiRedefrota = await client.SendAsync(request);
                var contentResp = await ResponseApiRedefrota.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<RedeFrotaResponse>(contentResp);

                if (ResponseApiRedefrota.IsSuccessStatusCode)
                {
                    response.CodigoHttp = ResponseApiRedefrota.StatusCode;
                    response.DadosRetorno = objResponse;
                } else
                {
                    response.CodigoHttp = ResponseApiRedefrota.StatusCode;
                    response.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }
            }
            return response;
        }
    }
}
