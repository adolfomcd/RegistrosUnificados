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
    public class JuzgadosController : ApiController
    {
        // GET: api/Juzgados
        public HttpResponseMessage Get()
        {
            JuzgadosManagers dm = new JuzgadosManagers();
            List<JuzgadoDto> listado = dm.ListadoJuzgados();
            return Request.CreateResponse<List<JuzgadoDto>>(HttpStatusCode.OK, listado);
        }

        // GET: api/Juzgados/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Juzgados
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Juzgados/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Juzgados/5
        public void Delete(int id)
        {
        }
    }
}
