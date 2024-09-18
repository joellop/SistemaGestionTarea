app.factory('TareasService', ['$http', function ($http) {
    var apiBase = '/api/Tareas/';

    return {
        // Obtener todas las tareas
        getTareas: function () {
            return $http.get(apiBase + 'ObtenerListadoTareas');
        },

        // Crear nueva tarea
        createTarea: function (tarea) {
            return $http.post(apiBase + 'CrearTarea', tarea);
        },

        // Actualizar tarea existente
        updateTarea: function (id, tarea) {
            return $http.put(apiBase + 'ActualizarTarea/' + id, tarea);
        },

        // Obtener tarea por Id
        getTareaById: function (id) {
            return $http.get(apiBase + 'ObtenerTareaPorId/' + id);
        },

        // Eliminar tarea
        deleteTarea: function (id) {
            return $http.delete(apiBase + 'BorrarTarea/' + id);
        }
    };
}]);
