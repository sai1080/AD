using Gtk;
using System;

namespace PArticulo
{
	public partial class ArticuloView : Gtk.Window
	{
		public ArticuloView () : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
		
		
			
			
		public string Nombre {
			get {return entryNombre.Text;}
				set {entryNombre.Text = value;}
			}
			
		public double Precio {
				get{return Convert.ToDecimal(spinButtonPrecio.Value);}
				set{spinButtonPrecio.Value = Convert.ToDouble(value);}
			}
		
		public long Categoria{
			set{
				
			}
		}
		
		public Gtk.Action SaveAction {
			get {return saveAction;}
		}
		
			
		
	}
}

