using System;

namespace com.sporadicism.util.logger
{
	/// <summary>
	/// Summary description for ObjectCreator.
	/// </summary>
	public class LogActivator
	{
		private String assembly;
		private String classname;

		/// <summary>
		/// Assembly to search for object in.
		/// </summary>
		public String Assembly 
		{
			get {return this.assembly;}
			set {this.assembly = value;}
		}
		/// <summary>
		/// Class name of file we will create an object for.
		/// </summary>
		public String Classname
		{
			get {return this.classname;}
			set {this.classname = value;}
		}

		/// <summary>
		/// Creates a new instance of an object specified by the <code>assembly</code>
		///		and the <code>classname</code> of that object.
		/// </summary>
		public LogActivator ()
		{
		}

		/// <summary>
		/// Creates a new instance of the object specified by the 
		///		<code>Assembly</code> and <code>Classname</code>
		///		properties.
		/// </summary>
		/// <returns></returns>
		public object activate ()
		{
			System.Runtime.Remoting.ObjectHandle handle =
				System.Activator.CreateInstance (this.Assembly, this.Classname);
			return handle.Unwrap ();
		}
	}
}
