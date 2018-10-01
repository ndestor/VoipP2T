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

namespace com.sporadicism.util.logger
{
	/// <summary>
	/// Summary description for LogFactory.
	/// </summary>
	public class LogFactory
	{
		private const String DEFAULT_ASSEMBLY = "com.sporadicism.util.logger.dll";
		private const String DEFAULT_LOGGER_CLASS = "com.sporadicism.util.logger.EventLogger";

		private LogProperties properties;
		/// <summary>
		/// Public constructor
		/// </summary>
		public LogFactory()
		{
			this.properties = new LogProperties ();
		}

		/// <summary>
		/// Returns a new event logger
		/// </summary>
		/// <param name="machine">Machine that log will go to</param>
		/// <param name="log">Name of log</param>
		/// <param name="source">Source of the log event</param>
		/// <returns></returns>
		public static ILogger getEventLogger (String machine, String log, String source)
		{
			com.sporadicism.util.logger.eventlog.EventLogger logger = 
				new com.sporadicism.util.logger.eventlog.EventLogger ();
			logger.getInstance ();
			return new EventLogger (log, machine, source);
		}

		/// <summary>
		/// Creates a logger class of the type identified in the properties
		///		file.
		/// </summary>
		/// <returns>A new instance of an object that implements <code>ILogger</code></returns>
		public ILogger getLogger ()
		{
			ILogger logger = this.createLogger ();

			return logger;
		}

		private ILogger createLogger ()
		{
			object tObject = this.properties.Logger.activate ();

			if (tObject is ILogger)
			{
				return (ILogger)tObject;
			}
			throw new Exception ("Create logger failed.");
		}

		private ILogFormatter createFormatter()
		{
			object tObject = this.properties.Formatter.activate ();

			if (tObject is ILogFormatter)
			{
				return (ILogFormatter)tObject;
			}
			throw new Exception ("Create formatter failed.");
		}

	}
}
