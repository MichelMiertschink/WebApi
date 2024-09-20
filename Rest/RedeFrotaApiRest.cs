using System.Dynamic;
using System.Text.Json;
using WebApi.Dtos;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Rest
{
    public class RedeFrotaApiRest : IRedeFrotaApi
    {
        public async Task<ResponseGenerico<RedeFrotaResponse>> BuscarPorData(string dta_inicio, string dta_final)
        {
            /* https://prd-redefrota-apim.azure-api.net/inteligencia/FormatoGestranTransacao?cliente=17595&dta_inicio=2024-09-08T18:43:13&dta_final=2024-09-08T18:43:13
            */
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://prd-redefrota-apim.azure-api.net/inteligencia/FormatoGestranTransacao?" +
                "cliente={cliente}" +
                "&dta_inicio={dta_inicio}" +
                "&dta_final={dta_final}");

            request.Headers.Add("Ocp-Apim-Subscription-Key", "1f568d7faeec4d069b7f74343ecfdc5c");
            request.Headers.Add("Ocp-Apim-Trace", "true");

            var content = new StringContent("{\r\n    \"cliente\":17595,\r\n    \"dta_inicio\":\"" + $"{dta_inicio}" + "\",\r\n    \"dta_fim\":\"" +
                $"{dta_final}" + "\"\r\n}", null, "application/json");

            request.Content = content;

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
