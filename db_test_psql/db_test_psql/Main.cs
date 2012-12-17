using System;
using NpgsqlTypes;
using Npgsql;
using System.Data;

namespace db_test_psql
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			
			
			
			// Crear la cadena de conexion
			
			NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;Database=dbprueba;User id=dbprueba;Password=sistemas;");
			
			
			String sql = "select  a.nombre, a.precio,c.nombre as categoria from articulo a, categoria c where c.id=a.categoria";
			
			NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
			
			//NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sql, conn);
			//adapter.
			conn.Open();
			
			NpgsqlDataReader lector = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
			
			//cmd.ExecuteReader(CommandBehavior.SequentialAccess
			
			while (lector.NextResult()) 
			{
				String nombreArticulo = lector.GetString(0);
				double  precio        = lector.GetDouble(1);
				String nombreCat      = lector.GetString(2);
				
				Console.WriteLine("{0}\t{1}\t{2}", nombreArticulo, precio, nombreCat);
			}
			
			conn.Close();
			
			Console.WriteLine("FIN");
		}
	}
}
