CREATE TABLE [dbo].[t_Nota]
(
	[ID_Nota]		        INT			NOT NULL, 
    [FechaHoraCreacion]     DATETIME NOT NULL, 
    [FechaHoraRealizacion]  DATETIME NOT NULL, 
    [Descripcion]           VARCHAR(50) NULL, 
    [Urgente]               BIT NOT NULL DEFAULT 0, 
    [ID_Empleada]           INT NOT NULL, 
    CONSTRAINT [PK_t_Nota] PRIMARY KEY ([ID_Nota]),
    CONSTRAINT [FK_t_Nota_t_Empleada] FOREIGN KEY ([ID_Empleada]) REFERENCES [dbo].[t_Empleada]([ID_Persona])
)
