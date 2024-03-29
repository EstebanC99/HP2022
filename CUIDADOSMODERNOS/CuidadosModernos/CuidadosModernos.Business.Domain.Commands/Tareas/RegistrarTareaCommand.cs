﻿using Cross.Business.Domain.Commands;
using System;

namespace CuidadosModernos.Business.Domain.Commands.Tareas
{
    public class RegistrarTareaCommand : Command<int>
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public TimeSpan HoraRealizacion { get; set; }
        public DateTime FechaInicioVigencia { get; set; }
        public DateTime? FechaFinVigencia { get; set; }
        public int FrecuenciaID { get; set; }
    }
}
