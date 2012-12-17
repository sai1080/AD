using System;
using System.IO;
using System.Windows.Forms;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		_btOpen.Clicked += new EventHandler (clickOpen);
		
		
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Gtk.Application.Quit ();
		a.RetVal = true;
	}
	
	protected void clickOpen(object sender, EventArgs e)
	{
		OpenFileDialog ofd = new OpenFileDialog();
		ofd.Filter = "ficheros de texto |*.txt|Todos los ficheros|*.*";
		
		
		
		if(ofd.ShowDialog() == DialogResult.OK)
		{
			String filename = ofd.FileName;
			
			String texto = File.ReadAllText(filename);
			
			
			
			this._txtTexto.Buffer.Text = texto;
		}
		
		
		ofd.Dispose();
	}
}
