SET IDENTITY_INSERT t_Persona ON;
MERGE t_Persona t
USING
(
	SELECT *
	FROM
	(
		VALUES
		(1, 'Maria Eugenia', 'Gironacci', '21525706', '3364532186')
	) i (ID_Persona, Nombre, Apellido, DNI, Telefono)
) ii ON (ii.ID_Persona = t.ID_Persona)
WHEN MATCHED THEN UPDATE SET
	t.Nombre = ii.Nombre,
	t.Apellido = ii.Apellido,
	t.DNI = ii.DNI,
	t.Telefono = ii.Telefono
WHEN NOT MATCHED BY TARGET THEN INSERT
	(ID_Persona, Nombre, Apellido, DNI, Telefono)
	VALUES
	(ii.ID_Persona, ii.Nombre, ii.Apellido, ii.DNI, ii.Telefono);
SET IDENTITY_INSERT t_Persona OFF;