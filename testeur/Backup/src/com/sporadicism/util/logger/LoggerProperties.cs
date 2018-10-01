using System;
using System.Configuration;

namespace com.sporadicism.util.logger
{
	/// <summary>
	/// Reads the properties file and sets default properties.
	/// </summary>
	public class LogProperties
	{
		private String CSHARP_LOGGER_PROPERTIES = "csharp-logger.xml";
		private String LOGGER_ASSEMBLY = "LoggerAssembly";
		private String LOGGER_CLASSNAME = "LoggerClassname";

		/// <summary>
		/// Public accessor for the file that contains all properties
		///		for the logger.
		/// </summary>
		public String LogPropertiesFile { get{return this.CSHARP_LOGGER_PROPERTIES;}}

		private LogActivator formatter = new LogActivator ();
		/// <summary>
		/// Returns the activator object that knows how to create a new 
		///		Formatter.
		/// </summary>
		public LogActivator Formatter 
		{ 
			get {return this.formatter;}
		}
		
		private LogActivator logger = new LogActivator ();
		/// <summary>
		/// Returns the activator object that knows how to create a 
		///		new Logger.
		/// </summary>
		public LogActivator Logger
		{
			get {return this.logger;}
		}

		private Level logLevel = Level.DEBUG;
		/// <summary>
		/// The logging level for the application.
		/// </summary>
		public Level LogLevel 
		{ 
			get {return this.logLevel;}
		}

		/// <summary>
		/// Creates a new instance of <code>LoggerProperties</code>.
		/// </summary>
		public LogProperties ()
		{
			this.logger = getActivator (this.LOGGER_ASSEMBLY, this.LOGGER_CLASSNAME);			
		}

		private LogActivator getActivator (String assembly, String classname)
		{
			LogActivator activator = new LogActivator ();
			AppSettingsReader reader = new AppSettingsReader ();

			activator.Assembly = (String)reader.GetValue (assembly, typeof(String));
			activator.Classname = (String)reader.GetValue (classname, typeof(String));

			return activator;
		}

	}
}
