using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
using System.Data;

namespace Negocio {
    public class NegocioTurno {
        DaoTurno daoTurno = new DaoTurno();

        public bool agregarTurno(Turno t) {
            if (t.getLegajo() == 0 || string.IsNullOrWhiteSpace(t.getDniPaciente())
                || string.IsNullOrWhiteSpace(t.getFecha()))
                return false;

            return daoTurno.agregarTurno(t);
        }

        public DataTable getTurnosPorMedico(int legajo) {
            return daoTurno.getTurnosPorMedico(legajo);
        }
    }
}
