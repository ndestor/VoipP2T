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
	/// Class that holds the constant values for typical Windows NT/ 2000 Event Log Names
	/// </summary>
	public class LogName
	{
		/// <summary>
		/// Application Log
		/// </summary>
		public static String APPLICATION { get { return "Application Log"; } }

		/// <summary>
		/// System Log
		/// </summary>
		public static String SYSTEM { get { return "System Log"; } }

		/// <summary>
		/// Security Log
		/// </summary>
		public static String SECURITY { get { return "Security Log"; } }

		/// <summary>
		/// Directory Service Log
		/// </summary>
		public static String DIRECTORY_SERVICE { get { return "Directory Service"; } }

		/// <summary>
		/// DNS Server Log
		/// </summary>
		public static String DNS_SERVER { get { return "DNS Server"; } }

		/// <summary>
		/// File Replication Service
		/// </summary>
		public static String FILE_REPLICATION_SERVICE { get { return "File Replication Service"; } }

		/// <summary>
		/// Development event log
		/// </summary>
		public static String PORTAL_DEV { get { return "PortalDev"; } }

		/// <summary>
		/// Production event log
		/// </summary>
		public static String PORTAL_PROD { get { return "Prod_Sporadicism"; } }
	}
}
