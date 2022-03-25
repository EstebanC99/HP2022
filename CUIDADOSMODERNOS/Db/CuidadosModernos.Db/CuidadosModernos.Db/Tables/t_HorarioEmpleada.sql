CREATE TABLE [dbo].[t_HorarioEmpleada]
(
	[ID_HorarioEmpleada]    INT     NOT NULL , 
    [ID_Empleada]           INT     NOT NULL, 
    [ID_Horario]            INT     NOT NULL, 
    [DiaVigencia]           DATE    NOT NULL, 
    CONSTRAINT [PK_t_HorarioEmpleada] PRIMARY KEY ([ID_HorarioEmpleada]),
    CONSTRAINT [FK_t_Empleada_t_HorarioEmpleada] FOREIGN KEY (ID_Empleada) REFERENCES [dbo].[t_Empleada](ID_Empleada),
    CONSTRAINT [FK_t_Horario_t_HorarioEmpleada] FOREIGN KEY (ID_Horario) REFERENCES [dbo].[t_Horario](ID_Horario)
)
