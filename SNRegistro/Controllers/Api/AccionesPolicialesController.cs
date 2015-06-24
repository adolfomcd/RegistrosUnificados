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
    public class AccionesPolicialesController : ApiController
    {
        // GET: api/AccionesPoliciales
        public HttpResponseMessage Get()
        {
            AccionesPolicialesManagers dm = new AccionesPolicialesManagers();
            List<AccionesPolicialeDto> listado = dm.ListadoAccionesPoliciales();
            return Request.CreateResponse<List<AccionesPolicialeDto>>(HttpStatusCode.OK, listado);
        }
        [HttpGet]
        [Route("api/AccionesPoliciales/SegunProcesoPolicialID")]
        public HttpResponseMessage GetTipoConsulta(int ProcesoPolicialID)
        {
            AccionesPolicialesManagers tsm = new AccionesPolicialesManagers();
            List<AccionesPolicialeDto> generaciones = tsm.ListadoAccionesPoliciales(ProcesoPolicialID);
            return Request.CreateResponse<List<AccionesPolicialeDto>>(HttpStatusCode.OK, generaciones);
        }

        // GET: api/AccionesPoliciales/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AccionesPoliciales
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AccionesPoliciales/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AccionesPoliciales/5
        public void Delete(int id)
        {
        }
    }
}
