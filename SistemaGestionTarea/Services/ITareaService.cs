using SistemaGestionTarea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTarea.Services
{
    public interface ITareaService
    {
        IEnumerable<Tarea> ObtenerListadoTareas();
        Tarea CrearTarea(Tarea tarea);
        Tarea ActualizarTarea(int id, Tarea tarea);
        string BorrarTarea(int id);
        Tarea ObtenerTareaPorId(int id);
    }
}
