using System;
using System.Collections.Generic;

namespace Serpis.Ad
{
	public class TypeExtensions//referentes a los tipos
	{
		/// <summary>
		/// devuelve el array conteniendo el tipo indicado(type) las veces indicadas(count)
		/// </summary>
		
		public static Type[] GetTypes(Type type, int count)
		{
			List<Type> types = new List<Type>();
			for(int i = 0; i<count; i++)
				types.Add(type);
			return types.ToArray();
		}
	}
}

