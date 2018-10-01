using System;

namespace com.sporadicism.util.logger
{
	/// <summary>
	/// Summary description for ILogFormatter.
	/// </summary>
	public interface ILogFormatter
	{
		/// <summary>
		/// Format the message applying and return the formatted message.
		///		The formatter can be specified in the properties file.
		/// </summary>
		String format (String message);
	}
}
