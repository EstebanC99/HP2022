MERGE t_EstadoTareaTurno t
USING
(
	SELECT *
	FROM
	(
		VALUES
		(1, 'Sin Asignar'),
		(2, 'Asignada'),
		(3, 'Realizada'),
		(4, 'Realizada con retraso'),
		(5, 'Incumplida')
	) i (ID_EstadoTareaTurno, Descripcion)
) ii ON (ii.ID_EstadoTareaTurno = t.ID_EstadoTareaTurno)
WHEN MATCHED THEN UPDATE SET
	t.Descripcion = ii.Descripcion
WHEN NOT MATCHED BY TARGET THEN INSERT
	(ID_EstadoTareaTurno, Descripcion)
	VALUES
	(ii.ID_EstadoTareaTurno, Descripcion);