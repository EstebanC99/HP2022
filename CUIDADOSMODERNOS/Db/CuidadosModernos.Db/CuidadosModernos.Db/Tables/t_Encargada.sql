CREATE TABLE [dbo].[t_Encargada]
(
	[ID_Persona]      INT NOT NULL 
    CONSTRAINT [PK_t_Encargada] PRIMARY KEY ([ID_Persona]),
	CONSTRAINT [FK_t_Encargada_t_Persona] FOREIGN KEY ([ID_Persona]) REFERENCES [dbo].[t_Persona]([ID_Persona]) ON UPDATE CASCADE ON DELETE CASCADE
)
