using System;

namespace com.sporadicism.util.logger
{
	/// <summary>
	/// Summary description for MessageAppender.
	/// </summary>
	public class MessageFormatter
	{
		private MessageFormatter()
		{
		}

		/// <summary>
		/// Formats the String in the format specified in a properties file.
		///		Appends date values, line numbers, etc.
		/// </summary>
		/// <param name="message">The message to be formatted.</param>
		/// <returns>The formatted message.</returns>
		public static String format (String message)
		{
			return message;
		}
	}
}
