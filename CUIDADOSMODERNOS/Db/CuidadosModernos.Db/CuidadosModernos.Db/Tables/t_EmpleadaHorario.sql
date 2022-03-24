CREATE TABLE [dbo].[t_EmpleadaHorario]
(
	[ID_EmpleadaHorario]    INT     NOT NULL , 
    [ID_Empleada]           INT     NOT NULL, 
    [ID_Horario]            INT     NOT NULL, 
    [DiaVigencia]           DATE    NOT NULL, 
    CONSTRAINT [PK_t_EmpleadaHorario] PRIMARY KEY ([ID_EmpleadaHorario]),
    CONSTRAINT [FK_t_Empleada_t_EmpleadaHorario] FOREIGN KEY (ID_Empleada) REFERENCES [dbo].[t_Empleada](ID_Empleada),
    CONSTRAINT [FK_t_Horario_t_EmpleadaHorario] FOREIGN KEY (ID_Horario) REFERENCES [dbo].[t_Horario](ID_Horario)
)
