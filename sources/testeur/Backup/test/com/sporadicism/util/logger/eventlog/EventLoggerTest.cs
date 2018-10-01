using System;

using NUnit.Framework;

namespace com.sporadicism.util.logger.eventlog
{
	/// <summary>
	/// Summary description for EventLoggerTest.
	/// </summary>
	[TestFixture]
	public class EventLoggerTest
	{
		private const String SOURCE = "EventLoggerTest";
		private ILogger log;

		/// <summary>
		/// Setup the logger for testing.
		/// </summary>
		[SetUp]
		public void Setup ()
		{
			LogFactory factory = new LogFactory ();
			log = factory.getLogger ();
		}
		/// <summary>
		/// Test the write method does not throw an exception
		///		writing to the log.
		/// </summary>
		[Test]
		public void TestLogDebug ()
		{
			log.debug ("Testing debug message");
		}

		/// <summary>
		/// Test the write method does not throw an exception
		///		writing to the log.
		/// </summary>
		[Test]
		public void TestLogInfo ()
		{
			log.info ("Testing info message");
		}

		/// <summary>
		/// Test the write method does not throw an exception
		///		writing to the log.
		/// </summary>
		[Test]
		public void TestLogWarn ()
		{
			log.warn ("Testing warn message");
		}

		/// <summary>
		/// Test the write method does not throw an exception
		///		writing to the log.
		/// </summary>
		[Test]
		public void TestLogError ()
		{
			log.error ("Testing error message");
		}
	}
}
