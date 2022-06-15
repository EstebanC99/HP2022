MERGE t_Encargada t
USING
(
	SELECT *
	FROM
	(
		VALUES
		(1, 'Maria Eugenia', 'Gironacci', '21525706', '3364532186')
	) i (ID_Encargada, Nombre, Apellido, DNI, Telefono)
) ii ON (ii.ID_Encargada = t.ID_Encargada)
WHEN MATCHED THEN UPDATE SET
	t.Nombre = ii.Nombre,
	t.Apellido = ii.Apellido,
	t.DNI = ii.DNI,
	t.Telefono = ii.Telefono
WHEN NOT MATCHED BY TARGET THEN INSERT
	(ID_Encargada, Nombre, Apellido, DNI, Telefono)
	VALUES
	(ii.ID_Encargada, ii.Nombre, ii.Apellido, ii.DNI, ii.Telefono);