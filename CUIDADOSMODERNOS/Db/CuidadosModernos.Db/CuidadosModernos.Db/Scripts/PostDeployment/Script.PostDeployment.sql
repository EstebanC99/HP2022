﻿/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
:r .\t_RolUsuario.sql
:r .\t_EstadoTareaTurno.sql
:r .\t_Persona.sql
:r .\t_Encargada.sql
:r .\t_Usuario.sql
:r .\t_Frecuencia.sql
