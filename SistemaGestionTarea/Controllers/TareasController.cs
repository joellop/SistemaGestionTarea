using SistemaGestionTarea.Models;
using SistemaGestionTarea.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace SistemaGestionTarea.Controllers
{
    [RoutePrefix("api/Tareas")]
    public class TareasController : ApiController
    {
        private readonly ITareaService _tareaService;
        public TareasController(ITareaService tareaService)
        {
            _tareaService = tareaService;
        }

        [HttpGet]
        public IHttpActionResult ObtenerListadoTareas()
        {
            try
            {
                var tareas = _tareaService.ObtenerListadoTareas();
                return Ok(tareas);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPost]
        [Route("CrearTarea")]
        public IHttpActionResult CrearTarea([FromBody] Tarea nuevaTarea)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var tarea = _tareaService.CrearTarea(nuevaTarea);
                return Created(new Uri(Request.RequestUri + "/" + tarea.Id), tarea);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("BorrarTarea/{id:int}")]
        public IHttpActionResult BorrarTarea(int id)
        {
            try
            {
                var mensaje = _tareaService.BorrarTarea(id)
;
                return Ok(mensaje);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPut]
        [Route("ActualizarTarea/{id:int}")]
        public IHttpActionResult ActualizarTarea(int id, [FromBody] Tarea tareaActualizada)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var tarea = _tareaService.ActualizarTarea(id, tareaActualizada);
                return Ok(tarea);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("ObtenerTareaPorId/{id:int}")]
        public IHttpActionResult ObtenerTareaPorId(int id)
        {
            try
            {
                var tareas = _tareaService.ObtenerTareaPorId(id);
                return Ok(tareas);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}