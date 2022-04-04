CREATE TABLE [dbo].[t_EstadoTareaEmpleada]
(
	[ID_EstadoTareaEmpleada]    INT         NOT NULL, 
    [Descripcion]               VARCHAR(50) NULL, 
    CONSTRAINT [PK_t_EstadoTareaEmpleada] PRIMARY KEY ([ID_EstadoTareaEmpleada]) 
)
