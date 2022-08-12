CREATE TABLE [dbo].[t_Turno]
(
	[ID_Turno]                  INT         IDENTITY (1, 1) NOT NULL,
    [FechaHoraInicio]           DATETIME    NOT NULL,
    [FechaHoraFin]              DATETIME    NOT NULL, 
    [FechaHoraRealInicio]       DATETIME    NULL,
    [FechaHoraRealFin]          DATETIME    NULL, 
    [ID_Empleada]               INT         NOT NULL, 
    [ID_Empleada_Reemplazante]  INT         NULL, 
    CONSTRAINT [FK_t_Turno_t_Empleada] FOREIGN KEY (ID_Empleada) REFERENCES [dbo].[t_Empleada]([ID_Persona]),
    CONSTRAINT [FK_t_Turno_t_Empleada_Reemplazo] FOREIGN KEY (ID_Empleada_Reemplazante) REFERENCES [dbo].[t_Empleada]([ID_Persona]), 
    CONSTRAINT [PK_t_Turno] PRIMARY KEY ([ID_Turno])
)
