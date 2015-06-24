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
    public class ComisariasController : ApiController
    {
        // GET: api/Comisarias
        public HttpResponseMessage Get()
        {
            ComisariasManagers dm = new ComisariasManagers();
            List<ComisariaDto> listado = dm.Listado();
            return Request.CreateResponse<List<ComisariaDto>>(HttpStatusCode.OK, listado);
        }

        // GET: api/Comisarias/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Comisarias
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Comisarias/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Comisarias/5
        public void Delete(int id)
        {
        }
    }
}
