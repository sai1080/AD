using System;
using System.IO;
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

	protected void OnOpenActionActivated (object sender, System.EventArgs e)
	{
		FileChooserDialog fileChooserDialog =
			new FileChooserDialog("Abrir archivo", null, FileChooserAction.Open,
			                      Stock.Cancel, ResponseType.Cancel,
			                      Stock.Open, ResponseType.Accept);
		ResponseType response = (ResponseType)fileChooserDialog.Run();
		if(response == ResponseType.Accept)
			textview1.Buffer.Text = File.ReadAllText(fileChooserDialog.Filename);
		fileChooserDialog.Destroy();
		//throw new System.NotImplementedException ();
	}

	

	protected void OnNewActionActivated (object sender, System.EventArgs e)
	{
		textview1.Buffer.Text="";
		Console.WriteLine ("newAction activaded!");
		//throw new System.NotImplementedException ();
	}

	
}
