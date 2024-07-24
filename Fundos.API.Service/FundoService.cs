using Fundos.API.Domain.Core.Repository;
using Fundos.API.Domain.Core.Service;
using Fundos.API.Domain.Entity;
using Fundos.API.Infra.Repo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fundos.API.Domain.Service
{
    public class FundoService : BaseService<Fundo>, IFundoService
    {
        public readonly IFundoRepository _repository;

        public FundoService(IFundoRepository repo)
            : base(repo)
        {
            _repository = repo;
        }

        public Fundo GetFundoByCodigo(string codigo)
        {
            return _repository.GetFundoByCodigo(codigo);
        }

        public Fundo GetFundoByCNPJ(string cnpj)
        {
            return _repository.GetFundoByCNPJ(cnpj);
        }

        public void UpdateFundo(Fundo fundo)
        {
            _repository.UpdateFundo(fundo);                
        }

        public void RemoveFundo(Fundo fundo)
        {
            _repository.RemoveFundo(fundo);
        }
        public List<Fundo> GetAllFundos()
        {
            return _repository.GetAllFundos();
        }

    }
}
