CREATE TABLE [dbo].[t_Persona]
(
	[ID_Persona]        INT IDENTITY(1, 1)  NOT NULL, 
	[Nombre]            VARCHAR(50)         NOT NULL, 
    [Apellido]          VARCHAR(50)         NOT NULL, 
    [DNI]               VARCHAR(8)          NOT NULL, 
    [Telefono]          VARCHAR(11)         NOT NULL, 
    CONSTRAINT [PK_t_Persona] PRIMARY KEY ([ID_Persona]) 
)
