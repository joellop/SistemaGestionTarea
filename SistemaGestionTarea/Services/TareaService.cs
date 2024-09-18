using SistemaGestionTarea.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaGestionTarea.Services
{
    public class TareaService : ITareaService
    {
        TaskManagerContext bd = new TaskManagerContext();
        public IEnumerable<Tarea> ObtenerListadoTareas()
        {
            try
            {
                return bd.Tareas.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las tareas.", ex);
            }
        }

        public Tarea CrearTarea(Tarea nuevaTarea)
        {
            try
            {
                if (nuevaTarea == null)
                {
                    throw new ArgumentNullException("No existe tarea por agregar");
                }
                else
                {
                    nuevaTarea.FechaCreacion = DateTime.Now;
                    bd.Tareas.Add(nuevaTarea);
                    bd.SaveChanges();
                    return nuevaTarea;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la tarea.", ex);
            }
        }

        public string BorrarTarea(int id)
        {
            try
            {
                var tarea = bd.Tareas.Find(id);
                if (tarea == null)
                    throw new KeyNotFoundException($"No se encontró la tarea con el ID: {id}.");

                bd.Tareas.Remove(tarea);
                bd.SaveChanges();

                return $"La tarea con el ID {id} fue borrado con exito";
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la tarea.", ex);
            }
        }
        public Tarea ActualizarTarea(int id, Tarea tareaActualizada)
        {
            try
            {
                var tarea = bd.Tareas.Find(id);
                if (tarea == null)
                    throw new KeyNotFoundException($"No se encontró la tarea con el ID {id}.");

                tarea.Titulo = tareaActualizada.Titulo;
                tarea.Descripcion = tareaActualizada.Descripcion;
                tarea.Estado = tareaActualizada.Estado;

                bd.Entry(tarea).State = EntityState.Modified;
                bd.SaveChanges();
                return tarea;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la tarea.", ex);
            }
        }

        public Tarea ObtenerTareaPorId(int id)
        {
            try
            {
                var tarea = bd.Tareas.Find(id);
                if (tarea == null)
                    throw new KeyNotFoundException($"No se encontró la tarea con el ID {id}.");

                return tarea;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al encontrar la tarea.", ex);
            }
        }
    }
}