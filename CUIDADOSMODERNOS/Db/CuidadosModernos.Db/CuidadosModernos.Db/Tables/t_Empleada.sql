CREATE TABLE [dbo].[t_Empleada]
(
	[ID_Persona]            INT    NOT NULL, 
    [Email]                 VARCHAR(100)        NULL, 
    [ID_Encargada]          INT                 NOT NULL,
    [Activa]                BIT                 NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_t_Empleada] PRIMARY KEY ([ID_Persona]),
    CONSTRAINT [FK_t_Empleada_t_Encargada] FOREIGN KEY ([ID_Encargada]) REFERENCES [dbo].[t_Encargada]([ID_Persona]) ON DELETE CASCADE,
    CONSTRAINT [FK_t_Empleada_t_Persona] FOREIGN KEY ([ID_Persona]) REFERENCES [dbo].[t_Persona]([ID_Persona]) ON UPDATE CASCADE
)
