using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;
using Fundos.API.App.Interface;
using Fundos.API.App.DTO;
using Newtonsoft.Json.Linq;

namespace Fundos.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]    
    [ApiVersion("1.0")]
    public class FundoController : BaseController
    {

        private readonly IAppFundo _application;

        public FundoController(IAppFundo application)
        {
            this._application = application;
        }

        // GET: api/Fundo
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_application.GetAllFundo());
        }

        // GET: api/Fundo/001
        [HttpGet("{codigo}", Name = "Get")]
        public ActionResult<string> Get(string codigo)
        {
            try
            {
                return Ok(_application.GetFundo(codigo));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // POST: api/Fundo
        [HttpPost]
        public ActionResult Post([FromBody] FundoDTO value)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(GetErrorModel(ModelState));

                _application.GravarFundo(value);
                return Ok(new { message = "Fundo cadastrado com sucesso!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // PUT: api/Fundo/TESTE01
        [HttpPut("{codigo}")]
        public ActionResult Put([FromBody] FundoDTO value)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(GetErrorModel(ModelState));

                _application.UpdateFundo(value);
                return Ok(new { message = "Fundo atualizado com sucesso!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // DELETE: api/Fundo/TESTE01
        [HttpDelete("{codigo}")]
        public ActionResult Delete(string codigo)
        {
            try
            {
                _application.DeleteFundo(codigo);
                return Ok(new { message = "Fundo excluido com sucesso!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut("{codigo}/patrimonio")]
        public ActionResult MovimentarPatrimonio(string codigo, [FromBody] MovimentacaoDTO movimentacao)
        {
            try
            {
                var fundo = _application.MovimentarPatrimonio(codigo, movimentacao);
                return Ok(new { newpatrimonio = fundo.Patrimonio });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
