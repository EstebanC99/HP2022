CREATE TABLE [dbo].[t_Horario]
(
	[ID_Turno]              INT         NOT NULL,
    [ID_Empleada]           INT         NULL,
    [FechaHoraInicio]       DATETIME    NOT NULL, 
    [FechaHoraFin]          DATETIME    NOT NULL,
    CONSTRAINT [PK_t_Horario] PRIMARY KEY ([ID_Turno]), 
    CONSTRAINT [FK_t_Turno_t_Empleada] FOREIGN KEY (ID_Empleada) REFERENCES [dbo].[t_Empleada](ID_Empleada)
)
