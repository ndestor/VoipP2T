#region The Sporadic Software License
/*
 * ====================================================================
 *
 * The Sporadic Software License, Version 1.0
 *
 * Copyright (c) 2002-2003 Clayton Harbour.  All rights
 * reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 *
 * 1. Redistributions of source code must retain the above copyright
 *    notice, this list of conditions and the following disclaimer.
 *
 * 2. Redistributions in binary form must reproduce the above copyright
 *    notice, this list of conditions and the following disclaimer in
 *    the documentation and/or other materials provided with the
 *    distribution.
 *
 * 3. The end-user documentation included with the redistribution, if
 *    any, must include the following acknowlegement:
 *       "This product includes software developed by 
 *        Clayton Harbour (http://www.sporadicism.com/)."
 *    Alternately, this acknowlegement may appear in the software itself,
 *    if and wherever such third-party acknowlegements normally appear.
 *
 * 4. Neither the name of Clayton Harbour nor the names of its 
 *	  contributors may be used to endorse or promote products derived 
 *	  from this software without specific prior written permission. 
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS 
 * "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
 * LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS 
 * FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE 
 * COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
 * INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
 * BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS 
 * OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND 
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR 
 * TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
 * USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *
 * ====================================================================
 *
 *
 */
#endregion

using System;
using System.Diagnostics;

namespace com.sporadicism.util.logger
{
	/// <summary>
	/// Logs events to the System Event Log
	/// </summary>
	public class EventLogger : ILogger
	{	
		private EventLog eventLog;
		private int loggerLevel;
		private Level logLevel;

		private String logName = "Application";
		private String source = Application.LOGGER;
		private String machineName = Machine.LOCAL;

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
		public String Source {
			get{return this.source;}
			set{this.source = value;}
		}
		/// <summary>
		/// The machine to log the event to.
		/// </summary>
		public String MachineName {
			get{return this.machineName;}
			set{this.machineName = value;}
		}

		/// <summary>
		/// The level to be applied to the application logging.
		/// </summary>
		public Level LogLevel
		{
			get {return this.logLevel;}
			set {this.logLevel = value;}
		}

		/// <summary>
		/// Sets the logging level of the current logger
		/// </summary>
		public int LoggerLevel
		{
			get {return loggerLevel;}
			set {this.loggerLevel = value;}
		}

		/// <summary>
		/// Log object
		/// </summary>
		public ILogger Log 
		{
			get {return new EventLogger ();}
		}

		/// <summary>
		/// Constant for the logger application
		/// </summary>
		public class Application
		{
			/// <summary>
			/// Default name of the application being logged
			/// </summary>
			public const String LOGGER = "Logger";
		}

		/// <summary>
		/// Local machine logging
		/// </summary>
		public class Machine
		{
			/// <summary>
			/// Default location of the machine to log to
			/// </summary>
			public const String LOCAL = ".";
		}

		
		/// <summary>
		/// Creates an instance of the logger using the Application log category
		/// </summary>
		public EventLogger()
		{
			this.eventLog = 
				createEventLog (this.LogName, this.Source, this.MachineName);
		}

		/// <summary>
		/// Creates an instance of the event logger taking an application
		///		log name.
		/// </summary>
		/// <param name="log">Name of the application the log is for</param>
		/// <param name="machine">Name of the machine to log to</param>
		public EventLogger (String log, String machine)
		{
			this.eventLog = createEventLog (log, machine);
		}

		/// <summary>
		/// Public constructor for Logger.
		/// </summary>
		/// <param name="log">Log to log event to</param>
		/// <param name="machine">The event log exists on</param>
		/// <param name="source">The application/ source of the event</param>
		public EventLogger (String log, String machine, String source)
		{
			this.eventLog = createEventLog (log, machine, source);
		}

		/// <summary>
		/// Creates an instance of the event logger.  If the log does not
		///		exist then it is created
		/// </summary>
		/// <param name="application">Source of the logging event</param>
		/// <param name="machine">Machine to log the event to, "." is the local machine</param>
		/// <returns></returns>
		private EventLog createEventLog (String application, String machine)
		{
			return createEventLog (application, machine, application);
		}

		private EventLog createEventLog (String log, String machine, String source)
		{
			EventLog eventLog = new EventLog ();

			if ( String.Empty == EventLog.LogNameFromSourceName (source, machine))
			{
				createEventSource (log, machine, source);
			}

			eventLog.Source = source;
			eventLog.MachineName = machine;

			return eventLog;
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
			eventLog.WriteEntry ( message );			
		}

		/// <summary>
		/// Log information to the event log
		/// </summary>
		/// <param name="message">Message to Log</param>
		public void info ( String message )
		{
			eventLog.WriteEntry (message, EventLogEntryType.Information);
		}

		/// <summary>
		/// Log a warning to the event log
		/// </summary>
		/// <param name="message">Message to log</param>
		public void warn (String message)
		{
			eventLog.WriteEntry (message, EventLogEntryType.Warning);
		}

		/// <summary>
		/// Log an error to the event log
		/// </summary>
		/// <param name="message">Message to log</param>
		public void error (String message)
		{
			eventLog.WriteEntry (message, EventLogEntryType.Error);
		}

	}
}
