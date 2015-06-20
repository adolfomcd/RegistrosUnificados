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
    public class RegistrosPolicialesController : ApiController
    {
        // GET: api/RegistrosPoliciales
        public HttpResponseMessage Get()
        {
            RegistrosPolicialesManagers rm = new RegistrosPolicialesManagers();
            List<RegistrosPolicialeDto> listado = rm.ListadoRegistroPolicial();
            return Request.CreateResponse<List<RegistrosPolicialeDto>>(HttpStatusCode.OK, listado);
        }


        // GET: api/RegistrosPoliciales/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RegistrosPoliciales
        public HttpResponseMessage Post(RegistrosPolicialeDto rDto)
        {
            RegistrosPolicialesManagers rm = new RegistrosPolicialesManagers();
            MensajeDto mensaje = rm.CargarRegistroPolicial(rDto);
            return Request.CreateResponse(HttpStatusCode.Created, mensaje);
        }

        // PUT: api/RegistrosPoliciales/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RegistrosPoliciales/5
        public void Delete(int id)
        {
        }
    }
}
