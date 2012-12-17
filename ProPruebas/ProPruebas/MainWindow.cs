using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void click (object sender, System.EventArgs e)
	{
		//throw new System.NotImplementedException ();
		//label1.Text="Hola Mundo";
		MessageDialog dialogo;
		dialogo = new MessageDialog(this, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, "MENSAJE DE ERROR");
		dialogo.Run();
		dialogo.Destroy();

	}
}
