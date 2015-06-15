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
    public class CiudadanosController : ApiController
    {
        // GET: api/Ciudadanos
        public HttpResponseMessage Get()
        {
            CiudadanosManagers cm = new CiudadanosManagers();
            List<CiudadanoDto> listado = cm.Listado();
            return Request.CreateResponse<List<CiudadanoDto>>(HttpStatusCode.OK, listado);
        }

        // GET: api/Ciudadanos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Ciudadanos
        public HttpResponseMessage Post(CiudadanoDto cDto)
        {
            CiudadanosManagers dm = new CiudadanosManagers();
            MensajeDto mensaje = dm.CargarCiudadano(cDto);
            return Request.CreateResponse(HttpStatusCode.Created, mensaje);
        }

        // PUT: api/Ciudadanos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Ciudadanos/5
        public void Delete(int id)
        {
        }
    }
}
