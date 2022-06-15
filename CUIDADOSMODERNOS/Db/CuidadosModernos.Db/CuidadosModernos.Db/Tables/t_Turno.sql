CREATE TABLE [dbo].[t_Turno]
(
	[ID_Turno]                  INT         NOT NULL,
    [FechaHoraInicio]           DATETIME    NOT NULL,
    [FechaHoraFin]              DATETIME    NOT NULL, 
    [FechaHoraRealInicio]       DATETIME    NOT NULL,
    [FechaHoraRealFin]          DATETIME    NOT NULL, 
    [ID_Empleada]               INT         NOT NULL, 
    [ID_Empleada_Reemplazante]  INT         NULL, 
    CONSTRAINT [FK_t_Turno_t_Empleada] FOREIGN KEY (ID_Empleada) REFERENCES [dbo].[t_Empleada](ID_Empleada),
    CONSTRAINT [FK_t_Turno_t_Empleada_Reemplazo] FOREIGN KEY (ID_Empleada_Reemplazante) REFERENCES [dbo].[t_Empleada](ID_Empleada), 
    CONSTRAINT [PK_t_Turno] PRIMARY KEY ([ID_Turno])
)
