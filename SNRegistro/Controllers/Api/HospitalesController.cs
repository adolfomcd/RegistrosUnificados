using SNRegistros.Aplicacion.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SNRegistros.Dominio.Managers;

namespace SNRegistro.Controllers.Api
{
    public class HospitalesController : ApiController
    {
        // GET: api/Hospitales
        public HttpResponseMessage Get()
        {
            HospitalesManagers dm = new HospitalesManagers();
            List<HospitaleDto> listado = dm.Listado();
            return Request.CreateResponse<List<HospitaleDto>>(HttpStatusCode.OK, listado);
        }
        // GET: api/Hospitales/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Hospitales
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Hospitales/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Hospitales/5
        public void Delete(int id)
        {
        }
    }
}
