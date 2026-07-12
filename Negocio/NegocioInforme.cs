using System;
using System.Data;
using Datos;

namespace Negocio {
    public class NegocioInforme {
        DaoInforme dao = new DaoInforme();

        public DataTable obtenerAsistenciaPacientes(DateTime desde, DateTime hasta) {
            return dao.obtenerAsistenciaPacientes(desde, hasta);
        }
        public DataTable obtenerTurnosPorEspecialidad(DateTime desde, DateTime hasta) {
            return dao.obtenerTurnosPorEspecialidad(desde, hasta);
        }
    }
}