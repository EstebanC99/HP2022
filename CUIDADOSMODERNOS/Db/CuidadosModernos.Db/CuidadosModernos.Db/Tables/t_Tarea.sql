CREATE TABLE [dbo].[t_Tarea]
(
	[ID_Tarea]          INT             NOT NULL, 
    [Descripcion]       VARCHAR(200)    NOT NULL, 
    [HoraMinima]        TIME            NOT NULL, 
    [HoraMaxima]        TIME            NULL, 
    CONSTRAINT [PK_t_Tarea] PRIMARY KEY ([ID_Tarea]) 
)
