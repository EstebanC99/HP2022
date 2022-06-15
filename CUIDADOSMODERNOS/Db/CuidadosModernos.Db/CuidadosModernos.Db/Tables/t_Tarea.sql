CREATE TABLE [dbo].[t_Tarea]
(
	[ID_Tarea]                  INT             NOT NULL, 
    [Descripcion]               VARCHAR(200)    NOT NULL, 
    [HoraRealizacion]           TIME            NOT NULL, 
    [FechaInicioVigencia]       DATE            NOT NULL, 
    [FechaFinVigencia]          DATE            NULL, 
    [ID_Frecuencia]             INT             NOT NULL, 
    CONSTRAINT [PK_t_Tarea] PRIMARY KEY ([ID_Tarea]),
    CONSTRAINT [FK_t_Tarea_t_Frecuencia] FOREIGN KEY ([ID_Frecuencia]) REFERENCES [dbo].[t_Frecuencia]([ID_Frecuencia])
)
