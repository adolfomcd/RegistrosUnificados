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
    public class DoctoresController : ApiController
    {
        // GET: api/Doctores
        public HttpResponseMessage Get()
        {
            DoctoresManagers dm = new DoctoresManagers();
            List<DoctoreDto> listado = dm.Listado();
            return Request.CreateResponse<List<DoctoreDto>>(HttpStatusCode.OK, listado);
        }

        // GET: api/Doctores/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Doctores
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Doctores/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Doctores/5
        public void Delete(int id)
        {
        }
    }
}
