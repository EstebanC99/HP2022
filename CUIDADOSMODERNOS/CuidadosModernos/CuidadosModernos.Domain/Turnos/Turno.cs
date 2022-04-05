using Cross.Business.Domain;
using Cross.Crosscutting.Exceptions;
using CuidadosModernos.CrossCutting.Exceptions;
using CuidadosModernos.Domain.Generales;
using CuidadosModernos.Domain.ValueObjects.Turnos;
using System;

namespace CuidadosModernos.Domain.Horarios
{
    public class Turno : Aggregate<int>
    {
        public virtual DateTime FechaHoraInicio { get; private set; }

        public virtual DateTime FechaHoraFin { get; private set; }

        public virtual Empleada Empleada { get; private set; }

        public Turno(Empleada empleada)
        {
            this.Empleada = empleada;
        }

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
