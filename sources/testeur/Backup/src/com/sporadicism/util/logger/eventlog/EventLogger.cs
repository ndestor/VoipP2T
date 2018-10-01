using System;
using System.Diagnostics;

namespace com.sporadicism.util.logger.eventlog
{
	/// <summary>
	/// Summary description for EventLogger.
	/// </summary>
	public class EventLogger : ILogger
	{
		private Level logLevel;

		private EventLogProperties properties;
		private EventLog eventLog;

		/// <summary>
		/// The level to be applied to the application logging.
		/// </summary>
		public Level LogLevel
		{
			get {return this.logLevel;}
			set {this.logLevel = value;}
		}

		/// <summary>
		/// Creates a new instance of the event logger.
		/// </summary>
		public EventLogger()
		{
			this.properties = new EventLogProperties ();
			this.createEventLog (this.properties.LogName, 
				this.properties.MachineName, this.properties.Source);
		}

		/// <summary>
		/// Returns an instance of the event logger.
		/// </summary>
		public  ILogger getInstance ()
		{
			ILogger logger = 
				new EventLogger ();

			return logger;
		}

		private void createEventLog (String log, String machine, String source)
		{
			this.eventLog = new EventLog ();

			if ( String.Empty == 
				EventLog.LogNameFromSourceName (source, machine))
			{
				this.createEventSource (log, machine, source);
			}

			this.eventLog.Source = source;
			this.eventLog.MachineName = machine;

			this.eventLog = eventLog;
		}

		/// <summary>
		/// Creates an event source if it is not already associated with a log
		/// </summary>
		/// <param name="machine">Machine the event occurred on</param>
		/// <param name="source">Source of the event</param>
		/// <param name="log">Name of the log to be logged to</param>
		private void createEventSource (String log, String machine, String source)
		{
			try
			{
				EventLog.CreateEventSource (source, log, machine);
			}
			catch ( System.ArgumentException e )
			{
				System.Console.WriteLine ( e.ToString () );
			}

		}

		/// <summary>
		/// Log the given message to the event log
		/// </summary>
		/// <param name="message">Message to log</param>
		public void debug ( String message )
		{
			this.eventLog.WriteEntry ( message );			
		}

		/// <summary>
		/// Log information to the event log
		/// </summary>
		/// <param name="message">Message to Log</param>
		public void info ( String message )
		{
			this.eventLog.WriteEntry (message, EventLogEntryType.Information);
		}

		/// <summary>
		/// Log a warning to the event log
		/// </summary>
		/// <param name="message">Message to log</param>
		public void warn (String message)
		{
			this.eventLog.WriteEntry (message, EventLogEntryType.Warning);
		}

		/// <summary>
		/// Log an error to the event log
		/// </summary>
		/// <param name="message">Message to log</param>
		public void error (String message)
		{
			this.eventLog.WriteEntry (message, EventLogEntryType.Error);
		}


	}
}
