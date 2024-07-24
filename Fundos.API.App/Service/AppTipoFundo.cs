using AutoMapper;
using Fundos.Api.Domain.Entity;
using Fundos.API.App.DTO;
using Fundos.API.App.Interface;
using Fundos.API.Domain.Core.Service;
using Fundos.API.Domain.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fundos.API.App.Service
{
    public class AppTipoFundo : IAppTipoFundo
    {
        private readonly ITipoFundoService _tipoFundoService;
        private readonly IMapper _mapper;
        private readonly ILogger<AppFundo> _logger;

        public AppTipoFundo(ITipoFundoService service, IMapper mapper, ILogger<AppFundo> logger)
        {
            this._tipoFundoService = service;
            this._mapper = mapper;
            this._logger = logger;
        }

        public void DeleteTipoFundo(int codigo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoFundoDTO> GetAllTiposFundo()
        {
            return _mapper.Map<List<TipoFundoDTO>>(_tipoFundoService.GetAll());
        }

        public TipoFundoDTO GetTipoFundo(int codigo)
        {
            return _mapper.Map<TipoFundoDTO>(_tipoFundoService.Get(codigo));
        }

        public void GravarTipoFundo(TipoFundoDTO tipo)
        {
            try
            {
                _tipoFundoService.Save(_mapper.Map<TipoFundo>(tipo));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public void UpdateTipoFundo(TipoFundoDTO tipo)
        {
            _tipoFundoService.Update(_mapper.Map<TipoFundo>(tipo));
        }
    }
}
