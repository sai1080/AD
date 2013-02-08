using Gtk;
using System;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernate;
using Serpis.Ad;
using System.Collections;


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

		ISessionFactory sessionFactory = configuration.BuildSessionFactory();

		//modifico la categoria 2
		//updateCategoria (sessionFactory);
		
		//insertCategoria(sessionFactory);
		
		//loadArticulo(sessionFactory);
		
		//el using es equivalente a un try/finally(
		using (ISession session = sessionFactory.OpenSession()){		
			ICriteria criteria = session.CreateCriteria (typeof(Articulo));
			criteria.SetFetchMode("Categoria", FetchMode.Join);
			IList list = criteria.List();
			foreach(Articulo articulo in list)
				Console.WriteLine("Articulo Id{0} Nombre={1} Precio{2} Categoria={3}",	
				                  articulo.Id, articulo.Nombre, articulo.Precio, articulo.Categoria);
		} 
		
		
		sessionFactory.Close();
	}
	
		private void loadArticulo(ISessionFactory sessionFactory){
	
		using (ISession session = sessionFactory.OpenSession()){
			Articulo articulo = (Articulo)session.Load(typeof(Articulo), 2L);
			Console.WriteLine("Articulo Id={0} Nombre={1} Precio={2} ",
			              articulo.Id, articulo.Nombre, articulo.Precio);
			if(articulo.Categoria == null)
				Console.WriteLine("Categoria=null");
			else
				Console.WriteLine("Categoria.Id{0}", articulo.Categoria.Id);
				//Console.WriteLine("Categoria.Nombre{0}", articulo.Categoria.Nombre);
		}
	}
	
	private void updateCategoria(ISessionFactory  sessionFactory){
		ISession session = sessionFactory.OpenSession();
		try{
			Categoria categoria = (Categoria)session.Load(typeof(Categoria),2L);			
			Console.WriteLine("Categoria Id={0} Nombre={1}", categoria.Id, categoria.Nombre);
			categoria.Nombre = DateTime.Now.ToString();
			session.SaveOrUpdate (categoria);
			session.Flush();  
		} finally {
			session.Close();
		}
	}
	
	/*private void insertCategoria(ISessionFactory sessionFactory){
		ISession session = sessionFactory.OpenSession();
		try{
			Categoria categoria = new Categoria();
			categoria.Nombre = "Nueva " + DateTime.Now.ToString();
			session.SaveOrUpdate (categoria);
			session.Flush(); 
		} finally {
			session.Close();
		}
	}*/
	
	//con using tenemos un idisposable y compila como si fuera un try/finally
	private void insertCategoria(ISessionFactory sessionFactory){
		using (ISession session = sessionFactory.OpenSession()) {		
			Categoria categoria = new Categoria();
			categoria.Nombre = "Nueva " + DateTime.Now.ToString();
			session.SaveOrUpdate (categoria);
			session.Flush(); 	
		}
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
