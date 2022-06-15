CREATE TABLE [dbo].[t_Empleada]
(
	[ID_Empleada]           INT IDENTITY(1, 1)  NOT NULL, 
    [Nombre]                VARCHAR(50)         NOT NULL, 
    [Apellido]              VARCHAR(50)         NOT NULL, 
    [DNI]                   VARCHAR(8)          NOT NULL, 
    [Email]                 VARCHAR(100)        NULL, 
    [Telefono]              VARCHAR(11)         NULL,
    [Usuario]               VARCHAR(50)         NULL,
    [Password]              VARCHAR(50)         NULL,
    [ID_Encargada]          INT                 NOT NULL,
    CONSTRAINT [PK_t_Empleada] PRIMARY KEY ([ID_Empleada]),
    CONSTRAINT [FK_t_Empleada_t_Encargada] FOREIGN KEY ([ID_Encargada]) REFERENCES [dbo].[t_Encargada]([ID_Encargada])
)
