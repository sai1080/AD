using System;
using Gtk;
using Npgsql;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		treeView.Selection.Mode = SelectionMode.Multiple;//seleccion multiple de item
		
		
		treeView.AppendColumn("Columna uno",new CellRendererText(),"text",0);
		treeView.AppendColumn("Columna dos",new CellRendererText(),"text",1);
		treeView.AppendColumn("Columna tres",new CellRendererText(),"text",2);
		
		ListStore listStore = new ListStore(typeof(string), typeof(string), typeof(string));
		
		treeView.Model = listStore;
		
		listStore.AppendValues("clave uno", "valor uno", "uno");
		listStore.AppendValues("clave dos", "valor dos", "dos");
		listStore.AppendValues("clave tres", "valor tres", "tres");
		listStore.AppendValues("clave cuatro", "valor cuatro", "cuatro");
		
		treeView.Selection.Changed += delegate {//añade la ocurrencia del metodo al evento
			int count = treeView.Selection.CountSelectedRows();
			Console.WriteLine("treeView.Selection.Changed CountSelectedRows={0}", count);

			treeView.Selection.SelectedForeach(delegate(TreeModel model, TreePath path, TreeIter iter)
			{
				object value = listStore.GetValue(iter, 0);
				Console.WriteLine("value={0}", value);
			});	
	  	};
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
