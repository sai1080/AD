using System;

namespace Serpis.Ad
{
	public class Articulo
	{
		public virtual long Id {get; set;}
		public virtual string Nombre {get; set;}
		public virtual decimal Precio {get; set;}
		//TODO propiedades Categoria
		public virtual int Categoria{get; set;}
	}
}

