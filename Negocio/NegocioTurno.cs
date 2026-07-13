using Datos;
using Entidades;
using System.Data;

namespace Negocio {
    public class NegocioTurno {
        private readonly DaoTurno dao = new DaoTurno();

        public bool agregarTurno(Turno t) {
                        if (t.getLegajo() == 0 || string.IsNullOrWhiteSpace(t.getDniPaciente())
                || string.IsNullOrWhiteSpace(t.getFecha()))
                return false;

            if (dao.existeTurnoMedico(t.getLegajo(), t.getFecha(), t.getHorarioInicio())) {
                return false;
            }
            return dao.agregarTurno(t);
        }
        
        public DataTable getTurnosPorMedico(int legajo) {
            return dao.getTurnosPorMedico(legajo);
        }

        public bool existeTurnoMedico(int legajo, string fecha, int horario) {
            return dao.existeTurnoMedico(legajo, fecha, horario);
        }
        public bool actualizarTurno(int idTurno, bool asistencia, string observacion) {
            return dao.actualizarTurno(idTurno, asistencia, observacion);
        }
    }
}
