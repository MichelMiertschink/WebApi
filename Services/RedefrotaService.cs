﻿using AutoMapper;
using WebApi.Dtos;
using WebApi.Interfaces;

namespace WebApi.Services
{
    public class RedefrotaService : IRedeFrotaService
    {
        private readonly IMapper _mapper;
        private readonly IRedeFrotaApi _redeFrotaApi;

        public RedefrotaService(IMapper mapper, IRedeFrotaApi redeFrotaApi)
        {
            _mapper = mapper;
            _redeFrotaApi = redeFrotaApi;
        }

        //criar o redefrotaresponse
        public async Task<ResponseGenerico<RedeFrotaResponse>> BuscarRedefrota(string dta_inicio, string dta_final)
        {
            var redeFrota = await _redeFrotaApi.BuscarPorData(dta_inicio, dta_final);
            return _mapper.Map<ResponseGenerico<RedeFrotaResponse>>(redeFrota);
        }
    }
}
