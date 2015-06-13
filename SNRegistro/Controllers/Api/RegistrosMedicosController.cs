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
    public class RegistroMedicosController : ApiController
    {
        // GET: api/RegistroMedicos
        public HttpResponseMessage Get()
        {
            RegistrosMedicosManagers rm = new RegistrosMedicosManagers();
            List<RegistroMedicoDto> listado = rm.ListadoRegistroMedico();
            return Request.CreateResponse<List<RegistroMedicoDto>>(HttpStatusCode.OK, listado);
        }

        // GET: api/RegistroMedicos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RegistroMedicos
        public HttpResponseMessage Post(RegistroMedicoDto rDto)
        {
            RegistrosMedicosManagers rm = new RegistrosMedicosManagers();
            MensajeDto mensaje = rm.CargarRegistroMedico(rDto);
            return Request.CreateResponse(HttpStatusCode.Created, mensaje);
        }

        // PUT: api/RegistroMedicos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RegistroMedicos/5
        public void Delete(int id)
        {
        }
    }
}
