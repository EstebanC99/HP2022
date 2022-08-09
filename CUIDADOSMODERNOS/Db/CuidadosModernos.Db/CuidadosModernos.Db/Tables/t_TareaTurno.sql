CREATE TABLE [dbo].[t_TareaTurno]
(
	[ID_TareaTurno]         INT IDENTITY (1, 1) NOT NULL, 
    [FechaHoraRealizacion]  DATETIME NULL, 
    [Comentario]            VARBINARY(MAX) NULL, 
    [ID_Estado]             INT NOT NULL, 
    [ID_Turno]              INT NOT NULL, 
    [ID_Tarea]              INT NOT NULL, 
    CONSTRAINT [PK_t_TareaTurno] PRIMARY KEY ([ID_TareaTurno]),
    CONSTRAINT [FK_t_EstadoTareaTurno_t_TareaTurno] FOREIGN KEY (ID_Estado) REFERENCES [dbo].[t_EstadoTareaTurno](ID_EstadoTareaTurno),
    CONSTRAINT [FK_t_Turno_t_TareaTurno] FOREIGN KEY (ID_Turno) REFERENCES [dbo].[t_Turno](ID_Turno),
    CONSTRAINT [FK_t_Tarea_t_TareaTurno] FOREIGN KEY (ID_Tarea) REFERENCES [dbo].[t_Tarea](ID_Tarea)
)
