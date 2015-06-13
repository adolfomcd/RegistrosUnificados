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
    public class AccionesController : ApiController
    {
        // GET: api/Acciones
        public HttpResponseMessage Get()
        {
            AccionesManagers dm = new AccionesManagers();
            List<AccioneDto> listado = dm.ListadoAcciones();
            return Request.CreateResponse<List<AccioneDto>>(HttpStatusCode.OK, listado);
        }
        [HttpGet]
        [Route("api/Acciones/SegunProcesoID")]
        public HttpResponseMessage GetTipoConsulta(int ProcesoID)
        {
            AccionesManagers tsm = new AccionesManagers();
            List<AccioneDto> generaciones = tsm.ListadoAcciones(ProcesoID);
            return Request.CreateResponse<List<AccioneDto>>(HttpStatusCode.OK, generaciones);
        }
        // GET: api/Acciones/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Acciones
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Acciones/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Acciones/5
        public void Delete(int id)
        {
        }
    }
}
