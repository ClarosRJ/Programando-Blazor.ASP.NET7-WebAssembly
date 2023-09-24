using Microsoft.EntityFrameworkCore;

namespace BlazorPeliculas.Server.Helpers
{
	public static class HttpContextExtensions
	{
		public async static Task InsertarParametrosPaginacionEnRespuesta<T>(
			this HttpContext context, IQueryable<T> queryable,int cantidadRegistroAMostrar)
		{
			if (context is null )
			{
				throw new ArgumentNullException(nameof(context));
			}

			double conteo = await queryable.CountAsync();
			double totalPaginas = Math.Ceiling(conteo / cantidadRegistroAMostrar);
			context.Response.Headers.Add("conteo", conteo.ToString());
			context.Response.Headers.Add("totalPaginas", totalPaginas.ToString());
		}
	}
}
