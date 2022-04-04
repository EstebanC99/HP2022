CREATE TABLE [dbo].[t_TareaHorario]
(
	[ID_TareaEmpleada]          INT         NOT NULL , 
    [ID_Tarea]                  INT         NULL, 
    [ID_Empleada]               INT         NULL, 
    [FechaHoraRealizacion]      DATETIME    NULL, 
    [ID_EstadoTareaEmpleada]    INT         NULL, 
    CONSTRAINT [PK_t_TareaEmpleada] PRIMARY KEY ([ID_TareaEmpleada]),
    CONSTRAINT [FK_t_Tarea_t_TareaEmpleada] FOREIGN KEY (ID_Tarea) REFERENCES [dbo].[t_Tarea](ID_Tarea),
    CONSTRAINT [FK_t_Empleada_t_TareaEmpleada] FOREIGN KEY (ID_Empleada) REFERENCES [dbo].[t_Horario]([ID_Turno]),
    CONSTRAINT [FK_t_EstadoTareaEmpleada_t_TareaEmpleada] FOREIGN KEY (ID_EstadoTareaEmpleada) REFERENCES [dbo].[t_EstadoTareaEmpleada]([ID_EstadoTareaEmpleada])
)
