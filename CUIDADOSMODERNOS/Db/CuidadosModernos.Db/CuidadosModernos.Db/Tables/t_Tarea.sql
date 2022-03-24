CREATE TABLE [dbo].[t_Tarea]
(
	[ID_Tarea]          INT             NOT NULL, 
    [Descripcion]       VARCHAR(200)    NOT NULL, 
    [Hora]              TIMESTAMP       NOT NULL, 
    CONSTRAINT [PK_t_Tarea] PRIMARY KEY ([ID_Tarea]) 
)
