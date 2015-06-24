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
    public class ProcesosPolicialesController : ApiController
    {
        // GET: api/ProcesosPoliciales
        public HttpResponseMessage Get()
        {
            ProcesosPolicialesManagers dm = new ProcesosPolicialesManagers();
            List<ProcesosPolicialeDto> listado = dm.Listado();
            return Request.CreateResponse<List<ProcesosPolicialeDto>>(HttpStatusCode.OK, listado);
        }

        // GET: api/ProcesosPoliciales/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ProcesosPoliciales
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ProcesosPoliciales/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProcesosPoliciales/5
        public void Delete(int id)
        {
        }
    }
}
