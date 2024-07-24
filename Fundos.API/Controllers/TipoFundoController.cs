using Fundos.API.App.DTO;
using Fundos.API.App.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace Fundos.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class TipoFundoController : BaseController
    {
        private readonly IAppTipoFundo _application;

        public TipoFundoController(IAppTipoFundo application)
        {
            this._application = application;
        }


        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_application.GetAllTiposFundo());
        }


        [HttpGet("{codigo}", Name = "GetTipoFundo")]
        public ActionResult<string> Get(int codigo)
        {
            try
            {
                return Ok(_application.GetTipoFundo(codigo));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpPost]
        public ActionResult Post([FromBody] TipoFundoDTO value)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(GetErrorModel(ModelState));

                _application.GravarTipoFundo(value);
                return Ok(new { message = "Tipo de Fundo cadastrado com sucesso!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpPut]
        public ActionResult Put([FromBody] TipoFundoDTO value)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(GetErrorModel(ModelState));

                _application.UpdateTipoFundo(value);
                return Ok(new { message = "Tipo de Fundo atualizado com sucesso!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
