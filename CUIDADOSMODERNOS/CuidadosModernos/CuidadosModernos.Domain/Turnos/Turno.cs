using Cross.Business.Domain;
using Cross.Crosscutting.Exceptions;
using CuidadosModernos.CrossCutting.Exceptions;
using CuidadosModernos.Domain.Tareas;
using CuidadosModernos.Domain.Usuarios;
using CuidadosModernos.Domain.ValueObjects.Turnos;
using System;
using System.Collections.Generic;

namespace CuidadosModernos.Domain.Horarios
{
    public class Turno : Aggregate<int>
    {
        public Turno()
        {
            this.Tareas = new List<TareaTurno>();
        }

        public Turno(Empleada empleada)
        {
            this.Tareas = new List<TareaTurno>();
            this.Empleada = empleada;
        }

        public virtual DateTime FechaHoraInicio { get; private set; }

        public virtual DateTime FechaHoraFin { get; private set; }

        public virtual DateTime FechaHoraRealInicio { get; private set; }

        public virtual DateTime FechaHoraRealFin { get; private set; }

        public virtual Empleada Empleada { get; private set; }

        public virtual Empleada EmpleadaReemplazante { get; private set; }

        public virtual List<TareaTurno> Tareas { get; private set; }

        #region Registrar Turno

        public void Registrar(RegistrarTurno registrarTurno)
        {
            this.ValidarRegistrar(registrarTurno);

            this.FechaHoraInicio = registrarTurno.FechaHoraInicio;
            this.FechaHoraFin = registrarTurno.FechaHoraFin;

        }

        private void ValidarRegistrar(RegistrarTurno registrarTurno)
        {
            var validaciones = new ValidationException();

            if (this.Empleada == null)
            {
                validaciones.AddValidationResult(Messages.NoSeEncontroLaEmpleada);
            }

            if (registrarTurno.FechaHoraInicio == null || registrarTurno.FechaHoraInicio == DateTime.MinValue)
            {
                validaciones.AddValidationResult(Messages.LaFechaHoraInicioEsRequerida);
            }

            if (registrarTurno.FechaHoraFin == null || registrarTurno.FechaHoraFin == DateTime.MinValue)
            {
                validaciones.AddValidationResult(Messages.LaFechaHoraFinEsRequerida);
            }

            validaciones.Throw();
        }

        #endregion
    }
}
