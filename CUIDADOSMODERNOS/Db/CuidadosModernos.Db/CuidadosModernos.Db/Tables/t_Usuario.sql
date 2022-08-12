CREATE TABLE [dbo].[t_Usuario]
(
	[ID_Usuario] INT IDENTITY(1, 1) NOT NULL, 
    [Username] VARCHAR(50) NOT NULL, 
    [Password] VARCHAR(20) NOT NULL, 
    [ID_Persona] INT NOT NULL, 
    [FechaAlta] DATE NOT NULL, 
    [FechaBaja] DATE NULL, 
    [Activo] TINYINT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_t_Usuario] PRIMARY KEY ([ID_Usuario]),
    CONSTRAINT [FK_t_Usuario_t_Persona] FOREIGN KEY ([ID_Persona]) REFERENCES [dbo].[t_Persona]([ID_Persona])
)
