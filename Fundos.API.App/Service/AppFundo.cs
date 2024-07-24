using AutoMapper;
using Fundos.API.App.DTO;
using Fundos.API.App.Enums;
using Fundos.API.App.Interface;
using Fundos.API.Domain.Core.Service;
using Fundos.API.Domain.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fundos.API.App.Service
{
    public class AppFundo : IAppFundo
    {
        private readonly IFundoService _fundoService;
        private readonly IMapper _mapper;
        private readonly ILogger<AppFundo> _logger;

        public AppFundo(IFundoService service, IMapper mapper, ILogger<AppFundo> logger)
        {
            this._fundoService = service;
            this._mapper = mapper;
            this._logger = logger;
        }

        public void DeleteFundo(string codigo)
        {
            try
            {
                FundoDTO fundo = _mapper.Map<FundoDTO>(_fundoService.GetFundoByCodigo(codigo));
                _fundoService.RemoveFundo(_mapper.Map<Fundo>(fundo));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public IEnumerable<FundoDTOView> GetAllFundo()
        {
            try
            {
                return _mapper.Map<List<FundoDTOView>>(_fundoService.GetAllFundos());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public FundoDTOView GetFundo(string codigo)
        {
            try
            {
                if (string.IsNullOrEmpty(codigo))
                    throw new Exception("Código inválido");

                return _mapper.Map<FundoDTOView>(_fundoService.GetFundoByCodigo(codigo));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public void GravarFundo(FundoDTO fundo)
        {
            try
            {
                if (!(GetFundo(fundo.Codigo) is null))
                    throw new Exception("Código de fundo já cadastrado");

                var fundoBase = _fundoService.GetFundoByCNPJ(fundo.Cnpj);

                if(fundoBase != null)
                    throw new Exception("CNPJ já cadastrado");

                _fundoService.Save(_mapper.Map<Fundo>(fundo));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public FundoDTO MovimentarPatrimonio(string codigo, MovimentacaoDTO movimentacao)
        {
            try
            {
                if (movimentacao.Valor < 0)
                    throw new Exception("Valor negativo não é permitido");
                
                if (movimentacao.Acao < 0 || (int)movimentacao.Acao > Enum.GetValues(typeof(Acao)).Length)
                    throw new Exception("Opcão de acão inválida, opcão Adicionar(0) ou Subtrair(1)");

                FundoDTO fundo = _mapper.Map<FundoDTO>(_fundoService.GetFundoByCodigo(codigo));

                if ((Acao)movimentacao.Acao == Acao.Adicionar)
                    fundo.Patrimonio = fundo.Patrimonio + movimentacao.Valor;

                if ((Acao)movimentacao.Acao == Acao.Subtrair)
                    fundo.Patrimonio = fundo.Patrimonio - movimentacao.Valor;

                _fundoService.UpdateFundo(_mapper.Map<Fundo>(fundo));
                return fundo;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public void UpdateFundo(FundoDTO fundo)
        {
            _fundoService.UpdateFundo(_mapper.Map<Fundo>(fundo));
        }
    }
}
