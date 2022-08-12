MERGE t_Encargada t
USING
(
	SELECT *
	FROM
	t_Persona i 
) ii ON (ii.ID_Persona = t.ID_Persona)
WHEN NOT MATCHED BY TARGET THEN INSERT
	(ID_Persona)
	VALUES
	(ii.ID_Persona);