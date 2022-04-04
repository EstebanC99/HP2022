MERGE t_EstadoTareaEmpleada t
USING
(
	SELECT *
	FROM
	(
		VALUES
		(1, 'Sin Asignar'),
		(2, 'Asignada'),
		(3, 'Realizada a tiempo'),
		(4, 'Realizada fuera de tiempo'),
		(5, 'Incumplida')
	) i (ID_EstadoTareaEmpleada, Descripcion)
) ii ON (ii.ID_EstadoTareaEmpleada = t.ID_EstadoTareaEmpleada)
WHEN MATCHED THEN UPDATE SET
	t.Descripcion = ii.Descripcion
WHEN NOT MATCHED BY TARGET THEN INSERT
	(ID_EstadoTareaEmpleada, Descripcion)
	VALUES
	(ii.ID_EstadoTareaEmpleada, Descripcion);