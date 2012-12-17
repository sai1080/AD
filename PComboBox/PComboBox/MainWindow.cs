using System;
using Gtk;

public delegate int MyFunction (int a, int b);

public partial class MainWindow: Gtk.Window
{	
	//private ListStore listStore;//esta variable es el campo y asi acceder a varios metodos.
	
	public event MyFunction NombreDelEvento;
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		
		Build ();
		
//		MyFunction[] funtions = new MyFunction[]{suma, resta, multiplica};
//		
//		int random = new Random().Next(3);
//		
//		f = functions [random];
//		
//		
//		
//		Console.WriteLine("f={0}", f(5,3));
		
		
		CellRenderer cellRenderer = new CellRendererText();//crea(dibuja) celda de texto
		comboBox.PackStart(cellRenderer, false); //expand=false
		comboBox.AddAttribute (cellRenderer, "text", 1);
		
		ListStore listStore = new ListStore(typeof(string), typeof(string));//creo dos columnas id y nombre
		comboBox.Model = listStore;
		
		listStore.AppendValues("1", "Uno");
		listStore.AppendValues("2", "Dos");
		
//		comboBox.Changed += delegate //se ejecuta solo cuando hay un cambio
//		{
//			
//			TreeIter treeIter;
//			if(	comboBox.GetActiveIter(out treeIter))//item seleccionado
//			{
//				object value = listStore.GetValue(treeIter, 0);//tenemos el indice y la columna
//				//en esta variable guardo el valor de la columna y lo muestro
//				Console.WriteLine("comboBox.Changed delegate value={0}", value);
//			}
//			
//		};
	
		comboBox.Changed += comboBoxChanged;
		
		}
		
//			private int suma(int a, int b)
//			{
//				return a + b;
//			}
//			
//			private int resta(int a, int b)
//			{
//				return a - b;
//			}
//			
//			private int multiplica(int a, int b)
//			{
//				return a * b;
//			}
//		
	
	
	
	
     private void comboBoxChanged(object obj, EventArgs args)
	{
			ListStore listStore = (ListStore)comboBox.Model;
			
			TreeIter treeIter;
			if(	comboBox.GetActiveIter(out treeIter))//item seleccionado
			{
				object value = listStore.GetValue(treeIter, 0);//tenemos el indice y la columna
				//en esta variable guardo el valor de la columna y lo muestro
				Console.WriteLine("comboBox.Changed value={0}", value);
			}
	}
		
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
