using System;
using Gtk;
using npgsql;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		
		treeView.AppendColumn("Columna uno",new CellRendererText(),"text",0);
		treeView.AppendColumn("Columna dos",new CellRendererText(),"text",1);
		
		ListStore listStore = new ListStore(typeof(string), typeof(string));
		
		treeView.Model = listStore;
		
		listStore.AppendValues("clave uno", "valor uno");
		listStore.AppendValues("clave dos", "valor dos");
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
