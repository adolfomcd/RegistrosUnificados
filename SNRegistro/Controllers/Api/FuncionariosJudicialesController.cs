using SNRegistros.Aplicacion.Dto;
using SNRegistros.Dominio.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SNRegistro.Controllers.Api
{
    public class FuncionariosJudicialesController : ApiController
    {
        // GET: api/FuncionariosJudiciales
        public HttpResponseMessage Get()
        {
            FuncionariosJudicialesManagers dm = new FuncionariosJudicialesManagers();
            List<FuncionariosJudicialesDto> listado = dm.Listado();
            return Request.CreateResponse<List<FuncionariosJudicialesDto>>(HttpStatusCode.OK, listado);
        }
        // GET: api/FuncionariosJudiciales/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FuncionariosJudiciales
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/FuncionariosJudiciales/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FuncionariosJudiciales/5
        public void Delete(int id)
        {
        }
    }
}
