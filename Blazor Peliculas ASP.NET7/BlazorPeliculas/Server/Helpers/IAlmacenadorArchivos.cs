﻿namespace BlazorPeliculas.Server.Helpers
{
	public interface IAlmacenadorArchivos
	{
		Task<string> GuardarAchivo(byte[] contenido, string extension, string nombreContenedor);
		Task EliminarArchivo(string ruta, string nombreContenedor);
		async Task<string> EditarArchivo(byte[] contenido, string extension, string nombreContenedor, string ruta)
		{
			if (ruta is not null)
			{
				await EliminarArchivo(ruta, nombreContenedor);
			}
			return await GuardarAchivo(contenido, extension, nombreContenedor);
		}
	}
}
