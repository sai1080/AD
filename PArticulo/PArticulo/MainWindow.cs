
using Gtk;
using Npgsql;
using Serpis.Ad;
using System;
using System.Collections.Generic;
using System.Data;
using PArticulo;


public partial class MainWindow: Gtk.Window
{	
	private IDbConnection dbConnection;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		
		string connectionString = "Server=localhost;Database=dbprueba;user Id=dbprueba; Password=sistemas";
		
	    ApplicationContext.Instance.DbConnection = new NpgsqlConnection(connectionString);
		dbConnection = ApplicationContext.Instance.DbConnection;
		dbConnection = open();
		
		IDbCommand dbCommand = ApplicationContext.Instance.DbConnection.CreateCommand();
		dbCommand.CommandText = "select a.id, a.nombre, c.nombre as categoria " +
		        			  	"from articulo a left join categoria c " +
		                    	"on a.categoria = c.id";
		
		IDataReader dataReader = dbCommand.ExecuteReader();//en el datareader esta la informacion de las columnas
		
		TreeViewExtensions.Fill (treeView, dataReader);
		dataReader.Close();
		
		dataReader = dbCommand.ExecuteReader();
		TreeViewExtensions.Fill (treeView, dataReader);
		dataReader.Close();
		
	
		                                     
		                              	                                     
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		ApplicationContext.Instance.DbConnection.Close();
		Application.Quit ();
		a.RetVal = true;
	}
	
	protected  void OnClearActionActivated(object sender, System.EventArgs e)
	{
		ListStore listStore = (ListStore)treeView.Model;
		listStore.Clear();
		
	}

	protected void OnEditActionActivated (object sender, System.EventArgs e)
	{
		long id = getSelectedId();
		
		Console.WriteLine("id={0}", id);

		
		ArticuloView articuloView = new ArticuloView(id);
			
		articuloView.Show();
		
		dataReader.Close();
		
		
	}
	
	private long getSelectedId(){
		TreeIter treeIter;
		treeView.Selection.GetSelected(out treeIter);
		
		ListStore listStore = (ListStore)treeView.Model;
		return long.Parse(listStore.GetValue (treeIter, 0).ToString());
		
	}
	
	

	
}
