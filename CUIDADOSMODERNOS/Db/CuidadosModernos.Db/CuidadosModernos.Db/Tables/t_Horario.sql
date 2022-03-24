CREATE TABLE [dbo].[t_Horario]
(
	[ID_Horario]        INT     NOT NULL , 
    [HoraInicio]        TIME    NOT NULL, 
    [HoraFin]           TIME    NOT NULL, 
    CONSTRAINT [PK_t_Horario] PRIMARY KEY ([ID_Horario]), 
    
)
