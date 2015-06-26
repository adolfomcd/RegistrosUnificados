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
    public class PoliciasController : ApiController
    {
        // GET: api/Policias
        public HttpResponseMessage Get()
        {
            PoliciasManagers dm = new PoliciasManagers();
            List<PoliciaDto> listado = dm.Listado();
            return Request.CreateResponse<List<PoliciaDto>>(HttpStatusCode.OK, listado);
        }

        // GET: api/Policias/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Policias
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Policias/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Policias/5
        public void Delete(int id)
        {
        }
    }
}
