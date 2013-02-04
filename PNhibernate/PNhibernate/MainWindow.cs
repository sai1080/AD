using System;
using Gtk;

using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

using NHibernate;

using Serpis.Ad;


public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		Configuration configuration = new Configuration();
		configuration.Configure();
		configuration.SetProperty(NHibernate.Cfg.Environment.Hbm2ddlKeyWords,"none");
		
		configuration.AddAssembly(typeof(Categoria).Assembly);
		
		new SchemaExport(configuration).Execute(true, false, false);
		//creamos la sesion
		ISessionFactory sessionFactory = configuration.BuildSessionFactory();
		//acceso a la base de datos
		ISession session = sessionFactory.OpenSession();
		//carge el 2L de categoria
		Categoria categoria = (Categoria)session.Load(typeof(Categoria),2L);
			
		Console.WriteLine("Categoria Id={0} Nombre={1}", categoria.Id, categoria.Nombre);
		categoria.Nombre = DateTime.Now.ToString();
		session.SaveOrUpdate (categoria);
		 session.Flush();                         
		session.Close();
		
		sessionFactory.Close();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
