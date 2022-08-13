MERGE t_Usuario t
USING
(
	SELECT i.ID_Persona, p.Nombre, p.Apellido, p.DNI
	FROM
	t_Encargada i 
	INNER JOIN t_Persona p ON p.ID_Persona = i.ID_Persona
) ii ON (ii.ID_Persona = t.ID_Persona)
WHEN NOT MATCHED BY TARGET THEN INSERT
	(Username, Password, ID_Persona, FechaAlta, ID_RolUsuario)
	VALUES
	(LOWER(CONCAT(SUBSTRING(ii.Nombre, 1,1), ii.Apellido)), ii.DNI, ii.ID_Persona, GETDATE(), 1);