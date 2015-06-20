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
    public class ProcesosJudicialesController : ApiController
    {
        // GET: api/ProcesosJudiciales
        public HttpResponseMessage Get()
        {
            ProcesosJudicialesManagers dm = new ProcesosJudicialesManagers();
            List<ProcesosJudicialeDto> listado = dm.Listado();
            return Request.CreateResponse<List<ProcesosJudicialeDto>>(HttpStatusCode.OK, listado);
        }

        // GET: api/ProcesosJudiciales/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ProcesosJudiciales
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ProcesosJudiciales/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProcesosJudiciales/5
        public void Delete(int id)
        {
        }
    }
}
