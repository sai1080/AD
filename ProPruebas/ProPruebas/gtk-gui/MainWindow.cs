
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.VBox saludo;
	private global::Gtk.Label label1;
	private global::Gtk.Button Saludo;
	
	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.saludo = new global::Gtk.VBox ();
		this.saludo.Name = "saludo";
		this.saludo.Spacing = 6;
		this.saludo.BorderWidth = ((uint)(180));
		// Container child saludo.Gtk.Box+BoxChild
		this.label1 = new global::Gtk.Label ();
		this.label1.Name = "label1";
		this.saludo.Add (this.label1);
		global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.saludo [this.label1]));
		w1.Position = 0;
		w1.Expand = false;
		w1.Fill = false;
		// Container child saludo.Gtk.Box+BoxChild
		this.Saludo = new global::Gtk.Button ();
		this.Saludo.CanFocus = true;
		this.Saludo.Name = "Saludo";
		this.Saludo.UseUnderline = true;
		this.Saludo.Label = global::Mono.Unix.Catalog.GetString ("enviar");
		this.saludo.Add (this.Saludo);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.saludo [this.Saludo]));
		w2.Position = 1;
		w2.Expand = false;
		w2.Fill = false;
		this.Add (this.saludo);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 444;
		this.DefaultHeight = 441;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.Saludo.Clicked += new global::System.EventHandler (this.click);
	}
}
