MERGE t_Frecuencia t
USING
(
	SELECT *
	FROM
	(
		VALUES
		(1, 'Diariamente'),
		(2, 'Dia por medio'),
		(3, 'Semanalmente')
	) i (ID_Frecuencia, Descripcion)
) ii ON (ii.ID_Frecuencia = t.ID_Frecuencia)
WHEN MATCHED THEN UPDATE SET
	t.Descripcion = ii.Descripcion
WHEN NOT MATCHED BY TARGET THEN INSERT
	(ID_Frecuencia, Descripcion)
	VALUES
	(ii.ID_Frecuencia, Descripcion);