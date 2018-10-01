using System;

namespace com.sporadicism.util.logger
{
	/// <summary>
	/// Level stores the default logging level for the application.
	///		All loggers have to know what logging level the application
	///		is currently defined at.
	/// </summary>
	public class Level
	{
		/// <summary>
		/// The <code>DEBUG</code> level designates the level used to 
		/// debug the system and to help in resolving issues surrounding
		/// an application's malfunction.
		/// </summary>
		public static Level DEBUG { get {return new Level ();} }

		/// <summary>
		/// The <code>INFO</code> logging level designates events that
		///	are useful in monitoring events that are significant
		///	in an application life cycle.
		/// </summary>
		public static Level INFO {get {return new Level();}}

		/// <summary>
		/// the <code>WARN</code> level designates events that might
		/// be harmful to system stability.
		/// </summary>
		public static Level WARN {get {return new Level ();}}
		/// <summary>
		/// The <code>ERROR</code> level designates error events that
		/// might still allow the application to continue running.
		/// </summary>
		public static Level ERROR {get {return new Level ();}}

		/// <summary>
		/// Default constructor for the level object.  This constructor
		///		is called by the constant properties defining the logging
		///		levels.
		/// </summary>
		protected Level()
		{
		}
	}
}
