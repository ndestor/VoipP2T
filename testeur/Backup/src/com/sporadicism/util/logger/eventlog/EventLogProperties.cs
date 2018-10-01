using System;

namespace com.sporadicism.util.logger.eventlog
{
	/// <summary>
	/// This class is used to get the event log property information from
	///		the properties file.  The 
	/// </summary>
	public class EventLogProperties
	{
		private String logName = "Application";
		private String source = "Logger";
		private String machineName = ".";

		/// <summary>					 
		/// The name of the application log that events will be logged to.
		/// </summary>
		public String LogName 
		{
			get{return this.logName;}
			set{this.logName = value;}
		}
		/// <summary>
		/// The name of the event source.
		/// </summary>
		public String Source 
		{
			get{return this.source;}
			set{this.source = value;}
		}
		/// <summary>
		/// The machine to log the event to.
		/// </summary>
		public String MachineName 
		{
			get{return this.machineName;}
			set{this.machineName = value;}
		}

		/// <summary>
		/// Creates a new instance of the event log properties.
		/// </summary>
		public EventLogProperties()
		{
		}
	}
}
