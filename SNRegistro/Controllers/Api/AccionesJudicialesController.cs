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
    public class AccionesJudicialesController : ApiController
    {
        // GET: api/AccionesJudiciales
        public HttpResponseMessage Get()
        {
            AccionesJudicialesManagers dm = new AccionesJudicialesManagers();
            List<AccionesJudicialeDto> listado = dm.ListadoAccionesJudiciales();
            return Request.CreateResponse<List<AccionesJudicialeDto>>(HttpStatusCode.OK, listado);
        }
        [HttpGet]
        [Route("api/AccionesJudiciales/SegunProcesoJudID")]
        public HttpResponseMessage GetTipoConsulta(int ProcesoJudID)
        {
            AccionesJudicialesManagers tsm = new AccionesJudicialesManagers();
            List<AccionesJudicialeDto> generaciones = tsm.ListadoAccionesJudiciales(ProcesoJudID);
            return Request.CreateResponse<List<AccionesJudicialeDto>>(HttpStatusCode.OK, generaciones);
        }
        // GET: api/AccionesJudiciales/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AccionesJudiciales
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AccionesJudiciales/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AccionesJudiciales/5
        public void Delete(int id)
        {
        }
    }
}
