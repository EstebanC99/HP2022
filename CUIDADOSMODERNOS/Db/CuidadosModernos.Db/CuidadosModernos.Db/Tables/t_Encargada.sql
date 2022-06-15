CREATE TABLE [dbo].[t_Encargada]
(
	[ID_Encargada]      INT                 NOT NULL , 
    [Nombre]            VARCHAR(50)         NOT NULL, 
    [Apellido]         VARCHAR(50)         NOT NULL, 
    [DNI]               VARCHAR(8)          NOT NULL, 
    [Telefono]          VARCHAR(11)         NOT NULL, 
    CONSTRAINT [PK_t_Encargada] PRIMARY KEY ([ID_Encargada])
)
