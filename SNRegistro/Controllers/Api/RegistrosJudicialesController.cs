﻿using SNRegistros.Aplicacion.Dto;
using SNRegistros.Dominio.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SNRegistro.Controllers.Api
{
    public class RegistrosJudicialesController : ApiController
    {
        // GET: api/RegistrosJudiciales
        public HttpResponseMessage Get()
        {
            RegistrosJudicialesManagers rm = new RegistrosJudicialesManagers();
            List<RegistrosJudicialeDto> listado = rm.ListadoRegistroMedico();
            return Request.CreateResponse<List<RegistrosJudicialeDto>>(HttpStatusCode.OK, listado);
        }

        // GET: api/RegistrosJudiciales/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RegistrosJudiciales
        public HttpResponseMessage Post(RegistrosJudicialeDto rDto)
        {
            RegistrosJudicialesManagers rm = new RegistrosJudicialesManagers();
            MensajeDto mensaje = rm.CargarRegistroJudicial(rDto);
            return Request.CreateResponse(HttpStatusCode.Created, mensaje);
        }

        // PUT: api/RegistrosJudiciales/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RegistrosJudiciales/5
        public void Delete(int id)
        {
        }
    }
}
