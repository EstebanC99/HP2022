MERGE t_RolUsuario t
USING
(
	SELECT *
	FROM
	(
		VALUES
		(1, 'Encargada'), 
		(2, 'Empleada')
	) i (ID_RolUsuario, Descripcion)
) ii ON (ii.ID_RolUsuario = t.ID_RolUsuario)
WHEN MATCHED THEN UPDATE SET
	t.Descripcion = ii.Descripcion
WHEN NOT MATCHED BY TARGET THEN INSERT
	(ID_RolUsuario, Descripcion)
	VALUES
	(ii.ID_RolUsuario, ii.Descripcion);