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
    public class ProcesosController : ApiController
    {
        // GET: api/Procesos
        public HttpResponseMessage Get()
        {
            ProcesosManagers dm = new ProcesosManagers();
            List<ProcesoDto> listado = dm.Listado();
            return Request.CreateResponse<List<ProcesoDto>>(HttpStatusCode.OK, listado);
        }
        // GET: api/Procesos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Procesos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Procesos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Procesos/5
        public void Delete(int id)
        {
        }
    }
}
