CREATE TABLE [dbo].[t_Tarea]
(
	[ID_Tarea]                  INT IDENTITY(1, 1)  NOT NULL,
    [Titulo]                    VARCHAR(50)         NOT NULL,
    [Descripcion]               VARCHAR(200)        NOT NULL, 
    [HoraRealizacion]           TIME                NOT NULL, 
    [FechaInicioVigencia]       DATE                NOT NULL, 
    [FechaFinVigencia]          DATE                NULL, 
    [ID_Frecuencia]             INT                 NOT NULL, 
    [Activa]                    BIT                 NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_t_Tarea] PRIMARY KEY ([ID_Tarea]),
    CONSTRAINT [FK_t_Tarea_t_Frecuencia] FOREIGN KEY ([ID_Frecuencia]) REFERENCES [dbo].[t_Frecuencia]([ID_Frecuencia])
)
