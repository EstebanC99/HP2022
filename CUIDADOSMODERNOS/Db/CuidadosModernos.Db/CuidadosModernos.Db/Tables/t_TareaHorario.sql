CREATE TABLE [dbo].[t_TareaHorario]
(
	[ID_TareaHorario]   INT NOT NULL , 
    [ID_Tarea]          INT NOT NULL, 
    [ID_Horario]        INT NOT NULL, 
    CONSTRAINT [PK_t_TareaHorario] PRIMARY KEY ([ID_TareaHorario]),
    CONSTRAINT [FK_t_Tarea_TareaHorario] FOREIGN KEY (ID_Tarea) REFERENCES [dbo].[t_Tarea](ID_Tarea),
    CONSTRAINT [FK_t_Horario_TareaHorario] FOREIGN KEY (ID_Horario) REFERENCES [dbo].[t_Horario](ID_Horario)
)
