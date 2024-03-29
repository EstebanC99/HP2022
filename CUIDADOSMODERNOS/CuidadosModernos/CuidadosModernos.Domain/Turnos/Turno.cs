﻿using Cross.Business.Domain;
using Cross.Crosscutting.Exceptions;
using CuidadosModernos.CrossCutting.Exceptions;
using CuidadosModernos.CrossCutting.Global;
using CuidadosModernos.Domain.Factories.Turnos;
using CuidadosModernos.Domain.Services;
using CuidadosModernos.Domain.Services.Tareas;
using CuidadosModernos.Domain.Tareas;
using CuidadosModernos.Domain.Usuarios;
using CuidadosModernos.Domain.ValueObjects.Turnos;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public virtual DateTime? FechaHoraRealInicio { get; private set; }

        public virtual DateTime? FechaHoraRealFin { get; private set; }

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

        public void AsignarTareas(List<Tarea> tareas,
                                  ITareaTurnoFactory tareaTurnoFactory)
        {
            foreach (var tarea in tareas)
            {
                this.Tareas.Add(tareaTurnoFactory.Crear(this, tarea));
            }

            var tareasEliminar = new List<Tarea>();

            foreach (var tarea in tareas)
            {
                if (this.Tareas.Any(t => t.Tarea.ID == tarea.ID && t.Tarea.HoraRealizacion > DateTime.Now.TimeOfDay))
                {
                    tareasEliminar.Add(tarea);
                }
            }

            this.Tareas.RemoveAll(t => tareasEliminar.Contains(t.Tarea));
        }

        public void RegistrarIngreso(RegistrarIngresoTurno ingreso)
        {
            #region Validaciones
            var validaciones = new ValidationException();

            if (ingreso.Empleada == null)
                validaciones.AddValidationResult(Messages.NoSeEncontroLaEmpleada);

            validaciones.Throw();
            #endregion

            #region Setter

            if (this.Empleada.ID != ingreso.Empleada.ID)
                this.EmpleadaReemplazante = ingreso.Empleada;

            this.FechaHoraRealInicio = ingreso.FechaRealIngreso;

            #endregion
        }

        public void FinalizarTurno(DateTime fechaFin,
                                   IEntityLoaderDomainService entityLoaderDomainService)
        {
            foreach (var tareaTurno in this.ObtenerTareasSinRealizar())
            {
                tareaTurno.MarcarIncumplida(entityLoaderDomainService);
            }

            this.FechaHoraRealFin = fechaFin;
        }

        private List<TareaTurno> ObtenerTareasSinRealizar()
        {
            return this.Tareas.Where(t => t.Estado.ID == EstadosTareaTurno.Asignada).ToList();
        }

    }
}
